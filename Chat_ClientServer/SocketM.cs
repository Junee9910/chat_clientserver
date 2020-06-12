using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Chat_ClientServer
{
    public class SocketM
    {
        public Socket _Socket { get; set; }
        public string _Name { get; set; }
        public SocketM(Socket socket)
        {
            this._Socket = socket;
        }
    }
}
