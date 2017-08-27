using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace CScan.Components
{
    internal class Header : IComponent
    {
        public void Run(ref Report report, List<Dictionary<string, string>> list)
        {
            list.Add(new Dictionary<string, string>
            {
                {"raw", Main.name + " Version " + Main.version}
            });

            var ci = CultureInfo.InstalledUICulture;

            list.Add(new Dictionary<string, string>
            {
                {
                    "raw",
                    "Running from " + Assembly.GetExecutingAssembly().Location.Substring(0, 3) + " as " +
                    WindowsIdentity.GetCurrent().Name + " on " + DateTime.Now
                }
            });

            list.Add(new Dictionary<string, string>
            {
                {"raw", "Windows Version " + WmiQuery("Version") + MinorRevision() + " Language " + ci.EnglishName}
            });

            var totalMemory = (int) Math.Round(double.Parse(WmiQuery("TotalVisibleMemorySize")));
            totalMemory = totalMemory/1000000;

            var freeMemory = double.Parse(WmiQuery("FreePhysicalMemory"));
            freeMemory = freeMemory/1000000;

            list.Add(new Dictionary<string, string>
            {
                {
                    "raw",
                    totalMemory.ToString("N0") + "GB RAM installed; " + freeMemory.ToString("N1") + "GB RAM available"
                }
            });

            report.Add(list);
        }

        private string MinorRevision()
        {
            using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                if (key.GetValue("UBR") == null) {
                    return "";
                }

                return "." + key.GetValue("UBR").ToString(); // What the fuck?
            }
        }

        private string WmiQuery(string parameter)
        {
            var searcher = new ManagementObjectSearcher("SELECT " + parameter + " FROM Win32_OperatingSystem");

            foreach (ManagementObject entry in searcher.Get())
            {
                return entry.GetPropertyValue(parameter).ToString();
            }

            return null;
        }
    }
}