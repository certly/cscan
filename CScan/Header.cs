﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScan.Components
{
    class Header : Component
    {
        public bool Run(ref CScan.Report report, List<List<KeyValuePair<string, string>>> list)
        {
            list.Add(new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("data", Main.name + " Version " + Main.version),
            });

            list.Add(new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("data", "Running as " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + " on Windows " + Environment.OSVersion.Version),
            });

            report.Add(list);

            return true;
        }
    }
}