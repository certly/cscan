using System.Collections.Generic;
using Microsoft.Win32;
using System.Linq;

namespace CScan.Components
{
    internal class Programs : IComponent
    {
        public void Run(ref Report report, List<Dictionary<string, string>> list)
        {
            var registryKey = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

            foreach (var result in RegistryWrapper.RegistryWrapper.QuerySubKey(RegistryHive.LocalMachine, registryKey))
            {
                foreach (var subKeyName in result.key.GetSubKeyNames())
                {
                    using (var subKey = result.key.OpenSubKey(subKeyName))
                    {
                        var displayName = (string) subKey.GetValue("DisplayName");
                        var hidden = subKey.GetValue("SystemComponent") != null;
                        var publisher = (string)subKey.GetValue("Publisher");

                        if (displayName != null)
                        {
                            list.Add(new Dictionary<string, string>
                            {
                                {"token", "Prg"},
                                {"hive", @"[HKLM]"},
                                {"publisher", "(" + publisher + ")"},
                                {"display_name", displayName},
                                {"is_hidden", hidden ? "[b](Hidden)[/b]" : null}
                            });
                        }
                    }
                }
            }

            foreach (var result in RegistryWrapper.RegistryWrapper.QuerySubKey(RegistryHive.CurrentUser, registryKey))
            {
                foreach (var subKeyName in result.key.GetSubKeyNames())
                {
                    using (var subKey = result.key.OpenSubKey(subKeyName))
                    {
                        var displayName = (string)subKey.GetValue("DisplayName");
                        var hidden = subKey.GetValue("SystemComponent") != null;
                        var publisher = (string)subKey.GetValue("Publisher");

                        if (displayName != null)
                        {
                            list.Add(new Dictionary<string, string>
                            {
                                {"token", "Prg"},
                                {"hive", @"[HKCU]"},
                                {"publisher", "(" + publisher + ")"},
                                {"display_name", displayName},
                                {"is_hidden", hidden ? "[b](Hidden)[/b]" : null}
                            });
                        }
                    }
                }
            }

            list.Sort((entry1, entry2) => entry1["display_name"].CompareTo(entry2["display_name"]));

            report.Add(list);
        }
    }
}