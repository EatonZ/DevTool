// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Test.Xbox.XDRPC;
using Microsoft.Test.Xbox.Profiles;
using XDevkit;

namespace DevTool.Classes
{
    public static class XDKUtilities
    {
        #region XBDM

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct DM_VERSION_INFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            private byte[] data;

            public ushort QFE
            {
                get { return BitConverterEx.GetUInt16(data, 6, EndianTypes.BigEndian); }
                set
                {
                    if (data == null) data = new byte[8];
                    BitConverterEx.SetUInt16(data, 6, value, EndianTypes.BigEndian);
                }
            }

            public Version Version
            {
                get { return new Version(BitConverterEx.GetInt16(data, 0, EndianTypes.BigEndian), BitConverterEx.GetInt16(data, 2, EndianTypes.BigEndian), BitConverterEx.GetInt16(data, 4, EndianTypes.BigEndian), 0); }
                set
                {
                    if (data == null) data = new byte[8];
                    BitConverterEx.SetUInt16(data, 0, (ushort)value.Major, EndianTypes.BigEndian);
                    BitConverterEx.SetUInt16(data, 2, (ushort)value.Minor, EndianTypes.BigEndian);
                    BitConverterEx.SetUInt16(data, 4, (ushort)value.Build, EndianTypes.BigEndian);
                }
            }

            public override string ToString() { return "v" + Version.Build; }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct DM_SYSTEM_INFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private byte[] data;

            //NOTE: ALWAYS set to 0x32 (20) before using!
            public int SizeOfStruct
            {
                get { return BitConverterEx.GetInt32(data, 0, EndianTypes.BigEndian); }
                set
                {
                    if (data == null) data = new byte[4];
                    BitConverterEx.SetInt32(data, 0, value, EndianTypes.BigEndian);
                }
            }

            public DM_VERSION_INFO BaseKernelVersion { get; set; }

            public DM_VERSION_INFO KernelVersion { get; set; }

            public DM_VERSION_INFO XDKVersion { get; set; }

            public DM_SYSTEM_INFO_FLAGS Flags { get; set; }

            public override string ToString() { return string.Format("{0}, Flash: {1}, XDK: {2}", Flags, KernelVersion, XDKVersion); }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct DM_SYSTEM_INFO_FLAGS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private byte[] data;

            public bool IsHDDEnabled { get { return (BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian) & 0x00000020) == 0x00000020; } }

            public bool IsTestKit { get { return (BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian) & 0x02000000) == 0x02000000; } }

            public SystemRevisions Revision { get { return (SystemRevisions)(BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian) & 0xF0000000); } }

            public ProcessorRevisions Processor { get { return (ProcessorRevisions)(BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian) & 3); } }

            public override string ToString() { return string.Format("Rev: {0}, CPU: {1}", Revision, Processor); }
        }

        public enum SystemRevisions : uint
        {
            Xenon = 0x00000000,
            Zephyr = 0x10000000,
            Falcon = 0x20000000,
            Jasper = 0x30000000,
            Trinity = 0x40000000,
            Corona = 0x50000000,
            Winchester = 0x60000000
        }

        public enum ProcessorRevisions : uint
        {
            Alpha = 0,
            Mongrel = 1,
            Shiva = 2,
            Waternoose = 3
        }

        public static DM_SYSTEM_INFO DmGetSystemInfo(XboxConsole Console)
        {
            var pdmGetSystemInfo = new XDRPCStructArgumentInfo<DM_SYSTEM_INFO>(new DM_SYSTEM_INFO { SizeOfStruct = 0x20 }, ArgumentType.ByRef);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xbdm.xex", 161, pdmGetSystemInfo);
            if (returnVal != 0x02DA0000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return pdmGetSystemInfo.Value;
        }

        public enum ConsoleTypes
        {
            Development_Kit = 0,
            Test_Kit = 1,
            Reviewer_Kit = 2
        }

        public static ConsoleTypes DmGetConsoleType(XboxConsole Console)
        {
            var pdwConsoleType = new XDRPCArgumentInfo<uint>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xbdm.xex", 140, pdwConsoleType);
            if (returnVal != 0x02DA0000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return (ConsoleTypes)pdwConsoleType.Value;
        }

        [Flags]
        public enum ConsoleFeatures : uint
        {
            None = 0,
            Debugging = 1,
            Secondary_NIC = 2,
            GB_Ram = 4
        }

        public static ConsoleFeatures DmGetConsoleFeatures(XboxConsole Console)
        {
            var pdwConsoleFeatures = new XDRPCArgumentInfo<uint>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xbdm.xex", 220, pdwConsoleFeatures);
            if (returnVal != 0x02DA0000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return (ConsoleFeatures)pdwConsoleFeatures.Value;
        }

        #endregion

        #region XAM

        public enum XNotifyUITypes : uint
        {
            XNOTIFYUI_TYPE_FRIENDONLINE = 0,
            XNOTIFYUI_TYPE_GAMEINVITE = 1,
            XNOTIFYUI_TYPE_FRIENDREQUEST = 2,
            XNOTIFYUI_TYPE_GENERIC = 3,
            XNOTIFYUI_TYPE_MULTIPENDING = 4,
            XNOTIFYUI_TYPE_PERSONALMESSAGE = 5,
            XNOTIFYUI_TYPE_SIGNEDOUT = 6,
            XNOTIFYUI_TYPE_SIGNEDIN = 7,
            XNOTIFYUI_TYPE_SIGNEDINLIVE = 8,
            XNOTIFYUI_TYPE_SIGNEDINNEEDPASS = 9,
            XNOTIFYUI_TYPE_CHATREQUEST = 10,
            XNOTIFYUI_TYPE_CONNECTIONLOST = 11,
            XNOTIFYUI_TYPE_DOWNLOADCOMPLETE = 12,
            XNOTIFYUI_TYPE_SONGPLAYING = 13,
            XNOTIFYUI_TYPE_PREFERRED_REVIEW = 14,
            XNOTIFYUI_TYPE_AVOID_REVIEW = 15,
            XNOTIFYUI_TYPE_COMPLAINT = 16,
            XNOTIFYUI_TYPE_CHATCALLBACK = 17,
            XNOTIFYUI_TYPE_REMOVEDMU = 18,
            XNOTIFYUI_TYPE_REMOVEDGAMEPAD = 19,
            XNOTIFYUI_TYPE_CHATJOIN = 20,
            XNOTIFYUI_TYPE_CHATLEAVE = 21,
            XNOTIFYUI_TYPE_GAMEINVITESENT = 22,
            XNOTIFYUI_TYPE_CANCELPERSISTENT = 23,
            XNOTIFYUI_TYPE_CHATCALLBACKSENT = 24,
            XNOTIFYUI_TYPE_MULTIFRIENDONLINE = 25,
            XNOTIFYUI_TYPE_ONEFRIENDONLINE = 26,
            XNOTIFYUI_TYPE_ACHIEVEMENT = 27,
            XNOTIFYUI_TYPE_HYBRIDDISC = 28,
            XNOTIFYUI_TYPE_MAILBOX = 29,
            XNOTIFYUI_TYPE_VIDEOCHATINVITE = 30,
            XNOTIFYUI_TYPE_DOWNLOADCOMPLETEDREADYTOPLAY = 31,
            XNOTIFYUI_TYPE_CANNOTDOWNLOAD = 32,
            XNOTIFYUI_TYPE_DOWNLOADSTOPPED = 33,
            XNOTIFYUI_TYPE_CONSOLEMESSAGE = 34,
            XNOTIFYUI_TYPE_GAMEMESSAGE = 35,
            XNOTIFYUI_TYPE_DEVICEFULL = 36,
            XNOTIFYUI_TYPE_CHATMESSAGE = 38,
            XNOTIFYUI_TYPE_MULTIACHIEVEMENTS = 39,
            XNOTIFYUI_TYPE_NUDGE = 40,
            XNOTIFYUI_TYPE_MESSENGERCONNECTIONLOST = 41,
            XNOTIFYUI_TYPE_MESSENGERSIGNINFAILED = 43,
            XNOTIFYUI_TYPE_MESSENGERCONVERSATIONMISSED = 44,
            XNOTIFYUI_TYPE_FAMILYTIMERREMAINING = 45,
            XNOTIFYUI_TYPE_CONNECTIONLOSTRECONNECT = 46,
            XNOTIFYUI_TYPE_EXCESSIVEPLAYTIME = 47,
            XNOTIFYUI_TYPE_PARTYJOINREQUEST = 49,
            XNOTIFYUI_TYPE_PARTYINVITESENT = 50,
            XNOTIFYUI_TYPE_PARTYGAMEINVITESENT = 51,
            XNOTIFYUI_TYPE_PARTYKICKED = 52,
            XNOTIFYUI_TYPE_PARTYDISCONNECTED = 53,
            XNOTIFYUI_TYPE_PARTYCANNOTCONNECT = 56,
            XNOTIFYUI_TYPE_PARTYSOMEONEJOINED = 57,
            XNOTIFYUI_TYPE_PARTYSOMEONELEFT = 58,
            XNOTIFYUI_TYPE_GAMERPICTUREUNLOCKED = 59,
            XNOTIFYUI_TYPE_AVATARAWARDUNLOCKED = 60,
            XNOTIFYUI_TYPE_PARTYJOINED = 61,
            XNOTIFYUI_TYPE_REMOVEDUSB = 62,
            XNOTIFYUI_TYPE_PLAYERMUTED = 63,
            XNOTIFYUI_TYPE_PLAYERUNMUTED = 64,
            XNOTIFYUI_TYPE_CHATMESSAGE2 = 65,
            XNOTIFYUI_TYPE_KINECTCONNECTED = 66,
            XNOTIFYUI_TYPE_KINECTBREAK = 67,
            XNOTIFYUI_TYPE_ETHERNET = 68,
            XNOTIFYUI_TYPE_KINECTPLAYERRECOGNIZED = 69,
            XNOTIFYUI_TYPE_CONSOLESHUTTINGDOWNSOONALERT = 70,
            XNOTIFYUI_TYPE_PROFILESIGNEDINELSEWHERE = 71,
            XNOTIFYUI_TYPE_LASTSIGNINELSEWHERE = 73,
            XNOTIFYUI_TYPE_KINECTDEVICEUNSUPPORTED = 74,
            XNOTIFYUI_TYPE_WIRELESSDEVICETURNOFF = 75,
            XNOTIFYUI_TYPE_UPDATING = 76,
            XNOTIFYUI_TYPE_SMARTGLASSAVAILABLE = 77
        }

        public enum XNotifyUIPriorities
        {
            XNOTIFYUI_PRIORITY_LOW = 0,
            XNOTIFYUI_PRIORITY_DEFAULT = 1,
            XNOTIFYUI_PRIORITY_HIGH = 2,
            XNOTIFYUI_PRIORITY_PERSISTENT = 3
        }

        public static void XNotifyQueueUI(XboxConsole Console, uint XUserIndex, XNotifyUITypes XNotifyUIType, XNotifyUIPriorities XNotifyUIPriority, string XNotifyMessage)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XNotifyQueueUI: Invalid user index specified. It must be less than or equal to 3.");
            if (!Enum.IsDefined(typeof(XNotifyUITypes), XNotifyUIType)) throw new Exception("XDKUtilities.XNotifyQueueUI: Invalid notification type specified.");
            if (!Enum.IsDefined(typeof(XNotifyUIPriorities), XNotifyUIPriority)) throw new Exception("XDKUtilities.XNotifyQueueUI: Invalid notification priority specified.");
            var dwType = new XDRPCArgumentInfo<uint>((uint)XNotifyUIType);
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var dwPriority = new XDRPCArgumentInfo<uint>((uint)XNotifyUIPriority);
            var pwszStringParam = new XDRPCStringArgumentInfo(XNotifyMessage, Encoding.BigEndianUnicode);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 656, dwType, dwUserIndex, dwPriority, pwszStringParam);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static string XamGetCachedTitleName(XboxConsole Console, uint TitleID)
        {
            if (TitleID == 0) return string.Empty;
            var dwTitleId = new XDRPCArgumentInfo<uint>(TitleID);
            var pwsz = new XDRPCArrayArgumentInfo<byte[]>(new byte[56], ArgumentType.Out, 56);
            var pcch = new XDRPCArgumentInfo<int>(56, ArgumentType.ByRef);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 694, dwTitleId, pwsz, pcch);
            if (returnVal == 0x3E5) return string.Empty;
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return Encoding.BigEndianUnicode.GetString(pwsz.Value).Replace("\0", string.Empty);
        }

        public static void XamShowFriendRequestUI(XboxConsole Console, uint XUserIndex, ulong FriendXUID = 0)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowFriendRequestUI: Invalid user index specified. It must be less than or equal to 3.");
            if (FriendXUID != 0 && !XUID.IsOnlineXUID(FriendXUID) && !XUID.IsTeamXUID(FriendXUID)) throw new Exception("XDKUtilities.XamShowFriendRequestUI: Invalid friend online/team XUID specified.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var xuidUser = new XDRPCArgumentInfo<ulong>(FriendXUID);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 718, dwUserIndex, xuidUser);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowMessageComposeUI(XboxConsole Console, uint XUserIndex, ulong[] Recipients = null, string MessageText = "")
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowMessageComposeUI: Invalid user index specified.");
            if (Recipients != null)
            {
                if (Recipients.Length > 64) throw new Exception("XDKUtilities.XamShowMessageComposeUI: Too many recipients specified. The maximum is 64.");
                if (Recipients.Any(recipient => !XUID.IsOnlineXUID(recipient) && !XUID.IsTeamXUID(recipient))) throw new Exception("XDKUtilities.XamShowMessageComposeUI: Invalid recipient online/team XUID specified.");
            }
            if (MessageText.Length > 255) throw new Exception("XDKUtilities.XamShowMessageComposeUI: Specified message text is invalid. It must be less than or equal to 255 characters in length.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var pXuidRecipients = Recipients == null || Recipients.Length == 0 ? new XDRPCNullArgumentInfo() : (XDRPCArgumentInfo)new XDRPCArrayArgumentInfo<ulong[]>(Recipients);
            var cRecipients = Recipients == null ? 0 : Recipients.Length;
            var pszText = string.IsNullOrWhiteSpace(MessageText) ? new XDRPCNullArgumentInfo() : (XDRPCArgumentInfo)new XDRPCStringArgumentInfo(MessageText, Encoding.BigEndianUnicode);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 716, dwUserIndex, pXuidRecipients, cRecipients, pszText);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowGameInviteUI(XboxConsole Console, uint XUserIndex, ulong[] Recipients = null)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowGameInviteUI: Invalid user index specified. It must be less than or equal to 3.");
            if (Recipients != null)
            {
                if (Recipients.Length > 64) throw new Exception("XDKUtilities.XamShowGameInviteUI: Too many recipients specified. The maximum is 64.");
                if (Recipients.Any(recipient => !XUID.IsOnlineXUID(recipient) && !XUID.IsTeamXUID(recipient))) throw new Exception("XDKUtilities.XamShowGameInviteUI: Invalid recipient online/team XUID specified.");
            }
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var pXuidRecipients = Recipients == null || Recipients.Length == 0 ? new XDRPCNullArgumentInfo() : (XDRPCArgumentInfo)new XDRPCArrayArgumentInfo<ulong[]>(Recipients);
            var cRecipients = Recipients == null ? 0 : Recipients.Length;
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 717, dwUserIndex, pXuidRecipients, cRecipients);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowPartyUI(XboxConsole Console, uint XUserIndex)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowPartyUI: Invalid user index specified. It must be less than or equal to 3.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 773, dwUserIndex);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowMessagesUI(XboxConsole Console, uint XUserIndex)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowMessagesUI: Invalid user index specified. It must be less than or equal to 3.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 704, dwUserIndex);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowFriendsUI(XboxConsole Console, uint XUserIndex)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowFriendsUI: Invalid user index specified. It must be less than or equal to 3.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 703, dwUserIndex);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowPlayersUI(XboxConsole Console, uint XUserIndex)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowPlayersUI: Invalid user index specified. It must be less than or equal to 3.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 712, dwUserIndex);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowGamerCardUIForXUID(XboxConsole Console, uint XUserIndex, ulong GamerXUID)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowGamerCardUIForXUID: Invalid user index specified. It must be less than or equal to 3.");
            if (!XUID.IsOnlineXUID(GamerXUID) && !XUID.IsTeamXUID(GamerXUID)) throw new Exception("XDKUtilities.XamShowGamerCardUIForXUID: Invalid gamer online/team XUID specified.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var xuidPlayer = new XDRPCArgumentInfo<ulong>(GamerXUID);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 771, dwUserIndex, xuidPlayer);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        public static void XamShowFofUI(XboxConsole Console, uint XUserIndex, ulong FriendXUID, string Gamertag)
        {
            if (XUserIndex > 3) throw new Exception("XDKUtilities.XamShowFofUI: Invalid user index specified. It must be less than or equal to 3.");
            if (!XUID.IsOnlineXUID(FriendXUID) && !XUID.IsTeamXUID(FriendXUID)) throw new Exception("XDKUtilities.XamShowFofUI: Invalid friend online/team XUID specified.");
            if (Gamertag.Length > 15) throw new Exception("XDKUtilities.XamShowFofUI: Invalid Gamertag specified. It must be less than or equal to 16 characters in length.");
            var dwUserIndex = new XDRPCArgumentInfo<uint>(XUserIndex);
            var xuidFriend = new XDRPCArgumentInfo<ulong>(FriendXUID);
            var pszGamertag = new XDRPCStringArgumentInfo(Gamertag, Encoding.ASCII);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 1572, dwUserIndex, xuidFriend, pszGamertag);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XAMACCOUNTINFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x17C)]
            private byte[] data;

            public bool IsRecovering { get { return (BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian) & 0x40000000) == 0x40000000; } }

            public bool IsOnlineEnabled { get { return (BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian) & 0x20000000) == 0x20000000; } }

            public bool HasPasscode { get { return (BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian) & 0x10000000) == 0x10000000; } }

            public bool RequiresManagement { get { return (BitConverterEx.GetUInt32(data, 4, EndianTypes.BigEndian) & 1) == 1; } }

            public string Gamertag
            {
                get { return Encoding.BigEndianUnicode.GetString(data, 8, 15 * 2); }
                set
                {
                    if (value.Length > 15) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid Gamertag specified. It must be less than or equal to 15 characters in length.");
                    if (data == null) data = new byte[0x17C];
                    Buffer.BlockCopy(Encoding.BigEndianUnicode.GetBytes(value), 0, data, 8, 15 * 2);
                }
            }

            public ulong OnlineXUID
            {
                get { return BitConverterEx.GetUInt64(data, 0x28, EndianTypes.BigEndian); }
                set
                {
                    if (!XUID.IsOnlineXUID(value)) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid online XUID specified.");
                    if (data == null) data = new byte[0x17C];
                    BitConverterEx.SetUInt64(data, 0x28, value, EndianTypes.BigEndian);
                }
            }

            public byte NoShowRating { get { return (byte)(BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0x1C); } }

            public byte DisconnectRating { get { return (byte)(BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0xE0); } }

            public XboxLiveCountries Country { get { return (XboxLiveCountries)((BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0xFF00) >> 8); } }

            public bool IsVoiceAllowed { get { return (BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0x10000) == 0; } }

            public bool IsAllowedToPurchase { get { return (BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0x20000) == 0; } }

            public bool CanHaveNickname { get { return (BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0x40000) == 0; } }

            public bool CanAccessSharedContent { get { return (BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0x80000) == 0; } }

            public bool IsParentalControlled { get { return (BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0x1000000) == 0x1000000; } }

            public SubscriptionTiers Membership { get { return (SubscriptionTiers)((BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0xF00000) >> 20); } }

            public XboxLiveLanguages Language { get { return (XboxLiveLanguages)((BitConverterEx.GetUInt32(data, 0x30, EndianTypes.BigEndian) & 0x3E000000) >> 25); } }

            public XboxLiveServices Service
            {
                get { return (XboxLiveServices)BitConverterEx.GetUInt32(data, 0x34, EndianTypes.BigEndian); }
                set
                {
                    //Ignore enum verification here because there are other uncommon LIVE Environments not enumerated.
                    if (data == null) data = new byte[0x17C];
                    BitConverterEx.SetUInt32(data, 0x34, (uint)value, EndianTypes.BigEndian);
                }
            }

            public PasscodeButtons[] Passcode
            {
                get { return new[] { (PasscodeButtons)data[0x38], (PasscodeButtons)data[0x39], (PasscodeButtons)data[0x3A], (PasscodeButtons)data[0x3B] }; }
                set
                {
                    if (!Enum.IsDefined(typeof(PasscodeButtons), value[0]) || !Enum.IsDefined(typeof(PasscodeButtons), value[1]) || !Enum.IsDefined(typeof(PasscodeButtons), value[2]) || !Enum.IsDefined(typeof(PasscodeButtons), value[3])) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid passcode specified.");
                    if (data == null) data = new byte[0x17C];
                    data[0x38] = (byte)value[0];
                    data[0x39] = (byte)value[1];
                    data[0x3A] = (byte)value[2];
                    data[0x3B] = (byte)value[3];
                }
            }

            public string Domain
            {
                get { return Encoding.ASCII.GetString(data, 0x3C, 20); }
                set
                {
                    if (value.Length != 20) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid domain specified. It must be equal to 20 characters in length.");
                    if (data == null) data = new byte[0x17C];
                    Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 0x3C, 20);
                }
            }

            public string KerberosRealm
            {
                get { return Encoding.ASCII.GetString(data, 0x50, 24); }
                set
                {
                    if (value.Length != 24) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid Kerberos realm specified. It must be equal to 24 characters in length.");
                    if (data == null) data = new byte[0x17C];
                    Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 0x50, 24);
                }
            }

            public byte[] OnlineKey
            {
                get { return XtraFunctions.GetData(data, 0x68, 16); }
                set
                {
                    if (value.Length != 16) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid online key specified. It must be equal to 16 bytes in length.");
                    if (data == null) data = new byte[0x17C];
                    Buffer.BlockCopy(value, 0, data, 0x68, 16);
                }
            }

            public string UserPassportMembername
            {
                get { return Encoding.ASCII.GetString(data, 0x78, 114); }
                set
                {
                    if (value.Length != 114) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid user Passport member name specified. It must be equal to 114 characters in length.");
                    if (data == null) data = new byte[0x17C];
                    Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 0x78, 114);
                }
            }

            public string UserPassportPassword
            {
                get { return Encoding.ASCII.GetString(data, 0xEA, 32); }
                set
                {
                    if (value.Length != 32) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid user Passport password specified. It must be equal to 32 characters in length.");
                    if (data == null) data = new byte[0x17C];
                    Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 0xEA, 32);
                }
            }

            public string OwnerPassportMembername
            {
                get { return Encoding.ASCII.GetString(data, 0x10A, 114); }
                set
                {
                    if (value.Length != 114) throw new Exception("XDKUtilities.XAMACCOUNTINFO: Invalid owner Passport member name specified. It must be equal to 114 characters in length.");
                    if (data == null) data = new byte[0x17C];
                    Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 0x10A, 114);
                }
            }

            public override string ToString() { return Gamertag; }
        }

        public enum XboxLiveLanguages : byte
        {
            None = 0,
            English = 1,
            Japanese = 2,
            German = 3,
            French = 4,
            Spanish = 5,
            Italian = 6,
            Korean = 7,
            Chinese = 8,
            Portuguese = 9,
            Chinese2 = 10,
            Polish = 11,
            Russian = 12,
            Danish = 13,
            Finnish = 14,
            Norwegian = 15,
            Dutch = 16,
            Swedish = 17,
            Czech = 18,
            Greek = 19,
            Hungarian = 20
        }

        public enum XboxLiveCountries : byte
        {
            Unknown = 0,
            UnitedArabEmirates = 1,
            Albania = 2,
            Armenia = 3,
            Argentina = 4,
            Austria = 5,
            Australia = 6,
            Azerbaijan = 7,
            Belgium = 8,
            Bulgaria = 9,
            Bahrain = 10,
            BruneiDarussalam = 11,
            Bolivia = 12,
            Brazil = 13,
            Belarus = 14,
            Belize = 15,
            Canada = 16,
            Switzerland = 18,
            Chile = 19,
            China = 20,
            Colombia = 21,
            CostaRica = 22,
            CzechRepublic = 23,
            Germany = 24,
            Denmark = 25,
            DominicanRepublic = 26,
            Algeria = 27,
            Ecuador = 28,
            Estonia = 29,
            Egypt = 30,
            Spain = 31,
            Finland = 32,
            FaroeIslands = 33,
            France = 34,
            UnitedKingdom = 35,
            Georgia = 36,
            Greece = 37,
            Guatemala = 38,
            HongKong = 39,
            Honduras = 40,
            Croatia = 41,
            Hungary = 42,
            Indonesia = 43,
            Ireland = 44,
            Israel = 45,
            India = 46,
            Iraq = 47,
            Iran = 48,
            Iceland = 49,
            Italy = 50,
            Jamaica = 51,
            Jordan = 52,
            Japan = 53,
            Kenya = 54,
            Kyrgyzstan = 55,
            Korea = 56,
            Kuwait = 57,
            Kazakhstan = 58,
            Lebanon = 59,
            Liechtenstein = 60,
            Lithuania = 61,
            Luxembourg = 62,
            Latvia = 63,
            LibyanArabJamahiriya = 64,
            Morocco = 65,
            Monaco = 66,
            Macedonia = 67,
            Mongolia = 68,
            Macao = 69,
            Maldives = 70,
            Mexico = 71,
            Malaysia = 72,
            Nicaragua = 73,
            Netherlands = 74,
            Norway = 75,
            NewZealand = 76,
            Oman = 77,
            Panama = 78,
            Peru = 79,
            Philippines = 80,
            Pakistan = 81,
            Poland = 82,
            PuertoRico = 83,
            Portugal = 84,
            Paraguay = 85,
            Qatar = 86,
            Romania = 87,
            RussianFederation = 88,
            SaudiArabia = 89,
            Sweden = 90,
            Singapore = 91,
            Slovenia = 92,
            Slovakia = 93,
            ElSalvador = 95,
            SyrianArabRepublic = 96,
            Thailand = 97,
            Tunisia = 98,
            Turkey = 99,
            TrinidadAndTobago = 100,
            Taiwan = 101,
            Ukraine = 102,
            UnitedStates = 103,
            Uruguay = 104,
            Uzbekistan = 105,
            Venezuela = 106,
            Vietnam = 107,
            Yemen = 108,
            SouthAfrica = 109,
            Zimbabwe = 110,
        }

        public enum SubscriptionTiers : byte
        {
            None = 0,
            Silver = 3,
            Gold = 6,
            FamilyGold = 9,
        }

        public enum XboxLiveServices : uint
        {
            None = 0,
            ProductionNet = 0x50524F44,
            PartnerNet = 0x50415254
        }

        public enum PasscodeButtons : byte
        {
            None = 0x00,
            DpadUp = 0x01,
            DpadDown = 0x02,
            DpadLeft = 0x03,
            DpadRight = 0x04,
            X = 0x05,
            Y = 0x06,
            LeftTrigger = 0x09,
            RightTrigger = 0x0A,
            LeftBumper = 0x0B,
            RightBumper = 0x0C,
            Unknown = 0xFF
        }

        public static XAMACCOUNTINFO XamProfileFindAccount(XboxConsole Console, ulong OfflineXUID)
        {
            if (!XUID.IsOfflineXUID(OfflineXUID)) throw new Exception("XDKUtilities.XamProfileFindAccount: Invalid offline XUID specified.");
            var xuidOffline = new XDRPCArgumentInfo<ulong>(OfflineXUID);
            var pAccountInfo = new XDRPCStructArgumentInfo<XAMACCOUNTINFO>(new XAMACCOUNTINFO(), ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 565, xuidOffline, pAccountInfo);
            if (returnVal != 0x00000000) throw ProfilesExceptionFactory.CreateExceptionFromErrorCode(returnVal);
            return pAccountInfo.Value;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct ExecutionID
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x18)]
            private byte[] data;

            public uint MediaID
            {
                get { return BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian); }
                set
                {
                    if (data == null) data = new byte[0x18];
                    BitConverterEx.SetUInt32(data, 0, value, EndianTypes.BigEndian);
                }
            }

            public Version Version
            {
                get
                {
                    var version = BitConverterEx.GetInt32(data, 4, EndianTypes.BigEndian);
                    return new Version(version >> 28, (version >> 24) & 0xF, (version >> 8) & ushort.MaxValue, version & byte.MaxValue);
                }
            }

            public Version BaseVersion
            {
                get
                {
                    var baseVersion = BitConverterEx.GetInt32(data, 8, EndianTypes.BigEndian);
                    return new Version(baseVersion >> 28, (baseVersion >> 24) & 0xF, (baseVersion >> 8) & ushort.MaxValue, baseVersion & byte.MaxValue);
                }
            }

            public uint TitleID
            {
                get { return BitConverterEx.GetUInt32(data, 0xC, EndianTypes.BigEndian); }
                set
                {
                    if (data == null) data = new byte[0x18];
                    BitConverterEx.SetUInt32(data, 0xC, value, EndianTypes.BigEndian);
                }
            }

            public byte Platform
            {
                get { return data[0x10]; }
                set
                {
                    if (data == null) data = new byte[0x18];
                    data[0x10] = value;
                }
            }

            public byte ExecutableType
            {
                get { return data[0x11]; }
                set
                {
                    if (data == null) data = new byte[0x18];
                    data[0x11] = value;
                }
            }

            public byte DiscNum
            {
                get { return data[0x12]; }
                set
                {
                    if (data == null) data = new byte[0x18];
                    data[0x12] = value;
                }
            }

            public byte DiscsInSet
            {
                get { return data[0x13]; }
                set
                {
                    if (data == null) data = new byte[0x18];
                    data[0x13] = value;
                }
            }

            public uint SaveGameID
            {
                get { return BitConverterEx.GetUInt32(data, 0x14, EndianTypes.BigEndian); }
                set
                {
                    if (data == null) data = new byte[0x18];
                    BitConverterEx.SetUInt32(data, 0x14, value, EndianTypes.BigEndian);
                }
            }

            public override string ToString() { return string.Format("{0} - v{1}", XtraFunctions.ValueToHex(TitleID).Replace("0x", string.Empty), Version); }
        }

        public static ExecutionID XamGetExecutionId(XboxConsole Console)
        {
            var ppExecutionId = new XDRPCArgumentInfo<uint>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 640, ppExecutionId);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            if (ppExecutionId.Value == 0) throw new Exception("XDKUtilities.XamGetExecutionId: Invalid pointer returned.");
            //The above only gets the pointer in console memory to the Execution ID. We still have to grab it below.
            //Props to MS devs for making a really nice function to do this.
            using (var refr = new XDRPCReference(Console, ppExecutionId.Value, 24)) return refr.Get<ExecutionID>();
        }

        public static bool XTestOnlineIsConnectedToLive(XboxConsole Console) { return Console.ExecuteRPC<bool>(XDRPCMode.Title, "xam.xex", 1290); }

        public static uint XamAlloc(XboxConsole Console, uint Flags, uint Size)
        {
            var dwFlags = new XDRPCArgumentInfo<uint>(Flags);
            var cb = new XDRPCArgumentInfo<uint>(Size);
            var ppv = new XDRPCArgumentInfo<uint>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 490, dwFlags, cb, ppv);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return ppv.Value;
        }

        public static void XamFree(XboxConsole Console, uint Address)
        {
            var pv = new XDRPCArgumentInfo<uint>(Address);
            Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 492, pv);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct FIND_USER_REPLY_MSG
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x18)]
            private byte[] data;

            public ulong OnlineXUID
            {
                get { return BitConverterEx.GetUInt64(data, 0, EndianTypes.BigEndian); }
                set
                {
                    if (!XUID.IsOnlineXUID(value)) throw new Exception("XDKUtilities.FIND_USER_INFO_RESPONSE: Invalid online XUID specified.");
                    BitConverterEx.SetUInt64(data, 0, value, EndianTypes.BigEndian);
                }
            }

            public string Gamertag
            {
                get { return Encoding.ASCII.GetString(data, 8, 15); }
                set
                {
                    if (value.Length != 15) throw new Exception("XDKUtilities.FIND_USER_INFO_RESPONSE: Invalid Gamertag specified. It must be equal to 15 characters in length.");
                    Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 8, 15);
                }
            }
        }

        public static FIND_USER_REPLY_MSG XUserFindUser(XboxConsole Console, uint FunctionAddress, ulong YourXUID, object GamertagOrXUID)
        {
            var qwUserId = new XDRPCArgumentInfo<ulong>(YourXUID);
            XDRPCArgumentInfo qwFindId = null;
            XDRPCArgumentInfo szSenderName = null;
            if (GamertagOrXUID is ulong)
            {
                if (!XUID.IsOnlineXUID((ulong)GamertagOrXUID) && !XUID.IsTeamXUID((ulong)GamertagOrXUID)) throw new Exception("XDKUtilities.XUserFindUser: Invalid gamer online/team XUID specified.");
                qwFindId = new XDRPCArgumentInfo<ulong>((ulong)GamertagOrXUID);
            }
            else if (GamertagOrXUID is string)
            {
                if (GamertagOrXUID.ToString().Length > 15) throw new Exception("XDKUtilities.XUserFindUser: Invalid Gamertag specified. It must be less than or equal to 15 characters in length.");
                szSenderName = new XDRPCStringArgumentInfo(GamertagOrXUID.ToString(), Encoding.ASCII, ArgumentType.ByRef, 16);
            }
            if (qwFindId == null && szSenderName == null) throw new Exception("XDKUtilities.XUserFindUser: Invalid gamertag/XUID specified.");
            if (qwFindId == null) qwFindId = new XDRPCArgumentInfo<ulong>(0);
            if (szSenderName == null) szSenderName = new XDRPCStringArgumentInfo(string.Empty, Encoding.ASCII, ArgumentType.ByRef, 16);
            var cbResults = new XDRPCArgumentInfo<int>(0x18);
            var pResults = new XDRPCStructArgumentInfo<FIND_USER_REPLY_MSG>(new FIND_USER_REPLY_MSG(), ArgumentType.Out);
            var pXOverlapped = new XDRPCArgumentInfo<uint>(0);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, FunctionAddress, qwUserId, qwFindId, szSenderName, cbResults, pResults, pXOverlapped);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return pResults.Value;
        }

        public enum XamAppIDs : uint
        {
            PRELOADED_HUD = 0x01,
            LIVE_MESSENGER = 0x02,
            XMP = 0x03,
            XAM_COMMUNITY = 0x04,
            XIME = 0x05,
            XSTUDIO = 0x06,
            WIRELESS_WAVE_A = 0x07,
            XDK_HEAP = 0x21,
            PIX_STREAM = 0x22,
            ETX_BOOST = 0x23,
            XS_LOGS = 0x24,
            TEST_XEX = 0x26,
            XAM_UI_AUTOMATION = 0x27
        }

        public static bool XamFeatureEnabled(XboxConsole Console, XamAppIDs AppID)
        {
            var appID = new XDRPCArgumentInfo<uint>((uint)AppID);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 512, appID);
            if (returnVal != 0 && returnVal != 1) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return Convert.ToBoolean(returnVal);
        }

        public static void XamFeatureEnableDisable(XboxConsole Console, bool EnableDisable, XamAppIDs AppID)
        {
            var enableDisable = new XDRPCArgumentInfo<bool>(EnableDisable);
            var appID = new XDRPCArgumentInfo<uint>((uint)AppID);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xam.xex", 515, enableDisable, appID);
            if (returnVal != 0) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
        }

        #endregion

        #region Kernel

        public enum SMCCommands : byte
        {
            SMC_POWERON_TYPE = 0x1,
            SMC_QUERY_RTC = 0x4,
            SMC_QUERY_SENSOR = 0x7,
            SMC_QUERY_TRAY = 0xA,
            SMC_QUERY_AVPACK = 0xF,
            SMC_I2C_READ_WRITE = 0x11,
            SMC_QUERY_VERSION = 0x12,
            SMC_FIFO_TEST = 0x13,
            SMC_QUERY_IR_ADDRESS = 0x16,
            SMC_QUERY_TILT_SENSOR = 0x17,
            SMC_READ_82_INTERRUPTS = 0x1E,
            SMC_READ_8E_INTERRUPTS = 0x20,
            SMC_SET_STANDBY = 0x82,
            SMC_SET_TIME = 0x85,
            SMC_SET_FAN_ALGORITHM = 0x88,
            SMC_SET_FAN_SPEED_CPU = 0x89,
            SMC_SET_DVD_TRAY = 0x8B,
            SMC_SET_POWER_LED = 0x8C,
            SMC_SET_AUDIO_MUTE = 0x8D,
            SMC_ARGON_RELATED = 0x90,
            SMC_SET_FAN_SPEED_GPU = 0x94, //Not present on slim, not used/respected on newer phat.
            SMC_SET_IR_ADDRESS = 0x95,
            SMC_SET_DVD_TRAY_SECURE = 0x98,
            SMC_SET_LEDS = 0x99,
            SMC_SET_RTC_WAKE = 0x9A,
            SMC_ANA_RELATED = 0x9B,
            SMC_SET_ASYNC_OPERATION = 0x9C,
            SMC_SET_82_INTERRUPTS = 0x9D,
            SMC_SET_9F_INTERRUPTS = 0x9F
        }

        public enum SMCTemperatureIndices : byte
        {
            CPU = 0,
            GPU = 1,
            RAM = 2,
            BOARD = 3
        }

        public static void HalSendSMCMessage(XboxConsole Console, byte[] Request, ref byte[] Response)
        {
            if (Request.Length != 16) throw new Exception("XDKUtilities.HalSendSMCMessage: Invalid request specified. It must be 16 bytes in length.");
            if (!Enum.IsDefined(typeof(SMCCommands), Request[0])) throw new Exception("XDKUtilities.HalSendSMCMessage: Invalid request specified. The first byte needs to be a valid request value.");
            var request = new XDRPCArrayArgumentInfo<byte[]>(Request);
            var response = Response == null ? (XDRPCArgumentInfo)new XDRPCNullArgumentInfo() : new XDRPCArrayArgumentInfo<byte[]>(Response, ArgumentType.ByRef);
            Console.ExecuteRPC<uint>(XDRPCMode.Title, "xboxkrnl.exe", 41, request, response);
            if (!(response is XDRPCNullArgumentInfo)) Response = ((XDRPCArrayArgumentInfo<byte[]>)response).Value;
        }

        public enum FirmwareReentries : uint
        {
            HalHaltRoutine = 0,
            HalRebootRoutine = 1,
            HalKdRebootRoutine = 2,
            HalFatalErrorRebootRoutine = 3,
            HalResetSMCRoutine = 4,
            HalPowerDownRoutine = 5,
            HalRebootQuiesceRoutine = 6,
            HalForceShutdownRoutine = 7,
            HalPowerCycleQuiesceRoutine = 8,
            HalMaximumRoutine = 9,
        }

        public static void HalReturnToFirmware(XboxConsole Console, FirmwareReentries FirmwareReentry)
        {
            if (!Enum.IsDefined(typeof(FirmwareReentries), FirmwareReentry)) throw new Exception("XDKUtilities.HalReturnToFirmware: Invalid firmware reentry specified.");
            var firmwareReentry = new XDRPCArgumentInfo<uint>((uint)FirmwareReentry);
            Console.ExecuteRPC<uint>(XDRPCMode.Title, "xboxkrnl.exe", 40, firmwareReentry);
        }

        public static uint XexGetModuleHandle(XboxConsole Console, string ModuleName)
        {
            var name = new XDRPCStringArgumentInfo(ModuleName, Encoding.ASCII);
            var handle = new XDRPCArgumentInfo<uint>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xboxkrnl.exe", 405, name, handle);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return handle.Value;
        }

        public static uint XexGetProcedureAddress(XboxConsole Console, uint ModuleHandle, uint FunctionOrdinal)
        {
            if (ModuleHandle == 0) throw new Exception("XDKUtilities.XexGetProcedureAddress: Invalid module handle specified.");
            if (FunctionOrdinal == 0) throw new Exception("XDKUtilities.XexGetProcedureAddress: Invalid function ordinal specified.");
            var handle = new XDRPCArgumentInfo<uint>(ModuleHandle);
            var ordinal = new XDRPCArgumentInfo<uint>(FunctionOrdinal);
            var address = new XDRPCArgumentInfo<uint>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xboxkrnl.exe", 407, handle, ordinal, address);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            return address.Value;
        }

        public enum XexHeaderFieldIDs : uint
        {
            ResourceInfo = 0x000002FF,
            BaseFileFormat = 0x000003FF,
            DeltaPatchDescriptor = 0x000005FF,
            BaseReference = 0x00000405,
            OriginalBaseAddress = 0x00010001,
            EntryPoint = 0x00010100,
            ImageBaseAddress = 0x00010201,
            ImportLibraries = 0x000103FF,
            ImageChecksumTimestamp = 0x00018002,
            EnabledForCallcap = 0x00018102,
            EnabledForFastcap = 0x00018200,
            OriginalPEImageName = 0x000183FF,
            StaticLibraries = 0x000200FF,
            TLSInfo = 0x00020104,
            DefaultStackSize = 0x00020200,
            DefaultFileSystemCacheSize = 0x00020301,
            DefaultHeapSize = 0x00020401,
            PageHeapSizeAndflags = 0x00028002,
            SystemFlags = 0x00030000,
            ExecutionID = 0x00040006,
            TitleWorkspaceSize = 0x00040201,
            GameRatingsSpecified = 0x00040310,
            LANKey = 0x00040404,
            IncludesXbox360Logo = 0x000405FF,
            MultidiscMediaIDs = 0x000406FF,
            AlternateTitleIDs = 0x000407FF,
            AdditionalTitleMemory = 0x00040801,
            BoundingPath = 0x000080FF,
            DeviceID = 0x00008105,
            IncludesExportsByName = 0x00E10402
        }

        public static T RtlImageXexHeaderField<T>(XboxConsole Console, string ModuleName, XexHeaderFieldIDs HeaderFieldID, int HeaderLength)
        {
            if (!Enum.IsDefined(typeof(XexHeaderFieldIDs), HeaderFieldID)) throw new Exception("XDKUtilities.RtlImageXexHeaderField: Invalid header field ID specified.");
            uint xexHeaderBase;
            using (var refr = new XDRPCReference(Console, XexGetModuleHandle(Console, ModuleName) + 0x58, 4)) xexHeaderBase = refr.Get<uint>();
            if (xexHeaderBase == 0) throw new Exception(string.Format("XDKUtilities.RtlImageXexHeaderField: {0} has an invalid XexHeaderBase.", ModuleName));
            var headerBase = new XDRPCArgumentInfo<uint>(xexHeaderBase);
            var headerField = new XDRPCArgumentInfo<uint>((uint)HeaderFieldID);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xboxkrnl.exe", 299, headerBase, headerField);
            if (returnVal == 0x00000000) throw new Exception(string.Format("XDKUtilities.RtlImageXexHeaderField: Failed to retrieve header ({0}) from {1}.", HeaderFieldID, ModuleName));
            using (var refr2 = new XDRPCReference(Console, returnVal, HeaderLength)) return refr2.Get<T>();
        }

        #endregion

        #region Other Utility Methods

        public static void LaunchModule(XboxConsole Console, uint ConsoleConnection, string ModulePath)
        {
            var tmpString = ModulePath.Replace('\\', '~').Split('~');
            var directory = ModulePath.Substring(0, (ModulePath.Length - tmpString[tmpString.Length - 1].Length) - 1);
            string outsts;
            string command;
            if (directory.Contains("\\")) command = string.Format("magicboot title=\"{0}\"" + " directory=\"{1}\"", ModulePath, directory);
            else
            {
                //We can only launch from the FLASH root.
                if (string.CompareOrdinal(directory, "FLASH:") == 0) command = string.Format("magicboot title=\"{0}\"", ModulePath);
                else throw new Exception("XDKUtilities.LaunchModule: You can only launch modules from the FLASH root, not any others.");
            }
            Console.SendTextCommand(ConsoleConnection, command, out outsts);
        }

        #endregion

        #region General

        public static string CreateExceptionMessage(Exception EX, XboxManager Manager)
        {
            if (EX == null || Manager == null) return "(Error in XDKUtilities.CreateExceptionMessage)";
            if (!(EX is COMException)) return EX.Message;
            try { return Manager.TranslateError(((COMException)EX).ErrorCode); }
            catch (Exception) { return EX.Message; }
        }

        #endregion
    }
}