using System.Collections.Generic;
using System.IO;
using System.Management;
using CScan.Whitelist;

namespace CScan.Components
{
    internal class Drivers : IComponent
    {
        public void Run(ref Report report, List<Dictionary<string, string>> list)
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SystemDriver");

            foreach (ManagementObject entry in searcher.Get())
            {
                if (entry.GetPropertyValue("PathName") != null)
                {
                    var description = entry.GetPropertyValue("Description").ToString().Trim();
                    var path = entry.GetPropertyValue("PathName").ToString().Trim();

                    var exists = File.Exists(path);

                    if (DriverWhitelist.IsWhitelisted(path, description))
                    {
                        continue;
                    }

                    var signed = !exists || Authenticode.IsSigned(path);

                    list.Add(new Dictionary<string, string>
                    {
                        {"token", "Drv"},
                        {"path", path},
                        {"description", "(" + entry.GetPropertyValue("Description") + ")"},
                        {"exists", !exists ? "[b](file not found)[/b]" : null},
                        {"signed", !signed ? "[b](file not signed)[/b]" : null},
                    });
                }
            }

            list.Sort((entry1, entry2) => entry1["path"].CompareTo(entry2["path"]));

            report.Add(list);
        }
    }
}