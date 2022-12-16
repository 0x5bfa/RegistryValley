﻿using System.Runtime.CompilerServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace RegistryValley.Core.Helpers
{
    public static class RegistryServices
    {
        public static Win32Error RegValleyOpenKey(HKEY hkey, string subRoot, REGSAM samDesired, out HKEY phkResult, bool use86Arch = false)
        {
            // If specified machine, should use RegConnectRegistry
            var result = RegOpenKeyEx(hkey, subRoot, 0, samDesired, out var phkRes);

            if (result.Succeeded)
                phkResult = phkRes;
            else
                phkResult = HKEY.NULL;

            return result;
        }

        public unsafe static ref T NullRef<T>()
        {
            return ref Unsafe.AsRef<T>(null);
        }
    }
}
