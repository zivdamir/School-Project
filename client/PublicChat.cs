using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using ProjectClasses;
using System.Threading;

namespace Login
{
    public partial class PublicChat : Form
    {
        public List<string> Messages;
        public  TcpClient Mishtamesh;
        public string name { get; set; }
        public PublicChat(TcpClient Mishtamesh,string name)//constructor
        {
            InitializeComponent();
            this.name = name;
            this.Mishtamesh = Mishtamesh;
            Messages = new List<string>();
          //  Thread t1 = new Thread();
           
        }
        public void IsTypingChanger(string name)//change the TypingLabel 
        {
            TypingLabel.Text = name ;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)//signals the server that this user exit the public chat
        {
            base.OnFormClosing(e);
            
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            sw.WriteLine("PubChatSend");
            sw.Flush();
            string  msg =name+" has logged out of the chat";
            sw.WriteLine(msg);
            sw.Flush();
            sw.WriteLine("EndPubChat");
            sw.Flush();
            CollectMsgs.Stop();
            

        }
        private void PublicChat_Load(object sender, EventArgs e)//signals the server that this user joined the public chat
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            
            sw.WriteLine("PubChatSend");
            sw.Flush();
            string msg = name + " has joined the chat";
            sw.WriteLine(msg);

            MsgBox.Clear();
            CollectMsgs.Start();
            sw.WriteLine("StartPubChat");
            sw.Flush();
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//will make the form " Is Typing..,the " will be the last guy that typed something
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            if (MsgBox.Text != "")
            {
                
                sw.WriteLine("IsTyping");
                sw.Flush();
                sw.WriteLine(name);
                sw.Flush();
            }
            else
            {
                sw.WriteLine("IsTyping");
                sw.Flush();
                sw.WriteLine("");
                sw.Flush();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)//sends the message 
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            BinaryFormatter bn = new BinaryFormatter();
            string msg; 
            if (e.KeyCode == Keys.Enter)
            {
                if (MsgBox.Text != "")
                {
                    sw.WriteLine("PubChatSend");
                    sw.Flush();
                    msg = name + " :" + MsgBox.Text;
                    sw.WriteLine(msg);
                    sw.Flush();
                    //ArrayList arr = new ArrayList();
                    //string state = StateOfClient.PubChatSend.ToString();
                    //User us = new User(name, "password", "email");//the email and password doesnt matter
                    //arr.Add(state);
                    //arr.Add(us);
                    //arr.Add(msg);
                    //bn.Serialize(Mishtamesh.GetStream(), arr);
                    MsgBox.Clear();
                }
                else
                {
                    MessageBox.Show("do not send an empty messages");
                }
                
            }

        }
    ////    public void SetMessages(List<string> list)
    //    {
    //        CollectMsgs.Stop();
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            Messages.Add(list[i]);
    //        }
    //        CollectMsgs.Start();
    //    }
        public void AddMessage(string message)//add the message to the list of messages
        {
            CollectMsgs.Stop();
            Messages.Add(message);
            CollectMsgs.Start();
        }
        private void CollectMsgs_Tick(object sender, EventArgs e)//adds the messages from messages list to the chat
        {
            while (Messages.Count > 0)
            {
                try
                {
                    MessageShowText.AppendText(Messages[0].ToString() + "\r \n");
                }
                catch
                {
                }
                Messages.RemoveAt(0);
            }
        }

       

        private void TypingLabel_Click(object sender, EventArgs e)
        {

        }

        private void MessageShowText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
