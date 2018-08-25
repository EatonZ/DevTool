// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using DevExpress.LookAndFeel;

namespace DevTool.Classes
{
    public static class GlobalVariables
    {
        public static DefaultLookAndFeel DLF = new DefaultLookAndFeel();

        public static string ApplicationName { get { return Assembly.GetEntryAssembly().GetName().Name; } }

        public static AssemblyName ApplicationAssembly { get { return Assembly.GetEntryAssembly().GetName(); } }

        public static string Skin
        {
            get { return DLF.LookAndFeel.SkinName; }
            set { DLF.LookAndFeel.SetSkinStyle(value); }
        }

        public static Version ProgramVersion { get { return Assembly.GetEntryAssembly().GetName().Version; } }

        public static bool IsDebugBuild
        {
            get
            {
                #if DEBUG
                return true;
                #else
                return false;
                #endif
            }
        }

        public static string BuildDate { get { return FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductVersion.Substring(0, 13); } }

        public static DateTime BuildDateReal { get { return DateTime.ParseExact(BuildDate, "yyyy.MM.dd.HH", CultureInfo.InvariantCulture); } }

        public static string BuildDateFriendly { get { return BuildDateReal.ToString("MMMM dd, yyyy - HH tt"); } }

        public static string BuildBitness { get { return Environment.Is64BitProcess ? "64 bit (x64)" : "32 bit (x86)"; } }
    }
}