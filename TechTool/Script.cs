using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TechTool
{
    class Script
    {
        /*wrapper for running bat files in the local apps folder, returns cmdline output*/
        public string RunApp(string batFile)
        {
            Process cmdLine = new Process();
            cmdLine.StartInfo.FileName = "cmd.exe";
            cmdLine.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+@"\apps";
            cmdLine.StartInfo.Arguments = " /K "+batFile;
            cmdLine.StartInfo.CreateNoWindow = false;
            cmdLine.StartInfo.UseShellExecute = false;
            cmdLine.StartInfo.RedirectStandardOutput = true;
            cmdLine.StartInfo.RedirectStandardInput = true;
            cmdLine.Start();
            string fullData = cmdLine.StandardOutput.ReadToEnd();
            cmdLine.WaitForExit();
            cmdLine.Close();

            return fullData;// fullData;
        }

    }
}
