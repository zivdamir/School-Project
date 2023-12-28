using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using ProjectClasses;
namespace Login
{
    public partial class FriendChoose : Form
    {
        List<string> friends;
        string name;
        TcpClient Mishtamesh;
        public FriendChoose( TcpClient Mishtamesh,string name)//constructor
        {
            InitializeComponent();
            this.friends = new List<string>();
            this.name = name;
            this.Mishtamesh = Mishtamesh;

        }
        public void matchlists(List<string> friends)//matches the list of the parametr to the properties
        {
            this.friends = friends;
            organizeList();
        }
        private void FriendSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void organizeList()//organize the users on a list
        {
            friends.Remove(name);
            FriendSelector.Items.Clear();
            foreach (string user in friends)
            {
                FriendSelector.Items.Add(user);
            }
        }
        private void FriendChoose_Load(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
            sw.WriteLine("FriendLookOut");
            sw.Flush();
            sw.WriteLine(name);
            sw.Flush();
            
           
        }

        private void AddFrindbtn_Click(object sender, EventArgs e)//event that handles the user friendsrequest sending
        {

            try
            {

                string namerequested = FriendSelector.SelectedItem.ToString();
                StreamWriter sw = new StreamWriter(Mishtamesh.GetStream());
                sw.WriteLine("FriendRequest");
                sw.Flush();
                sw.WriteLine(namerequested);
                sw.Flush();
                sw.WriteLine(name);
                sw.Flush();
                MessageBox.Show("a friend request has been sent to " + namerequested);
                FriendSelector.Items.Remove(namerequested);
            }
            catch
            {
            }
            
        } 
    }
}
