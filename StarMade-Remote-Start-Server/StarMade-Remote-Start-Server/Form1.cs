using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace StarMade_Remote_Start_Server
{
    public partial class Form1 : Form
    {
        private const string BAT_SERVER_NAME = "StarMade-dedicated-server-windows.bat";
        private string batFilePath;
        private string whiteListPath;
        private byte[][] allowedIPs;
        private string messageLogs;
        byte[] localhost;
        bool whiteListSet;
        bool batchFileSet;


        public Form1()
        {
            InitializeComponent();
            localhost = IPAddress.Parse("127.0.0.1").GetAddressBytes();
            backgroundWorker1.WorkerReportsProgress = true;

        }

        private void batchFilebtn_Click(object sender, EventArgs e)
        {
            batchFileSet = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                batFilePath = folderBrowserDialog1.SelectedPath;
                batchFileLbl.Text = folderBrowserDialog1.SelectedPath;
                folderBrowserDialog1.Reset();
                batchFileSet = true;
            }
        }

        private void whitelistBtn_Click(object sender, EventArgs e)
        {
            whiteListSet = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                whiteListPath = folderBrowserDialog1.SelectedPath;
                whiteListLbl.Text = folderBrowserDialog1.SelectedPath;
                folderBrowserDialog1.Reset();
                whiteListSet = true;
            }
            whiteListReader ipLoader = new whiteListReader(Path.Combine(whiteListPath, "whitelist.txt"));
            allowedIPs = ipLoader.getJaggedIps();

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (!whiteListSet && !batchFileSet)
            {
                MessageBox.Show("batch file and whitlist.txt locations must be set to in order to start");
            }
            else
            {
                backgroundWorker1.RunWorkerAsync(allowedIPs);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            IPEndPoint messenger = new IPEndPoint(IPAddress.Any, 0);
            bool run = true;
            byte[][] whitelist = (byte[][])e.Argument;
            UdpClient server = new UdpClient(3444);
            serverManager manager = new serverManager(batFilePath, BAT_SERVER_NAME);
            while (run)
            {
                string recievedMessage = Encoding.ASCII.GetString(server.Receive(ref messenger));
                byte[] endIPBytes = IPAddress.Parse(messenger.Address.ToString()).GetAddressBytes();

                if (checkIP(whitelist, endIPBytes))
                {
                    if (recievedMessage == "quit")
                    {
                        run = false;
                        backgroundWorker1.ReportProgress(1, "Command:" + recievedMessage + ", " + DateTime.Now.ToString() + ", Action: Stopped Listening");
                    }
                    else if (recievedMessage == "start")
                    {
                        if (manager.isRunning() != true)
                        {
                            manager.startServer();
                            backgroundWorker1.ReportProgress(1, "Command:" + recievedMessage + ", " + DateTime.Now.ToString() + ", Action: started");
                        }
                        else
                        {
                            backgroundWorker1.ReportProgress(1, "Command:" + recievedMessage + ", " + DateTime.Now.ToString() + ", Action: already started");
                        }
                    }
                }
            }
            server.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            messageLogs += connectionLog.Text;
            connectionLog.Text = "";
            connectionLog.Text = messageLogs + e.UserState.ToString() + "\r\n";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Shutdown successful, no longer accepting remote start commands");
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            UdpClient quitClient = new UdpClient();
            byte[] sendQuit = Encoding.ASCII.GetBytes("quit");

            try
            {
                quitClient.Send(sendQuit, sendQuit.Length, "127.0.0.1", 3444);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to end operation\n" + ex.ToString());
            }
            quitClient.Close();
        }
        private bool checkIP(byte[][] compare, byte[] target)
        {
            if (compare.Length == 0)
            {
                return true;
            }
            else
            {
                foreach (byte[] white in compare)
                {
                    if (white.SequenceEqual(target))
                    {
                        return true;
                    }
                }
                if (localhost.SequenceEqual(target))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
