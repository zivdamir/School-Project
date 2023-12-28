using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net.Sockets;
using ProjectClasses;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Login
{
   
    public partial class Login : Form
    {
        MainMenu MM;
        TcpClient Mishtamesh;
        public Login(TcpClient Mishtamesh,MainMenu MM)
        {
            
            InitializeComponent();
            this.Mishtamesh = Mishtamesh;
            this.MM = MM;
        }
        private void login_Load(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
     
        }
        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }
        public bool TextClearOrNot(TextBox txt)//clear-false;not clear-true
        {
            if (txt.Text =="") return false;
            else return true;
        }
        public void login(string username, string password)
        {
            
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            sw.WriteLine("Log");
            sw.WriteLine("2");
            sw.WriteLine(username);
            sw.WriteLine(password);
            sw.Flush();
           
            //בהמשך הפעולה יקבל,אם הפרטים קיימים ונכונים,יקבל שם ,וזה יכנס לפורם חדש שבו הוא יוכל לנהל את המשתמש ולעשות פעולות.
        }
            public void LoginA(ArrayList Info)
            {
                string msg = Info[1].ToString();
            switch(bool.Parse(Info[2].ToString()))
            {
                case true:
                    if (msg == "CanLogin")
                    {
                        MM.OpenHomeStart(Info, Mishtamesh, MM);
                    }
                    else if (msg == "CantLogin")
                    {
                        MessageBox.Show("The User you are trying to connect to is Already Online,Please enter with antoer user name or try later");
                    }
            break;
                case false:
            MessageBox.Show("User name does not exists/password isn't match");
            break;
            }
            
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            bool a = TextClearOrNot(passwordtxt) && TextClearOrNot(nametxt);
            switch (a)
            {
                case true:
                    login(Convert.ToString(nametxt.Text),Convert.ToString( passwordtxt.Text));

                    break;
                case false:
                    MessageBox.Show("Please make sure to fill all the fields");
                    break;
            }
        }
        
    }
}
