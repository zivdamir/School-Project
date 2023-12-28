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
using System.IO;
using System.Threading;
namespace Login
{//צריך להוסיף מערכת חברים-נק דגש:1)ברגע שמישהו כבר רוצה להוסיף חבר,
    public partial class HomeStart : Form
    {
        ArrayList Info;
        TcpClient Mishtamesh;
        MainMenu MM;
        Thread t1;
        string name;
        string nameofchatter;
        string state;
        ArrayList friendrequests;
        public HomeStart(ArrayList Info,TcpClient Mishtamesh,MainMenu MM)
        {
            InitializeComponent();
            this.Info = Info;
            this.Mishtamesh = Mishtamesh;
            this.MM = MM;
            this.name = Info[0].ToString();
            this.friendrequests = (ArrayList)Info[4];
            this.t1 = new Thread(new ThreadStart(()=>MM.OpenPrivateFriendsChoose(Mishtamesh, name, new List<string>(100))));
        //    Thread t1 = new Thread(()=>CheckIfPrivateChat(nameofchatter,name));//
            state = null;
          
        }
        public void PrivateChatRequest(string nameofrequester)
        {

            CheckIfPrivateChat(nameofrequester, name);
        }
        public void CheckIfPrivateChat(string Chatter,string NameOfUser)//chatter-the one the user chats with,nameofuser-the user itself.
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            DialogResult dialogResult = MessageBox.Show("User: " + Chatter + " want to chat with you,accpet?", "Incoming Request!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                sw.WriteLine("AnswerRequestToChat");
                sw.WriteLine(NameOfUser);
                sw.WriteLine(Chatter);
                sw.WriteLine("Yes");
                sw.Flush();
                MM.OpenPrivateChat(Chatter, NameOfUser, Mishtamesh);//OPENS THE CHAT.
            }
            else if (dialogResult == DialogResult.No)
            {
                sw.WriteLine("AnswerRequestToChat");
                sw.WriteLine(NameOfUser);
                sw.WriteLine(Chatter);
                sw.WriteLine("No");
                sw.Flush();
            }
        }
        public void OnLoggingOut()//signals the server that this user is logging out
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            sw.WriteLine("LogOut");
            sw.Flush();
            sw.WriteLine(name);
            sw.Flush();
           
        }
       //
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            OnLoggingOut();
            base.OnFormClosing(e);
        }

        public bool checkifnotempty(ArrayList arr)//if array isn't empty will return true,else false;
        {
            if (arr.Count>0)
            {
                return true;
            }
            else return false;
        }
        public void OrganizeFriendList(ArrayList Arr)//organize the arraylist on a list
        {
            Friend.Show();
            AddBtn.Show();
            Declinebtn.Show();
            foreach (string name in Arr)
            {
                Friend.Items.Add(name.ToString());
            }
        }
        public void FriendRequests()//checks if there is some friend requests for the user
        {
            if (checkifnotempty(friendrequests) == true)
            {
                MessageBox.Show("You have some Friend Requests to deal with");
                OrganizeFriendList(friendrequests);
            }
        }
        private void HomeStart_Load(object sender, EventArgs e)
        {
            Friend.Hide();
            AddBtn.Hide();
            Declinebtn.Hide();
            Namelbl.Text = Info[0].ToString();
            FriendRequests();
        }

        private void Hellolabel_Click(object sender, EventArgs e)
        {
           
        }

        private void PblicChtBtn_Click(object sender, EventArgs e)
        {
            MM.OpenChat(Info[0].ToString());
            
        }

     

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            MM.OpenChooseFriends(Mishtamesh, name);
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            sw.WriteLine("AddFriend");
            string FriendToAdd = Friend.SelectedItem.ToString();//the friend the user want to add;
            sw.WriteLine(name);//the user's name
            sw.WriteLine(FriendToAdd);
            sw.Flush();
            MessageBox.Show("You Have succesfully added a friend");
            Friend.Items.Remove(FriendToAdd);
            }
            catch
            {
                MessageBox.Show("Make sure you choose a name,null isn't a friend :(");//need to change xD

            }

        }

        private void Declinebtn_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
                sw.WriteLine("DeclineFriend");
                string FriendToDecline = Friend.SelectedItem.ToString();//the friend the user doesn't want to add.
                sw.WriteLine(name);//the user's name
               
                sw.WriteLine(FriendToDecline);
                sw.Flush();
                MessageBox.Show("User: "+FriendToDecline+" had been declined");
                Friend.Items.Remove(FriendToDecline);
                
            }
            catch
            {
                MessageBox.Show("Make sure you choose a name,you cant decline to Null :/");//need to change xD
            }
            
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PrivChatBtn_Click(object sender, EventArgs e)
        {
            MM.OpenPrivateFriendsChoose(Mishtamesh, name, new List<string>(100));
        }
       
    }
}

