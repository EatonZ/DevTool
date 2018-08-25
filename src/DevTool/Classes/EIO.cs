// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace DevTool.Classes
{
    #region EndianType

    public enum EndianTypes : byte
    {
        LittleEndian = 0,
        BigEndian = 1,
    }

    #endregion

    #region EndianIO

    public class EndianIO : IDisposable
    {
        #region Fields, Properties, and Constructors

        private EndianTypes et;
        private EndianReader rdr;
        private EndianWriter wtr;

        public EndianTypes EndianType
        {
            get { return et; }
            set
            {
                if (!Enum.IsDefined(typeof(EndianTypes), value)) throw new Exception("EndianIO.EndianType: Invalid endian type specified.");
                et = value;
            }
        }

        public virtual EndianReader Reader
        {
            get
            {
                if (rdr == null) throw new Exception("EndianIO.Reader: This instance is either not initialized properly or the stream doesn't support reading.");
                return rdr;
            }
            internal set { rdr = value; }
        }

        public virtual EndianWriter Writer
        {
            get
            {
                if (wtr == null)  throw new Exception("EndianIO.Writer: This instance is either not initialized properly or the stream doesn't support writing.");
                return wtr;
            }
            internal set { wtr = value; }
        }

        public virtual string FileLocation { get; protected set; }

        public virtual Stream Stream { get; protected set; }

        public virtual long Position
        {
            get { return Stream.Position; }
            set { SetPosition(value); }
        }

        public virtual long Length { get { return Stream.Length; } }

        public bool IsOpen { get; protected set; }

        public bool IsDisposed { get; protected set; }

        internal EndianIO(){}

        public EndianIO(string FileLocation, EndianTypes EndianType, FileMode Mode = FileMode.Open, FileAccess Access = FileAccess.ReadWrite, FileShare Share = FileShare.Read) : this(new FileStream(FileLocation, Mode, Access, Share), EndianType)
        {
            this.FileLocation = FileLocation;
        }

        public EndianIO(Stream Stream, EndianTypes EndianType)
        {
            if (!Stream.CanSeek) throw new Exception("EndianIO: Invalid stream specified. It doesn't support seeking.");
            if (Stream.CanRead) rdr = new EndianReader(Stream, EndianType);
            if (Stream.CanWrite) wtr = new EndianWriter(Stream, EndianType);
            this.EndianType = EndianType;
            this.Stream = Stream;
            IsOpen = true;
        }

        public EndianIO(byte[] ByteArray, EndianTypes EndianType) : this(new MemoryStream(ByteArray), EndianType){}

        #endregion

        #region Methods

        public virtual void SetPosition(long Position) { SetPosition(Position, SeekOrigin.Begin); }

        public virtual void SetPosition(long Position, SeekOrigin Origin) { Stream.Seek(Position, Origin); }

        //NOTE: Sets stream position to the very end.
        public virtual byte[] ToArray() { return XtraFunctions.ReadAllBytes(Stream); }

        public override string ToString() { return !IsOpen || IsDisposed ? "(Closed/Disposed)" : Path.GetFileName(FileLocation); }

        public virtual void Close()
        {
            if (!IsOpen) return;
            if (Stream != null) Stream.Close();
            if (rdr != null) rdr.Close();
            if (wtr != null) wtr.Close();
            IsOpen = false;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed || !disposing) return;
            if (Stream != null) Stream.Dispose();
            if (rdr != null) rdr.Dispose();
            if (wtr != null) wtr.Dispose();
            Stream = null;
            Reader = null;
            Writer = null;
            FileLocation = null;
            IsOpen = false;
            IsDisposed = true;
        }

        ~EndianIO() { Dispose(false); }

        #endregion
    }

    #endregion

    #region EndianReader

    public class EndianReader : BinaryReader
    {
        #region Fields, Properties, and Constructors

        private EndianTypes et;

        public EndianTypes EndianType
        {
            get { return et; }
            set
            {
                if (!Enum.IsDefined(typeof(EndianTypes), value)) throw new Exception("EndianReader.EndianType: Invalid endian type specified.");
                et = value;
            }
        }

        public EndianReader(Stream Input, EndianTypes EndianType) : base(Input) { this.EndianType = EndianType; }

        #endregion

        #region Methods

        public virtual byte[] ReadBytes(int Count, EndianTypes EndianType)
        {
            var data = base.ReadBytes(Count);
            if (EndianType == EndianTypes.BigEndian) Array.Reverse(data);
            return data;
        }

        public override char[] ReadChars(int Count) { return ReadChars(Count, EndianType); }

        public virtual char[] ReadChars(int Count, EndianTypes EndianType)
        {
            var chars = base.ReadChars(Count);
            if (EndianType == EndianTypes.BigEndian) Array.Reverse(chars);
            return chars;
        }

        public override short ReadInt16() { return ReadInt16(EndianType); }

        public virtual short ReadInt16(EndianTypes EndianType) { return BitConverter.ToInt16(ReadBytes(2, EndianType), 0); }

        public override ushort ReadUInt16() { return ReadUInt16(EndianType); }

        public virtual ushort ReadUInt16(EndianTypes EndianType) { return BitConverter.ToUInt16(ReadBytes(2, EndianType), 0); }

        public virtual uint ReadUInt24() { return ReadUInt24(EndianType); }

        public virtual uint ReadUInt24(EndianTypes EndianType)
        {
            var array = ReadBytes(3, EndianType);
            return ((uint)(array[2] << 16) | (uint)(array[1] << 8) | (uint)array[0]);
        }

        public override int ReadInt32() { return ReadInt32(EndianType); }

        public virtual int ReadInt32(EndianTypes EndianType) { return BitConverter.ToInt32(ReadBytes(4, EndianType), 0); }

        public override uint ReadUInt32() { return ReadUInt32(EndianType); }

        public virtual uint ReadUInt32(EndianTypes EndianType) { return BitConverter.ToUInt32(ReadBytes(4, EndianType), 0); }

        public virtual ulong ReadUInt40() { return ReadUInt40(EndianType); }

        public virtual ulong ReadUInt40(EndianTypes EndianType)
        {
            var array = ReadBytes(5, EndianType);
            return ((ulong)array[4] << 32 | (ulong)array[3] << 24 | (ulong)array[2] << 16 | (ulong)array[1] << 8 | (ulong)array[0]);
        }

        public virtual ulong ReadUInt48() { return ReadUInt48(EndianType); }

        public virtual ulong ReadUInt48(EndianTypes EndianType)
        {
            var array = ReadBytes(6, EndianType);
            return ((ulong)array[5] << 40 | (ulong)array[4] << 32 | (ulong)array[3] << 24 | (ulong)array[2] << 16 | (ulong)array[1] << 8 | (ulong)array[0]);
        }

        public virtual ulong ReadUInt56() { return ReadUInt56(EndianType); }

        public virtual ulong ReadUInt56(EndianTypes EndianType)
        {
            var array = ReadBytes(7, EndianType);
            return ((ulong)array[6] << 48 | (ulong)array[5] << 40 | (ulong)array[4] << 32 | (ulong)array[3] << 24 | (ulong)array[2] << 16 | (ulong)array[1] << 8 | (ulong)array[0]);
        }

        public override long ReadInt64() { return ReadInt64(EndianType); }

        public virtual long ReadInt64(EndianTypes EndianType) { return BitConverter.ToInt64(ReadBytes(8, EndianType), 0); }

        public override ulong ReadUInt64() { return ReadUInt64(EndianType); }

        public virtual ulong ReadUInt64(EndianTypes EndianType) { return BitConverter.ToUInt64(ReadBytes(8, EndianType), 0); }

        public override double ReadDouble() { return ReadDouble(EndianType); }

        public virtual double ReadDouble(EndianTypes EndianType) { return BitConverter.ToDouble(ReadBytes(8, EndianType), 0); }

        public override float ReadSingle() { return ReadSingle(EndianType); }

        public virtual float ReadSingle(EndianTypes EndianType) { return BitConverter.ToSingle(ReadBytes(4, EndianType), 0); }

        /// <summary>
        /// Reads a string from the underlying stream in the specified encoding.
        /// </summary>
        /// <param name="Length">The length of the string. If ReadUntilNull is true, the reader will stop reading until it reaches Length or a null character; whichever comes first. If ReadUntilNull is true and the reader stops reading before it reaches Length, the position of the reader will automatically be adjusted. Enter -1 if you do not know the length.</param>
        /// <param name="Encoding">The encoding to interpret the bytes in. ASCII or Unicode should be used as your standards.</param>
        /// <param name="ReadUntilNull">Determines whether the reader should stop reading once it reaches a null character. Length should be considered "MaxLength" if you set this parameter to true.</param>
        public virtual string ReadString(int Length, Encoding Encoding, bool ReadUntilNull = false)
        {
            /* 10/13 internal test cases:
            1. Start to EOF - Pass!
            2. Start to EOF - 1 - Pass
            3. Start to EOF with null - Pass
            4. Start to EOF - 1 with null - Pass
            5. Start to past EOF
            6. Start to EOF with null - Fail, we can't properly account for this because it never checks the last byte in the stream.
            */

            //This may be a little slow and inefficient, but the ease-of-use makes up for it.

            if (Length == 0) return null;
            var lengthCancel = Length <= -1;
            if (ReadUntilNull)
            {
                var sb = new StringBuilder();
                if (Encoding.IsSingleByte)
                {
                    var value = ReadBytes(1, EndianTypes.LittleEndian);
                    var end = value.Length == 0;
                    while ((lengthCancel || Length > 0) && !end && value[0] != 0)
                    {
                        sb.Append(Encoding.GetString(value));
                        value = ReadBytes(1, EndianTypes.LittleEndian);
                        end = value.Length == 0;
                        Length--;
                    }
                    if (Length == 0 && !end) BaseStream.Position -= 1;
                    else BaseStream.Position += end ? 0 : Length - 1; //-1 because we are already +1 into the advance, which turned out to be an empty byte.
                    return sb.ToString();
                }
                else
                {
                    var value = ReadBytes(2, EndianTypes.LittleEndian);
                    var end = value.Length == 0;
                    while ((lengthCancel || Length > 0) && !end && (value[0] != 0 || value[1] != 0))
                    {
                        sb.Append(Encoding.GetString(value));
                        value = ReadBytes(2, EndianTypes.LittleEndian);
                        end = value.Length == 0;
                        Length--;
                    }
                    if (Length == 0 && !end) BaseStream.Position -= 2;
                    else BaseStream.Position += end ? 0 : (Length * 2) - 2; //-2 because we are already +2 into the advance, which turned out to be empty bytes.
                    return sb.ToString();
                }
            }
            return Encoding.GetString(ReadBytes(Encoding.IsSingleByte ? Length : Length * 2, EndianTypes.LittleEndian));
        }

        public virtual Image ReadImage(int Size)
        {
            using (var stream = new MemoryStream(ReadBytes(Size, EndianTypes.LittleEndian)))
            {
                return Image.FromStream(stream);
            }
        }

        #endregion
    }

    #endregion

    #region EndianWriter

    public class EndianWriter : BinaryWriter
    {
        #region Fields and Constructors

        private EndianTypes et;

        public EndianTypes EndianType
        {
            get { return et; }
            set
            {
                if (!Enum.IsDefined(typeof(EndianTypes), value)) throw new Exception("EndianWriter.EndianType: Invalid endian type specified.");
                et = value;
            }
        }

        public EndianWriter(Stream Input, EndianTypes EndianType) : base(Input) { this.EndianType = EndianType; }

        #endregion

        #region Methods

        public virtual void Write(byte[] Data, EndianTypes EndianType)
        {
            if (EndianType == EndianTypes.BigEndian) Array.Reverse(Data);
            base.Write(Data);
        }

        public override void Write(char[] Data) { Write(Data, EndianType); }

        public virtual void Write(char[] Data, EndianTypes EndianType)
        {
            if (EndianType == EndianTypes.BigEndian) Array.Reverse(Data);
            base.Write(Data);
        }

        public override void Write(short Value) { Write(Value, EndianType); }

        public virtual void Write(short Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        public override void Write(ushort Value) { Write(Value, EndianType); }

        public virtual void Write(ushort Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        public virtual void WriteUInt24(uint Value) { WriteUInt24(Value, EndianType); }

        public virtual void WriteUInt24(uint Value, EndianTypes EndianType)
        {
            if (Value > 0xFFFFFF) throw new Exception("EndianWriter.WriteUInt24: Invalid value specified. It is too large for a uint24.");
            var buffer = BitConverter.GetBytes(Value);
            Array.Resize(ref buffer, 3);
            Write(buffer, EndianType);
        }

        public override void Write(int Value) { Write(Value, EndianType); }

        public virtual void Write(int Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        public override void Write(uint Value) { Write(Value, EndianType); }

        public virtual void Write(uint Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        public virtual void WriteUInt40(ulong Value) { WriteUInt40(Value, EndianType); }

        public virtual void WriteUInt40(ulong Value, EndianTypes EndianType)
        {
            if (Value > 0xFFFFFFFFFF) throw new Exception("EndianWriter.WriteUInt40: Invalid value specified. It is too large for a uint40.");
            var buffer = BitConverter.GetBytes(Value);
            Array.Resize(ref buffer, 5);
            Write(buffer, EndianType);
        }

        public virtual void WriteUInt48(ulong Value) { WriteUInt48(Value, EndianType); }

        public virtual void WriteUInt48(ulong Value, EndianTypes EndianType)
        {
            if (Value > 0xFFFFFFFFFFFF) throw new Exception("EndianWriter.WriteUInt48: Invalid value specified. It is too large for a uint48.");
            var buffer = BitConverter.GetBytes(Value);
            Array.Resize(ref buffer, 6);
            Write(buffer, EndianType);
        }

        public virtual void WriteUInt56(ulong Value) { WriteUInt56(Value, EndianType); }

        public virtual void WriteUInt56(ulong Value, EndianTypes EndianType)
        {
            if (Value > 0xFFFFFFFFFFFFFF) throw new Exception("EndianWriter.WriteUInt56: Invalid value specified. It is too large for a uint56.");
            var buffer = BitConverter.GetBytes(Value);
            Array.Resize(ref buffer, 7);
            Write(buffer, EndianType);
        }

        public override void Write(long Value) { Write(Value, EndianType); }

        public virtual void Write(long Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        public override void Write(ulong Value) { Write(Value, EndianType); }

        public virtual void Write(ulong Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        public override void Write(double Value) { Write(Value, EndianType); }

        public virtual void Write(double Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        public override void Write(float Value) { Write(Value, EndianType); }

        public virtual void Write(float Value, EndianTypes EndianType) { Write(BitConverter.GetBytes(Value), EndianType); }

        /// <summary>
        /// Writes a string to the current stream in the specified encoding, and advances the current position of the stream in accordance with the encoding used and the specific characters being written to the stream.
        /// </summary>
        /// <param name="Value">The string to write.</param>
        /// <param name="Encoding">The encoding to interpret the string in. ASCII or Unicode should be used as your standards.</param>
        /// <param name="Padding">If the string you specify has a max length and you don't meet it, you can specify the amount of null characters to write after the string has been written. Note that the amount of bytes actually written differs by the encoding used. (ex: 1=1byte for ASCII, 1=2bytes for unicode)</param>
        public void Write(string Value, Encoding Encoding, int Padding = 0)
        {
            Write(Encoding.GetBytes(Value), EndianTypes.LittleEndian);
            if (Padding > 0) Write(new byte[Encoding.IsSingleByte ? Padding : Padding * 2], EndianTypes.LittleEndian);
        }

        public virtual void Write(Image Image)
        {
            using (var ms = new MemoryStream())
            {
                Image.Save(ms, Image.RawFormat);
                ms.Flush();
                Write(ms.ToArray(), EndianTypes.LittleEndian);
            }
        }

        #endregion
    }

    #endregion
}