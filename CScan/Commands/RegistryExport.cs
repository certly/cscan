using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace CScan.Commands
{
    internal class RegistryExport : ICommand
    {
        public List<Dictionary<string, string>> Run(List<string> arguments, List<Dictionary<string, string>> list)
        {
            foreach (var key in arguments)
            {
                var tempFile = Path.GetTempFileName();

                var process = Process.Start("reg.exe", "export " + "\"" + Regex.Replace(key, @"(\\+)$", @"$1$1") + "\" " + "\"" + Regex.Replace(tempFile, @"(\\+)$", @"$1$1") + "\" /y");
                process.WaitForExit();

                var text = File.ReadAllText(tempFile);

                list.Add(new Dictionary<string, string>
                {
                    {"token", "Registry"},
                    {"key", key},
                    {"text", Environment.NewLine + text},
                });
            }

            return list;
        }
    }
}