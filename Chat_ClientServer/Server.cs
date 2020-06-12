using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Chat_ClientServer
{
    public partial class Server : Form
    {
        private byte[] _buffer = new byte[1024];
        public List<SocketM> __ClientSockets { get; set; }
        List<string> _names = new List<string>();
        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            __ClientSockets = new List<SocketM>();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            SetupServer();
        }
        private void SetupServer()
        {
            lb_stt.Text = "Setting up server . . .";
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse(tbIP.Text), int.Parse(tbPort.Text)));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void AppceptCallback(IAsyncResult ar)
        {
            Socket socket = _serverSocket.EndAccept(ar);
            __ClientSockets.Add(new SocketM(socket));
            list_client.Items.Add(socket.RemoteEndPoint.ToString());

            tbNumClient.Text =__ClientSockets.Count.ToString();
            lb_stt.Text = "Client connected. . .";
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            if (socket.Connected)
            {
                int received;
                try
                {
                    received = socket.EndReceive(ar);
                }
                catch (Exception)
                {
                    // client đóng kết nối
                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            __ClientSockets.RemoveAt(i);
                            tbNumClient.Text =__ClientSockets.Count.ToString();
                        }
                    }
                    // xóa trong list
                    return;
                }
                if (received != 0)
                {
                    byte[] dataBuf = new byte[received];
                    Array.Copy(_buffer, dataBuf, received);
                    string text = Encoding.ASCII.GetString(dataBuf);
                    lb_stt.Text = "Text received: " + text;

                    string reponse = string.Empty;
                    if (text.Contains("@@"))
                    {
                        for (int i = 0; i < list_client.Items.Count; i++)
                        {
                            if (socket.RemoteEndPoint.ToString().Equals(__ClientSockets[i]._Socket.RemoteEndPoint.ToString()))
                            {
                                list_client.Items.RemoveAt(i);
                                list_client.Items.Insert(i, text.Substring(1, text.Length - 1));
                                __ClientSockets[i]._Name = text;
                                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                                return;
                            }
                        }
                    }

                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (socket.RemoteEndPoint.ToString().Equals(__ClientSockets[i]._Socket.RemoteEndPoint.ToString()))
                        {
                            rb_Mess.AppendText("\n" + __ClientSockets[i]._Name + ": " + text);
                        }
                    }



                    if (text == "bye")
                    {
                        return;
                    }
                    reponse = "server da nhan " + text;
                    SendData(socket, reponse);
                }
                else
                {
                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            __ClientSockets.RemoveAt(i);
                            tbNumClient.Text =__ClientSockets.Count.ToString();
                        }
                    }
                }
            }
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }
        private void SendData(Socket socket, string noidung)
        {
            byte[] data = Encoding.ASCII.GetBytes(noidung);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void SendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list_client.SelectedItems.Count; i++)
            {
                string t = list_client.SelectedItems[i].ToString();
                for (int j = 0; j < __ClientSockets.Count; j++)
                {
                    if (__ClientSockets[j]._Socket.Connected && __ClientSockets[j]._Name.Equals("@"+t))
                    {
                        SendData(__ClientSockets[j]._Socket, tbMess.Text);
                    }
                }
            }
            rb_Mess.AppendText("\nServer: " + tbMess.Text);
        }
    }
}
