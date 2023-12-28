using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace Login
{
    public partial class PrivChat : Form
    {
        string Chatter;//the antoer user that the current user want to chat with
        string nameofuser;//Current USER
        TcpClient Mishtamesh;
        List<string> PrivateChatMessages;
        public PrivChat(string Chatter,string nameofuser,TcpClient Mishtamesh)//constructor
        {
            InitializeComponent();
            this.Chatter = Chatter;
            this.nameofuser = nameofuser;
            this.Mishtamesh = Mishtamesh;
            this.PrivateChatMessages = new List<string>();
        }

        public void addMessage(string msg)//adds the message to Messagelist
        {
            CollectMsgs.Stop();
            PrivateChatMessages.Add(msg);
            CollectMsgs.Start();
        }
        private void PrivChat_Load(object sender, EventArgs e)//set the topic and starts the collecting messages timer
        {
            string msg = "Chat with " + Chatter;
            this.Text = msg;
            CollectMsgs.Start();
        }
        public void IsTypingChanger(string name)//changes the "Is Typing ""...." when "" is the user that typing
        {
            TypingLabel.Text = name;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//triggers the "Is typing"
        {
            StreamWriter sm = new StreamWriter(Mishtamesh.GetStream());
            sm.WriteLine("PrivChatIsTyping");
            sm.WriteLine(Chatter);
            sm.WriteLine(nameofuser);
            if (PrivMsgBox.Text != "")
            {
                sm.WriteLine(nameofuser);//who is typing                
            }
            else
            {
                sm.WriteLine("");//in case no one is typing
            }
            sm.Flush();
        }

        private void PrivateChatSendMsgBox_KeyDown(object sender, KeyEventArgs e)//sends the message
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());

            string msg;
            if (e.KeyCode == Keys.Enter)
            {
                if (PrivMsgBox.Text != "")
                {
                    sw.WriteLine("PrivChatSend");
                    sw.WriteLine(Chatter);
                    sw.WriteLine(nameofuser);
                    msg = nameofuser + ": " + PrivMsgBox.Text;
                    sw.WriteLine(msg);
                    sw.Flush();
                    PrivMsgBox.Clear();
                }
                else
                {
                    MessageBox.Show("do not send an empty messages");
                }

            }
        }

        private void CollectMsgs_Tick(object sender, EventArgs e)//adds the messages to the chat box
        {
            while (PrivateChatMessages.Count > 0)
            {
                try
                {
                    PrivChatBox.AppendText(PrivateChatMessages[0].ToString() + "\r \n");
                }
                catch
                {
                }
                PrivateChatMessages.RemoveAt(0);
            }
        }

       
    }
}
