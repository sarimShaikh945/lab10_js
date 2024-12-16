using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {

        TcpClient clinet = null;
        public Form1()
        {
            InitializeComponent();
            clinet = new TcpClient("127.0.0.1",888);
            NetworkStream ns = clinet.GetStream();
            StreamReader sr = new StreamReader(ns);

            textBox1.Text = "server | " + sr.ReadLine();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkStream ns = clinet.GetStream();
            StreamWriter sr = new StreamWriter(ns);
            sr.WriteLine(textBox2.Text);
            sr.Flush();
            textBox2.Clear();


        }

       
    }
}
           

