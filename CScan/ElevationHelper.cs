using Microsoft.Win32;
using System.IO;
using System.Threading;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CScan
{
    internal class ElevationHelper
    {
        const string MASTER_MUTEX = "cscanmaster";
        const string CLIENT_MUTEX = "cscanclient";

        Mutex masterMutex;
        Mutex clientMutex;

        bool isMaster;
        bool isClient;

        public ElevationHelper()
        {
            if (!AttemptMasterLock() && !AttemptClientLock())
            {
                throw new System.Exception("Could not lock client or master.");
            }
        }

        public bool Elevate()
        {
            if (isClient || Debugger.IsAttached)
            {
                return true;
            }

            ElevateFromMaster();

            /* We need to keep our lock on the master mutex until the client is alive. */
            bool clientLaunched = false;
            while (!clientLaunched)
            {
                var loopSuccess = true;

                try
                {
                    Mutex.OpenExisting(CLIENT_MUTEX);
                } catch
                {
                    loopSuccess = false;
                }

                clientLaunched = loopSuccess;
            }

            Environment.Exit(0);

            return true;
        }

        private bool ElevateFromMaster()
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "psexec.exe");
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }

            var file = File.Open(tempPath, FileMode.CreateNew);
 
            file.Write(Resources.PsExec, 0, Resources.PsExec.Length);
            file.Close();

            var selfPath = Process.GetCurrentProcess().MainModule.FileName;
            selfPath = "\"" + Regex.Replace(selfPath, @"(\\+)$", @"$1$1") + "\"";

            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            userPath = "\"" + Regex.Replace(userPath, @"(\\+)$", @"$1$1") + "\"";

            var psi = new ProcessStartInfo(tempPath, "-i -s " + selfPath + " " + userPath)
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            using (var process = Process.Start(psi))
            {
                process.WaitForExit(1000);
            }

            return true;
        }

        public bool AttemptClientLock()
        {
            clientMutex = new Mutex(true, CLIENT_MUTEX, out isClient);
            return isClient;
        }

        public bool AttemptMasterLock()
        {
            masterMutex = new Mutex(true, MASTER_MUTEX, out isMaster);
            return isMaster;
        }
    }
}