using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Management;


namespace TechTool
{
    class PcInfo
    {
        public String OperatingSystem { get; set; }
        public String OperatingSystemBuild { get; set; }
        public String OperatingSystemVersion { get; set; }
        public String OperatingSystemArchitecture{ get; set; }

        public String Language { get; set; }
        public String OwnerName { get; set; }
        public string UserName { get; set; }

        public String ComputerName { get; set; }
        public String MoboVendor { get; set; }
        public String MoboVersion { get; set; }
        public String BiosVendor { get; set; }
        public String BiosVersion { get; set; }
        public String Processor { get; set; }

        public int ProcessorCores { get; set; }
        public int ProcessorThreads { get; set; }

        public long MainDriveCapacity { get; set; }
        public long MainDriveUsed { get; set; }

        public long RamCapacity { get; set; }
        public long RamUsed { get; set; }
        public int RamSlotCount { get; set; }
        public string RamConfig { get; set; }
        public List<string> RamSlot = new List<string>();

        public List<string> VideoCards = new List<string>();
        public List<string> AudioCards = new List<string>();
        public List<string> InstalledApps = new List<string>();
        public List<StartupItem> StartUpItems = new List<StartupItem>();
        public List<string> AntivirusPrograms = new List<string>();
        public List<Password> Passwords = new List<Password>();
        public int ProcessCount { get; set; }


        public DriveInfo[] Drives { get; set; }

        private List<string> StartupRegLocations = new List<string>();

        public PcInfo(){
            GetData();
        }


        /*use registy and vb device to grab details*
         *must add reference to Microsoft.VisualBasic in references
         */
        public void GetData () {
            Microsoft.VisualBasic.Devices.ComputerInfo info = new Microsoft.VisualBasic.Devices.ComputerInfo();

            UserName = Environment.UserName;
            const string OSPATH = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            //OperatingSystem = (string)Registry.GetValue(OSPATH,"ProductName",null);
            //OperatingSystemBuild = (string)Registry.GetValue(OSPATH, "CurrentBuild", null);
            //OperatingSystemVersion = (string)Registry.GetValue(OSPATH, "CurrentVersion", null);

            OperatingSystem = info.OSFullName;
            OperatingSystemBuild = info.OSPlatform;
            OperatingSystemVersion = info.OSVersion;
            OwnerName = (string)Registry.GetValue(OSPATH, "RegisteredOwner", null);

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem").Get())
            {
                OperatingSystemArchitecture = item["OSArchitecture"].ToString();
            }

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem").Get())
            {
                ProcessCount = int.Parse(item["NumberOfProcesses"].ToString());
            }

            const string BIOSPATH = @"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\BIOS";
            MoboVendor = (string)Registry.GetValue(BIOSPATH, "BaseBoardManufacturer", null);
            MoboVersion = (string)Registry.GetValue(BIOSPATH, "BaseBoardProduct", null);
            BiosVendor = (string)Registry.GetValue(BIOSPATH, "BIOSVendor", null);
            BiosVersion = (string)Registry.GetValue(BIOSPATH, "BIOSVersion", null);

            const string CPUPATH = @"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\CentralProcessor";
            Processor = (string)Registry.GetValue(CPUPATH + @"\0", "ProcessorNameString", null);

            ComputerName = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName", "ComputerName", null);
            Drives = DriveInfo.GetDrives();
            Language = info.InstalledUICulture.ToString();
            
            GetRamConfig();

            ProcessorCores = 0;
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get()) {
                ProcessorCores += int.Parse(item["NumberOfCores"].ToString());
            }

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get()) {
                ProcessorThreads= int.Parse(item["NumberOfLogicalProcessors"].ToString());
            }

            SelectQuery queryVideo = new SelectQuery("Win32_VideoController");
            ManagementObjectSearcher searchVideo = new ManagementObjectSearcher(queryVideo);
            foreach (ManagementObject video in searchVideo.Get()){  
                VideoCards.Add(video["Name"].ToString());
            }

            SelectQuery queryAudio = new SelectQuery("Win32_SoundDevice");
            ManagementObjectSearcher searchAudio = new ManagementObjectSearcher(queryAudio);
            foreach (ManagementObject audio in searchAudio.Get())
            {
                AudioCards.Add(audio["Name"].ToString());
            }

            CheckInstalledApplications();

            CheckStartUpApplications();

            GetAntivirusInfo();
        }

        /*return description of ram configuration*/
        public string GetRamConfig()
        {
            Microsoft.VisualBasic.Devices.ComputerInfo info = new Microsoft.VisualBasic.Devices.ComputerInfo();

            RamCapacity = (long)info.TotalPhysicalMemory;
            RamUsed = RamCapacity - (long)info.AvailablePhysicalMemory;

            string ramConfig = "";
            string detail = new Script().RunApp("memory_info.bat");
            string [] lines = detail.Split(new Char [] {'\n','\r','='},StringSplitOptions.RemoveEmptyEntries);
            //set class data
            lines[0] = lines[3] = "";
            //RamConfig = String.Join(",",lines);
            System.Diagnostics.Debug.WriteLine(RamConfig);
            RamSlotCount = int.Parse(lines[2].Trim());
            RamSlot.Clear();
            for (int i = 5; i < lines.Length; i += 10)
            {
                long ramSize= long.Parse(lines[i+2]) / 1073741824;
                string slotInfo = lines[i] + ": " + lines[i + 6] + " "+ ramSize.ToString() + "GB";
                ramConfig += slotInfo + "\r\n";
                RamSlot.Add(slotInfo);
            }
            //make info string

            return ramConfig;
        }

        /*get antivirus info*/
        public void GetAntivirusInfo()
        {
            string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
            var searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
            var instances = searcher.Get();
            foreach (var instance in instances)
            {
                //Console.WriteLine();
                AntivirusPrograms.Add(instance.GetPropertyValue("displayName").ToString());
                //System.Diagnostics.Debug.WriteLine(instance.GetPropertyValue("displayName"));
            }
        }

        public string VirusScan (string scantype, string batchfile){
            string report = scantype +"\r\n";
            string results = new Script().RunApp(batchfile);
            string [] lines = results.Split('\n');
            report += lines[lines.Length - 8] + "\r\n";
            report += lines[lines.Length - 7] + "\r\n";
            return report;
        }

        /*populate list with key values of startup item reg entries*/
        public void CheckStartUpApplications()
        {
            
            StartupRegLocations.Add(@"Software\Microsoft\Windows\CurrentVersion\Run");
            StartupRegLocations.Add(@"Software\Microsoft\Windows\CurrentVersion\RunOnce");
            StartupRegLocations.Add(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run");
            StartupRegLocations.Add(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\RunOnce");
            StartupRegLocations.Add(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run");
            StartupRegLocations.Add(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\RunOnce");
            StartupRegLocations.Add(@"Software\Microsoft\Windows\CurrentVersion\RunService");
            StartupRegLocations.Add(@"Software\Microsoft\Windows\CurrentVersion\RunServiceOnce");
            StartupRegLocations.Add(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon\Userinit");

            foreach (string location in StartupRegLocations)
            {
                AddToStartups(location);
            }
        }

        /*clean backup copies of keys from techtooldisabled folders*/
        public void PurgeOldStartups()
        {
            List<string> hives = new List<string>();
            hives.Add("HKLM");
            hives.Add("HKCU");
            hives.Add("HKLM64");
            hives.Add("HKCU64");

            foreach (string registryKey in StartupRegLocations)
            {
                //after initial scan check sub folders for disabled startups, TechToolDisabled ... and other applications such as autoruns
                List<string> disabledFolders = new List<string>();
                disabledFolders.Add("TechToolDisabled");

                foreach (string folder in disabledFolders)
                {
                    foreach (string hive in hives)
                    {
                        RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey,true);
                        switch (hive)
                        {
                            case "HKLM":
                                key = Registry.LocalMachine.OpenSubKey(registryKey,true); ;
                                break;
                            case "HKCU":
                                key = Registry.CurrentUser.OpenSubKey(registryKey,true );
                                break;
                            //64 bit versions
                            case "HKLM64":
                                RegistryKey rb = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                                key = rb.OpenSubKey(registryKey,true);
                                break;
                            case "HKCU64":
                                RegistryKey rb2 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                                key = rb2.OpenSubKey(registryKey,true);
                                break;
                        } //end switch

                        if (key != null)
                        {
                            try
                            {
                                key.DeleteSubKey(folder);
                            }
                            catch
                            {
                                //dont stress
                            }
                        }

                    } //end foreach hives
                } //end foreach disabled folder   
            }//for each registrykey
        }

        private void AddToStartups(string registryKey)
        {
            //*
            bool EnabledSwitch =true;
            List <string> hives=new List<string>();
            hives.Add("HKLM");
            hives.Add("HKCU");
            hives.Add("HKLM64");
            hives.Add("HKCU64");

            //after initial scan check sub folders for disabled startups, TechToolDisabled ... and other applications such as autoruns
            List<string> disabledFolders = new List<string>();
            disabledFolders.Add("");
            disabledFolders.Add(@"\TechToolDisabled");
            
            foreach (string folder in disabledFolders)
            {
                foreach (string hive in hives)
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);

                    switch (hive)
                    {
                        case "HKLM":
                            key = Registry.LocalMachine.OpenSubKey(registryKey+folder); ;
                            break;
                        case "HKCU":
                            key = Registry.CurrentUser.OpenSubKey(registryKey + folder);
                            break;
                        //64 bit versions
                        case "HKLM64":
                            RegistryKey rb = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                            key = rb.OpenSubKey(registryKey + folder);
                            break;
                        case "HKCU64":
                            RegistryKey rb2 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                            key = rb2.OpenSubKey(registryKey + folder);
                            break;
                    } //end switch

                    if (key != null)
                    {
                        foreach (String name in key.GetValueNames())
                        {
                            if (name != "")
                            {
                                StartupItem tempStartup = new StartupItem(name, key.GetValue(name).ToString(), EnabledSwitch);
                                tempStartup.Hive = hive;
                                tempStartup.Key = registryKey; //note: maintains original folder location for easy re-enabling
                                StartUpItems.Add(tempStartup);
                            }
                        }
                    }

                } //end foreach hives
                EnabledSwitch=false; //after first iteration, were now looking at disabled folders
            } //end foreach disabled folder   
        }

        

        /*initially populate list of installed apps, subsequent runs return list of missing apps*/
        public List<String> CheckInstalledApplications (){
            String registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                foreach (String subkeyName in key.GetSubKeyNames())
                {
                    if (key.OpenSubKey(subkeyName).GetValue("DisplayName") != null){
                        InstalledApps.Add( key.OpenSubKey(subkeyName).GetValue("DisplayName").ToString());
                        //System.Diagnostics.Debug.WriteLine(key.OpenSubKey(subkeyName).GetValue("DisplayName"));
                    }
                }
            }

            //return current set
            return InstalledApps;
        }

        /*recover browser passwords, return as string, refactor into a struct*/
        public string GetBrowserPasswords()
        {
            //Script pwords = new Script();
            string pwordsData=new Script().RunApp("pwdump.bat");
            string[] tokens = pwordsData.Split('\n');
            string buildString = "";
            for (int i = 17; i < tokens.Length-7; i++)
            {
                if (tokens[i] != "\r")
                {
                    //seperate into password structure!
                    string[] subStrings = tokens[i].Split('\t');
                    buildString += tokens[i] + "\n";
                }
            }
            
            return buildString;
        }

        public override String ToString() {
            string driveInfo = "";
            foreach (DriveInfo drive in Drives)
            {
                if (drive.IsReady)
                {
                    driveInfo += drive.Name + "\t" +
                        (drive.TotalSize / 1073741824) + " GB\t( "+
                        (drive.TotalFreeSpace / 1073741824) + " GB \t"+
                        (int)(((double)drive.TotalFreeSpace / (double)drive.TotalSize) * 100) + "% Free ) \r\n\t";

                }
            }
            
            string temps = "";
            int core = 0;
            /** problems reading temps

            foreach (Temperature t in Temperature.Temperatures)
            {
                temps +="[ "+core+" ] "+t.CurrentValue + "°c  ";
                core++;
            }
            */
            string videostats = "";
            foreach (string vid in VideoCards){
                videostats += "\t"+vid + "\r\n";
            }

            string audiostats = "";
            foreach (string snd in AudioCards)
            {
                audiostats += "\t" + snd + "\r\n";
            }

            string antivirus = "";
            foreach (string av in AntivirusPrograms)
            {
                antivirus += "\t" + av + "\r\n";
            }

            string ramSlots = GetRamConfig();
         
            return (    "User: "+UserName+" on Computer: "+ComputerName+"\r\n" + 
                        "OS: " + OperatingSystem + " " +OperatingSystemArchitecture+"\r\n" +
                        //"Platform: " + OperatingSystemBuild + " Ver:" + OperatingSystemVersion + "\r\n" +
                        "Owner: "+ OwnerName + "\r\n"+
                        "Language: (" + Language + ")\r\n\r\n" +
                        "Mobo: " + MoboVendor + " (" + MoboVersion + ")" + "\r\n\r\n" +
                        "CPU: " + Processor + "\r\n" +
                        "Cores: "+ProcessorCores+"\tThreads: "+ProcessorThreads+"\r\n"+
                        "CPU Temperatures: " +temps + "\r\n\r\n"+
                        "RAM: " + ((double)RamCapacity / 1073741824).ToString("0.00") + "GB \t" +
                        (int)(((double)RamUsed / (double)RamCapacity) * 100) + "% Used" + "\r\n" +
                        RamSlotCount + " Ram Slots: \r\n" + ramSlots + "\r\n\r\n" +
                        "Drive Info:\r\n\t" + driveInfo + "\r\n\r\n" +
                        "Video:\r\n" + videostats + "\r\n\r\n" +
                        "Audio:\r\n" + audiostats +"\r\n"+
                        "Installed Applications: " + InstalledApps.Count + "\r\n"+
                        "Start Up Applications: " + StartUpItems.Count + "\r\n"+
                        "Running Processes: " + ProcessCount + "\r\n\r\n" +
                        "Antivirus Programs:\r\n\t" + antivirus
                        );
        }

      
    }


}
