using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace CScan.Components
{
    internal class Processes : IComponent
    {
        public void Run(ref Report report, List<Dictionary<string, string>> list)
        {
            var processes = Process.GetProcesses();

            var sortedProcesses = processes.OrderBy(process => process.Id).ToList();

            foreach (var process in sortedProcesses)
            {
                if (process.Id == 0)
                {
                    continue;
                }

                string path;
                bool error = false;

                try
                {
                    path = process.MainModule.FileName;
                }
                catch (Win32Exception)
                {
                    path = process.ProcessName;
                }
                catch (InvalidOperationException)
                {
                    path = "";
                    error = true;
                }

                list.Add(new Dictionary<string, string>
                {
                    {"token", "Proc"},
                    {"pid", "(" + process.Id + ")"},
                    {"path", !error ? path : "(could not get path)"}
                });
            }

            report.Add(list);
        }
    }
}