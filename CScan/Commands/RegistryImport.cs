using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace CScan.Commands
{
    internal class RegistryImport : ICommand
    {
        public List<Dictionary<string, string>> Run(List<string> arguments, List<Dictionary<string, string>> list)
        {
            var tempFile = Path.GetTempFileName();
            arguments.Insert(0, "Windows Registry Editor Version 5.00");

            File.WriteAllLines(tempFile, arguments.ToArray());

            var process = Process.Start("reg.exe", "import " + "\"" + Regex.Replace(tempFile, @"(\\+)$", @"$1$1") + "\"");
            process.WaitForExit();

            File.Delete(tempFile);

            list.Add(new Dictionary<string, string>
            {
                {"token", "Registry"},
                {"path", "Merged successfully"}
            });

            return list;
        }
    }
}