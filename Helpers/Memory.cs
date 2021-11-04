using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace T9Host.Helpers
{
    using static MainForm;
    public class Memory
    {
        public IntPtr ProcessHandle;
        public Int64 BaseAddress;

        [DllImport("ntdll.dll")]
        public static extern Int64 NtWriteVirtualMemory(IntPtr ProcessHandle, Int64 BaseAddress, byte[] Buffer, int NumberOfBytesToWrite, out int NumberOfBytesWritten);

        [DllImport("ntdll.dll")]
        public static extern Int64 NtReadVirtualMemory(IntPtr ProcessHandle, Int64 BaseAddress, [Out] byte[] Buffer, uint NumberOfBytesToRead, out int NumberOfBytesRead);
        //E8 ? ? ? ? E9 ? ? ? ? C7 82 ? ? ? ? ? ? ? ?  - theater patch
        /// <summary>
        /// fix for dolly camera location
        /// </summary>
        public void Fix()
        {
            int si = 0;
            NtWriteVirtualMemory(ProcessHandle, BaseAddress + 0x9625900, new byte[] { 0xC3 }, 1, out si);
        }
        /// <summary>
        /// restore for dolly camera location
        /// </summary>
        public void Restore()
        {
            int si = 0;
            NtWriteVirtualMemory(ProcessHandle, BaseAddress + 0x9625900, new byte[] { 0x40 }, 1, out si);
        }

        public bool AttachProcess(string processName)
        {
            try
            {
                Process processes = Process.GetProcessesByName(processName)[0];

                if (processes.Handle.ToInt64() != 0)
                {
                    BaseAddress = processes.MainModule.BaseAddress.ToInt64();
                    ProcessHandle = processes.Handle;
                    return true;
                }
            }
            catch (Exception ex)
            {
                BaseAddress = 0;
                ProcessHandle = IntPtr.Zero;
                return false;
            }
            return false;
        }

        public void WriteInt(Int64 pAddress, int value)
        {

            try
            {
                int outSize = 0;
                NtWriteVirtualMemory(ProcessHandle, pAddress, BitConverter.GetBytes(value), 4, out outSize);
            }
            catch (Exception ex)
            {

            }
        }

        public void WriteUInt(Int64 pAddress, uint value)
        {

            try
            {
                int outSize = 0;
                NtWriteVirtualMemory(ProcessHandle, pAddress, BitConverter.GetBytes(value), 4, out outSize);
            }
            catch (Exception ex)
            {

            }
        }

        public void WriteFloat(Int64 pAddress, float value)
        {

            try
            {
                int outSize = 0;
                NtWriteVirtualMemory(ProcessHandle, pAddress, BitConverter.GetBytes(value), 4, out outSize);
            }
            catch (Exception ex)
            {

            }
        }

        public void WritePointer(Int64 pAddress, UInt64 value)
        {
            try
            {
                int outSize = 0;
                NtWriteVirtualMemory(ProcessHandle, pAddress, BitConverter.GetBytes(value), 8, out outSize);
            }
            catch (Exception ex)
            {

            }
        }

        public short ReadShort(Int64 pAddress)
        {
            try
            {
                int outSize = 0;
                byte[] bytes = new byte[4];
                NtReadVirtualMemory(ProcessHandle, pAddress, bytes, 2, out outSize);
                {
                    return BitConverter.ToInt16(bytes, 0);
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public void WriteBytes(Int64 pAddress, byte[] value)
        {
            try
            {
                int outSize = 0;
                NtWriteVirtualMemory(ProcessHandle, pAddress, value, value.Length, out outSize);
            }
            catch (Exception ex)
            {

            }
        }

        public string ReadString(Int64 pAddress)
        {
            try
            {
                byte[] bytes = new byte[0x500];
                int outSize = 0;
                NtReadVirtualMemory(ProcessHandle, pAddress, bytes, 0x500, out outSize);
                {
                    string str_build = "";
                    int str_len = 0;
                    while (bytes[str_len] != 0)
                    {
                        str_build += (char)bytes[str_len];
                        str_len++;
                    }
                    return str_build;
                }
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        public Int64 ReadPointer(Int64 pAddress)
        {
            try
            {
                int outSize = 0;
                byte[] bytes = new byte[8];
                NtReadVirtualMemory(ProcessHandle, pAddress, bytes, 8, out outSize);
                return BitConverter.ToInt64(bytes, 0);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public int ReadInt(Int64 pAddress)
        {
            try
            {
                int outSize = 0;
                byte[] bytes = new byte[4];
                NtReadVirtualMemory(ProcessHandle, pAddress, bytes, 4, out outSize);
                return BitConverter.ToInt32(bytes, 0);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public uint ReadUInt(Int64 pAddress)
        {
            try
            {
                int outSize = 0;
                byte[] bytes = new byte[4];
                NtReadVirtualMemory(ProcessHandle, pAddress, bytes, 4, out outSize);
                return BitConverter.ToUInt32(bytes, 0);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public float ReadFloat(Int64 pAddress)
        {
            try
            {
                int outSize = 0;
                byte[] bytes = new byte[4];
                NtReadVirtualMemory(ProcessHandle, pAddress, bytes, 4, out outSize);
                return BitConverter.ToSingle(bytes, 0);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public byte[] ReadBytes(Int64 pAddress, int length)
        {
            byte[] bytes = new byte[length];
            int outSize = 0;
            NtReadVirtualMemory(ProcessHandle, pAddress, bytes, (uint)length, out outSize);
            return bytes;
        }

        public void WriteString(Int64 pAddress, string pString)
        {
            try
            {
                int outSize = 0;
                NtWriteVirtualMemory(ProcessHandle, pAddress, System.Text.Encoding.UTF8.GetBytes(pString), pString.Length, out outSize);
                byte[] null_byte = new byte[1];
                NtWriteVirtualMemory(ProcessHandle, pAddress + pString.Length, null_byte, 1, out outSize);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
