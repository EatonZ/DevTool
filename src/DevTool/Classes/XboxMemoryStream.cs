// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.IO;
using XDevkit;

namespace DevTool.Classes
{
    public sealed class XboxMemoryStream : Stream
    {
        #region Fields, Properties, and Constructors

        private IXboxDebugTarget target;
        private long position;
        private bool cr;
        private bool cs;
        private bool cw;

        public bool IsOpen { get; private set; }

        public bool IsDisposed { get; private set; }

        public override long Position
        {
            get
            {
                if (!IsOpen) throw new Exception("XboxMemoryStream.Position: The XMS stream is not open.");
                if (!CanSeek) throw new Exception("XboxMemoryStream.Position: Seeking is not supported.");
                return position;
            }
            set
            {
                value = (uint)value;
                if (!IsOpen || IsDisposed) throw new Exception("XboxMemoryStream.Position: The XMS stream is not open.");
                if (!CanSeek) throw new Exception("XboxMemoryStream.Position: Seeking is not supported.");
                if (value < 0 || value > uint.MaxValue) throw new Exception("XboxMemoryStream.Position: Invalid position specified. It must be greater than or equal to 0 and less than uint.MaxValue.");
                position = value;
            }
        }

        public override long Length { get { throw new InvalidOperationException(); } }

        public override bool CanRead { get { return cr; } }

        public override bool CanSeek { get { return cs; } }

        public override bool CanWrite { get { return cw; } }

        public XboxMemoryStream(IXboxDebugTarget Target)
        {
            if (Target == null) throw new Exception("XboxMemoryStream: Invalid debug target specified. It is null.");
            target = Target;
            IsOpen = true;
            cr = true;
            cs = true;
            cw = true;
        }

        #endregion

        #region Methods

        public override int Read(byte[] Data, int Offset, int Count)
        {
            if (!IsOpen || IsDisposed) throw new Exception("XboxMemoryStream.Read: The XMS stream is not open.");
            if (Position < 0 || Position > uint.MaxValue) throw new Exception("XboxMemoryStream.Read: Invalid position specified. It must be greater than or equal to 0 and less than uint.MaxValue.");
            if (Data == null) throw new Exception("XboxMemoryStream.Read: No recipient data array specified.");
            if (Offset < 0) throw new Exception("XboxMemoryStream.Read: Invalid offset specified. It must be greater than or equal to 0.");
            if (Count < 0) throw new Exception("XboxMemoryStream.Read: Invalid count specified. It must be greater than or equal to 0.");
            if (Count == 0) return 0;
            if (Offset + Count > Data.Length) throw new Exception("XboxMemoryStream.Read: Invalid offset/count specified. They must fit within the size of the data.");
            uint read;
            target.InvalidateMemoryCache(true, (uint)Position, (uint)Count);
            if (Offset == 0) target.GetMemory((uint)Position, (uint)Count, Data, out read);
            else
            {
                var temp = new byte[Count];
                target.GetMemory((uint)Position, (uint)Count, temp, out read);
                temp.CopyTo(Data, Offset);
            }
            Position += read;
            return (int)read;
        }

        public override void Flush() { return; }

        public override long Seek(long Position, SeekOrigin Origin)
        {
            switch (Origin)
            {
                case SeekOrigin.Begin:
                    {
                        this.Position = Position;
                        break;
                    }
                case SeekOrigin.Current:
                    {
                        this.Position += Position;
                        break;
                    }
                case SeekOrigin.End:
                    {
                        this.Position -= Position;
                        break;
                    }
            }
            return this.Position;
        }

        public override void SetLength(long Value) { throw new InvalidOperationException(); }

        public override void Write(byte[] Data, int Offset, int Count)
        {
            if (!IsOpen || IsDisposed) throw new Exception("XboxMemoryStream.Write: The XMS stream is not open.");
            if (Position < 0 || Position > uint.MaxValue) throw new Exception("XboxMemoryStream.Writes: Invalid position specified. It must be greater than or equal to 0 and less than uint.MaxValue.");
            if (Data == null) throw new Exception("XboxMemoryStream.Write: No data array specified.");
            if (Offset < 0) throw new Exception("XboxMemoryStream.Write: Invalid offset specified. It must be greater than or equal to 0.");
            if (Count < 0) throw new Exception("XboxMemoryStream.Write: Invalid count specified. It must be greater than or equal to 0.");
            if (Count == 0) return;
            if (Offset + Count > Data.Length) throw new Exception("XboxMemoryStream.Write: Invalid offset/count specified. They must fit within the size of the data.");
            uint bytesWritten;
            target.SetMemory((uint)Position, (uint)Count, Data, out bytesWritten);
            Position += bytesWritten;
        }

        public override string ToString() { return !IsOpen || IsDisposed ? "(Closed/Disposed)" : target.Console.Name; }

        public override void Close()
        {
            cr = false;
            cs = false;
            cw = false;
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
            target = null;
            position = 0;
            Close();
            IsDisposed = true;
        }

        ~XboxMemoryStream() { Dispose(false); }

        #endregion
    }
}