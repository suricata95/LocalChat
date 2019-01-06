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
using System.Configuration;
using System.Security.Cryptography;

namespace LocalChat
{
    public partial class Principal : Form
    {
        private TcpClient ClienteTCP;
        public StreamReader STR;
        public StreamWriter STW;
        public string TextoRecibido;
        public String TextoEnviar;

        private readonly UdpClient udp = new UdpClient(Convert.ToInt32(ConfigurationManager.AppSettings.Get("PuertoUDP")));
        IAsyncResult ar_ = null;


        public Principal()
        {
            InitializeComponent();

            StartListening();

            txtSPuerto.Text = ConfigurationManager.AppSettings.Get("PuertoTCP");
            txtCPuerto.Text = ConfigurationManager.AppSettings.Get("PuertoTCP");

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    txtSIP.Text = address.ToString();
                }
            }
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(txtSPuerto.Text));
                listener.Start();
                ClienteTCP = listener.AcceptTcpClient();
                STR = new StreamReader(ClienteTCP.GetStream());
                STW = new StreamWriter(ClienteTCP.GetStream());
                STW.AutoFlush = true;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }

                backgroundWorker2.WorkerSupportsCancellation = true;
            });
        }

        private async void btnConectar_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                ClienteTCP = new TcpClient();
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(txtCIP.Text), int.Parse(txtCPuerto.Text));

                try
                {
                    ClienteTCP.Connect(IpEnd);

                    if (ClienteTCP.Connected)
                    {
                        //txtConversacion.AppendText("Connected to server" + "\n");
                        STW = new StreamWriter(ClienteTCP.GetStream());
                        STR = new StreamReader(ClienteTCP.GetStream());
                        STW.AutoFlush = true;
                        if (!backgroundWorker1.IsBusy)
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                        backgroundWorker2.WorkerSupportsCancellation = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            });
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (ClienteTCP.Connected)
            {
                try
                {
                    TextoRecibido = STR.ReadLine();
                    this.txtConversacion.Invoke(new MethodInvoker(delegate ()
                    {
                        txtConversacion.AppendText("You:" + DesencriptarString(TextoRecibido) + Environment.NewLine);
                    }));
                    TextoRecibido = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ClienteTCP.Connected)
            {
                STW.WriteLine(EncriptarString(TextoEnviar));
                this.txtConversacion.Invoke(new MethodInvoker(delegate ()
                {
                    txtConversacion.AppendText("Me:" + TextoEnviar + Environment.NewLine);
                }));
            }
            else
            {
                MessageBox.Show("Error al enviar");
            }
            backgroundWorker2.CancelAsync();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text != "")
            {
                TextoEnviar = txtMensaje.Text;
                if (!backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
            }
            txtMensaje.Text = string.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    Send(address.ToString());
                }
            }
        }
        private void StartListening()
        {
            ar_ = udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, Convert.ToInt32(ConfigurationManager.AppSettings.Get("PuertoUDP")));
            byte[] bytes = udp.EndReceive(ar, ref ip);
            string message = DesencriptarString(Encoding.ASCII.GetString(bytes));

            if (string.IsNullOrEmpty(txtCIP.Text))
            {
                if (!txtSIP.Text.Equals(message))
                {
                    txtCIP.Invoke((MethodInvoker)(() => txtCIP.Text = message));
                }
            }
            StartListening();
        }
        public void Send(string message)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, Convert.ToInt32(ConfigurationManager.AppSettings.Get("PuertoUDP")));
            byte[] bytes = Encoding.ASCII.GetBytes(EncriptarString(message));
            client.Send(bytes, bytes.Length, ip);
            client.Close();
        }

        public string DesencriptarString(string textoEncriptado)
        {
            return Desencriptar(textoEncriptado, ConfigurationManager.AppSettings.Get("ClaveEncriptado"), "s@lAvz", "MD5",
              1, "@1B2c3D4e5F6g7H8", 128);
        }

        public string EncriptarString(string stringEncriptado)
        {
            return Encriptar(stringEncriptado, ConfigurationManager.AppSettings.Get("ClaveEncriptado"), "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
        }

        public string Encriptar(string textoQueEncriptaremos, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoQueEncriptaremos);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor,
             CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

       

        public string Desencriptar(string textoEncriptado, string passBase,
        string saltValue, string hashAlgorithm, int passwordIterations,
        string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor,
              CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0,
              plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0,
              decryptedByteCount);
            return plainText;
        }
    }
}
