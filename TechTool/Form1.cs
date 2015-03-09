using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;

namespace TechTool
{
    public partial class Form1 : Form
    {
        PcInfo info;
        Script script;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetComputerInfo() {

            info = new PcInfo();
            outputPanel.Text = info.ToString();
        }


        private long GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalFreeSpace; // divide by 1024*1024*1024 for GB
                }
            }
            return -1;
        }


        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(@"test.txt", true);
            file.WriteLine("Test Output");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("test.txt");
            System.Diagnostics.Debug.WriteLine(text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            Process.Start(@"C:\Users\"+info.UserName+@"\AppData\Roaming\Microsoft\Windows\"); //recent docs

            
        }

        public void DoObservations()
        {
            
            int bits = int.Parse(info.OperatingSystemArchitecture.Split('-')[0]);
            float maxRam = 32f;
            //find max memory based on windows version

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetComputerInfo();
            UpdateStartupLists();

            DoObservations();
        }

        public void UpdateStartupLists()
        {
            EnabledStartupList.Items.Clear();
            DisabledStartupList.Items.Clear();
            int id = 0;
            foreach (StartupItem item in info.StartUpItems)
            {
                if (item.Enabled)
                    EnabledStartupList.Items.Add(id+"\t"+item.Name);//+" ( "+item.Value+" )");
                else
                    DisabledStartupList.Items.Add(id + "\t" + item.Name); // + " ( " + item.Value + " )");
                id++;
            }
            
        }

        private void EnabledStartupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse( EnabledStartupList.Items[EnabledStartupList.SelectedIndex].ToString().Split('\t')[0]);
            info.StartUpItems[id].DisableItem();
            UpdateStartupLists();
        }

        private void DisabledStartupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(DisabledStartupList.Items[DisabledStartupList.SelectedIndex].ToString().Split('\t')[0]);
            info.StartUpItems[id].EnableItem();
            UpdateStartupLists();
        }

        private void PurgeStartups_Click(object sender, EventArgs e)
        {
            info.PurgeOldStartups();
            DisabledStartupList.Items.Clear();
        }

        private void EnableAll_Click(object sender, EventArgs e)
        {
            foreach (string item in DisabledStartupList.Items)
            {
                int id = int.Parse(item.ToString().Split('\t')[0]);
                info.StartUpItems[id].EnableItem();
            }
            UpdateStartupLists();
        }

        private void DisableAll_Click(object sender, EventArgs e)
        {
            foreach (string item in EnabledStartupList.Items)
            {
                int id = int.Parse(item.ToString().Split('\t')[0]);
                info.StartUpItems[id].DisableItem();
            }
            UpdateStartupLists();
        }


        private void AddToData(string data){

        }

        private void PasswordButton_Click(object sender, EventArgs e)
        {
            //cmdLine.StartInfo.Arguments = " /K explorer "+path;//"/K control /name Microsoft.DevicesAndPrinters";
            SecurityOutput.Text = info.GetBrowserPasswords();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void malwarescanButton_Click(object sender, EventArgs e)
        {
            SecurityOutput.Text = "Short Malware Scan ...\r\n";
            SecurityOutput.Refresh();
            SecurityOutput.Text += info.VirusScan("Memory", "malware_memory.bat");
            SecurityOutput.Refresh();
            SecurityOutput.Text += info.VirusScan("RootKits", "malware_rk.bat");
            SecurityOutput.Refresh();
            SecurityOutput.Text += info.VirusScan("Smart Scan + pup", "malware_quick.bat");
            SecurityOutput.Refresh();
            SecurityOutput.Text += info.VirusScan("Spyware", "malware_spyware.bat");
            SecurityOutput.Refresh();

            SecurityOutput.Text += "======================\r\nMalware Scan Complete";
            SecurityOutput.Refresh();
        }

        private void fullmalwarescan_Click(object sender, EventArgs e)
        {
            SecurityOutput.Text = "Malware Scan ...\r\n";
            SecurityOutput.Refresh();
            SecurityOutput.Text += info.VirusScan("RootKits", "malware_rk.bat");
            SecurityOutput.Refresh();
            SecurityOutput.Text += info.VirusScan("Full Scan", "malware_full.bat");
            SecurityOutput.Text += "======================\r\nMalware Scan Complete";
            SecurityOutput.Refresh();
        }

    }
}
