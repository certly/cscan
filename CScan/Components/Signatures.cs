using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CScan.Components
{
    internal class Signatures : IComponent
    {
        public readonly string[] files =
        {
            @"C:\Windows\explorer.exe",
            @"C:\Windows\System32\userinit.exe",
            @"C:\Windows\System32\svchost.exe",
            @"C:\Windows\System32\wininit.exe",
            @"C:\Windows\System32\Drivers\volsnap.sys",
            @"C:\Windows\System32\User32.dll",
            @"C:\Windows\System32\dllhost.exe",
            Assembly.GetExecutingAssembly().Location
        };

        public void Run(ref Report report, List<Dictionary<string, string>> list)
        {
            foreach (var file in files)
            {
                var exists = File.Exists(file);

                list.Add(new Dictionary<string, string>
                {
                    {"token", "Sig"},
                    {"file", file},
                    {"signed", exists
                            ? !Authenticode.IsSigned(file, true) ? "[b]is not signed[/b]" : "is signed"
                            : "[b]does not exist[/b]"
                    }
                });
            }

            report.Add(list);
        }
    }
}