using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using T9Host.Helpers;
using DarkUI.Forms;
using DarkUI.Controls;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace T9Host
{
    public partial class MainForm : DarkForm
    {
		/// <summary>
		/// these could have been done better tbh
		/// </summary>
		private PlayerData[] playerdata = new PlayerData[(int)eAddresses.maxclient];
		private SaveLocation[] savelocations = new SaveLocation[(int)eAddresses.maxsaveconfig];
		private Memory mem = new Memory();

		[DllImport("User32.dll")]
		static extern short GetAsyncKeyState(int vKey);

		private float[] DollyCamera = new float[3];

		/// <summary>
		/// Process for game being used
		/// </summary>
		private string ProcessName = "BlackOpsColdWar";
		/// <summary>
		/// A shitty config location lol
		/// </summary>
		private string SaveListConfig = $"{Application.StartupPath}\\savelocations.txt";
		private int CurrentPlayer;

		private string[] mapnames = new string[6] { "wz_duga", "wz_ski_slopes", "wz_forest", "wz_sanatorium", "wz_golova", "wz_zoo" };

		public enum eAddresses : Int64
        {
			g_clients = 0x1112CD08, //49 69 D8 ? ? ? ? 48 63 C2
			g_entities = 0x1112CD10, //add 8 from g_clients address
			g_entities_size = 0x5E8,
			g_clients_size = 0x0B970,

			mapname = 0x13B30628, //found by searching memory
			gametype = 0x13B305F9, //found by searching memory

			playback = 0x11E49DA8, //48 8B 05 ? ? ? ? 48 89 9C 24 ? ? ? ? 48 63 58 34 E8 ? ? ? ? 

			playback_origin = 0x103291C,

			//these 4 things change a lot when new operators are added
			malez = 26,
			femalez = 27,
			nakedmale = 28,
			nakedfemale = 29,

			xor_addr_0 = 0xE25E2AC, //8B 15 ? ? ? ? 8B 0D ? ? ? ? F7 D1

			maxclient = 24,
			maxsaveconfig = 300,

		}

		public MainForm()
        {
            InitializeComponent();

            for (int iPlayer = 0;iPlayer < (int)eAddresses.maxclient;iPlayer++)
            {
				playerdata[iPlayer] = new PlayerData();
            }

            for (int iSaveLoc = 0;iSaveLoc < (int)eAddresses.maxsaveconfig; iSaveLoc++)
            {
				savelocations[iSaveLoc] = new SaveLocation();
			}
			ReloadConfig();

		}


		private void MainForm_Load(object sender, EventArgs e)
        {
			for (int iClient = 0; iClient < (int)eAddresses.maxclient; iClient++)
			{
				TreeView_PlayerList.Nodes.Add(new DarkTreeNode(""));
			}

			BW_Noclip.RunWorkerAsync();
			BW_PlayerList.RunWorkerAsync();
			BW_ReadPlayerInfo.RunWorkerAsync();


		}

		/// <summary>
		/// used for getting the angles to forward (math stuff)
		/// </summary>
		/// <param name="angles"></param>
		/// <returns></returns>
		private float[] Scr_AnglesToForward(float[] angles) {
			float[] return_pos = new float[3];
			float angle, cy, sy, cp, cr, sr, anglea;

			cy = (float)Math.Cos(angles[1] * 0.017453292);
			sy = (float)Math.Sin(angles[1] * 0.017453292);
			angle = angles[0] * 0.017453292F;
			cp = (float)Math.Cos(angle);
			return_pos[1] = cp * sy;
			return_pos[0] = cp * cy;
			return_pos[2] = -(float)Math.Sin(angle);
			return return_pos;
		}
		/// <summary>
		/// used for getting the angles to right (math stuff)
		/// </summary>
		/// <param name="angles"></param>
		/// <returns></returns>
		private float[] Scr_AnglesToRight(float[] angles) {
			float[] return_pos = new float[3];

			float angle, cy, sy, cp, cr, sr, anglea;

			cy = (float)Math.Cos(angles[1] * 0.017453292);
			sy = (float)Math.Sin(angles[1] * 0.017453292);
			angle = angles[0] * 0.017453292F;
			cp = (float)Math.Cos(angle);
			anglea = angles[2] * 0.017453292F;
			cr = (float)Math.Cos(anglea);
			sr = (float)Math.Sin(anglea);
			return_pos[0] = (float)(cr * sy) - ((sr * (float)Math.Sin(angle)) * cy);
			return_pos[1] = (float)((cr * -1.0) * cy) - (float)((sr * (float)Math.Sin(angle)) * sy);
			return_pos[2] = (float)(sr * -1.0) * cp;
			return return_pos;
		}

		/// <summary>
		/// used for setting the origin for an entity properly
		/// </summary>
		/// <param name="ent"></param>
		/// <param name="origin"></param>
		public void G_SetOrigin(Int64 ent, float[] origin)
		{
			uint ar1 = mem.ReadUInt(mem.BaseAddress + (long)eAddresses.xor_addr_0 + 0);
			uint ar2 = mem.ReadUInt(mem.BaseAddress + (long)eAddresses.xor_addr_0 + 4);
			uint ar3 = mem.ReadUInt(mem.BaseAddress + (long)eAddresses.xor_addr_0 + 8);


			mem.WriteUInt(ent + 0x10, (uint)(BitConverter.ToUInt32(BitConverter.GetBytes(origin[0]), 0) ^ ~ar1));
			mem.WriteUInt(ent + 0x14, (uint)(BitConverter.ToUInt32(BitConverter.GetBytes(origin[1]), 0) ^ ~ar2));
			mem.WriteUInt(ent + 0x18, (uint)(BitConverter.ToUInt32(BitConverter.GetBytes(origin[2]), 0) ^ ~ar3));

			mem.WriteBytes(ent + 0x30, new byte[1]);
			mem.WritePointer(ent + 0x28, 0);
			mem.WritePointer(ent + 0x1C, 0);
			mem.WriteInt(ent + 0x24, 0);

			mem.WriteFloat(ent + 0x2D4, origin[0]);
			mem.WriteFloat(ent + 0x2D8, origin[1]);
			mem.WriteFloat(ent + 0x2DC, origin[2]);
		}
		/// <summary>
		/// Used for making the player/entity visible
		/// </summary>
		/// <param name="ent"></param>
		public void ScrCmd_Show(Int64 ent)
		{
			uint lerpFlags = mem.ReadUInt(ent + 8);
			mem.WriteUInt(ent + 8, lerpFlags & 0x0FBFFFFFF);
			Int64 self = mem.ReadPointer(ent + 0x2F8);
			if (self != 0)
			{
				lerpFlags = mem.ReadUInt(self + 0xF18);
				mem.WriteUInt(self + 0xF18, lerpFlags & 0x0FBFFFFFF);
			}
			mem.WriteUInt(ent + 0x128, 0);
		}
		/// <summary>
		/// used for making the player/entity invisible
		/// </summary>
		/// <param name="ent"></param>
		public void ScrCmd_Hide(Int64 ent)
		{
			uint lerpFlags = mem.ReadUInt(ent + 8);
			mem.WriteUInt(ent + 8, lerpFlags | 0x4000000);
			Int64 self = mem.ReadPointer(ent + 0x2F8);
			if (self != 0)
			{
				lerpFlags = mem.ReadUInt(self + 0xF18);
				mem.WriteUInt(self + 0xF18, lerpFlags | 0x4000000);
			}
			mem.WriteUInt(ent + 0x128, 0xFFFFFFFF);
		}
		/// <summary>
		/// Used for setting the player "character" or the "operator" skin
		/// </summary>
		/// <param name="ent"></param>
		/// <param name="body"></param>
		public void PlayerCmd_SetCharacterBodyType(Int64 ent, int body)
		{
			UInt64 val = 0;
			val &= 0xFFFFFFFFFFFFFC07;
			val |= (ulong)(8 * ((body + 1) & 0x7F));
			val &= 0xFFFFFFFFFFFFFFF8;
			val |= (ulong)(body & 7);

			val &= 0xFFE20449091207FF;
			val |= 0x2044909120400;

			Int64 self = mem.ReadPointer(ent + 0x2F8);
			if (self != 0)
			{
				mem.WritePointer(self + 0x5CA8, val);
			}
		}
		/// <summary>
		/// Literally for local button presses
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public short GetKey(int key)
		{
			return GetAsyncKeyState(key);
		}

		/// <summary>
		/// This thread/background worker is for the "free cam" noclip for theatre to get outside of certain parts of the map that you cannot normally get to because of barriers
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BW_Noclip_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (mem.AttachProcess(ProcessName))
                {
					Int64 PlaybackPtr = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.playback);
                    if (PlaybackPtr != 0)
                    {
						if (CB_DollyNoclip.Checked)
						{
							float[] angles = new float[3];
							angles[0] = mem.ReadFloat(PlaybackPtr + (int)eAddresses.playback_origin + 12);
							angles[1] = mem.ReadFloat(PlaybackPtr + (int)eAddresses.playback_origin + 16);
							angles[2] = mem.ReadFloat(PlaybackPtr + (int)eAddresses.playback_origin + 20);
							float[] forwardangles = Scr_AnglesToForward(angles);
							float[] rightangles = Scr_AnglesToRight(angles);
							int noclipSpeed = (int)NUD_NoclipSpeed.Value;
							if ((GetKey('W')) != 0)
							{
								DollyCamera[0] += (forwardangles[0] * noclipSpeed);
								DollyCamera[1] += (forwardangles[1] * noclipSpeed);
								DollyCamera[2] += (forwardangles[2] * noclipSpeed);
							}

							if ((GetKey('S')) != 0)
							{
								DollyCamera[0] -= (forwardangles[0] * noclipSpeed);
								DollyCamera[1] -= (forwardangles[1] * noclipSpeed);
								DollyCamera[2] -= (forwardangles[2] * noclipSpeed);
							}

							if ((GetKey('D')) != 0)
							{
								DollyCamera[0] += (rightangles[0] * noclipSpeed);
								DollyCamera[1] += (rightangles[1] * noclipSpeed);
								DollyCamera[2] += (rightangles[2] * noclipSpeed);
							}

							if ((GetKey('A')) != 0)
							{
								DollyCamera[0] -= (rightangles[0] * noclipSpeed);
								DollyCamera[1] -= (rightangles[1] * noclipSpeed);
								DollyCamera[2] -= (rightangles[2] * noclipSpeed);
							}

							mem.WriteFloat(PlaybackPtr + (int)eAddresses.playback_origin + 0, DollyCamera[0]);
							mem.WriteFloat(PlaybackPtr + (int)eAddresses.playback_origin + 4, DollyCamera[1]);
							mem.WriteFloat(PlaybackPtr + (int)eAddresses.playback_origin + 8, DollyCamera[2]);

							//memcpy(reinterpret_cast<void*>(pClient + 0xDE8), reinterpret_cast<void*>(NoclipPosition), 12);
						}
						else
						{
							DollyCamera[0] = mem.ReadFloat(PlaybackPtr + (int)eAddresses.playback_origin + 0);
							DollyCamera[1] = mem.ReadFloat(PlaybackPtr + (int)eAddresses.playback_origin + 4);
							DollyCamera[2] = mem.ReadFloat(PlaybackPtr + (int)eAddresses.playback_origin + 8);
							//memcpy(reinterpret_cast<void*>(NoclipPosition), reinterpret_cast<void*>(pClient + 0xDE8), 12);
						}

					}
                }
				Thread.Sleep(30);
            }
        }
		/// <summary>
		/// this is for "noclip" kind of shitty but it works
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
				if (mem.AttachProcess(ProcessName)) {
					Int64 pClient = mem.ReadPointer(mem.BaseAddress + (Int64)eAddresses.g_clients);
                    if (pClient != 0)
                    {
						for (int iClient = 0; iClient < (int)eAddresses.maxclient; iClient++)
						{
							if (playerdata[iClient].bNoclip)
							{
								float[] angles = new float[3];
								angles[0] = mem.ReadFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xE0C + 0);
								angles[1] = mem.ReadFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xE0C + 4);
								angles[2] = mem.ReadFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xE0C + 8);
								//memcpy(reinterpret_cast<void*>(angles), reinterpret_cast<void*>(), 12);
								float[] forwardangles = Scr_AnglesToForward(angles);
								float[] rightangles = Scr_AnglesToRight(angles);
								//byte forwardmove = mem.ReadBytes(pClient + 0x5B3A, 1)[0];
								byte forwardmove = mem.ReadBytes(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0x5BFD, 1)[0];
								byte moveright = mem.ReadBytes(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0x5BFE, 1)[0];
								//if ((forwardmove & 0x40) != 0)
								int noclipSpeed = ((mem.ReadInt(pClient + 0x00005B32) & 0x4004) != 0) ? 40 : 12;
								if ((forwardmove == 0x7F))
								{
									playerdata[iClient].NoclipPosition[0] += (forwardangles[0] * noclipSpeed);
									playerdata[iClient].NoclipPosition[1] += (forwardangles[1] * noclipSpeed);
									playerdata[iClient].NoclipPosition[2] += (forwardangles[2] * noclipSpeed);
								}

								if ((forwardmove == 0x81))
								{
									playerdata[iClient].NoclipPosition[0] -= (forwardangles[0] * noclipSpeed);
									playerdata[iClient].NoclipPosition[1] -= (forwardangles[1] * noclipSpeed);
									playerdata[iClient].NoclipPosition[2] -= (forwardangles[2] * noclipSpeed);
								}

								if ((moveright == 0x7F))
								{
									playerdata[iClient].NoclipPosition[0] += (rightangles[0] * noclipSpeed);
									playerdata[iClient].NoclipPosition[1] += (rightangles[1] * noclipSpeed);
									playerdata[iClient].NoclipPosition[2] += (rightangles[2] * noclipSpeed);
								}

								if ((moveright == 0x81))
								{
									playerdata[iClient].NoclipPosition[0] -= (rightangles[0] * noclipSpeed);
									playerdata[iClient].NoclipPosition[1] -= (rightangles[1] * noclipSpeed);
									playerdata[iClient].NoclipPosition[2] -= (rightangles[2] * noclipSpeed);
								}
								mem.WriteInt(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xEE4, 0);
								mem.WriteFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xDFC, 2.0F);
								mem.WriteFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xDE8 + 0, playerdata[iClient].NoclipPosition[0]);
								mem.WriteFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xDE8 + 4, playerdata[iClient].NoclipPosition[1]);
								mem.WriteFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xDE8 + 8, playerdata[iClient].NoclipPosition[2]);

								//memcpy(reinterpret_cast<void*>(pClient + 0xDE8), reinterpret_cast<void*>(NoclipPosition), 12);
							}
							else
							{
								playerdata[iClient].NoclipPosition[0] = mem.ReadFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xDE8 + 0);
								playerdata[iClient].NoclipPosition[1] = mem.ReadFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xDE8 + 4);
								playerdata[iClient].NoclipPosition[2] = mem.ReadFloat(pClient + (iClient * (int)(eAddresses.g_clients_size)) + 0xDE8 + 8);
								//memcpy(reinterpret_cast<void*>(NoclipPosition), reinterpret_cast<void*>(pClient + 0xDE8), 12);
							}
							//if (move[0] != 0)
							//{
							//	Console.WriteLine($"move[0] reading {move[0]} for client {iClient}");
							//}
							//if (move[1] != 0)
							//{
							//	Console.WriteLine($"move[1] reading {move[1]} for client {iClient}");
							//}
						}
					}
				}
				Thread.Sleep(10);
            }
        }
		/// <summary>
		/// turns noclip on
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_NoclipON_Click(object sender, EventArgs e)
        {
			playerdata[CurrentPlayer].bNoclip = true;
		}
		/// <summary>
		/// turns noclip off
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_NoclipOFF_Click(object sender, EventArgs e)
        {
			playerdata[CurrentPlayer].bNoclip = false;
		}
		/// <summary>
		/// gets the index for the selected player in the treeview
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void TreeView_PlayerList_Click(object sender, EventArgs e)
        {
			CurrentPlayer = TreeView_PlayerList.SelectedNodes[0].VisibleIndex;
		}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			Application.Exit();
		}
		/// <summary>
		/// turns godmode on for the selected player
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_GodmodeON_Click(object sender, EventArgs e)
        {
            if (mem.AttachProcess(ProcessName))
            {
				Int64 pClient = mem.ReadPointer(mem.BaseAddress + (Int64)eAddresses.g_clients);
				mem.WriteUInt(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xE64, 0xA0000000);
			}
		}
		/// <summary>
		/// turns godmode off for selected player
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_GodmodeOFF_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 pClient = mem.ReadPointer(mem.BaseAddress + (Int64)eAddresses.g_clients);
				mem.WriteUInt(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xE64, 0x20000000);
			}
		}
		/// <summary>
		/// was supposed to reset all player variables but i ended up not really using it lol
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_ResetPlayerVariables_Click(object sender, EventArgs e)
        {
			playerdata[CurrentPlayer].NoclipPosition = new float[3];
			playerdata[CurrentPlayer].bNoclip = false;
        }
		/// <summary>
		/// teleports the player to location
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_TeleportPlayer_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 pClient = mem.ReadPointer(mem.BaseAddress + (Int64)eAddresses.g_clients);
				mem.WriteFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 0, (float)UD_PosX.Value);
				mem.WriteFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 4, (float)UD_PosY.Value);
				mem.WriteFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 8, (float)UD_PosZ.Value);
			}
		}
		/// <summary>
		/// saves player location with name of location to config file for saves
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_SavePosition_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 pClient = mem.ReadPointer(mem.BaseAddress + (Int64)eAddresses.g_clients);
				float OriginX = mem.ReadFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 0);
				float OriginY = mem.ReadFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 4);
				float OriginZ = mem.ReadFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 8);
				if (File.Exists(SaveListConfig))
				{
					string filecontents = File.ReadAllText(SaveListConfig);
                    if (!filecontents.Contains(Txt_SaveLocationName.Text))
                    {
						filecontents += $"{Txt_SaveLocationName.Text}={OriginX},{OriginY},{OriginZ}\n";
						File.WriteAllText(SaveListConfig, filecontents);
					}
                    else
                    {
						DarkMessageBox.ShowError("Name has already been used!", "Error", DarkDialogButton.Ok);
                    }
				}
				else
				{
					//Location Name=1.1.1
					File.WriteAllText(SaveListConfig, $"{Txt_SaveLocationName.Text}={OriginX},{OriginY},{OriginZ}\n");
				}
			}
        }
		/// <summary>
		/// loads position from dropdown for locations in saved config file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_LoadPosition_Click(object sender, EventArgs e)
        {
            if (mem.AttachProcess(ProcessName))
            {
                for (int iSave = 0;iSave < (int)eAddresses.maxsaveconfig;iSave++)
                {
                    if (SavedMapLocations.Text == savelocations[iSave].LocationName)
                    {
						Int64 pClient = mem.ReadPointer(mem.BaseAddress + (Int64)eAddresses.g_clients);
						mem.WriteFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 0, savelocations[iSave].Origin[0]);
						mem.WriteFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 4, savelocations[iSave].Origin[1]);
						mem.WriteFloat(pClient + (CurrentPlayer * (int)(eAddresses.g_clients_size)) + 0xDE8 + 8, savelocations[iSave].Origin[2]);
						break;
                    }
                }
            }
        }
		/// <summary>
		/// reloads the save location config
		/// </summary>
		private void ReloadConfig()
        {
			try
			{
				SavedMapLocations.Items.Clear();
			}
			catch (Exception ex)
			{

			}
			if (File.Exists(SaveListConfig))
			{
				string[] line = File.ReadAllLines(SaveListConfig);
				for (int iSave = 0; iSave < line.Length; iSave++)
				{
					string positionname = line[iSave].Split('=')[0];
					float OriginX = float.Parse(line[iSave].Split('=')[1].Split(',')[0]);
					float OriginY = float.Parse(line[iSave].Split('=')[1].Split(',')[1]);
					float OriginZ = float.Parse(line[iSave].Split('=')[1].Split(',')[2]);

					savelocations[iSave].LocationName = positionname;
					savelocations[iSave].Origin = new float[3] { OriginX, OriginY, OriginZ };

					SavedMapLocations.Items.Add(positionname);
				}
			}
		}
		/// <summary>
		/// calls the function for reloading the save location config
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_ReloadPositions_Click(object sender, EventArgs e)
        {
			ReloadConfig();
		}
		/// <summary>
		/// background worker that gets stuff
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BW_PlayerList_DoWork(object sender, DoWorkEventArgs e)
        {
			while (true)
			{
				if (mem.AttachProcess(ProcessName))
				{
					Int64 playback = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.playback);
					Lbl_MapGametype.Text = $"Map/Gametype: {mem.ReadString(mem.BaseAddress + (long)eAddresses.mapname)}/{mem.ReadString(mem.BaseAddress + (long)eAddresses.gametype)}";
					Int64 pClient = mem.ReadPointer(mem.BaseAddress + (Int64)eAddresses.g_clients);
					for (int i = 0; i < (int)eAddresses.maxclient; i++)
					{
						TreeView_PlayerList.Nodes[i].Text = mem.ReadString(pClient + 0x00006060);
						pClient += (int)eAddresses.g_clients_size;
					}
				}
				Thread.Sleep(500);
			}
		}
		/// <summary>
		/// button that removes death barriers in multiplayer to be able to walk outside the map (shown in this video https://www.youtube.com/watch?v=_0ybMan52Ao)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_RemoveDeathBarriers_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities);
				for (int iEnt = 0; iEnt < 2048; iEnt++)
				{
					uint temp = mem.ReadUInt(ent);
					if (temp != 0)
					{
						if (iEnt > 30)
						{
							if (mem.ReadUInt(ent + 8) == 0x84000000)
							{
								G_SetOrigin(ent, new float[3] { 0, 0, -99999999 });
							}
						}
					}
					ent += (int)(eAddresses.g_entities_size);
				}
			}
		}
		/// <summary>
		/// literally removed and does nothing which makes this comment useless lol idk why it is here it just is
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_SetOperator1_Click(object sender, EventArgs e)
        {

        }
		/// <summary>
		/// sets the naked player model (male)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_SetNakedMale_Click(object sender, EventArgs e)
        {
			Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities) + (CurrentPlayer * (int)(eAddresses.g_entities_size));
			PlayerCmd_SetCharacterBodyType(ent, (int)eAddresses.nakedmale);
		}
		/// <summary>
		/// sets the naked player model (female)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_SetNakedFemale_Click(object sender, EventArgs e)
        {
			Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities) + (CurrentPlayer * (int)(eAddresses.g_entities_size));
			PlayerCmd_SetCharacterBodyType(ent, (int)eAddresses.nakedfemale);
		}
		/// <summary>
		/// sets the zombie player model (male)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_SetakeZombie_Click(object sender, EventArgs e)
		{
			Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities) + (CurrentPlayer * (int)(eAddresses.g_entities_size));
			PlayerCmd_SetCharacterBodyType(ent, (int)eAddresses.malez);
		}
		/// <summary>
		/// sets the zombie player model (female)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_SetFemaleZombie_Click(object sender, EventArgs e)
		{
			Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities) + (CurrentPlayer * (int)(eAddresses.g_entities_size));
			PlayerCmd_SetCharacterBodyType(ent, (int)eAddresses.femalez);
		}
		/// <summary>
		/// sets the operator id to a custom one for selected player
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NUP_SetOperator_ValueChanged(object sender, EventArgs e)
        {// up to 38 operators
			Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities);
			PlayerCmd_SetCharacterBodyType(ent + (CurrentPlayer * (int)eAddresses.g_entities_size), (int)NUP_SetOperator.Value);
			darkLabel1.Text = $"Current Operator: {NUP_SetOperator.Value.ToString()}";//$"{mem.ReadInt(mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities) + (int)NUP_SetOperator.Value)}";
		}
		/// <summary>
		/// makes selected player invisible
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_InvisibleON_Click(object sender, EventArgs e)
        {
			Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities) + (CurrentPlayer * (int)(eAddresses.g_entities_size));
			ScrCmd_Hide(ent);
		}
		/// <summary>
		/// makes selected player visible
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_InvisibleOFF_Click(object sender, EventArgs e)
        {
			Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities) + (CurrentPlayer * (int)(eAddresses.g_entities_size));
			ScrCmd_Show(ent);
		}
		/// <summary>
		/// sets speed of selected player to x1
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_SetMoveSpeedScalex1_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 self = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients) + ((int)eAddresses.g_clients_size * CurrentPlayer);
				mem.WriteFloat(self + 0x5C70, 1.0f);
			}
		}
		/// <summary>
		/// sets speed of selected player to x2
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_SetMoveSpeedScalex2_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 self = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients) + ((int)eAddresses.g_clients_size * CurrentPlayer);
				mem.WriteFloat(self + 0x5C70, 2.0f);
			}
		}
		/// <summary>
		/// sets speed of selected player to x3
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_SetMoveSpeedScalex3_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 self = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients) + ((int)eAddresses.g_clients_size * CurrentPlayer);
				mem.WriteFloat(self + 0x5C70, 3.0f);
			}
		}
		/// <summary>
		/// sets speed of selected player to x4
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_SetMoveSpeedScalex4_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 self = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients) + ((int)eAddresses.g_clients_size * CurrentPlayer);
				mem.WriteFloat(self + 0x5C70, 4.0f);
			}
		}
		float[] zpos = new float[3];
		/// <summary>
		/// this was used to make zombies teleport in one place but was not implimented into finial release
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BW_ZombieTeleport_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
				Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities);
				for (int i = 0; i < 2048; i++)
				{
					uint iEntType = mem.ReadUInt(ent + 8);
					if (iEntType != 0)
					{
						switch (iEntType)
						{
							case 0x40110400:
							case 0x00110400:
								G_SetOrigin(ent, zpos);
								mem.WriteInt(ent + 0x390, 1);
								break;
						}
					}
					ent += (int)eAddresses.g_entities_size;
				}
				Thread.Sleep(10);
            }
        }
		/// <summary>
		/// was for zombies but was not used in final build
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BW_PlayerMods_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
				Int64 client = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients);
				for (int iClient = 0;iClient < 4;iClient++) {
                    for (int iAmmo = 0;iAmmo < 15;iAmmo ++)
                    {
						mem.WriteInt(client + 0x13E0 + (iAmmo * 4), 100);
					}
					mem.WriteUInt(client + 0xE64, 0xA0000000);
					client += (int)eAddresses.g_clients_size;
				}
				Thread.Sleep(10);
            }
        }
		/// <summary>
		/// gets location of player 1 for zombie teleport but was removed in final build
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void darkButton1_Click(object sender, EventArgs e)
        {
			Int64 pClient = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients);
			zpos[0] = mem.ReadFloat(pClient + 0xDE8 + 0);
			zpos[1] = mem.ReadFloat(pClient + 0xDE8 + 4);
			zpos[2] = mem.ReadFloat(pClient + 0xDE8 + 8);
		}
		/// <summary>
		/// spooky halloween stuff that was used on halloween
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_SpookyHalloween_Click(object sender, EventArgs e)
        {
            if (mem.AttachProcess(ProcessName))
            {
				Int64 pClient = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients);
				Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities);
				for (int iClient = 0;iClient < (int)eAddresses.maxclient;iClient++)
                {
					mem.WriteFloat(pClient + 0x5C70, 2.0f);
					PlayerCmd_SetCharacterBodyType(ent + (iClient * (int)(eAddresses.g_entities_size)), ((iClient % 2) == 0) ? (int)eAddresses.malez : (int)eAddresses.femalez);
					pClient += (int)eAddresses.g_clients_size;
				}
            }
        }
		/// <summary>
		/// sets the map to a zombies map in private match
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void CB_Maps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mem.AttachProcess(ProcessName))
            {
				mem.WriteString(mem.BaseAddress + (long)eAddresses.mapname, mapnames[CB_Maps.SelectedIndex]);
            }
        }
		/// <summary>
		/// makes all players invisbile 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_HideAll_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				Int64 pClient = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_clients);
				Int64 ent = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.g_entities);
				for (int iClient = 0; iClient < (int)eAddresses.maxclient; iClient++)
				{
					ScrCmd_Hide(ent + (iClient * (int)(eAddresses.g_entities_size)));
					pClient += (int)eAddresses.g_clients_size;
				}
			}
		}
		/// <summary>
		/// sets a custom mapname from textbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Txt_MapName_KeyDown(object sender, KeyEventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				if (e.KeyCode == Keys.Enter)
				{
					mem.WriteString(mem.BaseAddress + (long)eAddresses.mapname, Txt_MapName.Text);
				}
			}
		}
		/// <summary>
		/// teleports the dolly camera down by 3000 for testing reasons (hence why it was removed)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_DownTP_Click(object sender, EventArgs e)
		{
			if (mem.AttachProcess(ProcessName))
			{
				Int64 PlaybackPtr = mem.ReadPointer(mem.BaseAddress + (long)eAddresses.playback);
				float fVal = mem.ReadFloat(PlaybackPtr + (int)eAddresses.playback_origin + 8);
				mem.WriteFloat(PlaybackPtr + (int)eAddresses.playback_origin + 8, fVal - 3000);
			}
		}

		

		/// <summary>
		/// fixes a little sneaky thing for dolly cam
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_Fix_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				mem.Fix();
			}
		}
		/// <summary>
		/// restores fix for dolly cam thing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Btn_Restore_Click(object sender, EventArgs e)
        {
			if (mem.AttachProcess(ProcessName))
			{
				mem.Restore();
			}
		}
		/// <summary>
		/// was used but was removed lol
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void NUD_NoclipSpeed_ValueChanged(object sender, EventArgs e)
        {

        }
		private static string pString = "";
		/// <summary>
		/// used for copying the mapname and such
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (mem.AttachProcess(ProcessName))
            {
				pString += $"{mem.ReadString(mem.BaseAddress + (long)eAddresses.mapname)}\n";
				Clipboard.SetText(pString);
            }
        }
    }
    public class PlayerData
	{
		public float[] NoclipPosition = new float[3];
		public bool bNoclip;
    }

	public class SaveLocation
	{
		public string LocationName;
		public float[] Origin = new float[3];
    }



}
