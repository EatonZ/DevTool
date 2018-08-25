// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.IO;

namespace DevTool.Classes
{
    public sealed class TitleNameCache : IDisposable
    {
        #region Fields, Properties, and Constructors

        private StreamReader reader;
        private StreamWriter writer;

        public bool IsOpen { get; private set; }

        public bool IsDisposed { get; private set; }

        public TitleNameCache(string TitleNameCacheLocation) : this(new FileStream(TitleNameCacheLocation, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read)) { }

        public TitleNameCache(Stream TitleNameCache)
        {
            if (!TitleNameCache.CanRead || !TitleNameCache.CanWrite) throw new Exception("TitleNameCache: Invalid title name cache specified. It doesn't support reading/writing.");
            reader = new StreamReader(TitleNameCache);
            writer = new StreamWriter(TitleNameCache);
            IsOpen = true;
        }

        #endregion

        #region Methods

        public void AddTitle(string TitleName, string TitleID)
        {
            if (!IsOpen || IsDisposed) throw new Exception("TitleNameCache.AddTitle: The title name cache is not open.");
            if (string.IsNullOrWhiteSpace(TitleName)) throw new Exception("TitleNameCache.AddTitle: Invalid title name specified. It cannot be null, empty, or a white space character.");
            if (TitleID.Length != 8 || TitleID.StartsWith("0x") || !XtraFunctions.IsValidBase16String(TitleID)) throw new Exception("TitleNameCache.AddTitle: Invalid title ID specified. It must be 8 characters in length and in hexadecimal format without the '0x'.");
            writer.BaseStream.Position = writer.BaseStream.Length;
            writer.WriteLine(TitleID);
            writer.WriteLine(TitleName);
            writer.Flush();
        }

        public string TitleIDToTitleName(string TitleID)
        {
            if (!IsOpen || IsDisposed) throw new Exception("TitleNameCache.TitleIDToTitleName: The title name cache is not open.");
            if (TitleID.Length != 8 || TitleID.StartsWith("0x") || !XtraFunctions.IsValidBase16String(TitleID)) throw new Exception("TitleNameCache.TitleIDToTitleName: Invalid title ID specified. It must be 8 characters in length and in hexadecimal format without the '0x'.");
            reader.BaseStream.Position = 0;
            string tid;
            string tn;
            while (!string.IsNullOrWhiteSpace(tid = reader.ReadLine()) && !string.IsNullOrWhiteSpace(tn = reader.ReadLine())) if (String.CompareOrdinal(TitleID, tid) == 0) return tn;
            return "(NOT FOUND)";
        }

        public string TitleNameToTitleID(string TitleName)
        {
            if (!IsOpen || IsDisposed) throw new Exception("TitleNameCache.TitleNameToTitleID: The title name cache is not open.");
            if (string.IsNullOrWhiteSpace(TitleName)) throw new Exception("TitleNameCache.TitleNameToTitleID: Invalid title name specified. It cannot be null, empty, or a white space character.");
            reader.BaseStream.Position = 0;
            string tid;
            string tn;
            while (!string.IsNullOrWhiteSpace(tid = reader.ReadLine()) && !string.IsNullOrWhiteSpace(tn = reader.ReadLine())) if (String.CompareOrdinal(TitleName, tn) == 0) return tid;
            return "(NOT FOUND)";
        }

        public override string ToString() { return !IsOpen || IsDisposed ? "(Closed/Disposed)" : base.ToString(); }

        public void Close()
        {
            if (!IsOpen) return;
            //Just need to close 1, closing the writer is pointless since both use the same stream.
            reader.Close();
            IsOpen = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (IsDisposed || !disposing) return;
            //Just need to close 1, closing the writer is pointless since both use the same stream.
            reader.Dispose();
            reader = null;
            writer = null;
            IsOpen = false;
            IsDisposed = true;
        }

        ~TitleNameCache() { Dispose(false); }

        #endregion
    }
}