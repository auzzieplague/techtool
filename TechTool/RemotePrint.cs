using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TechTool
{
    class RemotePrint
    {
        public String RemoteIP { get; set; }

        public RemotePrint() {
            //constructor
            RemoteIP=GetIPFromFile();
        }

        public string GetIPFromFile (){
            return System.IO.File.ReadAllLines(@"printeraddress.txt")[0];
        }

        public void Print (string filename) {
            Debug.Write(RemoteIP);
            
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;
            //clientSocket.Blocking = false;

            IPAddress ip = IPAddress.Parse(RemoteIP);
            IPEndPoint ipep = new IPEndPoint(ip, 9100);
            clientSocket.Connect(ipep);

            byte[] fileBytes = File.ReadAllBytes(filename);

            clientSocket.Send(fileBytes);
            clientSocket.Close();
        }
    }
}
