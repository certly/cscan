using System.Collections.Generic;

namespace CScan.Whitelist
{
    internal class DriverWhitelist
    {
        private static readonly Dictionary<string, string> whitelist = new Dictionary<string, string>
        {
            {@"\??\C:\Program Files\NVIDIA Corporation\NvStreamSrv\NvStreamKms.sys", "NvStreamKms"},
            {@"\??\C:\WINDOWS\system32\drivers\cbfs6.sys", "cbfs6"},
            {@"\??\C:\WINDOWS\system32\drivers\hcmon.sys", "VMware hcmon"},
            {@"\??\C:\Windows\system32\drivers\KeyAgent.sys", "KeyAgent"},
            {@"\??\C:\Windows\system32\drivers\MacHALDriver.sys", "Mac HAL"},
            {@"C:\WINDOWS\system32\drivers\1394ohci.sys", "1394 OHCI Compliant Host Controller"},
            {@"C:\WINDOWS\system32\drivers\3ware.sys", "3ware"},
            {@"C:\WINDOWS\system32\drivers\ACPI.sys", "Microsoft ACPI Driver"},
            {@"C:\WINDOWS\system32\drivers\acpials.sys", "ALS Sensor Filter"},
            {@"C:\WINDOWS\system32\drivers\AcpiDev.sys", "ACPI Devices driver"},
            {@"C:\WINDOWS\system32\Drivers\acpiex.sys", "Microsoft ACPIEx Driver"},
            {@"C:\WINDOWS\system32\DRIVERS\ahcache.sys", "Application Compatibility Cache"},
            {@"C:\WINDOWS\system32\drivers\bridge.sys", "Microsoft MAC Bridge"},
            {@"C:\WINDOWS\system32\Drivers\cng.sys", "CNG"},
            {@"C:\WINDOWS\system32\drivers\disk.sys", "Disk Driver"},
            {@"C:\WINDOWS\system32\DRIVERS\drmkaud.sys", "Microsoft Trusted Audio Drivers"},
            {@"C:\WINDOWS\system32\DRIVERS\fvevol.sys", "BitLocker Drive Encryption Filter Driver"},
            {@"C:\WINDOWS\system32\drivers\xboxgip.sys", "Xbox Game Input Protocol Driver"},
        };

        public static bool IsWhitelisted(string key, string value, bool keyIsSignedFile = false)
        {
            if (whitelist.ContainsKey(key) && whitelist[key] == value)
            {
                return !keyIsSignedFile || keyIsSignedFile && Authenticode.IsSigned(key);
            }

            return false;
        }
    }
}