using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace StarMade_Remote_Start_Server
{
    class serverManager
    {
        private int processID;
        private string pathToBat;
        private string batFileName;
        //private Process cmdserver;
        //private ProcessStartInfo cmdServerStartInfo;

        public serverManager(string path1, string path2)
        {
            pathToBat = path1;
            batFileName = path2;
        }
        public void startServer()
        {
            Process cmdserver = new Process();
            Directory.SetCurrentDirectory(pathToBat);
            ProcessStartInfo cmdServerStartInfo = new ProcessStartInfo("cmd", "/K " + batFileName);
            cmdServerStartInfo.CreateNoWindow = false;
            cmdServerStartInfo.UseShellExecute = false;
            cmdserver.StartInfo = cmdServerStartInfo;
            cmdserver.Start();
            Thread.Sleep(5000);
            getJavaServerID();
            
        }
        public bool isRunning()
        {
            if (processID != 0)
            {
                try
                {
                    Process.GetProcessById(processID);
                    return true;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
            return false;
        }
        private void getJavaServerID()
        {
            string query = "SELECT ProcessId FROM Win32_Process WHERE Name = 'java.exe' AND CommandLine LIKE '%StarMade%'";

            List<Process> servers = null;
            using (var results = new ManagementObjectSearcher(query).Get())
                servers = results.Cast<ManagementObject>()
                                 .Select(mo => Process.GetProcessById((int)(uint)mo["ProcessId"]))
                                 .ToList();
            processID = servers[0].Id;
        }
    }
}
