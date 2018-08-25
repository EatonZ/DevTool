// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace DevTool.Classes
{
    public static class XtraFunctions
    {
        #region Data Manipulation

        public static byte[] GetData(byte[] Source, int Offset, int Count)
        {
            var dest = new byte[Count];
            Buffer.BlockCopy(Source, Offset, dest, 0, Count);
            return dest;
        }

        public static double ComputePercentage(long Current, long Total) { return (double)Current * 100 / Total ; }

        public static string ByteArrayToString(byte[] ByteArray) { return BitConverter.ToString(ByteArray).Replace("-", string.Empty); }

        public static byte[] ReadAllBytes(Stream Stream)
        {
            Stream.Position = 0;
            var stream = Stream as MemoryStream;
            if (stream != null) return stream.ToArray();
            using (var ms = new MemoryStream())
            {
                Stream.CopyTo(ms, 0x2000);
                ms.Flush();
                return ms.ToArray();
            }
        }

        public static string FormatSize(long FileSize)
        {
            if (FileSize <= 0) return "0 bytes";
            if (FileSize >= Math.Pow(2.0, 80.0)) return string.Format("{0} YB", Math.Round(FileSize / Math.Pow(2.0, 80.0), 2));
            if (FileSize >= Math.Pow(2.0, 70.0)) return string.Format("{0} ZB", Math.Round(FileSize / Math.Pow(2.0, 70.0), 2));
            if (FileSize >= Math.Pow(2.0, 60.0)) return string.Format("{0} EB", Math.Round(((FileSize) / Math.Pow(2.0, 60.0)), 2));
            if (FileSize >= Math.Pow(2.0, 50.0)) return string.Format("{0} PB", Math.Round(((FileSize) / Math.Pow(2.0, 50.0)), 2));
            if (FileSize >= Math.Pow(2.0, 40.0)) return string.Format("{0} TB", Math.Round(((FileSize) / Math.Pow(2.0, 40.0)), 2));
            if (FileSize >= Math.Pow(2.0, 30.0)) return string.Format("{0} GB", Math.Round(((FileSize) / Math.Pow(2.0, 30.0)), 2));
            if (FileSize >= Math.Pow(2.0, 20.0)) return string.Format("{0} MB", Math.Round(((FileSize) / Math.Pow(2.0, 20.0)), 2));
            return ((FileSize >= Math.Pow(2.0, 10.0)) ? string.Format("{0} KB", Math.Round(((FileSize) / Math.Pow(2.0, 10.0)), 2)) : string.Format("{0} bytes", FileSize));
        }

        public static string FormatSize(ulong FileSize)
        {
            if (FileSize == 0) return "0 bytes";
            if (FileSize >= Math.Pow(2.0, 80.0)) return string.Format("{0} YB", Math.Round(FileSize / Math.Pow(2.0, 80.0), 2));
            if (FileSize >= Math.Pow(2.0, 70.0)) return string.Format("{0} ZB", Math.Round(FileSize / Math.Pow(2.0, 70.0), 2));
            if (FileSize >= Math.Pow(2.0, 60.0)) return string.Format("{0} EB", Math.Round(((FileSize) / Math.Pow(2.0, 60.0)), 2));
            if (FileSize >= Math.Pow(2.0, 50.0)) return string.Format("{0} PB", Math.Round(((FileSize) / Math.Pow(2.0, 50.0)), 2));
            if (FileSize >= Math.Pow(2.0, 40.0)) return string.Format("{0} TB", Math.Round(((FileSize) / Math.Pow(2.0, 40.0)), 2));
            if (FileSize >= Math.Pow(2.0, 30.0)) return string.Format("{0} GB", Math.Round(((FileSize) / Math.Pow(2.0, 30.0)), 2));
            if (FileSize >= Math.Pow(2.0, 20.0)) return string.Format("{0} MB", Math.Round(((FileSize) / Math.Pow(2.0, 20.0)), 2));
            return ((FileSize >= Math.Pow(2.0, 10.0)) ? string.Format("{0} KB", Math.Round(((FileSize) / Math.Pow(2.0, 10.0)), 2)) : string.Format("{0} bytes", FileSize));
        }

        public static Bitmap ResizeImage(Image Image, int Width, int Height)
        {
            var result = new Bitmap(Width, Height);
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(Image, 0, 0, result.Width, result.Height);
            }
            return result;
        }

        public static string ValueToHex(long Value) { return string.Format("0x{0:X}", Value); }

        public static string ValueToHex(ulong Value) { return string.Format("0x{0:X}", Value); }

        public static ulong ValueFromHex(string Value)
        {
            if (Value.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) Value = Value.Substring(2);
            return ulong.Parse(Value, NumberStyles.HexNumber);
        }

        #endregion

        #region Timestamps

        public static DateTime UnixTime(uint UnixTimestamp)
        {
            try { return new DateTime(1970, 1, 1).AddSeconds(UnixTimestamp); }
            catch (Exception) { return DateTime.MinValue; }
        }

        #endregion

        #region Other

        public static string CreateTimePassedString(TimeSpan Span)
        {
            var delta = Math.Abs(Span.TotalSeconds);
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            if (delta < 0) return "not yet";
            if (delta < 1 * MINUTE) return Span.Seconds == 1 ? "1 second ago" : Span.Seconds + " seconds ago";
            if (delta < 2 * MINUTE) return "1 minute ago";
            if (delta < 45 * MINUTE) return Span.Minutes + " minutes ago";
            if (delta < 90 * MINUTE) return "1 hour ago";
            if (delta < 24 * HOUR) return Span.Hours + " hours ago";
            if (delta < 48 * HOUR) return "yesterday";
            if (delta < 30 * DAY) return Span.Days + " days ago";
            if (delta < 12 * MONTH)
            {
                var months = Convert.ToInt32(Math.Floor((double)Span.Days / 30));
                return months <= 1 ? "about 1 month ago" : string.Format("about {0} months ago", months);
            }
            else
            {
                var years = Convert.ToInt32(Math.Floor((double)Span.Days / 365));
                return years <= 1 ? "about 1 year ago" : string.Format("about {0} years ago", years);
            }
        }

        public static void InvokeEx<T>(T @Object, Action<T> Action) where T : ISynchronizeInvoke
        {
            if (@Object.InvokeRequired) @Object.Invoke(Action, new object[] { @Object });
            else Action(@Object);
        }

        public static bool IsValidBase16String(string String)
        {
            if (string.IsNullOrEmpty(String)) return false;
            return String.Length % 2 == 0 && String.All(t => t.ToString().ToUpper().IndexOfAny(new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'}) != -1);
        }

        public static int FindProcess(string ProcessName) => Process.GetProcesses().Count(process => string.Compare(process.ProcessName, ProcessName, StringComparison.OrdinalIgnoreCase) == 0);

        #endregion

        #region Native

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int StrCmpLogicalW(string psz1, string psz2);

        #endregion
    }
}