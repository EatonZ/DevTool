// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using DevExpress.Utils.Taskbar.Core;

namespace DevTool.Classes
{
    public static class WindowsTaskbarHelper
    {
        #region Fields and Properties

        //Extremely rare cases of people having corrupt systems where setting taskbar progress throws errors.
        private static bool cantInteractWithTaskbar;

        public static IntPtr MainWindowHandle { get; set; }

        #endregion

        #region Methods

        public static void SetProgressState(TaskbarButtonProgressMode State)
        {
            if (!cantInteractWithTaskbar && MainWindowHandle != IntPtr.Zero)
            {
                try { TaskbarHelper.SetProgressState(MainWindowHandle, State); }
                catch (Exception) { cantInteractWithTaskbar = true; }
            }
        }

        public static void SetProgressValue(long CurrentValue, long MaximumValue)
        {
            if (!cantInteractWithTaskbar && MainWindowHandle != IntPtr.Zero)
            {
                if (CurrentValue < 0 || MaximumValue < 0 || CurrentValue > MaximumValue) throw new Exception($"WindowsTaskbarHelper.SetProgressValue: Incorrect parameters - Cur: {CurrentValue}, Max: {MaximumValue}.");
                try { TaskbarHelper.SetProgressValue(MainWindowHandle, CurrentValue, MaximumValue); }
                catch (Exception) { cantInteractWithTaskbar = true; }
            }
        }

        public static void SetProgressValue(ulong CurrentValue, ulong MaximumValue)
        {
            if (!cantInteractWithTaskbar && MainWindowHandle != IntPtr.Zero)
            {
                if (CurrentValue > MaximumValue) throw new Exception($"WindowsTaskbarHelper.SetProgressValue: Incorrect parameters - Cur: {CurrentValue}, Max: {MaximumValue}.");
                try { TaskbarHelper.SetProgressValue(MainWindowHandle, CurrentValue, MaximumValue); }
                catch (Exception) { cantInteractWithTaskbar = true; }
            }
        }

        #endregion
    }
}