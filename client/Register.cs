using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.IO;
using ProjectClasses;
namespace Login
{
    public partial class Register : Form
    {

        TcpClient mishtamesh;
        public Register(TcpClient mishtamesh)
        {
            InitializeComponent();
            this.mishtamesh = mishtamesh;
           
        }
       
        
        private void regbtn_Click(object sender, EventArgs e)//will serilalize the user ,send it to the server,and will get true or false based on existance of the user.
        {
            if (UserNametxtbox.Text != "" && passtxt.Text != "" && emailtxt.Text != "")
            {
                StreamWriter sw = new StreamWriter(mishtamesh.GetStream());
                sw.WriteLine("Reg");
                sw.WriteLine("3");//cnt
                sw.WriteLine(UserNametxtbox.Text);
                sw.WriteLine(passtxt.Text);
                sw.WriteLine(emailtxt.Text);
                sw.Flush();
            }
            else
            {
                MessageBox.Show("Please Make Sure to fill all the fields before pressing 'Register'!");
            }
        }

        public void checker(bool exists)
        {
            switch (exists)
            {
                case true:
                    MessageBox.Show("One of the user Components is taken,please enter antoer username/email and try again");
                    UserNametxtbox.Clear();
                    passtxt.Clear();
                    emailtxt.Clear();
                    break;
                case false:
                    MessageBox.Show("You have successfully registeterd,an email will be sent to your chosen mail");
                    this.Close();
                    break;
            }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
