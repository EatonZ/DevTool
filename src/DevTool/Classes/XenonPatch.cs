// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;

namespace DevTool.Classes
{
    public sealed class XenonPatch : IDisposable
    {
        #region Fields and Properties

        private EndianIO eio;

        public bool IsOpen { get; private set; }

        public bool IsDisposed { get; private set; }

        public bool HasBeenRead { get; private set; }

        public List<PatchEntry> Patches { get; set; }

        #endregion

        #region Format Classes

        public class PatchEntry
        {
            #region Fields, Properties, and Constructors

            private byte[] data;

            public uint Address { get; set; }

            public byte[] Data
            {
                get { return data; }
                set
                {
                    if (value.Length % 4 != 0) throw new Exception("PatchEntry.Data: Invalid data specified. It must be 4-byte aligned.");
                    data = value;
                }
            }

            internal PatchEntry(){}

            #endregion

            #region Methods

            public void Read(EndianReader Reader)
            {
                Address = Reader.ReadUInt32();
                data = Reader.ReadBytes(Reader.ReadInt32() * 4);
            }

            public void Write(EndianWriter Writer)
            {
                Writer.Write(Address);
                Writer.Write(data.Length / 4);
                Writer.Write(data);
            }

            public override string ToString() { return XtraFunctions.ValueToHex(Address); }

            #endregion
        }

        #endregion

        #region Constructors

        public XenonPatch(string XenonPatchLocation) : this(new FileStream(XenonPatchLocation, FileMode.Open, FileAccess.ReadWrite, FileShare.Read)){}

        public XenonPatch(Stream XenonPatch)
        {
            if (!XenonPatch.CanRead || !XenonPatch.CanWrite) throw new Exception("XenonPatch: Invalid Xenon patch specified. It doesn't support reading/writing.");
            if (XenonPatch.Length > 0x4000 || XenonPatch.Length < 12 || (XenonPatch.Length % 4) != 0) throw new Exception("XenonPatch: Invalid Xenon patch specified. It is not a valid size.");
            eio = new EndianIO(XenonPatch, EndianTypes.BigEndian);
            IsOpen = true;
        }

        #endregion

        #region Methods

        public void Read()
        {
            if (!IsOpen || IsDisposed) throw new Exception("XenonPatch.Read: The Xenon patch is not open.");
            if (HasBeenRead) throw new Exception("XenonPatch.Read: The Xenon patch has already been read.");
            eio.SetPosition(0);
            Patches = new List<PatchEntry>();
            //Just has Kernel+XAM.
            {
                var nextAddr = eio.Reader.ReadUInt32();
                while (nextAddr != uint.MaxValue)
                {
                    eio.SetPosition(-4, SeekOrigin.Current);
                    var entry = new PatchEntry();
                    entry.Read(eio.Reader);
                    Patches.Add(entry);
                    nextAddr = eio.Reader.ReadUInt32();
                }
            }
            HasBeenRead = true;
        }

        public void Write()
        {
            if (!IsOpen || IsDisposed) throw new Exception("XenonPatch.Write: The Xenon patch is not open.");
            if (!HasBeenRead) throw new Exception("XenonPatch.Write: The Xenon patch has not been read.");
            eio.Stream.SetLength(0);
            Patches.ForEach(patch => patch.Write(eio.Writer));
            eio.Writer.Write(uint.MaxValue);
        }

        public override string ToString() { return !IsOpen || IsDisposed ? "(Closed/Disposed)" : Path.GetFileName(eio.FileLocation); }

        public void Close()
        {
            eio.Close();
            IsOpen = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            Patches = null;
            eio.Dispose();
            eio = null;
            IsOpen = false;
            IsDisposed = true;
        }

        ~XenonPatch() { Dispose(false); }

        #endregion
    }
}