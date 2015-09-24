using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TechTool
{
    class Report
    {
        PcInfo reportInfo;

        public Report(PcInfo info)
        {
            reportInfo = info;
        }

        public void Save(string filename) {
            System.IO.File.WriteAllText(filename, reportInfo.ToString());
        }
    }
}
