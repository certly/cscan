using CScan;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace CScan.Commands
{
    internal class Signature : ICommand
    {
        public List<Dictionary<string, string>> Run(List<string> arguments, List<Dictionary<string, string>> list)
        {
            foreach (string file in arguments)
            {
                if (!File.Exists(file))
                {
                    list.Add(new Dictionary<string, string>
                    {
                        {"token", "Signature"},
                        {"raw", "Could not find " + file },
                    });

                    continue;
                }

                bool isSigned = Authenticode.IsSigned(file);

                list.Add(new Dictionary<string, string>
                {
                    {"token", "Signature"},
                    {"raw", file + " is" + (isSigned ? " " : " not ") + "signed"},
                });
            }

            return list;
        }
    }
}