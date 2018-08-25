// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using Microsoft.Test.Xbox.XDRPC;
using System;
using System.Runtime.InteropServices;
using System.Text;
using XDevkit;

namespace DevTool.Classes
{
    public static class XConfig
    {
        public enum XCONFIG_CATEGORY_TYPES : short
        {
            XCONFIG_STATIC_CATEGORY = 0x0,
            XCONFIG_STATISTIC_CATEGORY = 0x1,
            XCONFIG_SECURED_CATEGORY = 0x2,
            XCONFIG_USER_CATEGORY = 0x3,
            XCONFIG_XNET_MACHINE_ACCOUNT_CATEGORY = 0x4,
            XCONFIG_XNET_PARAMETERS_CATEGORY = 0x5,
            XCONFIG_MEDIA_CENTER_CATEGORY = 0x6,
            XCONFIG_CONSOLE_CATEGORY = 0x7,
            XCONFIG_DVD_CATEGORY = 0x8,
            XCONFIG_IPTV_CATEGORY = 0x9,
            XCONFIG_SYSTEM_CATEGORY = 0xA,
            XCONFIG_DEVKIT_CATEGORY = 0xB
        }

        #region Static

        public enum XCONFIG_STATIC_ENTRIES : short
        {
            XCONFIG_STATIC_DATA = 0x0,
            XCONFIG_STATIC_FIRST_POWER_ON_DATE = 0x1,
            XCONFIG_STATIC_SMC_CONFIG = 0x2,
        }

        [StructLayout(LayoutKind.Sequential, Size = 3), XDRPCStruct]
        public struct Thermal
        {
            private byte cpu;
            private byte gpu;
            private byte edram;

            public byte CPU
            {
                get { return cpu; }
                set { cpu = value; }
            }

            public byte GPU
            {
                get { return gpu; }
                set { gpu = value; }
            }

            public byte EDRAM
            {
                get { return edram; }
                set { edram = value; }
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x10), XDRPCStruct]
        public struct TempSetting
        {
            private ushort cpuGain;
            private ushort cpuOffset;
            private ushort gpuGain;
            private ushort gpuOffset;
            private ushort edramGain;
            private ushort edramOffset;
            private ushort boardGain;
            private ushort boardOffset;

            public ushort CPUGain
            {
                get { return cpuGain; }
                set { cpuGain = value; }
            }

            public ushort CPUOffset
            {
                get { return cpuOffset; }
                set { cpuOffset = value; }
            }

            public ushort GPUGain
            {
                get { return gpuGain; }
                set { gpuGain = value; }
            }

            public ushort GPUOffset
            {
                get { return gpuOffset; }
                set { gpuOffset = value; }
            }

            public ushort EDRAMGain
            {
                get { return edramGain; }
                set { edramGain = value; }
            }

            public ushort EDRAMOffset
            {
                get { return edramOffset; }
                set { edramOffset = value; }
            }

            public ushort BoardGain
            {
                get { return boardGain; }
                set { boardGain = value; }
            }

            public ushort BoardOffset
            {
                get { return boardOffset; }
                set { boardOffset = value; }
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x17), XDRPCStruct]
        public struct ThermalCalData
        {
            public TempSetting therm;

            public sbyte AnaFuseValue;

            public Thermal SetPoint;

            public Thermal Overload;
        }

        [StructLayout(LayoutKind.Sequential, Size = 4), XDRPCStruct]
        public struct ViperData
        {
            public byte GpuVoltageNotSettingAndMemoryVoltageNotSetting;

            public byte GpuTarget;

            public byte MemoryTarget;

            public byte CheckSum;
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x100), XDRPCStruct]
        public struct SMCBlock
        {
            private byte structureVersion;
            private byte configSource;
            private sbyte clockSelect;
            private byte fanOrCpu;
            private byte fanOrGpu;
            private sbyte ejectPressTimeout;
            private byte flags;
            private sbyte delayOverloadTimer;
            private sbyte maxOverloadDelta;
            private sbyte dropDeadDelta;
            private ThermalCalData temperature;
            private sbyte minFanSpeed;
            private ViperData viper;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x98)]
            private byte[] pad4;
            private TempSetting thermalSet0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private byte[] pad5;
            private TempSetting thermalSet1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] pad6;
            private ThermalCalData backupThermalCalData;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            private byte[] pad7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] doNotUse;

            public byte StructureVersion
            {
                get { return structureVersion; }
                set { structureVersion = value; }
            }

            public byte ConfigurationSource
            {
                get { return configSource; }
                set { configSource = value; }
            }

            public sbyte ClockSelection
            {
                get { return clockSelect; }
                set { clockSelect = value; }
            }

            public byte CPUFanOverride
            {
                get { return fanOrCpu; }
                set { fanOrCpu = value; }
            }

            public byte GPUFanOverride
            {
                get { return fanOrGpu; }
                set { fanOrGpu = value; }
            }

            public sbyte TrayEjectTimeout
            {
                get { return ejectPressTimeout; }
                set { ejectPressTimeout = value; }
            }

            public byte Flags
            {
                get { return flags; }
                set { flags = value; }
            }

            public sbyte DelayOverloadTimer
            {
                get { return delayOverloadTimer; }
                set { delayOverloadTimer = value; }
            }

            public sbyte MaxOverloadDelta
            {
                get { return maxOverloadDelta; }
                set { maxOverloadDelta = value; }
            }

            public sbyte DropDeadDelta
            {
                get { return dropDeadDelta; }
                set { dropDeadDelta = value; }
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x10E), XDRPCStruct]
        public struct XCONFIG_STATIC_SETTINGS
        {
            private uint checkSum;
            private uint version;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            private byte[] firstPowerOnDate;
            private sbyte reserved;
            private SMCBlock smcConfig;

            internal uint CheckSum
            {
                get { return checkSum; }
                set { checkSum = value; }
            }

            public uint Version
            {
                get { return version; }
                set { version = value; }
            }

            public byte[] FirstPowerOnDate
            {
                get { return firstPowerOnDate; }
                set
                {
                    if (value.Length > 5) throw new Exception("XDKUtilities.XCONFIG_STATIC_SETTINGS: Invalid first power on date specified. It must be less than or equal to 5 bytes in length.");
                    firstPowerOnDate = value;
                }
            }

            public SMCBlock SMCConfig
            {
                get { return smcConfig; }
                set { smcConfig = value; }
            }
        }

        #endregion

        #region Statistic

        public enum XCONFIG_STATISTIC_ENTRIES : short
        {
            XCONFIG_STATISTICS_DATA = 0x0,
            XCONFIG_STATISTICS_XUID_MAC_ADDRESS = 0x1,
            XCONFIG_STATISTICS_XUID_COUNT = 0x2,
            XCONFIG_STATISTICS_ODD_FAILURES = 0x3,
            XCONFIG_STATISTICS_HDD_SMART_DATA = 0x4,
            XCONFIG_STATISTICS_UEM_ERRORS = 0x5,
            XCONFIG_STATISTICS_FPM_ERRORS = 0x6,
            XCONFIG_STATISTICS_LAST_REPORT_TIME = 0x7,
            XCONFIG_STATISTICS_BUG_CHECK_DATA = 0x8,
            XCONFIG_STATISTICS_TEMPERATURE = 0x9,
            XCONFIG_STATISTICS_XEKEYS_WRITE_FAILURE = 0xA
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XCONFIG_XEKEYS_WRITE_FAILURE
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            private byte[] data;

            public DateTime FailureDate
            {
                get { return DateTime.FromFileTime(BitConverterEx.GetInt64(data, 0, EndianTypes.BigEndian)); }
                set { BitConverterEx.SetInt64(data, 0, value.ToFileTime(), EndianTypes.BigEndian); }
            }

            public uint Status
            {
                get { return BitConverterEx.GetUInt32(data, 8, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 8, value, EndianTypes.BigEndian); }
            }

            public byte File
            {
                get { return data[0xC]; }
                set { data[0xC] = value; }
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XCONFIG_STATISTIC_SETTINGS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x161)]
            private byte[] data;
            private XCONFIG_XEKEYS_WRITE_FAILURE xekwf;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x48F)]
            private byte[] data2;

            public uint Checksum
            {
                get { return BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 0, value, EndianTypes.BigEndian); }
            }

            public uint Version
            {
                get { return BitConverterEx.GetUInt32(data, 4, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 4, value, EndianTypes.BigEndian); }
            }

            public byte[] XUIDMACAddress
            {
                get { return XtraFunctions.GetData(data, 8, 6); }
                set { Buffer.BlockCopy(value, 0, data, 8, 6); }
            }

            public uint XUIDCount
            {
                get { return BitConverterEx.GetUInt32(data, 0x10, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 0x10, value, EndianTypes.BigEndian); }
            }

            public byte[] ODDFailures
            {
                get { return XtraFunctions.GetData(data, 0x14, 0x20); }
                set { Buffer.BlockCopy(value, 0, data, 0x14, 0x20); }
            }

            public byte[] BugCheckData
            {
                get { return XtraFunctions.GetData(data, 0x34, 0x65); }
                set { Buffer.BlockCopy(value, 0, data, 0x34, 0x65); }
            }

            public byte[] TemperatureData
            {
                get { return XtraFunctions.GetData(data, 0x99, 0xC8); }
                set { Buffer.BlockCopy(value, 0, data, 0x99, 0xC8); }
            }

            public XCONFIG_XEKEYS_WRITE_FAILURE XeKeysWriteFailure { get { return xekwf; } }

            public byte[] HDDSmartData
            {
                get { return XtraFunctions.GetData(data2, 0x1C3, 0x200); }
                set { Buffer.BlockCopy(value, 0, data2, 0x1C3, 0x200); }
            }

            public byte[] UEMErrors
            {
                get { return XtraFunctions.GetData(data2, 0x3C3, 0x64); }
                set { Buffer.BlockCopy(value, 0, data2, 0x3C3, 0x64); }
            }

            public byte[] FPMErrors
            {
                get { return XtraFunctions.GetData(data2, 0x427, 0x60); }
                set { Buffer.BlockCopy(value, 0, data2, 0x427, 0x60); }
            }

            public DateTime LastReportTime
            {
                get { return DateTime.FromFileTime(BitConverterEx.GetInt64(data2, 0x487, EndianTypes.BigEndian)); }
                set { BitConverterEx.SetInt64(data2, 0x487, value.ToFileTime(), EndianTypes.BigEndian); }
            }
        }

        #endregion

        #region Secured

        public enum XCONFIG_SECURED_ENTRIES : short
        {
            XCONFIG_SECURED_DATA = 0x0,
            XCONFIG_SECURED_MAC_ADDRESS = 0x1,
            XCONFIG_SECURED_AV_REGION = 0x2,
            XCONFIG_SECURED_GAME_REGION = 0x3,
            XCONFIG_SECURED_DVD_REGION = 0x4,
            XCONFIG_SECURED_RESET_KEY = 0x5,
            XCONFIG_SECURED_SYSTEM_FLAGS = 0x6,
            XCONFIG_SECURED_POWER_MODE = 0x7,
            XCONFIG_SECURED_ONLINE_NETWORK_ID = 0x8,
            XCONFIG_SECURED_POWER_VCS_CONTROL = 0x9
        }

        public enum XCONFIG_AV_REGIONS : uint
        {
            Default = 0,
            NTSCM = 0x00400100,
            NTSCJ = 0x00400200,
            PAL60 = 0x00400400,
            PAL50 = 0x00800300
        }

        public enum XCONFIG_CONSOLE_REGIONS : uint
        {
            XC_CONSOLE_REGION_NA = 0,
            XC_CONSOLE_REGION_ASIA = 1,
            XC_CONSOLE_REGION_EUROPE = 2,
            XC_CONSOLE_REGION_RESTOFWORLD = 3,
            XC_CONSOLE_REGION_DEVKIT = 0x7F
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XCONFIG_POWER_MODE
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] data;

            public byte VIDDelta
            {
                get { return data[0]; }
                set { data[0] = value; }
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XCONFIG_POWER_VCS_CONTROL
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] data;

            public ushort ControlFlags
            {
                get { return BitConverterEx.GetUInt16(data, 0, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt16(data, 0, value, EndianTypes.BigEndian); }
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XCONFIG_SECURED_SETTINGS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x40)]
            private byte[] data;
            private XCONFIG_POWER_MODE powerMode;
            private XCONFIG_POWER_VCS_CONTROL pvcsControl;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x1BC)]
            private byte[] data2;

            public uint Checksum
            {
                get { return BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 0, value, EndianTypes.BigEndian); }
            }

            public uint Version
            {
                get { return BitConverterEx.GetUInt32(data, 4, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 4, value, EndianTypes.BigEndian); }
            }

            public XDKUtilities.XboxLiveServices OnlineNetworkID
            {
                get { return (XDKUtilities.XboxLiveServices)BitConverterEx.GetUInt32(data, 8, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 8, Convert.ToUInt32(value), EndianTypes.BigEndian); }
            }

            public byte[] MACAddress
            {
                get { return XtraFunctions.GetData(data, 0x20, 6); }
                set { Buffer.BlockCopy(value, 0, data, 0x20, 6); }
            }

            public XCONFIG_AV_REGIONS AVRegion
            {
                get { return (XCONFIG_AV_REGIONS)BitConverterEx.GetUInt32(data, 0x28, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 0x28, Convert.ToUInt32(value), EndianTypes.BigEndian); }
            }

            public ushort GameRegion
            {
                get { return BitConverterEx.GetUInt16(data, 0x2C, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt16(data, 0x2C, value, EndianTypes.BigEndian); }
            }

            public XCONFIG_CONSOLE_REGIONS DVDRegion
            {
                get { return (XCONFIG_CONSOLE_REGIONS)BitConverterEx.GetUInt32(data, 0x34, EndianTypes.BigEndian); }
                set
                {
                    var uintVal = Convert.ToUInt32(value);
                    if (uintVal >= 4 && uintVal != 0x7F) throw new Exception("XDKUtilities.XCONFIG_SECURED_SETTINGS: Invalid DVD region specified");
                    BitConverterEx.SetUInt32(data, 0x34, uintVal, EndianTypes.BigEndian);
                }
            }

            public uint ResetKey
            {
                get { return BitConverterEx.GetUInt32(data, 0x38, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 0x38, value, EndianTypes.BigEndian); }
            }

            public uint SystemFlags
            {
                get { return BitConverterEx.GetUInt32(data, 0x3C, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 0x3C, value, EndianTypes.BigEndian); }
            }

            public XCONFIG_POWER_MODE PowerMode { get { return powerMode; } }

            public XCONFIG_POWER_VCS_CONTROL PowerVcsControl { get { return pvcsControl; } }
        }

        #endregion

        #region User

        public enum XCONFIG_USER_ENTRIES : short
        {
            XCONFIG_USER_DATA = 0x0,
            XCONFIG_USER_TIME_ZONE_BIAS = 0x1,
            XCONFIG_USER_TIME_ZONE_STD_NAME = 0x2,
            XCONFIG_USER_TIME_ZONE_DLT_NAME = 0x3,
            XCONFIG_USER_TIME_ZONE_STD_DATE = 0x4,
            XCONFIG_USER_TIME_ZONE_DLT_DATE = 0x5,
            XCONFIG_USER_TIME_ZONE_STD_BIAS = 0x6,
            XCONFIG_USER_TIME_ZONE_DLT_BIAS = 0x7,
            XCONFIG_USER_DEFAULT_PROFILE = 0x8,
            XCONFIG_USER_LANGUAGE = 0x9,
            XCONFIG_USER_VIDEO_FLAGS = 0xA,
            XCONFIG_USER_AUDIO_FLAGS = 0xB,
            XCONFIG_USER_RETAIL_FLAGS = 0xC,
            XCONFIG_USER_DEVKIT_FLAGS = 0xD,
            XCONFIG_USER_COUNTRY = 0xE,
            XCONFIG_USER_PC_FLAGS = 0xF,
            XCONFIG_USER_SMB_CONFIG = 0x10,
            XCONFIG_USER_LIVE_PUID = 0x11,
            XCONFIG_USER_LIVE_CREDENTIALS = 0x12,
            XCONFIG_USER_AV_COMPOSITE_SCREENSZ = 0x13,
            XCONFIG_USER_AV_COMPONENT_SCREENSZ = 0x14,
            XCONFIG_USER_AV_VGA_SCREENSZ = 0x15,
            XCONFIG_USER_PC_GAME = 0x16,
            XCONFIG_USER_PC_PASSWORD = 0x17,
            XCONFIG_USER_PC_MOVIE = 0x18,
            XCONFIG_USER_PC_GAME_RATING = 0x19,
            XCONFIG_USER_PC_MOVIE_RATING = 0x1A,
            XCONFIG_USER_PC_HINT = 0x1B,
            XCONFIG_USER_PC_HINT_ANSWER = 0x1C,
            XCONFIG_USER_PC_OVERRIDE = 0x1D,
            XCONFIG_USER_MUSIC_PLAYBACK_MODE = 0x1E,
            XCONFIG_USER_MUSIC_VOLUME = 0x1F,
            XCONFIG_USER_MUSIC_FLAGS = 0x20,
            XCONFIG_USER_ARCADE_FLAGS = 0x21,
            XCONFIG_USER_PC_VERSION = 0x22,
            XCONFIG_USER_PC_TV = 0x23,
            XCONFIG_USER_PC_TV_RATING = 0x24,
            XCONFIG_USER_PC_EXPLICIT_VIDEO = 0x25,
            XCONFIG_USER_PC_EXPLICIT_VIDEO_RATING = 0x26,
            XCONFIG_USER_PC_UNRATED_VIDEO = 0x27,
            XCONFIG_USER_PC_UNRATED_VIDEO_RATING = 0x28,
            XCONFIG_USER_VIDEO_OUTPUT_BLACK_LEVELS = 0x29,
            XCONFIG_USER_VIDEO_PLAYER_DISPLAY_MODE = 0x2A,
            XCONFIG_USER_ALTERNATE_VIDEO_TIMING_ID = 0x2B,
            XCONFIG_USER_VIDEO_DRIVER_OPTIONS = 0x2C,
            XCONFIG_USER_MUSIC_UI_FLAGS = 0x2D,
            XCONFIG_USER_VIDEO_MEDIA_SOURCE_TYPE = 0x2E,
            XCONFIG_USER_MUSIC_MEDIA_SOURCE_TYPE = 0x2F,
            XCONFIG_USER_PHOTO_MEDIA_SOURCE_TYPE = 0x30
        }

        [Flags]
        public enum XCONFIG_RETAIL_FLAGS : uint
        {
            XC_MISC_FLAG_AUTOPOWERDOWN = 0x00000001,
            XC_MISC_FLAG_DONT_USE_DST = 0x00000002,
            XC_MISC_FLAG_CONNECTIONNOTICE = 0x00000004,
            XC_MISC_FLAG_24HCLOCK = 0x00000008,

            XC_MISC_FLAG_NO_NOTIFY_DISPLAY = 0x00000010,
            XC_MISC_FLAG_NO_NOTIFY_SOUND = 0x00000020,
            XC_MISC_FLAG_OOBE_HAS_RUN = 0x00000040,
            XC_MISC_FLAG_STARTUP_DASHBOARD = 0x00000080,

            XC_MISC_FLAG_NO_UI_SOUND = 0x00000100,
            XC_MISC_FLAG_NO_NOTIFY_DISPLAY_MOVIE = 0x00000200,
            XC_MISC_FLAG_PAL_HD_50HZ_COMPATIBLE = 0x00000400,
            XC_MISC_FLAG_STARTUP_IPTV = 0x00000800,

            XC_MISC_FLAG_IPTV_UI_ENABLE = 0x00001000,
            XC_MISC_FLAG_STARTUP_DISC = 0x00002000,
            XC_MISC_FLAG_NO_NOTIFY_DISPLAY_IPTV = 0x00004000,
            XC_UNKNOWN1 = 0x00008000,

            XC_MISC_FLAG_BKGD_MODE_DOWNLOADS = 0x00010000,
            XC_MISC_FLAG_STARTUP_MCXDOWNLOADER = 0x00020000,
            XC_MISC_FLAG_RTC_ALARM_SET = 0x00040000,
            XC_MISC_FLAG_IPTV_DVR_ENABLE = 0x00080000,

            XC_MISC_FLAG_NO_LIVE_SIGNUP = 0x00100000,
            XC_MISC_FLAG_NO_ADD_PAYMENT = 0x00200000,
            XC_MISC_FLAG_PURCHASE_PASSWORD = 0x00400000,
            XC_MISC_FLAG_NO_MODIFY_CONTACT_INFO = 0x00800000,

            XC_MISC_FLAG_NO_CHANGE_WLID = 0x01000000,
            XC_MISC_FLAG_IPTV_UNINSTALL_DISABLE = 0x02000000,
            XC_MISC_FLAG_HIDE_WELCOME_CHANNEL = 0x04000000,
            XC_MISC_FLAG_EPIX_NO_DEFAULT_CHANNEL_OVERRIDE = 0x08000000,

            XC_MISC_FLAG_PRE_LIVE_TOU_REPORTING_NOTICE = 0x10000000,
            XC_MISC_FLAG_NUI_OOBE_HAS_RUN = 0x20000000,
            XC_MISC_FLAG_KINECT_DEVICE_DISABLE = 0x80000000,
        }

        [Flags]
        public enum XCONFIG_AUDIO_FLAGS : uint
        {
            XC_AUDIO_FLAGS_SURROUND = 1,
            XC_AUDIO_FLAGS_MONO = 2,
            XC_AUDIO_FLAGS_STEREOBYPASS = 3,
            XC_AUDIO_FLAGS_ENABLE_DOLBYDIGITAL = 0x10000,
            XC_AUDIO_FLAGS_ENABLE_WMAPRO = 0x20000,
            XC_AUDIO_FLAGS_LOW_LATENCY = 0x80000000
        }

        [Flags]
        public enum XCONFIG_PARENTAL_CONTROL_FLAGS : byte
        {
            XC_PC_RESTRICTION_FLAG_XBL_ACCESS_ALLOWED = 1,
            XC_PC_RESTRICTION_FLAG_XBL_MEMBERSHIP_CREATION_ALLOWED = 2,
            XC_PC_RESTRICTION_FLAG_ENABLED = 0x80
        }

        public enum XCONFIG_PARENTAL_CONTROL_HINTS : byte
        {
            XC_PC_HINTS_FAVORITE_FICTIONAL_CHARACTER = 0,
            XC_PC_HINTS_FAVORITE_PERSON_FROM_HISTORY = 1,
            XC_PC_HINTS_FAVORITE_CHILDHOOD_BOOK_OR_STORY = 2,
            XC_PC_HINTS_FAVORITE_MOVIE = 3,
            XC_PC_HINTS_FAVORITE_FOOD = 4
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XCONFIG_TIMEZONE_DATE
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private byte[] data;

            public byte Month
            {
                get { return data[0]; }
                set
                {
                    if (value > 12) throw new Exception("XDKUtilities.XCONFIG_TIMEZONE_DATE: Invalid month specified.");
                    data[0] = value;
                }
            }

            public byte Day
            {
                get { return data[1]; }
                set
                {
                    if (value > DateTime.DaysInMonth(DateTime.Now.Year, Month)) throw new Exception("XDKUtilities.XCONFIG_TIMEZONE_DATE: Invalid day specified.");
                    data[1] = value;
                }
            }

            public byte DayOfWeek
            {
                get { return data[2]; }
                set
                {
                    if (value > 7) throw new Exception("XDKUtilities.XCONFIG_TIMEZONE_DATE: Invalid day of week specified.");
                    data[2] = value;
                }
            }

            public byte Hour
            {
                get { return data[3]; }
                set
                {
                    if (value > 23) throw new Exception("XDKUtilities.XCONFIG_TIMEZONE_DATE: Invalid hour specified.");
                    data[3] = value;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1), XDRPCStruct]
        public struct XCONFIG_USER_SETTINGS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x14)]
            private byte[] data;
            private XCONFIG_TIMEZONE_DATE tzStd;
            private XCONFIG_TIMEZONE_DATE tzDlt;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x1E1)]
            private byte[] data2;

            public uint Checksum
            {
                get { return BitConverterEx.GetUInt32(data, 0, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 0, value, EndianTypes.BigEndian); }
            }

            public uint Version
            {
                get { return BitConverterEx.GetUInt32(data, 4, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 4, value, EndianTypes.BigEndian); }
            }

            public uint TimeZoneBias
            {
                get { return BitConverterEx.GetUInt32(data, 8, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data, 8, value, EndianTypes.BigEndian); }
            }

            public string TimeZoneStdName
            {
                get { return Encoding.ASCII.GetString(data, 0xC, 4); }
                set { Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 0xC, 4); }
            }

            public string TimeZoneDltName
            {
                get { return Encoding.ASCII.GetString(data, 0x10, 4); }
                set { Buffer.BlockCopy(Encoding.ASCII.GetBytes(value), 0, data, 0x10, 4); }
            }

            public XCONFIG_TIMEZONE_DATE TimeZoneStdDate { get { return tzStd; } }

            public XCONFIG_TIMEZONE_DATE TimeZoneDltDate { get { return tzDlt; } }

            public uint TimeZoneStdBias
            {
                get { return BitConverterEx.GetUInt32(data2, 0, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0, value, EndianTypes.BigEndian); }
            }

            public uint TimeZoneDltBias
            {
                get { return BitConverterEx.GetUInt32(data2, 4, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 4, value, EndianTypes.BigEndian); }
            }

            public ulong DefaultProfile
            {
                get { return BitConverterEx.GetUInt64(data2, 0x8, EndianTypes.BigEndian); }
                set
                {
                    if (!XUID.IsOfflineXUID(value)) throw new Exception("XDKUtilities.XCONFIG_USER_SETTINGS: Invalid offline XUID specified.");
                    BitConverterEx.SetUInt64(data2, 0x8, value, EndianTypes.BigEndian);
                }
            }

            public XDKUtilities.XboxLiveLanguages Language
            {
                get { return (XDKUtilities.XboxLiveLanguages)BitConverterEx.GetUInt32(data2, 0x10, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x10, Convert.ToUInt32(value), EndianTypes.BigEndian); }
            }

            public uint VideoFlags
            {
                get { return BitConverterEx.GetUInt32(data2, 0x14, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x14, value, EndianTypes.BigEndian); }
            }

            public XCONFIG_AUDIO_FLAGS AudioFlags
            {
                get { return (XCONFIG_AUDIO_FLAGS)BitConverterEx.GetUInt32(data2, 0x18, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x18, Convert.ToUInt32(value), EndianTypes.BigEndian); }
            }

            public XCONFIG_RETAIL_FLAGS RetailFlags
            {
                get { return (XCONFIG_RETAIL_FLAGS)BitConverterEx.GetUInt32(data2, 0x1C, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1C, Convert.ToUInt32(value), EndianTypes.BigEndian); }
            }

            public uint DevkitFlags
            {
                get { return BitConverterEx.GetUInt32(data2, 0x20, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x20, value, EndianTypes.BigEndian); }
            }

            public XDKUtilities.XboxLiveCountries Country
            {
                get { return (XDKUtilities.XboxLiveCountries)data2[0x24]; }
                set { data2[0x24] = Convert.ToByte(value); }
            }

            public XCONFIG_PARENTAL_CONTROL_FLAGS ParentalControlFlags
            {
                get { return (XCONFIG_PARENTAL_CONTROL_FLAGS)data2[0x25]; }
                set { data2[0x25] = Convert.ToByte(value); }
            }

            public byte[] SMBConfig
            {
                get { return XtraFunctions.GetData(data2, 0x28, 0x100); }
                set { Buffer.BlockCopy(value, 0, data2, 0x28, 0x100); }
            }

            public ulong LivePUID
            {
                get { return BitConverterEx.GetUInt64(data2, 0x128, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt64(data2, 0x128, value, EndianTypes.BigEndian); }
            }

            public byte[] LiveCredentials
            {
                get { return XtraFunctions.GetData(data2, 0x130, 0x10); }
                set { Buffer.BlockCopy(value, 0, data2, 0x130, 0x10); }
            }

            //AV stuff here

            public uint ParentalControlGame
            {
                get { return BitConverterEx.GetUInt32(data2, 0x14C, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x14C, value, EndianTypes.BigEndian); }
            }

            public XDKUtilities.PasscodeButtons[] ParentalControlPassword
            {
                get { return new[] { (XDKUtilities.PasscodeButtons)data2[0x150], (XDKUtilities.PasscodeButtons)data2[0x151], (XDKUtilities.PasscodeButtons)data2[0x152], (XDKUtilities.PasscodeButtons)data2[0x153] }; }
                set
                {
                    if (!Enum.IsDefined(typeof(XDKUtilities.PasscodeButtons), value[0]) || !Enum.IsDefined(typeof(XDKUtilities.PasscodeButtons), value[1]) || !Enum.IsDefined(typeof(XDKUtilities.PasscodeButtons), value[2]) || !Enum.IsDefined(typeof(XDKUtilities.PasscodeButtons), value[3])) throw new Exception("XDKUtilities.XCONFIG_USER_SETTINGS: Invalid password specified.");
                    data2[0x150] = (byte)value[0];
                    data2[0x151] = (byte)value[1];
                    data2[0x152] = (byte)value[2];
                    data2[0x153] = (byte)value[3];
                }
            }

            public uint ParentalControlMovie
            {
                get { return BitConverterEx.GetUInt32(data2, 0x154, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x154, value, EndianTypes.BigEndian); }
            }

            public uint ParentalControlGameRating
            {
                get { return BitConverterEx.GetUInt32(data2, 0x158, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x158, value, EndianTypes.BigEndian); }
            }

            public uint ParentalControlMovieRating
            {
                get { return BitConverterEx.GetUInt32(data2, 0x15C, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x15C, value, EndianTypes.BigEndian); }
            }

            public XCONFIG_PARENTAL_CONTROL_HINTS ParentalControlHint
            {
                get { return (XCONFIG_PARENTAL_CONTROL_HINTS)data2[0x160]; }
                set { data2[0x160] = Convert.ToByte(value); }
            }

            public string ParentalControlHintAnswer
            {
                get { return Encoding.BigEndianUnicode.GetString(data2, 0x161, 0x10); }
                set { Buffer.BlockCopy(Encoding.BigEndianUnicode.GetBytes(value), 0, data2, 0x161, 0x10); }
            }

            public string ParentalControlOverride
            {
                get { return Encoding.BigEndianUnicode.GetString(data2, 0x181, 0x10); }
                set { Buffer.BlockCopy(Encoding.BigEndianUnicode.GetBytes(value), 0, data2, 0x181, 0x10); }
            }

            public uint MusicPlaybackMode
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1A1, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1A1, value, EndianTypes.BigEndian); }
            }

            public uint MusicVolume
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1A5, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1A5, value, EndianTypes.BigEndian); }
            }

            public uint MusicFlags
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1A9, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1A9, value, EndianTypes.BigEndian); }
            }

            public uint ArcadeFlags
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1AD, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1AD, value, EndianTypes.BigEndian); }
            }

            public uint ParentalControlVersion
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1B1, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1B1, value, EndianTypes.BigEndian); }
            }

            public uint ParentalControlTV
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1B5, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1B5, value, EndianTypes.BigEndian); }
            }

            public uint ParentalControlTVRating
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1B9, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1B9, value, EndianTypes.BigEndian); }
            }

            public bool ParentalControlExplicitVideo
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1BD, EndianTypes.BigEndian) != 0; }
                set { BitConverterEx.SetUInt32(data2, 0x1BD, (uint)(!value ? 0 : 0xFF), EndianTypes.BigEndian); }
            }

            public uint ParentalControlExplicitVideoRating
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1C1, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1C1, value, EndianTypes.BigEndian); }
            }

            public bool ParentalControlUnratedVideo
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1C5, EndianTypes.BigEndian) != 0; }
                set { BitConverterEx.SetUInt32(data2, 0x1C5, (uint)(!value ? 0 : 0xFF), EndianTypes.BigEndian); }
            }

            public uint ParentalControlUnratedVideoRating
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1C9, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1C9, value, EndianTypes.BigEndian); }
            }

            public uint VideoOutputBlackLevels
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1CD, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1CD, value, EndianTypes.BigEndian); }
            }

            public byte VideoPlayerDisplayMode
            {
                get { return data2[0x1D1]; }
                set { data2[0x1D1] = value; }
            }

            public uint AlternateVideoTimingIDs
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1D2, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1D2, value, EndianTypes.BigEndian); }
            }

            public uint VideoDriverOptions
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1D6, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1D6, value, EndianTypes.BigEndian); }
            }

            public uint MusicUIFlags
            {
                get { return BitConverterEx.GetUInt32(data2, 0x1DA, EndianTypes.BigEndian); }
                set { BitConverterEx.SetUInt32(data2, 0x1DA, value, EndianTypes.BigEndian); }
            }

            public byte VideoMediaSourceType
            {
                get { return data2[0x1DE]; }
                set { data2[0x1DE] = value; }
            }

            public byte MusicMediaSourceType
            {
                get { return data2[0x1DF]; }
                set { data2[0x1DF] = value; }
            }

            public byte PhotoMediaSourceType
            {
                get { return data2[0x1E0]; }
                set { data2[0x1E0] = value; }
            }
        }

        #endregion

        public enum XCONFIG_MEDIA_CENTER_ENTRIES : short
        {
            XCONFIG_MEDIA_CENTER_DATA = 0x0,
            XCONFIG_MEDIA_CENTER_MEDIA_PLAYER = 0x1,
            XCONFIG_MEDIA_CENTER_XESLED_VERSION = 0x2,
            XCONFIG_MEDIA_CENTER_XESLED_TRUST_SECRET = 0x3,
            XCONFIG_MEDIA_CENTER_XESLED_TRUST_CODE = 0x4,
            XCONFIG_MEDIA_CENTER_XESLED_HOST_ID = 0x5,
            XCONFIG_MEDIA_CENTER_XESLED_KEY = 0x6,
            XCONFIG_MEDIA_CENTER_XESLED_HOST_MAC_ADDRESS = 0x7,
            XCONFIG_MEDIA_CENTER_SERVER_UUID = 0x8,
            XCONFIG_MEDIA_CENTER_SERVER_NAME = 0x9,
            XCONFIG_MEDIA_CENTER_SERVER_FLAG = 0xA
        }

        public enum XCONFIG_CONSOLE_ENTRIES : short
        {
            XCONFIG_CONSOLE_DATA = 0x0,
            XCONFIG_CONSOLE_SCREEN_SAVER = 0x1,
            XCONFIG_CONSOLE_AUTO_SHUT_OFF = 0x2,
            XCONFIG_CONSOLE_WIRELESS_SETTINGS = 0x3,
            XCONFIG_CONSOLE_CAMERA_SETTINGS = 0x4,
            XCONFIG_CONSOLE_PLAYTIMERDATA = 0x5,
            XCONFIG_CONSOLE_MEDIA_DISABLEAUTOLAUNCH = 0x6,
            XCONFIG_CONSOLE_KEYBOARD_LAYOUT = 0x7,
            XCONFIG_CONSOLE_PC_TITLE_EXEMPTIONS = 0x8,
            XCONFIG_CONSOLE_NUI = 0x9,
            XCONFIG_CONSOLE_VOICE = 0xA,
            XCONFIG_CONSOLE_RETAIL_EX_FLAGS = 0xB,
            XCONFIG_CONSOLE_DASH_FIRST_USE_TUTORIAL_FLAGS = 0xC,
            XCONFIG_CONSOLE_TV_DIAGONAL_SIZE_IN_CM = 0xD,
            XCONFIG_CONSOLE_NETWORKSTORAGEDEVICE_SERIALNUMBER = 0xE,
            XCONFIG_CONSOLE_DISCOVERABLE = 0xF,
            XCONFIG_CONSOLE_LIVE_TV_PROVIDER = 0x10,
            XCONFIG_CONSOLE_UNUSED_1 = 0x11,
            XCONFIG_CONSOLE_CLOSEDCAPTIONINGSTATE = 0x12,
            XCONFIG_CONSOLE_CLOSEDCAPTIONINGSETTINGS = 0x13,
            XCONFIG_CONSOLE_ENCRYPTEDCONTRACTDATA = 0x14
        }

        public enum XCONFIG_DVD_ENTRIES : short
        {
            XCONFIG_DVD_DATA = 0x0,
            XCONFIG_DVD_VOLUME_ID = 0x1,
            XCONFIG_DVD_BOOKMARK = 0x2
        }

        public enum XCONFIG_IPTV_ENTRIES : short
        {
            XCONFIG_IPTV_DATA = 0x0,
            XCONFIG_IPTV_SERVICE_PROVIDER_NAME = 0x1,
            XCONFIG_IPTV_PROVISIONING_SERVER_URL = 0x2,
            XCONFIG_IPTV_SUPPORT_INFO = 0x3,
            XCONFIG_IPTV_BOOTSTRAP_SERVER_URL = 0x4
        }

        public enum XCONFIG_SYSTEM_ENTRIES : short
        {
            XCONFIG_SYSTEM_ALL = 0x0,
            XCONFIG_SYSTEM_ALARM_TIME = 0x1,
            XCONFIG_SYSTEM_PREVIOUS_FLASH_VERSION = 0x2,
            XCONFIG_SYSTEM_RGC_AUTH_DELAY = 0x3
        }

        public enum XCONFIG_DEVKIT_ENTRIES : short
        {
            XCONFIG_DEVKIT_DATA = 0x0,
            XCONFIG_DEVKIT_USBD_ROOT_HUB_PORT_DISABLE_MASK = 0x1,
            XCONFIG_DEVKIT_XAM_FEATURE_ENABLE_DISABLE_MASK = 0x2,
            XCONFIG_DEVKIT_KIOSK_ID = 0x3
        }

        public static T ExGetXConfigSetting<T>(XboxConsole Console, XCONFIG_CATEGORY_TYPES Category, short Entry, short SettingSize) where T : struct
        {
            var dwCategory = new XDRPCArgumentInfo<short>((short)Category);
            var dwEntry = new XDRPCArgumentInfo<short>(Entry);
            var pBuffer = new XDRPCStructArgumentInfo<T>(new T(), ArgumentType.Out);
            var cbBuffer = new XDRPCArgumentInfo<short>(SettingSize);
            var szSetting = new XDRPCArgumentInfo<short>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xboxkrnl.exe", 16, dwCategory, dwEntry, pBuffer, cbBuffer, szSetting);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            if (szSetting.Value != SettingSize) throw new XDRPCInvalidResponseException("XDKUtilities.ExGetXConfigSetting: The returned buffer size does not match the expected buffer size.");
            return pBuffer.Value;
        }

        public static byte[] ExGetXConfigSetting(XboxConsole Console, XCONFIG_CATEGORY_TYPES Category, short Entry, short SettingSize)
        {
            var dwCategory = new XDRPCArgumentInfo<short>((short)Category);
            var dwEntry = new XDRPCArgumentInfo<short>(Entry);
            var pBuffer = new XDRPCArrayArgumentInfo<byte[]>(new byte[SettingSize], ArgumentType.ByRef);
            var cbBuffer = new XDRPCArgumentInfo<short>(SettingSize);
            var szSetting = new XDRPCArgumentInfo<short>(0, ArgumentType.Out);
            var returnVal = Console.ExecuteRPC<uint>(XDRPCMode.Title, "xboxkrnl.exe", 16, dwCategory, dwEntry, pBuffer, cbBuffer, szSetting);
            if (returnVal != 0x00000000) throw new COMException("Exception from HRESULT: " + string.Format("0x{0:X}", returnVal), (int)returnVal);
            if (szSetting.Value != SettingSize) throw new XDRPCInvalidResponseException("XDKUtilities.ExGetXConfigSetting: The returned buffer size does not match the expected buffer size.");
            return pBuffer.Value;
        }

        private static uint XConfigCalculateStaticSettingsCheckSum(byte[] Data)
        {
            uint sum = 0;
            for (byte i = 0; i < 0xFC; i++) sum += Data[i + 0x10];
            sum = (~sum) & 0xFFFF;
            return ((sum & 0xFF00) << 8) + ((sum & 0xFF) << 24);
        }
    }
}