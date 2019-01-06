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

namespace LocalChat
{
    public partial class TestUDP : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public String TextToSend;
        private readonly UdpClient udp = new UdpClient(PORT_NUMBER);
        IAsyncResult ar_ = null;
        const int PORT_NUMBER = 15000;        

        public TestUDP()
        {
            InitializeComponent();

            //IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            //foreach (IPAddress address in localIP)
            //{
            //    if (address.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        txtSIP.Text = address.ToString();
            //    }
            //}

            Start();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(txtSPuerto.Text));
            //listener.Start();
            //client = listener.AcceptTcpClient();
            //STR = new StreamReader(client.GetStream());
            //STW = new StreamWriter(client.GetStream());
            //STW.AutoFlush = true;

            //backgroundWorker1.RunWorkerAsync();
            //backgroundWorker2.WorkerSupportsCancellation = true;

            Send(new Random().Next().ToString());

            Send("Puto el que lo lea");         
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            //client = new TcpClient();
            //IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(txtCIP.Text), int.Parse(txtCPuerto.Text));

            //try
            //{
            //    client.Connect(IpEnd);

            //    if (client.Connected)
            //    {
            //        txtConversacion.AppendText("Connected to server" + "\n");
            //        STW = new StreamWriter(client.GetStream());
            //        STR = new StreamReader(client.GetStream());
            //        STW.AutoFlush = true;
            //        backgroundWorker1.RunWorkerAsync();
            //        backgroundWorker2.WorkerSupportsCancellation = true;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (client.Connected)
            //{
            //    try
            //    {
            //        recieve = STR.ReadLine();
            //        this.txtConversacion.Invoke(new MethodInvoker(delegate ()
            //        {
            //            txtConversacion.AppendText("You:" + recieve + "\n");
            //        }));
            //        recieve = "";
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message.ToString());
            //    }
            //}
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (client.Connected)
            //{
            //    STW.WriteLine(TextToSend);
            //    this.txtConversacion.Invoke(new MethodInvoker(delegate ()
            //    {
            //        txtConversacion.AppendText("Me:" + TextToSend + "\n");
            //    }));
            //}
            //else
            //{
            //    MessageBox.Show("Sending failed");
            //}
            //backgroundWorker2.CancelAsync();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //if (txtMensaje.Text != "")
            //{
            //    TextToSend = txtMensaje.Text;
            //    backgroundWorker2.RunWorkerAsync();
            //}
            //txtMensaje.Text = "";
        }






        public void Start()
        {
            Console.WriteLine("Started listening");
            StartListening();
        }
        public void Stop()
        {
            try
            {
                udp.Close();
                Console.WriteLine("Stopped listening");
            }
            catch { /* don't care */ }
        }



        private void StartListening()
        {
            ar_ = udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, PORT_NUMBER);
            byte[] bytes = udp.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(bytes);
            txtConversacion.Invoke((MethodInvoker)(() => txtConversacion.Text = txtConversacion.Text + Environment.NewLine + string.Format("From {0} received: {1} ", ip.Address.ToString(), message)));            
            //Console.WriteLine("From {0} received: {1} ", ip.Address.ToString(), message);
            StartListening();
        }
        public void Send(string message)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, PORT_NUMBER);
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
            txtConversacion.Text = string.Format("Sent: {0} ", message);
            //Console.WriteLine("Sent: {0} ", message);
        }
    }
}