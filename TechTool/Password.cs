using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTool
{
    class Password
    {
        public String Application { get; set; }
        public String URL { get; set; }
        public String User { get; set; }
        public String PWord { get; set; }

        public Password(string username, string password, string url, string application)
        {
            Application = application;
            URL = url;
            PWord = password;
            User = username;
        }
    }
}
