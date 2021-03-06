﻿using System.Collections.Generic;
using Microsoft.Win32;

namespace CScan.Components
{
    internal class Shell : IComponent
    {
        public void Run(ref Report report, List<Dictionary<string, string>> list)
        {
            var registryKey = @"Software\Microsoft\Windows NT\CurrentVersion\Winlogon";

            var splitKeys = registryKey.Split('\\');

            var lastKey = splitKeys[splitKeys.Length - 1];

            using (var key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                var shell = (string) key.GetValue("Shell");
                var userinit = (string) key.GetValue("Userinit");

                if (shell != null)
                {
                    list.Add(
                        new Dictionary<string, string>
                        {
                            {"token", "Shell"},
                            {"key", @"HKLM\..\Winlogon: [Shell]"},
                            {"value", shell}
                        }
                        );
                }

                if (userinit != null)
                {
                    list.Add(
                        new Dictionary<string, string>
                        {
                            {"token", "Shell"},
                            {"key", @"HKLM\..\Winlogon: [Userinit]"},
                            {"value", userinit}
                        }
                        );
                }
            }

            using (var key = Registry.CurrentUser.OpenSubKey(registryKey))
            {
                var shell = (string) key.GetValue("Shell");
                var userinit = (string) key.GetValue("Userinit");

                if (shell != null)
                {
                    list.Add(
                        new Dictionary<string, string>
                        {
                            {"token", "Shl"},
                            {"key", @"HKCU\..\Winlogon: [Shell]"},
                            {"value", shell}
                        }
                        );
                }

                if (userinit != null)
                {
                    list.Add(
                        new Dictionary<string, string>
                        {
                            {"token", "Shl"},
                            {"key", @"HKCU\..\Winlogon: [Userinit]"},
                            {"value", userinit}
                        }
                        );
                }
            }

            report.Add(list);
        }
    }
}