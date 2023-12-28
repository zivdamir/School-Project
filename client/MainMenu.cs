using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Permissions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.IO;
using ProjectClasses;
using System.Runtime.Serialization.Formatters.Binary;
namespace Login
{
    enum StateOfClient
    {
        Register,
        Login,
        Exit,
        PubChatSend,
        PrivChat,
        FriSearch,
        FriRequest,
        FriAccept,
        FriDecline,

    }
    public partial class MainMenu : Form
    {
     
        Thread t1;
        PublicChat pc;
        Register rg;
        Login lg;
        ArrayList strings;
        FriendChoose fc;
        PrivateFriendsChoose Pfc;
        PrivChat PrCh;
        HomeStart Hs;
        public MainMenu(TcpClient Mishtamesh)
        {
           
            InitializeComponent();
            strings = new ArrayList();
            Timer.Start();
            this.Mishtamesh = Mishtamesh;
        }
        public  TcpClient Mishtamesh;

     
        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    Mishtamesh.Connect("192.168.0.101", 12346);
            //}
            //catch (Exception s)
            //{
                
            //    MessageBox.Show("The server isn't online right now!");
            //    this.Close();
                
            //}
            Thread t1 = new Thread(Maingetter);
            t1.Start();
        
           
           
        }
       

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            BinaryFormatter bn = new BinaryFormatter();
            ArrayList arr = new ArrayList(2);
            string state = StateOfClient.Exit.ToString();
            arr.Add(state);
            arr.Add(new User("adsa", " adad", "adsad"));
            try
            {
                bn.Serialize(Mishtamesh.GetStream(), arr);
            }
            catch
            {

            }
          
        }
       
        private void button1_Click(object sender, EventArgs e)//register form
        {
            rg = new Register(Mishtamesh);
            rg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             lg = new Login(Mishtamesh,this);
            lg.Show();

        }

        bool exists=false;
        string name;
        ArrayList Info = new ArrayList();
        string typemsg;
        List<string> names;
        List<string> OnlineFriends;
        string message;
        string requester;
        string answer;
        string nameofrequester;
        string privmessage;
        public void Maingetter()
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(Mishtamesh.GetStream());
            }
            catch(InvalidOperationException )
            {
                return;
            }
            BinaryFormatter bn = new BinaryFormatter();
           
            string msg;
            while (true)
            {
               
                   msg = sr.ReadLine();
                
               
                switch (msg)
                {
                    case "Reg":
                        exists=Convert.ToBoolean(sr.ReadLine());//problem.
                        strings.Add("Reg");
                        break;
                    case "Logi":
                        int cnt=Convert.ToInt32(sr.ReadLine());
                        Info = new ArrayList(5);
                        Info.Insert(0,sr.ReadLine());//inserts name
                        Info.Insert(1,sr.ReadLine());//the user is already online or not.
                        Info.Insert(2,Convert.ToBoolean(sr.ReadLine()));
                        cnt=Convert.ToInt32(sr.ReadLine());//size of the "Friends" array.
                        ArrayList Friends=new ArrayList(100);
                        if(cnt>0)
                        {
                             for (int i = 0; i <cnt; i++)
						{
                            Friends.Insert(i,sr.ReadLine());
                        }

                        }
                       Info.Insert(3,Friends);
                       cnt=Convert.ToInt32(sr.ReadLine());//size of the "FriendsRequests" array.
                        ArrayList FriendRequests=new ArrayList(100);
                        if(cnt>0)
                        {
                        for (int i = 0; i < cnt; i++)
			           {
			             FriendRequests.Insert(i,sr.ReadLine());
			           }
                        }
                        Info.Insert(4, FriendRequests);
                        strings.Add("Logi");
                        break;
                    case "PubChat":          
                        message = sr.ReadLine();//message.
                        strings.Add("PubChat");
                        break;
                    case "IsTyping":
                        name = (string)sr.ReadLine();
                        strings.Add("IsTyping");
                        break;
                    case "SendNames":
                        int Counter = Convert.ToInt32(sr.ReadLine());
                        names = new List<string>(100);
                        for (int i = 0; i < Counter; i++)
                        {
                            names.Insert(i, sr.ReadLine());
                        }
                        strings.Add("ShowFriends");
                  
                        break;
                    case "OnlineFriends":
                        int count = Convert.ToInt32(sr.ReadLine());
                        OnlineFriends = new List<string>(100);
                        if (count > 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                OnlineFriends.Insert(i, sr.ReadLine());
                            }
                        }
                        OnlineFriends.Sort();
                        strings.Add("OnlineFriends");
                        break;
                    case "AnswerRequestToPrivateChat":
                        requester = sr.ReadLine();//the name of the user we send the request to
                        answer = sr.ReadLine();//his answer
                        strings.Add("AnswerRequestToChat");
                        break;
                       case "RequestToPrivateChat":
                       nameofrequester = sr.ReadLine();
                       strings.Add("PrivChatRequest");
                       break;
                       case "PrivateIsTyping":
                       typemsg = sr.ReadLine();
                       strings.Add("PrivateTyper");
                       break;
                    case "PrivChat":
                       privmessage = sr.ReadLine();
                       strings.Add("PrivChatSendMsg");
                       break;
                      case "":
                        break;
                }
                
            }

        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();//the process is taking longer than the tick rate,inorder to defend it,we stop the method that the tick uses,until he finish to work
            //then we start the ticks again

            string msg;
            while (strings.Count != 0)
            {
                msg = strings[0].ToString();
                switch (msg)
                {
                    case "Reg":
                        rg.checker(exists);
                        break;
                    case "Logi":
                        lg.LoginA(Info);
                        break;
                    case "PubChat":
                        pc.AddMessage(message);
                        break;
                    case "ShowFriends":
                        fc.matchlists((List<string>)names);
                        break;
                    case "IsTyping":
                        pc.IsTypingChanger(name);
                        break;
                    case "OnlineFriends":
                        Pfc.MatchOnlineFriends(OnlineFriends);
                        break;
                    case "AnswerRequestToChat":
                       
                        Pfc.SetAnswer(answer);
                        Pfc.MatchChatters(requester);
                        break;
                    case "PrivChatRequest":
                        Hs.PrivateChatRequest(nameofrequester);
                        break;
                    case "PrivateTyper":
                        PrCh.IsTypingChanger(typemsg);
                        break;
                    case "PrivChatSendMsg":
                        PrCh.addMessage(privmessage);
                        break;

                }
                
                strings.RemoveAt(0);
            }

            Timer.Start();
        }
        public void OpenChat(string name)
        {
            pc = new PublicChat(Mishtamesh, name);
            pc.Show();
        }
        public void OpenChooseFriends(TcpClient Mishtamesh,string name)
        {
           fc = new FriendChoose(Mishtamesh,name);
           fc.Show();
        }
        public void OpenPrivateFriendsChoose(TcpClient Mishtamesh,string name,List<string> OnlineFriends)
        {

            Pfc = new PrivateFriendsChoose(name, OnlineFriends, Mishtamesh,this);
            Pfc.Show();
        }
        public void OpenPrivateChat(string Chatter, string name, TcpClient Mishtamesh)
        {
            PrCh = new PrivChat(Chatter, name, Mishtamesh);
            PrCh.Show();
        }
        public void OpenHomeStart(ArrayList Info, TcpClient Mishtamesh, MainMenu MM)
        {
            Hs = new HomeStart(Info, Mishtamesh, MM);
            Hs.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome To ZivBook,in ZivBook,You can chat with friends.Have fun!");
        }
    }
}
