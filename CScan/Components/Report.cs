using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace CScan
{
    internal class Report
    {
        protected List<Dictionary<string, string>> lines = new List<Dictionary<string, string>>();

        public void Add(List<Dictionary<string, string>> newLines)
        {
            foreach (var line in newLines)
            {
                lines.Add(line);
            }

            // Add an extra empty line between sections.
            if (newLines.Count > 0)
                lines.Add(new Dictionary<string, string>());
        }

        public string WriteToFile(bool json = false)
        {
            var homeDirectory = Environment.GetCommandLineArgs()[1];

            var path = homeDirectory + "\\Desktop\\" + Main.name + ".txt";

            var report = ToString(json);

            File.WriteAllText(path, report);

            return path;
        }

        public string ToString(bool json = false)
        {
            var output = "";

            if (!json)
            {
                foreach (var line in lines)
                {
                    foreach (var list in line)
                    {
                        if (list.Key != "token" && list.Value != null)
                        {
                            output = output + list.Value + " ";
                        }
                        else if (list.Value != null)
                        {
                            output = output + list.Value + ": ";
                        }
                    }

                    output = output + Environment.NewLine;
                }
            }
            else
            {
                output = ToJson();
            }

            return output;
        }

        public string ToJson()
        {
            return new JavaScriptSerializer().Serialize(lines);
        }
    }
}