// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

namespace DevTool.Classes
{
    public static class BitConverterEx
    {
        #region Methods

        //Getting

        public static short GetInt16(byte[] Source, int Offset, EndianTypes Endian) { return Endian == EndianTypes.LittleEndian ? (short)(Source[Offset] | (Source[Offset + 1] << 8)) : (short)((Source[Offset] << 8) | Source[Offset + 1]); }

        public static ushort GetUInt16(byte[] Source, int Offset, EndianTypes Endian) { return (ushort)GetInt16(Source, Offset, Endian); }

        public static int GetInt32(byte[] Source, int Offset, EndianTypes Endian) { return Endian == EndianTypes.LittleEndian ? (((Source[Offset] | (Source[Offset + 1] << 8)) | (Source[Offset + 2] << 0x10)) | (Source[Offset + 3] << 0x18)) : ((((Source[Offset] << 0x18) | (Source[Offset + 1] << 0x10)) | (Source[Offset + 2] << 8)) | Source[Offset + 3]); }

        public static uint GetUInt32(byte[] Source, int Offset, EndianTypes Endian) { return (uint)GetInt32(Source, Offset, Endian); }

        public static long GetInt64(byte[] Source, int Offset, EndianTypes Endian) { return Endian == EndianTypes.LittleEndian ? (uint)(((Source[Offset] | (Source[Offset + 1] << 8)) | (Source[Offset + 2] << 0x10)) | (Source[Offset + 3] << 0x18)) | ((long)(((Source[Offset + 4] | (Source[Offset + 5] << 8)) | (Source[Offset + 6] << 0x10)) | (Source[Offset + 7] << 0x18)) << 32) : (uint)((((Source[Offset + 4] << 0x18) | (Source[Offset + 5] << 0x10)) | (Source[Offset + 6] << 8)) | Source[Offset + 7]) | ((long)((((Source[Offset] << 0x18) | (Source[Offset + 1] << 0x10)) | (Source[Offset + 2] << 8)) | Source[Offset + 3]) << 32); }

        public static ulong GetUInt64(byte[] Source, int Offset, EndianTypes Endian) { return (ulong)GetInt64(Source, Offset, Endian); }

        //Setting

        public static void SetInt16(byte[] Dest, int Offset, short Value, EndianTypes Endian) { SetUInt16(Dest, Offset, (ushort)Value, Endian); }

        public static void SetUInt16(byte[] Dest, int Offset, ushort Value, EndianTypes Endian)
        {
            if (Endian == EndianTypes.LittleEndian)
            {
                Dest[Offset] = (byte)Value;
                Dest[Offset + 1] = (byte)(Value >> 8);
            }
            else
            {
                Dest[Offset] = (byte)(Value >> 8);
                Dest[Offset + 1] = (byte)Value;
            }
        }

        public static void SetInt32(byte[] Dest, int Offset, int Value, EndianTypes Endian) { SetUInt32(Dest, Offset, (uint)Value, Endian); }

        public static void SetUInt32(byte[] Dest, int Offset, uint Value, EndianTypes Endian)
        {
            if (Endian == EndianTypes.LittleEndian)
            {
                Dest[Offset] = (byte)Value;
                Dest[Offset + 1] = (byte)(Value >> 8);
                Dest[Offset + 2] = (byte)(Value >> 16);
                Dest[Offset + 3] = (byte)(Value >> 24);
            }
            else
            {
                Dest[Offset] = (byte)(Value >> 24);
                Dest[Offset + 1] = (byte)(Value >> 16);
                Dest[Offset + 2] = (byte)(Value >> 8);
                Dest[Offset + 3] = (byte)Value;
            }
        }

        public static void SetInt64(byte[] Dest, int Offset, long Value, EndianTypes Endian) { SetUInt64(Dest, Offset, (ulong)Value, Endian); }

        public static void SetUInt64(byte[] Dest, int Offset, ulong Value, EndianTypes Endian)
        {
            if (Endian == EndianTypes.LittleEndian)
            {
                Dest[Offset] = (byte)Value;
                Dest[Offset + 1] = (byte)(Value >> 8);
                Dest[Offset + 2] = (byte)(Value >> 16);
                Dest[Offset + 3] = (byte)(Value >> 24);
                Dest[Offset + 4] = (byte)(Value >> 32);
                Dest[Offset + 5] = (byte)(Value >> 40);
                Dest[Offset + 6] = (byte)(Value >> 48);
                Dest[Offset + 7] = (byte)(Value >> 56);
            }
            else
            {
                Dest[Offset] = (byte)(Value >> 56);
                Dest[Offset + 1] = (byte)(Value >> 48);
                Dest[Offset + 2] = (byte)(Value >> 40);
                Dest[Offset + 3] = (byte)(Value >> 32);
                Dest[Offset + 4] = (byte)(Value >> 24);
                Dest[Offset + 5] = (byte)(Value >> 16);
                Dest[Offset + 6] = (byte)(Value >> 8);
                Dest[Offset + 7] = (byte)Value;
            }
        }

        #endregion
    }
}