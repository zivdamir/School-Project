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
using System.Threading;
using System.Threading.Tasks;

namespace Login
{
    public partial class PrivateFriendsChoose : Form
    {
        MainMenu MM;
        string name;
        List<string> OnlineFriends;
        TcpClient Mishtamesh;

        string Chatter;
        public PrivateFriendsChoose(string name,List<string> OnlineFriends,TcpClient Mishtamesh,MainMenu MM)//constructor
        {
            InitializeComponent();
            this.name = name;
            this.OnlineFriends = OnlineFriends;
            this.Mishtamesh = Mishtamesh;
            
            this.MM = MM;
           
           
        }
        
        private void PrivateFriendsChoose_Load(object sender, EventArgs e)
        {
            FriendsUpdater.Start();

        }
       
        public void MatchChatters(string chatter)//match to the chatter in the properties
        {
            this.Chatter = chatter;
        }
        public void SetAnswer(string answer)//set the answer from the other user
        {
           
            Sndrequstbtn.Enabled = true;
            switch (answer)
            {
                case "Yes":
                    MessageBox.Show("User:"+Chatter+" has accpeted your request");
                    MM.OpenPrivateChat(Chatter, name, Mishtamesh);
                    break;
                case "No":
                    MessageBox.Show("User:" + Chatter + " has decliend your request!");
                    break;
            }

        }
        public void MatchOnlineFriends(List<string> OnlineFriends)//matches it to the properties and calls organizeonlinefriendsLists
        {
            this.OnlineFriends = OnlineFriends;
            organizeOnlineFriendsLists(OnlineFriends);
        }
        public void organizeOnlineFriendsLists(List<string> OnlineFriends)//organizes the online friends of the user.
        {
            if (OnlineFriends == null)
            {
                return;
            }

            PrivateChatFriendsSelector.Items.Clear();
            if (OnlineFriends.Count > 0)
            {
                foreach (string OnlineFriend in OnlineFriends)
                {
                    PrivateChatFriendsSelector.Items.Add(OnlineFriend);
                }
            }
        }

        private void PrivateChatFriendsSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Sndrequstbtn_Click(object sender, EventArgs e)//handles the send request to certain user
        {
            if(PrivateChatFriendsSelector.SelectedItem!=null)
            {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
             Chatter=PrivateChatFriendsSelector.SelectedItem.ToString();
             
                 sw.WriteLine("PrivateChatRequest");
                 sw.WriteLine(Chatter);//the name of the friend the user want to chat with.
                 sw.WriteLine(name);//the name of the user.
                 sw.Flush();
                 Sndrequstbtn.Enabled = false;//prevents the thread from starting over in case the user didnt realized that he shouldn't click again.
             }
             else
             {
                 MessageBox.Show("Please make sure you choose a real username!");
             }
            
        }

        private void FriendsUpdater_Tick(object sender, EventArgs e)//signals the server to send him his current online friends
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            sw.WriteLine("OnlineFriends");
            sw.WriteLine(name);
            sw.Flush();
            
        }

       

       
    }
}
