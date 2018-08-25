// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

namespace DevTool.Classes
{
    public static class XUID
    {
        public static bool IsOfflineXUID(ulong XUID) { return (XUID & 0xF000000000000000) == 0xE000000000000000; }

        public static bool IsOnlineXUID(ulong XUID) { return (XUID & 0xFFFF000000000000) == 0x0009000000000000; }

        public static bool IsTeamXUID(ulong XUID) { return (XUID & 0xFF00000000000000) == 0xFE00000000000000; }

        public static bool IsGuestXUID(ulong XUID)
        {
            var highPart = (uint)(XUID >> 48);
            return ((highPart & 0xF) == 0x9) && ((highPart & 0xC0) > 0);
        }

        public static bool IsValidXUID(ulong XUID)
        {
            if (IsOfflineXUID(XUID)) return true;
            if (IsOnlineXUID(XUID)) return true;
            if (IsTeamXUID(XUID)) return true;
            if (IsGuestXUID(XUID)) return true;
            return false;
        }
    }
}