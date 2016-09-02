using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using CScan.Components;
using Environment = System.Environment;

namespace CScan
{
    internal class Scanner
    {
        protected string[] components =
        {
            "Header",
            "SecurityCenter",
            "DisabledApplications",
            "IEProxy",
            "Processes",
            "Environment",
            "Shell",
            "IFEO",
            "RegistryRun",
            "Browser.Chrome",
            "Browser.Firefox",
            "HiJackThis.O2",
            "HiJackThis.O3",
            "HiJackThis.O20",
            "HiJackThis.O21",
            "Hosts",
            "Services",
            "Drivers",
            "Disks",
            "Signatures",
            "Programs",
            "Files"
        };

        protected List<IComponent> initializedComponents = new List<IComponent>();

        public Scanner()
        {
            InitializeComponents();
        }

        public void Scan(ref RichTextBox status, Config config)
        {
            var report = new Report();

            foreach (var component in initializedComponents)
            {
                var componentName = component.GetType().Name;

                if (componentName == "Files" && !config.EnableFiles)
                    continue;

                status.Text = status.Text + "Running " + componentName + "..." + Environment.NewLine;

                var watch = Stopwatch.StartNew();

                component.Run(ref report, new List<Dictionary<string, string>>());

                watch.Stop();
            }

            var path = report.WriteToFile(config.EncryptionKey, config.EnableJson);

            if (!config.EnableJson)
                Process.Start("notepad.exe", path);

            status.Text = status.Text + "Success!";
        }

        protected void InitializeComponents()
        {
            foreach (var component in components)
            {
                var t = Type.GetType("CScan.Components." + component);

                var initializedComponent = (IComponent) Activator.CreateInstance(t);

                initializedComponents.Add(initializedComponent);
            }
        }
    }
}