using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Login
{
    public partial class Connection : Form
    {
        TcpClient mishtamesh = new TcpClient();
        public Connection()
        {
            InitializeComponent();
        }

        private void Connectbtn_Click(object sender, EventArgs e)
        
        {
            try
            {

                IPAddress Ip = IPAddress.Parse(IpConnectionText.Text);
                mishtamesh.Connect(Ip, 12346);
            }
            catch (Exception s)
            {

                MessageBox.Show("The server isn't online right now!");
                this.Close();

            }
            MainMenu MM = new MainMenu(mishtamesh);
            MM.Show();
           
        }
    }
}
