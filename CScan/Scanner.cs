using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using CScan.Components;
using Environment = System.Environment;
using System.Linq.Expressions;
using System.Reflection;

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

        public void Scan(Config config) //(ref RichTextBox status, Config config)
        {
            var report = new Report();

            foreach (var component in initializedComponents)
            {
                var componentName = component.GetType().Name;

                if (componentName == "Files" && !config.EnableFiles)
                    continue;

                Status="Running " + componentName + "..." + Environment.NewLine;

                try
                {
                    component.Run(ref report, new List<Dictionary<string, string>>());
                } catch
                {
                    Status = "Failed to run " + componentName + "..." + Environment.NewLine;
                }
            }

            var path = report.WriteToFile(config.EnableJson);

            if (!config.EnableJson)
                Process.Start("notepad.exe", path);

            Status = "Success!";
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

        #region Status Update Subscription
        // This could be moved into the Main class, or this could be called as "new Scanner()."
        // Each have their problems. So here we are going to create an event handler and allow Main
        // to subscribe to that. In which, the statusText will be updated.

        private string _status;

        //Create event handle
        public event System.EventHandler StatusChanged;

        // Notify subscribers that the status changed
        protected virtual void OnStatusChanged()
        { if (StatusChanged != null) StatusChanged((object)Status.ToString(), EventArgs.Empty); }

        public string Status
        {
            get
            { return _status; }

            set
            {
                _status = value;
                OnStatusChanged();
            }
        }

        #endregion
    }
}