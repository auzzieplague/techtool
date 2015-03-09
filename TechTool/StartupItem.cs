using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TechTool
{
    class StartupItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Hive { get; set; }
        public string Key { get; set; }
        public bool Enabled { get; set; }

        public StartupItem(string name, string value, bool enabled)
        {
            this.Name = name;
            this.Value = value;
            this.Enabled = enabled;
        }

        public void DisableItem()
        {
            Enabled = false;

            //copy to disabled folder
            RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(this.Key+@"\TechToolDisabled");;
            RegistryKey oldkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(this.Key);
            //setup keys depending on hives
            switch (this.Hive)
            {
                case "HKCU":
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(this.Key+@"\TechToolDisabled");
                    oldkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(this.Key);
                    break;
                case "HKLM":
                    key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(this.Key + @"\TechToolDisabled");
                    oldkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(this.Key );
                    break;
                //64 bit versions
                case "HKLM64":
                    RegistryKey rb = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    key = rb.CreateSubKey(this.Key + @"\TechToolDisabled");
                    oldkey = rb.CreateSubKey(this.Key );
                    break;
                case "HKCU64":
                    RegistryKey rb2 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                    key = rb2.CreateSubKey(this.Key + @"\TechToolDisabled");
                    oldkey = rb2.CreateSubKey(this.Key );
                    break;
            }
            //create new key
            key.SetValue(this.Name, this.Value);
            key.Close();

            //remove orignal key
            try
            {
                oldkey.DeleteValue(this.Name);
            }
            catch
            {
                //dont stress
                //var result = MessageBox.Show("Failed to remove key from registry\r\n make sure we have admin rights!","Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            
            
        }

        public void EnableItem()
        {
            //var result = MessageBox.Show(this.Name, "Debug", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Enabled = true;
            RegistryKey oldkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(this.Key);
            //setup keys depending on hives
            switch (this.Hive)
            {
                case "HKCU":
                    oldkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(this.Key,true);
                    break;
                case "HKLM":
                    oldkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(this.Key, true);
                    break;
                //64 bit versions
                case "HKLM64":
                    RegistryKey rb = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    oldkey = rb.OpenSubKey(this.Key, true);
                    break;
                case "HKCU64":
                    RegistryKey rb2 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);

                    oldkey = rb2.OpenSubKey(this.Key, true);
                    break;
            }
            //create new key
            oldkey.SetValue(this.Name, this.Value);
            oldkey.Close();
        }

    }
}
