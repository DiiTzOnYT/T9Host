
namespace T9Host
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BW_Noclip = new System.ComponentModel.BackgroundWorker();
            this.BW_ReadPlayerInfo = new System.ComponentModel.BackgroundWorker();
            this.TreeView_PlayerList = new DarkUI.Controls.DarkTreeView();
            this.Context_PlayerOptions = new DarkUI.Controls.DarkContextMenu();
            this.noclipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_NoclipON = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_NoclipOFF = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Godmode = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_GodmodeON = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_GodmodeOFF = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetOperators = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetNakedMale = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetNakedFemale = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetakeZombie = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetFemaleZombie = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Invinisble = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_InvisibleON = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_InvisibleOFF = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetMoveSpeedScale = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetMoveSpeedScalex1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetMoveSpeedScalex2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetMoveSpeedScalex3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_SetMoveSpeedScalex4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_ResetPlayerVariables = new DarkUI.Controls.DarkButton();
            this.UD_PosX = new DarkUI.Controls.DarkNumericUpDown();
            this.UD_PosY = new DarkUI.Controls.DarkNumericUpDown();
            this.UD_PosZ = new DarkUI.Controls.DarkNumericUpDown();
            this.Btn_TeleportPlayer = new DarkUI.Controls.DarkButton();
            this.SavedMapLocations = new DarkUI.Controls.DarkComboBox();
            this.Btn_SavePosition = new DarkUI.Controls.DarkButton();
            this.Btn_LoadPosition = new DarkUI.Controls.DarkButton();
            this.Btn_ReloadPositions = new DarkUI.Controls.DarkButton();
            this.Txt_SaveLocationName = new DarkUI.Controls.DarkTextBox();
            this.BW_PlayerList = new System.ComponentModel.BackgroundWorker();
            this.Btn_RemoveDeathBarriers = new DarkUI.Controls.DarkButton();
            this.NUP_SetOperator = new DarkUI.Controls.DarkNumericUpDown();
            this.BW_ZombieTeleport = new System.ComponentModel.BackgroundWorker();
            this.BW_PlayerMods = new System.ComponentModel.BackgroundWorker();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.Btn_SpookyHalloween = new DarkUI.Controls.DarkButton();
            this.CB_Maps = new DarkUI.Controls.DarkComboBox();
            this.Lbl_MapGametype = new DarkUI.Controls.DarkLabel();
            this.Btn_HideAll = new DarkUI.Controls.DarkButton();
            this.Txt_MapName = new DarkUI.Controls.DarkTextBox();
            this.CB_DollyNoclip = new DarkUI.Controls.DarkCheckBox();
            this.NUD_NoclipSpeed = new DarkUI.Controls.DarkNumericUpDown();
            this.Btn_Fix = new DarkUI.Controls.DarkButton();
            this.Btn_Restore = new DarkUI.Controls.DarkButton();
            this.button1 = new System.Windows.Forms.Button();
            this.Context_PlayerOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_PosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_PosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_PosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_SetOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NoclipSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // BW_Noclip
            // 
            this.BW_Noclip.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Noclip_DoWork);
            // 
            // BW_ReadPlayerInfo
            // 
            this.BW_ReadPlayerInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // TreeView_PlayerList
            // 
            this.TreeView_PlayerList.ContextMenuStrip = this.Context_PlayerOptions;
            this.TreeView_PlayerList.Location = new System.Drawing.Point(9, 10);
            this.TreeView_PlayerList.Margin = new System.Windows.Forms.Padding(2);
            this.TreeView_PlayerList.MaxDragChange = 20;
            this.TreeView_PlayerList.Name = "TreeView_PlayerList";
            this.TreeView_PlayerList.Size = new System.Drawing.Size(204, 318);
            this.TreeView_PlayerList.TabIndex = 3;
            this.TreeView_PlayerList.Text = "darkTreeView1";
            this.TreeView_PlayerList.Click += new System.EventHandler(this.TreeView_PlayerList_Click);
            // 
            // Context_PlayerOptions
            // 
            this.Context_PlayerOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Context_PlayerOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Context_PlayerOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Context_PlayerOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noclipToolStripMenuItem,
            this.Btn_Godmode,
            this.Btn_SetOperators,
            this.Btn_Invinisble,
            this.Btn_SetMoveSpeedScale});
            this.Context_PlayerOptions.Name = "Context_PlayerOptions";
            this.Context_PlayerOptions.Size = new System.Drawing.Size(170, 114);
            // 
            // noclipToolStripMenuItem
            // 
            this.noclipToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.noclipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_NoclipON,
            this.Btn_NoclipOFF});
            this.noclipToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.noclipToolStripMenuItem.Name = "noclipToolStripMenuItem";
            this.noclipToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.noclipToolStripMenuItem.Text = "Noclip";
            // 
            // Btn_NoclipON
            // 
            this.Btn_NoclipON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_NoclipON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_NoclipON.Name = "Btn_NoclipON";
            this.Btn_NoclipON.Size = new System.Drawing.Size(95, 22);
            this.Btn_NoclipON.Text = "ON";
            this.Btn_NoclipON.Click += new System.EventHandler(this.Btn_NoclipON_Click);
            // 
            // Btn_NoclipOFF
            // 
            this.Btn_NoclipOFF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_NoclipOFF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_NoclipOFF.Name = "Btn_NoclipOFF";
            this.Btn_NoclipOFF.Size = new System.Drawing.Size(95, 22);
            this.Btn_NoclipOFF.Text = "OFF";
            this.Btn_NoclipOFF.Click += new System.EventHandler(this.Btn_NoclipOFF_Click);
            // 
            // Btn_Godmode
            // 
            this.Btn_Godmode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_Godmode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_GodmodeON,
            this.Btn_GodmodeOFF});
            this.Btn_Godmode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_Godmode.Name = "Btn_Godmode";
            this.Btn_Godmode.Size = new System.Drawing.Size(169, 22);
            this.Btn_Godmode.Text = "Godmode";
            // 
            // Btn_GodmodeON
            // 
            this.Btn_GodmodeON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_GodmodeON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_GodmodeON.Name = "Btn_GodmodeON";
            this.Btn_GodmodeON.Size = new System.Drawing.Size(95, 22);
            this.Btn_GodmodeON.Text = "ON";
            this.Btn_GodmodeON.Click += new System.EventHandler(this.Btn_GodmodeON_Click);
            // 
            // Btn_GodmodeOFF
            // 
            this.Btn_GodmodeOFF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_GodmodeOFF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_GodmodeOFF.Name = "Btn_GodmodeOFF";
            this.Btn_GodmodeOFF.Size = new System.Drawing.Size(95, 22);
            this.Btn_GodmodeOFF.Text = "OFF";
            this.Btn_GodmodeOFF.Click += new System.EventHandler(this.Btn_GodmodeOFF_Click);
            // 
            // Btn_SetOperators
            // 
            this.Btn_SetOperators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetOperators.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_SetNakedMale,
            this.Btn_SetNakedFemale,
            this.Btn_SetakeZombie,
            this.Btn_SetFemaleZombie});
            this.Btn_SetOperators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetOperators.Name = "Btn_SetOperators";
            this.Btn_SetOperators.Size = new System.Drawing.Size(169, 22);
            this.Btn_SetOperators.Text = "Set Operators";
            // 
            // Btn_SetNakedMale
            // 
            this.Btn_SetNakedMale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetNakedMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetNakedMale.Name = "Btn_SetNakedMale";
            this.Btn_SetNakedMale.Size = new System.Drawing.Size(156, 22);
            this.Btn_SetNakedMale.Text = "Naked Male";
            this.Btn_SetNakedMale.Click += new System.EventHandler(this.Btn_SetNakedMale_Click);
            // 
            // Btn_SetNakedFemale
            // 
            this.Btn_SetNakedFemale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetNakedFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetNakedFemale.Name = "Btn_SetNakedFemale";
            this.Btn_SetNakedFemale.Size = new System.Drawing.Size(156, 22);
            this.Btn_SetNakedFemale.Text = "Naked Female";
            this.Btn_SetNakedFemale.Click += new System.EventHandler(this.Btn_SetNakedFemale_Click);
            // 
            // Btn_SetakeZombie
            // 
            this.Btn_SetakeZombie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetakeZombie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetakeZombie.Name = "Btn_SetakeZombie";
            this.Btn_SetakeZombie.Size = new System.Drawing.Size(156, 22);
            this.Btn_SetakeZombie.Text = "Male Zombie";
            this.Btn_SetakeZombie.Click += new System.EventHandler(this.Btn_SetakeZombie_Click);
            // 
            // Btn_SetFemaleZombie
            // 
            this.Btn_SetFemaleZombie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetFemaleZombie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetFemaleZombie.Name = "Btn_SetFemaleZombie";
            this.Btn_SetFemaleZombie.Size = new System.Drawing.Size(156, 22);
            this.Btn_SetFemaleZombie.Text = "Female Zombie";
            this.Btn_SetFemaleZombie.Click += new System.EventHandler(this.Btn_SetFemaleZombie_Click);
            // 
            // Btn_Invinisble
            // 
            this.Btn_Invinisble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_Invinisble.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_InvisibleON,
            this.Btn_InvisibleOFF});
            this.Btn_Invinisble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_Invinisble.Name = "Btn_Invinisble";
            this.Btn_Invinisble.Size = new System.Drawing.Size(169, 22);
            this.Btn_Invinisble.Text = "Invisible";
            // 
            // Btn_InvisibleON
            // 
            this.Btn_InvisibleON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_InvisibleON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_InvisibleON.Name = "Btn_InvisibleON";
            this.Btn_InvisibleON.Size = new System.Drawing.Size(95, 22);
            this.Btn_InvisibleON.Text = "ON";
            this.Btn_InvisibleON.Click += new System.EventHandler(this.Btn_InvisibleON_Click);
            // 
            // Btn_InvisibleOFF
            // 
            this.Btn_InvisibleOFF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_InvisibleOFF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_InvisibleOFF.Name = "Btn_InvisibleOFF";
            this.Btn_InvisibleOFF.Size = new System.Drawing.Size(95, 22);
            this.Btn_InvisibleOFF.Text = "OFF";
            this.Btn_InvisibleOFF.Click += new System.EventHandler(this.Btn_InvisibleOFF_Click);
            // 
            // Btn_SetMoveSpeedScale
            // 
            this.Btn_SetMoveSpeedScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetMoveSpeedScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_SetMoveSpeedScalex1,
            this.Btn_SetMoveSpeedScalex2,
            this.Btn_SetMoveSpeedScalex3,
            this.Btn_SetMoveSpeedScalex4});
            this.Btn_SetMoveSpeedScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetMoveSpeedScale.Name = "Btn_SetMoveSpeedScale";
            this.Btn_SetMoveSpeedScale.Size = new System.Drawing.Size(169, 22);
            this.Btn_SetMoveSpeedScale.Text = "Move Speed Scale";
            // 
            // Btn_SetMoveSpeedScalex1
            // 
            this.Btn_SetMoveSpeedScalex1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetMoveSpeedScalex1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetMoveSpeedScalex1.Name = "Btn_SetMoveSpeedScalex1";
            this.Btn_SetMoveSpeedScalex1.Size = new System.Drawing.Size(86, 22);
            this.Btn_SetMoveSpeedScalex1.Text = "x1";
            this.Btn_SetMoveSpeedScalex1.Click += new System.EventHandler(this.Btn_SetMoveSpeedScalex1_Click);
            // 
            // Btn_SetMoveSpeedScalex2
            // 
            this.Btn_SetMoveSpeedScalex2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetMoveSpeedScalex2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetMoveSpeedScalex2.Name = "Btn_SetMoveSpeedScalex2";
            this.Btn_SetMoveSpeedScalex2.Size = new System.Drawing.Size(86, 22);
            this.Btn_SetMoveSpeedScalex2.Text = "x2";
            this.Btn_SetMoveSpeedScalex2.Click += new System.EventHandler(this.Btn_SetMoveSpeedScalex2_Click);
            // 
            // Btn_SetMoveSpeedScalex3
            // 
            this.Btn_SetMoveSpeedScalex3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetMoveSpeedScalex3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetMoveSpeedScalex3.Name = "Btn_SetMoveSpeedScalex3";
            this.Btn_SetMoveSpeedScalex3.Size = new System.Drawing.Size(86, 22);
            this.Btn_SetMoveSpeedScalex3.Text = "x3";
            this.Btn_SetMoveSpeedScalex3.Click += new System.EventHandler(this.Btn_SetMoveSpeedScalex3_Click);
            // 
            // Btn_SetMoveSpeedScalex4
            // 
            this.Btn_SetMoveSpeedScalex4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Btn_SetMoveSpeedScalex4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_SetMoveSpeedScalex4.Name = "Btn_SetMoveSpeedScalex4";
            this.Btn_SetMoveSpeedScalex4.Size = new System.Drawing.Size(86, 22);
            this.Btn_SetMoveSpeedScalex4.Text = "x4";
            this.Btn_SetMoveSpeedScalex4.Click += new System.EventHandler(this.Btn_SetMoveSpeedScalex4_Click);
            // 
            // Btn_ResetPlayerVariables
            // 
            this.Btn_ResetPlayerVariables.Location = new System.Drawing.Point(218, 10);
            this.Btn_ResetPlayerVariables.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ResetPlayerVariables.Name = "Btn_ResetPlayerVariables";
            this.Btn_ResetPlayerVariables.Padding = new System.Windows.Forms.Padding(4);
            this.Btn_ResetPlayerVariables.Size = new System.Drawing.Size(89, 37);
            this.Btn_ResetPlayerVariables.TabIndex = 4;
            this.Btn_ResetPlayerVariables.Text = "Reset Player Variables";
            this.Btn_ResetPlayerVariables.Click += new System.EventHandler(this.Btn_ResetPlayerVariables_Click);
            // 
            // UD_PosX
            // 
            this.UD_PosX.Location = new System.Drawing.Point(218, 98);
            this.UD_PosX.Margin = new System.Windows.Forms.Padding(2);
            this.UD_PosX.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.UD_PosX.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.UD_PosX.Name = "UD_PosX";
            this.UD_PosX.Size = new System.Drawing.Size(89, 20);
            this.UD_PosX.TabIndex = 5;
            // 
            // UD_PosY
            // 
            this.UD_PosY.Location = new System.Drawing.Point(311, 98);
            this.UD_PosY.Margin = new System.Windows.Forms.Padding(2);
            this.UD_PosY.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.UD_PosY.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.UD_PosY.Name = "UD_PosY";
            this.UD_PosY.Size = new System.Drawing.Size(89, 20);
            this.UD_PosY.TabIndex = 6;
            // 
            // UD_PosZ
            // 
            this.UD_PosZ.Location = new System.Drawing.Point(405, 98);
            this.UD_PosZ.Margin = new System.Windows.Forms.Padding(2);
            this.UD_PosZ.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.UD_PosZ.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.UD_PosZ.Name = "UD_PosZ";
            this.UD_PosZ.Size = new System.Drawing.Size(89, 20);
            this.UD_PosZ.TabIndex = 7;
            // 
            // Btn_TeleportPlayer
            // 
            this.Btn_TeleportPlayer.Location = new System.Drawing.Point(218, 51);
            this.Btn_TeleportPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_TeleportPlayer.Name = "Btn_TeleportPlayer";
            this.Btn_TeleportPlayer.Padding = new System.Windows.Forms.Padding(4);
            this.Btn_TeleportPlayer.Size = new System.Drawing.Size(89, 42);
            this.Btn_TeleportPlayer.TabIndex = 8;
            this.Btn_TeleportPlayer.Text = "Teleport Player";
            this.Btn_TeleportPlayer.Click += new System.EventHandler(this.Btn_TeleportPlayer_Click);
            // 
            // SavedMapLocations
            // 
            this.SavedMapLocations.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SavedMapLocations.FormattingEnabled = true;
            this.SavedMapLocations.Location = new System.Drawing.Point(218, 121);
            this.SavedMapLocations.Margin = new System.Windows.Forms.Padding(2);
            this.SavedMapLocations.Name = "SavedMapLocations";
            this.SavedMapLocations.Size = new System.Drawing.Size(278, 21);
            this.SavedMapLocations.TabIndex = 9;
            // 
            // Btn_SavePosition
            // 
            this.Btn_SavePosition.Location = new System.Drawing.Point(218, 145);
            this.Btn_SavePosition.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_SavePosition.Name = "Btn_SavePosition";
            this.Btn_SavePosition.Padding = new System.Windows.Forms.Padding(4);
            this.Btn_SavePosition.Size = new System.Drawing.Size(89, 19);
            this.Btn_SavePosition.TabIndex = 10;
            this.Btn_SavePosition.Text = "Save Position";
            this.Btn_SavePosition.Click += new System.EventHandler(this.Btn_SavePosition_Click);
            // 
            // Btn_LoadPosition
            // 
            this.Btn_LoadPosition.Location = new System.Drawing.Point(311, 145);
            this.Btn_LoadPosition.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_LoadPosition.Name = "Btn_LoadPosition";
            this.Btn_LoadPosition.Padding = new System.Windows.Forms.Padding(4);
            this.Btn_LoadPosition.Size = new System.Drawing.Size(89, 19);
            this.Btn_LoadPosition.TabIndex = 11;
            this.Btn_LoadPosition.Text = "Load Position";
            this.Btn_LoadPosition.Click += new System.EventHandler(this.Btn_LoadPosition_Click);
            // 
            // Btn_ReloadPositions
            // 
            this.Btn_ReloadPositions.Location = new System.Drawing.Point(405, 145);
            this.Btn_ReloadPositions.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ReloadPositions.Name = "Btn_ReloadPositions";
            this.Btn_ReloadPositions.Padding = new System.Windows.Forms.Padding(4);
            this.Btn_ReloadPositions.Size = new System.Drawing.Size(112, 19);
            this.Btn_ReloadPositions.TabIndex = 12;
            this.Btn_ReloadPositions.Text = "Reload Positions";
            this.Btn_ReloadPositions.Click += new System.EventHandler(this.Btn_ReloadPositions_Click);
            // 
            // Txt_SaveLocationName
            // 
            this.Txt_SaveLocationName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Txt_SaveLocationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_SaveLocationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Txt_SaveLocationName.Location = new System.Drawing.Point(218, 168);
            this.Txt_SaveLocationName.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_SaveLocationName.Name = "Txt_SaveLocationName";
            this.Txt_SaveLocationName.Size = new System.Drawing.Size(277, 20);
            this.Txt_SaveLocationName.TabIndex = 13;
            this.Txt_SaveLocationName.Text = "Location Name";
            this.Txt_SaveLocationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BW_PlayerList
            // 
            this.BW_PlayerList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_PlayerList_DoWork);
            // 
            // Btn_RemoveDeathBarriers
            // 
            this.Btn_RemoveDeathBarriers.Location = new System.Drawing.Point(311, 10);
            this.Btn_RemoveDeathBarriers.Name = "Btn_RemoveDeathBarriers";
            this.Btn_RemoveDeathBarriers.Padding = new System.Windows.Forms.Padding(5);
            this.Btn_RemoveDeathBarriers.Size = new System.Drawing.Size(136, 23);
            this.Btn_RemoveDeathBarriers.TabIndex = 14;
            this.Btn_RemoveDeathBarriers.Text = "Remove Death Barriers";
            this.Btn_RemoveDeathBarriers.Click += new System.EventHandler(this.Btn_RemoveDeathBarriers_Click);
            // 
            // NUP_SetOperator
            // 
            this.NUP_SetOperator.Location = new System.Drawing.Point(218, 293);
            this.NUP_SetOperator.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NUP_SetOperator.Name = "NUP_SetOperator";
            this.NUP_SetOperator.Size = new System.Drawing.Size(120, 20);
            this.NUP_SetOperator.TabIndex = 15;
            this.NUP_SetOperator.ValueChanged += new System.EventHandler(this.NUP_SetOperator_ValueChanged);
            // 
            // BW_ZombieTeleport
            // 
            this.BW_ZombieTeleport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_ZombieTeleport_DoWork);
            // 
            // BW_PlayerMods
            // 
            this.BW_PlayerMods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_PlayerMods_DoWork);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(218, 277);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(60, 13);
            this.darkLabel1.TabIndex = 16;
            this.darkLabel1.Text = "darkLabel1";
            // 
            // Btn_SpookyHalloween
            // 
            this.Btn_SpookyHalloween.Location = new System.Drawing.Point(311, 39);
            this.Btn_SpookyHalloween.Name = "Btn_SpookyHalloween";
            this.Btn_SpookyHalloween.Padding = new System.Windows.Forms.Padding(5);
            this.Btn_SpookyHalloween.Size = new System.Drawing.Size(136, 23);
            this.Btn_SpookyHalloween.TabIndex = 20;
            this.Btn_SpookyHalloween.Text = "Spooky Halloween";
            this.Btn_SpookyHalloween.Click += new System.EventHandler(this.Btn_SpookyHalloween_Click);
            // 
            // CB_Maps
            // 
            this.CB_Maps.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CB_Maps.FormattingEnabled = true;
            this.CB_Maps.Items.AddRange(new object[] {
            "Duga",
            "Alpine",
            "Ruka",
            "Sanatorium",
            "Golova",
            "Zoo"});
            this.CB_Maps.Location = new System.Drawing.Point(311, 68);
            this.CB_Maps.Name = "CB_Maps";
            this.CB_Maps.Size = new System.Drawing.Size(136, 21);
            this.CB_Maps.TabIndex = 21;
            this.CB_Maps.SelectedIndexChanged += new System.EventHandler(this.CB_Maps_SelectedIndexChanged);
            // 
            // Lbl_MapGametype
            // 
            this.Lbl_MapGametype.AutoSize = true;
            this.Lbl_MapGametype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Lbl_MapGametype.Location = new System.Drawing.Point(344, 195);
            this.Lbl_MapGametype.Name = "Lbl_MapGametype";
            this.Lbl_MapGametype.Size = new System.Drawing.Size(104, 13);
            this.Lbl_MapGametype.TabIndex = 22;
            this.Lbl_MapGametype.Text = "Map/Gametype: ?/?";
            // 
            // Btn_HideAll
            // 
            this.Btn_HideAll.Location = new System.Drawing.Point(453, 10);
            this.Btn_HideAll.Name = "Btn_HideAll";
            this.Btn_HideAll.Padding = new System.Windows.Forms.Padding(5);
            this.Btn_HideAll.Size = new System.Drawing.Size(79, 23);
            this.Btn_HideAll.TabIndex = 23;
            this.Btn_HideAll.Text = "Hide All";
            this.Btn_HideAll.Click += new System.EventHandler(this.Btn_HideAll_Click);
            // 
            // Txt_MapName
            // 
            this.Txt_MapName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Txt_MapName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_MapName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Txt_MapName.Location = new System.Drawing.Point(218, 193);
            this.Txt_MapName.Name = "Txt_MapName";
            this.Txt_MapName.Size = new System.Drawing.Size(120, 20);
            this.Txt_MapName.TabIndex = 24;
            this.Txt_MapName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_MapName_KeyDown);
            // 
            // CB_DollyNoclip
            // 
            this.CB_DollyNoclip.AutoSize = true;
            this.CB_DollyNoclip.Location = new System.Drawing.Point(218, 219);
            this.CB_DollyNoclip.Name = "CB_DollyNoclip";
            this.CB_DollyNoclip.Size = new System.Drawing.Size(82, 17);
            this.CB_DollyNoclip.TabIndex = 25;
            this.CB_DollyNoclip.Text = "Dolly Noclip";
            // 
            // NUD_NoclipSpeed
            // 
            this.NUD_NoclipSpeed.Location = new System.Drawing.Point(218, 242);
            this.NUD_NoclipSpeed.Name = "NUD_NoclipSpeed";
            this.NUD_NoclipSpeed.Size = new System.Drawing.Size(89, 20);
            this.NUD_NoclipSpeed.TabIndex = 26;
            this.NUD_NoclipSpeed.ValueChanged += new System.EventHandler(this.NUD_NoclipSpeed_ValueChanged);
            // 
            // Btn_Fix
            // 
            this.Btn_Fix.Location = new System.Drawing.Point(457, 276);
            this.Btn_Fix.Name = "Btn_Fix";
            this.Btn_Fix.Padding = new System.Windows.Forms.Padding(5);
            this.Btn_Fix.Size = new System.Drawing.Size(75, 23);
            this.Btn_Fix.TabIndex = 28;
            this.Btn_Fix.Text = "Fix";
            this.Btn_Fix.Click += new System.EventHandler(this.Btn_Fix_Click);
            // 
            // Btn_Restore
            // 
            this.Btn_Restore.Location = new System.Drawing.Point(457, 305);
            this.Btn_Restore.Name = "Btn_Restore";
            this.Btn_Restore.Padding = new System.Windows.Forms.Padding(5);
            this.Btn_Restore.Size = new System.Drawing.Size(75, 23);
            this.Btn_Restore.TabIndex = 29;
            this.Btn_Restore.Text = "Restore";
            this.Btn_Restore.Click += new System.EventHandler(this.Btn_Restore_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Restore);
            this.Controls.Add(this.Btn_Fix);
            this.Controls.Add(this.NUD_NoclipSpeed);
            this.Controls.Add(this.CB_DollyNoclip);
            this.Controls.Add(this.Txt_MapName);
            this.Controls.Add(this.Btn_HideAll);
            this.Controls.Add(this.Lbl_MapGametype);
            this.Controls.Add(this.CB_Maps);
            this.Controls.Add(this.Btn_SpookyHalloween);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.NUP_SetOperator);
            this.Controls.Add(this.Btn_RemoveDeathBarriers);
            this.Controls.Add(this.Txt_SaveLocationName);
            this.Controls.Add(this.Btn_ReloadPositions);
            this.Controls.Add(this.Btn_LoadPosition);
            this.Controls.Add(this.Btn_SavePosition);
            this.Controls.Add(this.SavedMapLocations);
            this.Controls.Add(this.Btn_TeleportPlayer);
            this.Controls.Add(this.UD_PosZ);
            this.Controls.Add(this.UD_PosY);
            this.Controls.Add(this.UD_PosX);
            this.Controls.Add(this.Btn_ResetPlayerVariables);
            this.Controls.Add(this.TreeView_PlayerList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "1.19.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Context_PlayerOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UD_PosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_PosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_PosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUP_SetOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NoclipSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BW_Noclip;
        private System.ComponentModel.BackgroundWorker BW_ReadPlayerInfo;
        private DarkUI.Controls.DarkTreeView TreeView_PlayerList;
        private DarkUI.Controls.DarkContextMenu Context_PlayerOptions;
        private System.Windows.Forms.ToolStripMenuItem noclipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Btn_NoclipON;
        private System.Windows.Forms.ToolStripMenuItem Btn_NoclipOFF;
        private System.Windows.Forms.ToolStripMenuItem Btn_Godmode;
        private System.Windows.Forms.ToolStripMenuItem Btn_GodmodeON;
        private System.Windows.Forms.ToolStripMenuItem Btn_GodmodeOFF;
        private DarkUI.Controls.DarkButton Btn_ResetPlayerVariables;
        private DarkUI.Controls.DarkNumericUpDown UD_PosX;
        private DarkUI.Controls.DarkNumericUpDown UD_PosY;
        private DarkUI.Controls.DarkNumericUpDown UD_PosZ;
        private DarkUI.Controls.DarkButton Btn_TeleportPlayer;
        private DarkUI.Controls.DarkComboBox SavedMapLocations;
        private DarkUI.Controls.DarkButton Btn_SavePosition;
        private DarkUI.Controls.DarkButton Btn_LoadPosition;
        private DarkUI.Controls.DarkButton Btn_ReloadPositions;
        private DarkUI.Controls.DarkTextBox Txt_SaveLocationName;
        private System.ComponentModel.BackgroundWorker BW_PlayerList;
        private DarkUI.Controls.DarkButton Btn_RemoveDeathBarriers;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetOperators;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetNakedMale;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetNakedFemale;
        private DarkUI.Controls.DarkNumericUpDown NUP_SetOperator;
        private System.Windows.Forms.ToolStripMenuItem Btn_Invinisble;
        private System.Windows.Forms.ToolStripMenuItem Btn_InvisibleON;
        private System.Windows.Forms.ToolStripMenuItem Btn_InvisibleOFF;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetMoveSpeedScale;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetMoveSpeedScalex1;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetMoveSpeedScalex2;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetMoveSpeedScalex3;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetMoveSpeedScalex4;
        private System.ComponentModel.BackgroundWorker BW_ZombieTeleport;
        private System.ComponentModel.BackgroundWorker BW_PlayerMods;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkButton Btn_SpookyHalloween;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetakeZombie;
        private System.Windows.Forms.ToolStripMenuItem Btn_SetFemaleZombie;
        private DarkUI.Controls.DarkComboBox CB_Maps;
        private DarkUI.Controls.DarkLabel Lbl_MapGametype;
        private DarkUI.Controls.DarkButton Btn_HideAll;
        private DarkUI.Controls.DarkTextBox Txt_MapName;
        private DarkUI.Controls.DarkCheckBox CB_DollyNoclip;
        private DarkUI.Controls.DarkNumericUpDown NUD_NoclipSpeed;
        private DarkUI.Controls.DarkButton Btn_Fix;
        private DarkUI.Controls.DarkButton Btn_Restore;
        private System.Windows.Forms.Button button1;
    }
}

