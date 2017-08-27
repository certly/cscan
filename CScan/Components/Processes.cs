using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace CScan.Components
{
    internal class Processes : IComponent
    {
        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

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
                string publisher = "";
                bool error = false;

                try
                {
                    path = process.MainModule.FileName;
                    publisher = FileInspector.GetPublisher(path);
                }
                catch (Win32Exception)
                {
                    continue;
                }
                catch (InvalidOperationException)
                {
                    path = "";
                    error = true;
                }

                list.Add(new Dictionary<string, string>
                {
                    {"token", "Proc"},
                    {"publisher", !error ? "(" + publisher + ")" : ""},
                    {"path", !error ? path : "(could not get path)"},
                    {"pid", "[" + process.Id + "]"},
                });
            }

            report.Add(list);
        }
    }
}