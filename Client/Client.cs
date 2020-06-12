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
using System.IO;
using System.Data.SqlClient;

namespace Client
{
    public partial class Client : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private TcpClient client;
        public StreamReader str;
        public StreamWriter stw;
        public string receive;
        public string TexttoSend;
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Client()
        {
            InitializeComponent();
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    tbYIP.Text = address.ToString();
                }
            }
        }
        byte[] receivedBuf = new byte[1024];
        private void ReceiveData(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            byte[] dataBuf = new byte[received];
            Array.Copy(receivedBuf, dataBuf, received);
            rb_chat.Text = ("Server: "+Encoding.ASCII.GetString(dataBuf));
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
        }
        private void SendLoop()
        {
            while(true)
            {
                byte[] receivedBuf = new byte[1024];
                int rev = _clientSocket.Receive(receivedBuf);
                if (rev != 0)
                {
                    byte[] data = new byte[rev];
                    Array.Copy(receivedBuf, data, rev);
                    lb_stt.Text = ("Received: " + Encoding.ASCII.GetString(data));
                    rb_chat.AppendText("\nServer: " + Encoding.ASCII.GetString(data));
                }
                else _clientSocket.Close();
            }
        }
        private void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Parse(tbIPYF.Text), int.Parse(tbPortYF.Text));
                }
                catch (SocketException)
                {
                    //Console.Clear();
                    lb_stt.Text = ("Connection attempts: " + attempts.ToString());
                }
            }
            lb_stt.Text = ("Connected!");
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (_clientSocket.Connected)
            {

                byte[] buffer = Encoding.ASCII.GetBytes(tbMess.Text);
                _clientSocket.Send(buffer);
                rb_chat.AppendText("Me: " + tbMess.Text);
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            LoopConnect();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes("@@" + tbUserName.Text);
            _clientSocket.Send(buffer);
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Parse(tbYIP.Text), int.Parse(tbYPort.Text));
            listener.Start();
            lb_stt.Text = ("Waiting friend!");
            client = listener.AcceptTcpClient();
            str = new StreamReader(client.GetStream());
            stw = new StreamWriter(client.GetStream());
            stw.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            tbUserName.Text = Login.showUser;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    receive = str.ReadLine();
                    this.rb_chat.Invoke(new MethodInvoker(delegate ()
                    {
                        rb_chat.AppendText("You: " + receive);
                        Console.WriteLine();
                    }));
                    receive = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                stw.WriteLine(TexttoSend);
                this.rb_chat.Invoke(new MethodInvoker(delegate ()
                {
                    rb_chat.AppendText("Me: " + TexttoSend);
                    Console.WriteLine();
                }));
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorker2.CancelAsync();
        }
    }
}
