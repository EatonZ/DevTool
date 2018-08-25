// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XDevkit;

namespace DevTool.Classes
{
    public sealed class NeighborhoodDrives
    {
        #region Fields and Constructors

        private readonly XboxConsole console;
        private readonly EndianIO xms;
        private readonly uint dtAddress;
        private readonly uint mptAddress;
        private readonly uint[] xbdmRange;
        private static readonly List<char> allowedDriveNameChars = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '5', '6', '7', '8', '9' };

        public bool HaveBeenRead { get; private set; }

        public List<DriveNameConversionTableEntry> Drives { get; set; }

        public NeighborhoodDrives(XboxConsole Console, EndianIO XMS, uint NopAddress, uint DriveTableAddress, uint MountedPackageTableAddress, uint[] XBDMRange)
        {
            if (XBDMRange.Length != 2 || XBDMRange[0] == 0 || XBDMRange[1] == 0) throw new Exception("NeighborhoodDrives: Invalid XBDM range specified.");
            console = Console;
            xms = XMS;
            dtAddress = DriveTableAddress;
            mptAddress = MountedPackageTableAddress;
            xbdmRange = XBDMRange;
            if (NopAddress != 0)
            {
                xms.SetPosition(NopAddress);
                xms.Writer.Write(0x60000000);
            }
        }

        #endregion

        #region Format Classes

        public class DriveNameConversionTableEntry
        {
            #region Fields and Properties

            private string loc;
            private string neighborhoodName;

            public uint NeighborhoodLocationPointer { get; set; }

            public string NeighborhoodLocation
            {
                get { return loc; }
                set
                {
                    if (!IsValidDriveLocation(value)) throw new Exception("DriveNameConversionTableEntry.NeighborhoodLocation: Invalid Neighborhood location specified. It is not a proper device path.");
                    loc = value;
                }
            }

            public string NeighborhoodName
            {
                get { return neighborhoodName; }
                set
                {
                    if (!IsValidDriveName(value)) throw new Exception("DriveNameConversionTableEntry.NeighborhoodName: Invalid Neighborhood name specified. It must be composed of 35 characters or less. A-Z, 0-9.");
                    neighborhoodName = value;
                }
            }

            public bool IsBrowsable { get; set; }

            public bool IsValid { get { return NeighborhoodLocationPointer != 0; } }

            #endregion

            #region Methods

            internal void Read(EndianReader Reader, out int NeighborhoodLocationLength)
            {
                NeighborhoodLocationPointer = Reader.ReadUInt32();
                NeighborhoodLocationLength = Reader.ReadInt32();
                neighborhoodName = Reader.ReadString(35, Encoding.ASCII, true);
                IsBrowsable = Reader.ReadBoolean();
            }

            internal void Write(EndianWriter Writer)
            {
                Writer.Write(NeighborhoodLocationPointer);
                Writer.Write(NeighborhoodLocation.Length);
                Writer.Write(neighborhoodName, Encoding.ASCII, 35 - neighborhoodName.Length);
                Writer.Write(IsBrowsable);
            }

            public override string ToString() { return string.Format("{0} {1}: {2}", (IsBrowsable ? "(Browsable)" : "(Not Browsable)"), neighborhoodName, NeighborhoodLocation); }

            #endregion
        }

        #endregion

        #region Methods

        //Some characters will break the drive listing. Not 100% sure of all the characters that do, but let's just make it basic for now.
        public static bool IsValidDriveName(string DriveName) { return !string.IsNullOrWhiteSpace(DriveName) && DriveName.Length <= 35 && DriveName.All(character => allowedDriveNameChars.Contains(char.ToUpper(character))); }

        public static bool IsValidDriveLocation(string DriveLocation) { return !string.IsNullOrWhiteSpace(DriveLocation) && DriveLocation.StartsWith("\\", StringComparison.Ordinal); }

        public Dictionary<string, string> GetMountedPackageDeviceNames()
        {
            if (!HaveBeenRead) throw new Exception("NeighborhoodDrives.GetMountedPackageDeviceNames: The Neighborhood drives have not been read.");
            var packages = new Dictionary<string, string>();
            xms.SetPosition(mptAddress);
            var nextAddr = xms.Reader.ReadUInt32();
            //The first uint in the structure is a pointer to the next one. If it is the same as the original pointer, then we have reached the end of the mounted package list.
            while (nextAddr != mptAddress)
            {
                xms.SetPosition(nextAddr + 0x9758);
                var deviceName = xms.Reader.ReadString(0x40, Encoding.ASCII, true);
                xms.SetPosition(-0x9357, SeekOrigin.Current);
                var packageName = xms.Reader.ReadString(35, Encoding.BigEndianUnicode, true);
                packages.Add(packageName, deviceName);
                xms.SetPosition(nextAddr);
                nextAddr = xms.Reader.ReadUInt32();
            }
            return packages;
        }

        public void Read()
        {
            if (HaveBeenRead) throw new Exception("NeighborhoodDrives.Read: The Neighborhood drives have already been read.");
            xms.SetPosition(dtAddress);
            //Map the structs into a local buffer. Reading from the console over sockets can be slow.
            using (var bufferedReader = new EndianReader(new MemoryStream(xms.Reader.ReadBytes(0x764)), EndianTypes.BigEndian))
            {
                Drives = new List<DriveNameConversionTableEntry>();
                //Limit is really 42, the last slot is used to mark the end of the listing.
                for (var i = 0; i < 43; i++)
                {
                    bufferedReader.BaseStream.Position = i * 0x2C;
                    var drive = new DriveNameConversionTableEntry();
                    int nllen;
                    drive.Read(bufferedReader, out nllen);
                    if (!drive.IsValid) break; //End of drives.
                    xms.SetPosition(drive.NeighborhoodLocationPointer);
                    drive.NeighborhoodLocation = xms.Reader.ReadString(nllen, Encoding.ASCII);
                    Drives.Add(drive);
                }
            }
            HaveBeenRead = true;
        }

        public void Write()
        {
            if (!HaveBeenRead) throw new Exception("NeighborhoodDrives.Write: The Neighborhood drives have not been read.");
            if (Drives.Count > 42) throw new Exception("NeighborhoodDrives.Write: There are too many drives in the list. The limit is 42.");
            var buffer = new byte[0x764];
            using (var bufferedWriter = new EndianWriter(new MemoryStream(buffer), EndianTypes.BigEndian))
            {
                Drives.ForEach(drive =>
                {
                    //Set up the mount path first.
                    //Check if the path is located within XBDM still. If the ptr is 0, we are forcing new allocation.
                    if (drive.NeighborhoodLocationPointer == 0 || drive.NeighborhoodLocationPointer > xbdmRange[0] && drive.NeighborhoodLocationPointer < xbdmRange[1])
                    {
                        //The path is in XBDM. We want to relocate it.
                        drive.NeighborhoodLocationPointer = XDKUtilities.XamAlloc(console, 0x14100000, (uint)drive.NeighborhoodLocation.Length + 1);
                    }
                    else
                    {
                        //The path is in allocated memory. Free the old memory and make a new spot.
                        XDKUtilities.XamFree(console, drive.NeighborhoodLocationPointer);
                        drive.NeighborhoodLocationPointer = XDKUtilities.XamAlloc(console, 0x14100000, (uint)drive.NeighborhoodLocation.Length + 1);
                    }
                    drive.Write(bufferedWriter);
                    xms.SetPosition(drive.NeighborhoodLocationPointer);
                    xms.Writer.Write(drive.NeighborhoodLocation, Encoding.ASCII, 1);
                });
                bufferedWriter.Flush();
            }
            xms.SetPosition(dtAddress);
            xms.Writer.Write(buffer);
        }

        #endregion
    }
}