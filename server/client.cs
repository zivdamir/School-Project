using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using ProjectClasses;
using System.Net.Mail;
namespace Server
{
    //3)write the book project.


    public class Client
    {
        #region variables
        public static List<string> names;


        public static ArrayList users;

        public string state;
        public User us;
        // public Client chat { get; set; }
        public TcpClient connector { get; set; }

        #endregion variables

        #region constructor
        public Client(TcpClient connector)
        {
            this.connector = connector;
            Thread t1 = new Thread(beatingheart);

            t1.Start();

        }
#endregion constructor

        #region "The Main"
        public void beatingheart()
        {

            StreamReader sr = new StreamReader(connector.GetStream());


            string msg;
            while (true)
            {
                try
                {
                    msg = sr.ReadLine();
                }
                catch (Exception e)
                {

                    msg = "Exit";
                }
                switch (msg)
                {
                    case "Reg"://regiseter
                        int cnt = Convert.ToInt32(sr.ReadLine());
                        ArrayList Info = new ArrayList(cnt);
                        for (int i = 0; i < cnt; i++)
                        {
                            string RegMsg = sr.ReadLine();
                            Info.Insert(i, RegMsg);
                        }
                        Register(Info);

                        break;
                    case "Log"://login
                        cnt = Convert.ToInt32(sr.ReadLine());
                        Info = new ArrayList(cnt);
                        for (int z = 0; z < cnt; z++)
                        {
                            string LogMsg = sr.ReadLine();
                            Info.Insert(z, LogMsg);
                        }
                        CheckLogin(Info);
                        break;
                    case "Exit"://exit
                        break;
                    case "StartPubChat"://start the public chat
                        AddToPubChat(connector);
                        break;
                    case "EndPubChat":
                        RemoveFromPubChat(connector);
                        break;
                    case "PubChatSend":
                        msg = sr.ReadLine();
                        PublicChatSendMessages(msg);
                        break;
                    case "AnswerRequestToChat":
                        string NameOfUser = sr.ReadLine();//the name of the user that answers
                        string Chatter = sr.ReadLine();//the name of teh suer that get the answers.
                        string Answer = sr.ReadLine();//yes or no
                        SendAnswer(Chatter, NameOfUser, Answer);
                        break;
                    case "IsTyping":
                        try
                        {
                            string name = sr.ReadLine();
                            if (name != "")
                            {
                                IsTyper(name);
                            }
                            else IsTyper("");

                        }
                        catch
                        {

                        }

                        break;
                    case "OnlineFriends"://will send the specific user his online friends.
                        NameOfUser = sr.ReadLine();
                        SendOnlineFriends(NameOfUser);
                        break;
                    case "FriendLookOut"://קשור לשמות המשתמשים
                        string requestname = sr.ReadLine().ToString();//the name of the user  which requestes to see the name of the users
                        SendNames(requestname);
                        break;
                    case "FriendRequest"://Linked to the "FriendRequest" Array
                        requestname = sr.ReadLine();//will serve as the friends name that the user wants to add; 
                        string sender = sr.ReadLine();//the name of the requester to send the friend request;
                        SendFriendRequest(requestname, sender);
                        break;
                    case "AddFriend"://linked to the "Friends" array and to the "FriendRequest" Array partially;
                        sender = sr.ReadLine();// the name of the user;
                        string FriendToAdd = sr.ReadLine();//the name of the friend the user wants to add;
                        AddAFriend(sender, FriendToAdd);
                        break;
                    case "DeclineFriend"://linked to the "FriendRequest" Array ;
                        sender = sr.ReadLine();//the name of the user
                        string FriendToDecline = sr.ReadLine();//the friend the user doens't want to add
                        DeclineFriend(sender, FriendToDecline);
                        break;
                    case "LogOut":
                        string RequesterName = sr.ReadLine();//name of the user that wants to exit
                        LogingOut(RequesterName);
                        break;
                    case "PrivateChatRequest":
                        Chatter = sr.ReadLine();//the user that is getting the request to chat.
                        RequesterName = sr.ReadLine();//name of the user the requests to chat.
                        SendPrivateChatRequest(Chatter, RequesterName);
                        break;
                    case "PrivChatIsTyping":
                            string PrivChatter = sr.ReadLine();
                            string PrivCurrUser = sr.ReadLine();
                            string IsTyping = sr.ReadLine();
                            IsPrivateChatTyping(PrivCurrUser, PrivChatter, IsTyping);
                        break;
                    case "PrivateChatSend":
                        Chatter = sr.ReadLine();//user that gets the message
                        string CurrentUser = sr.ReadLine();//user that sends the message
                        string message = sr.ReadLine();
                        SendMessage(Chatter, CurrentUser, message);
                        break;
                    case "":
                        break;

                }
            }

        }
        #endregion "The Main" 
        #region Auxiliary methods
        //private chat
        public static void MatchBetweenUserAndClient(ref ArrayList UserAndClientArray, ref ArrayList users)
        {
            if (users.Count > 0)
            {
                UserAndClientArray = new ArrayList(users.Count);
                foreach (User UserO in users)
                {

                    UserAndClient Us = new UserAndClient(UserO, null);//
                    UserAndClientArray.Add(Us);
                }
            }
            else
                UserAndClientArray = new ArrayList(users.Capacity);
        }
        public void IsPrivateChatTyping(string PrivCurrentUser, string PrivChatter, string PrivTyping)
        {
            string msgType;
            switch (PrivTyping)
	{
                case "":
                    msgType="Private Chat....";
                    break;
		default:
                    msgType=PrivTyping+" is typing......";
                    break;

	}
            ArrayList TcpUsers = new ArrayList(2);
            StreamWriter sw;
            TcpUsers.Add(FindUserAndClientByItsName(PrivCurrentUser).Client);
            TcpUsers.Add(FindUserAndClientByItsName(PrivChatter).Client);
            foreach (TcpClient item in TcpUsers)
            {
                sw = new StreamWriter(item.GetStream());
                sw.WriteLine("PrivateIsTyping");
                sw.WriteLine(msgType);
                sw.Flush();
            }

        }
        public void SendMessage(string Chatter, string CurrentUser, string message)//sends the message,need to mix with chathelper.
        {
            UserAndClient ChatterUsc = FindUserAndClientByItsName(Chatter);
            UserAndClient CurrentUserUsc = FindUserAndClientByItsName(CurrentUser);
            StreamWriter sw1 = new StreamWriter(ChatterUsc.Client.GetStream());
            StreamWriter sw2 = new StreamWriter(CurrentUserUsc.Client.GetStream());
            sw1.WriteLine("PrivChat");
            sw1.WriteLine(message);
            sw2.WriteLine("PrivChat");
            sw2.WriteLine(message);
            sw1.Flush();
            sw2.Flush();
        }
        public void SendAnswer(string Chatter, string Requester, string answer)//this action sends the answer to the Chatter according  to the chatter's answer.
        {
            UserAndClient usc = FindUserAndClientByItsName(Chatter);
            StreamWriter sw = new StreamWriter(usc.Client.GetStream());
            sw.WriteLine("AnswerRequestToPrivateChat");
            sw.WriteLine(Requester);
            sw.WriteLine(answer);
            sw.Flush();


        }
        public void SendPrivateChatRequest(string chatter, string RequesterName)//requestername-the user who sends the request,chatter- the user that is getting the request.
        {
            UserAndClient UAC = null;
            foreach (Client Client in (Program.Clients))
            {
                if (Client.us != null)
                {
                    if (Client.us.UserName == chatter)
                    {
                        UAC = new UserAndClient(Client.us, Client.connector);//the user that is getting requests
                        break;
                    }
                }
            }
            StreamWriter sw = new StreamWriter(UAC.Client.GetStream());
            sw.WriteLine("RequestToPrivateChat");
            sw.WriteLine(RequesterName);
            sw.Flush();

        }
        public UserAndClient FindUserAndClientByItsName(string name)//will return an UserandClient Object that matches to the name;
        {
            UserAndClient UAC = null;
            TcpClient tcp = null;

            foreach (Client Client in (Program.Clients))
            {
                if (Client.us != null)
                {
                    if (Client.us.UserName == name)
                    {
                        UAC = new UserAndClient(Client.us, Client.connector);
                        break;
                    }
                }

            }
            return UAC;
        }
        //private chat end
        //friends
        public void DeclineFriend(string sender, string FriendToDecline)//להוסיף: טיפול במערך בקשות החברות שהמשתמש עצמו שולח.
        {
            foreach (User userD in users)
            {
                if (sender == userD.UserName)
                {
                    userD.FriendRequests.Remove(FriendToDecline);
                    break;
                }
            }
            foreach (User UserN in users)
            {
                if (FriendToDecline == UserN.UserName)
                {
                    UserN.FriendRequestsSent.Remove(sender);
                    break;
                }
            }
        }
        public User MatchNameToUser(string name)
        {
            User a = null;
            foreach (User UserAG in users)
            {
                if (name == UserAG.UserName)
                {
                    a = UserAG;
                    break;
                }
            }
            return a;
        }
        public void SendOnlineFriends(string name)
        {
            User us = null;
            //will match users now
            foreach (User UserP in users)
            {
                if (name == UserP.UserName)
                {
                    us = UserP;
                    break;
                }
            }
            List<string> OnlineFriends = new List<string>(us.friends.Count);
            foreach (string UserAB in us.friends)//will delete all the users that aren't online.
            {
                User b = MatchNameToUser(UserAB);
                if (b.online == true)
                {
                    OnlineFriends.Add(b.UserName);
                }
            }
            OnlineFriends.TrimExcess();

            StreamWriter sw = new StreamWriter(connector.GetStream());
            sw.WriteLine("OnlineFriends");
            string count = OnlineFriends.Count.ToString();
            sw.WriteLine(count);
            foreach (String OnlineUserName in OnlineFriends)
            {
                sw.WriteLine(OnlineUserName);
            }
            sw.Flush();



        }
        public void AddAFriend(string sender, string FriendToAdd)//להוסיף:טיפול במערך בקשות החברות שהמשתמש עצמו שולח.
        {
            foreach (User userB in users)//linked to the user
            {
                if (sender == userB.UserName)
                {
                    userB.friends.Add(FriendToAdd);
                    userB.FriendRequests.Remove(FriendToAdd);

                    break;
                }

            }
            foreach (User userC in users)
            {
                if (FriendToAdd == userC.UserName)
                {
                    userC.friends.Add(sender);
                    userC.FriendRequestsSent.Remove(sender);
                    break;
                }

            }
        }
        public void SendFriendRequest(string requestname, string requester)
        {
            foreach (User us in users)
            {
                if (us.UserName == requestname)
                {
                    us.FriendRequests.Add(requester);
                }

            }
            foreach (User UserF in users)
            {
                if (requester == UserF.UserName)
                {
                    UserF.FriendRequestsSent.Add(requestname);
                }
            }
        }
        public void SendNames(string name)//שולח את רשימת החברים למשתמש.  
        {
            StreamWriter sw = new StreamWriter(connector.GetStream());
            sw.WriteLine("SendNames");
            if (names.Count != 0)
            {

                List<string> copy = new List<string>(100);
                foreach (string namescopy in names)
                {
                    copy.Add(namescopy);

                }

                copy.Remove(name);
                User UserToMatch = null;
                foreach (User UserE in users)//יעשה התאמה בין השם -למשתמש
                {
                    if (UserE.UserName == name)
                    {
                        UserToMatch = UserE;
                        break;
                    }

                }



                foreach (string NameOfUser in UserToMatch.friends)//חברים קיימים של משתמש לא צריכים להתווסף עוד פעם.
                {
                    copy.Remove(NameOfUser);
                }
                foreach (string NameOfFriendsSent in UserToMatch.FriendRequestsSent)//חברים קיימים שנשלח להם בקשת חברות לא צריכים שישלח אליהם עוד פעם בקשת חברות כל עוד לא אישרו/דחו את בקשת החברות הקיימת(מונע כפילות של בקשות חברות) לכן ימחקו ממערך האנשים שניתן לשלוח אליהם בקשת חברות
                {
                    copy.Remove(NameOfFriendsSent);
                }

                copy.TrimExcess();
                string count = copy.Count.ToString();//גודל הרשימה 'copy'
                sw.WriteLine(count);
                foreach (string UserName in copy)
                {
                    sw.WriteLine(UserName);
                }
                sw.Flush();
            }
            else//in case that Names.Count=0
            {
                sw.WriteLine("0");
                sw.Flush();
            }

        }
        // friends end
        //public chat
        public void RemoveFromPubChat(TcpClient Connector)
        {
            Program.PubChatUsers.Remove(connector);
            Console.WriteLine("the user is no longer participates in the chat!");
        }
        public void IsTyper(string name)
        {
            foreach (TcpClient Connector in Program.PubChatUsers)
            {
                StreamWriter sw = new StreamWriter(Connector.GetStream());
                sw.WriteLine("IsTyping");
                sw.Flush();
                if (name != "")
                {
                    sw.WriteLine(name + " is typing");
                    sw.Flush();
                }
                else
                {
                    sw.WriteLine("Public Chat...");
                    sw.Flush();
                }
            }
        }
        public void CheckState()//יעדכן את מצב המשתמש.
        {

            BinaryFormatter bn = new BinaryFormatter();
            try
            {
                ArrayList arr = (ArrayList)bn.Deserialize(connector.GetStream());//בעיה 
                state = arr[0].ToString();
                us = (User)arr[1];
                string msg = arr[2].ToString();
                Checker(us, state, msg);
            }
            catch
            {
            }


        }
        public void AddToPubChat(TcpClient connector)
        {
            Program.PubChatUsers.Add(connector);
            Console.WriteLine("a user has connected the public chat");
        }
        public void GetPublicMessages(string msg)
        {
            PublicChatSendMessages(msg);///////////////////////////////
        }
        public void PublicChatSendMessages(string message)
        {
            //BinaryFormatter bn = new BinaryFormatter();

            foreach (TcpClient Connector in Program.PubChatUsers)
            {
                StreamWriter sw = new StreamWriter(Connector.GetStream());
                sw.WriteLine("PubChat");
                sw.Flush();
                sw.WriteLine(message);
                sw.Flush();
            }
        }
        //public chat end
         //register
        public void Register(ArrayList Info)
        {
            StreamWriter sw = new StreamWriter(connector.GetStream());
            sw.WriteLine("Reg");
            sw.Flush();
            Console.WriteLine("Registartion is being activated");
            User us = new User(Info[0].ToString(), Info[1].ToString(), Info[2].ToString());
            if (CheckIfExistForRegister(us) == false)
            {
                AddUser(us);
                Console.WriteLine("success");
                returnBool(false);
                SendEmail(us);
                UserAndClient UsAndTcpClient = new UserAndClient(us, null);
                Program.UserAndClientArray.Add(UsAndTcpClient);
            }
            else
            {
                Console.WriteLine("failure");
                returnBool(true);
            }
        }//register
        public static void SendEmail(User us)//שולח מכתב לאימייל המשתמש
        {
            //message
            MailMessage message = new MailMessage();

            message.To.Add(us.Email);
            message.Subject = "Registartion!";
            message.From = new MailAddress("admin@gmail.com");
            message.Body = "Welcome" + " " + us.UserName + ", thank you for registering!" + "\n" + "your password is: " + us.Password;//need to add get function to password//
            //smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("projectadmziv@gmail.com", "206606709");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
        public void AddUser(User us)//will add the user to the arraylist of users;
        {
            Console.WriteLine("SUCCESS,user added");
            names.Add(us.UserName.ToString());
            users.Add(us);

            UserAndClient UsAndTcpClient = new UserAndClient(us, null);
            Program.UserAndClientArray.Add(UsAndTcpClient);

        }
        public void Checker(User us, string state, string msg)
        {
            StreamWriter sw = new StreamWriter(connector.GetStream());

            if (state == "Exit")
            {
                Program.Clients.Remove(this);
                Console.WriteLine("One of the users Has logged out");
            }
        }
   
        //register end
        
        public bool CheckIfExistForRegister(User us)//true-exist,false-not
        {
            bool exist = false;
            foreach (User item in users)
            {
                if (item.UserName == us.UserName)
                {
                    exist = true;
                }
                else
                {
                    if (item.Email == us.Email)
                        exist = true;
                }

            }
            return exist;
        }
        public void returnBool(bool b)//will return bool for the register thing,so they can communicate with ech other//
        {
            StreamWriter sw = new StreamWriter(connector.GetStream());
            string Exists = b.ToString();
            sw.WriteLine(Exists);
            sw.Flush();
        }
        public bool CheckIfExistForLogin(User us)//will return true if exists,else false
        {
            bool username = false;
            bool password = false;
            foreach (User item in users)
            {
                if (item.UserName == us.UserName)
                {
                    username = true;
                    if (item.Password == us.Password)
                    {
                        password = true;
                        break;
                    }
                }
                else username = false;

            }
            return username && password;

        }
        //online
        public void UpdateOnlineStatus(bool OnlineStatus, string nameOfUser)//onlinestatus=true online,online status=false->offline,will update in all the arrays of all the users the current online status of the user.
        {
            //match name to user.
            User UserMatched = null;
            foreach (User userAC in users)
            {
                if (userAC.UserName == nameOfUser)
                {
                    UserMatched = userAC;
                    break;
                }
            }
            UserMatched.online = OnlineStatus;
            //will now update all of the users arrays with teh current users status.
            foreach (User UserAD in users)
            {
                foreach (string UserAE in UserAD.friends)
                {
                    User c = MatchNameToUser(UserAE);
                    if (c.UserName == nameOfUser)
                    {
                        c.online = OnlineStatus;
                        break;
                    }
                }
            }
        }
        //online end
        //login
        public void CheckLogin(ArrayList Info)
        {

            User us = new User(Info[0].ToString(), Info[1].ToString(), "someemail");//the email doesn't matter.
            Console.WriteLine("login is being activated");
            if (CheckIfExistForLogin(us) == true)
            {
                MatchUsers(ref us, connector);//to synchronize between users
                Login(us, true);

                Console.WriteLine("Login succeed");
            }
            else
            {

                Login(null, false);
                Console.WriteLine("Login failed");
            }

        }
        public void Login(User us, bool Exists)
        {
            StreamWriter sw = new StreamWriter(connector.GetStream());
            sw.WriteLine("Logi");
            sw.Flush();
            sw.WriteLine("5");

            if (Exists == true)
            {
                if (us.online == false)//משתמש לא יוכל להכנס למשתמש שכבר מחובר
                {

                    foreach (User User in users)
                    {
                        if (us.UserName == User.UserName)
                        {
                            us.FriendRequests = User.FriendRequests;
                            us.friends = User.friends;
                        }
                    }

                    //friends list
                    sw.WriteLine(us.UserName);//will be his name
                    sw.WriteLine("CanLogin");//determines whether user is online or not. already
                    sw.WriteLine(Exists.ToString());//determiness if the  user exists
                    string friendsArrCounter = us.friends.Count.ToString();
                    sw.WriteLine(friendsArrCounter);
                    foreach (string FriendName in us.friends)
                    {
                        sw.WriteLine(FriendName);

                    }
                    string friendsReqArrayCounter = us.FriendRequests.Count.ToString();
                    sw.WriteLine(friendsReqArrayCounter);

                    foreach (string FriendsRequestName in us.FriendRequests)
                    {
                        sw.WriteLine(FriendsRequestName);
                    }


                    sw.Flush();
                    this.us = us;
                    MatchUsers(ref us, connector);
                    //will match here between client and user.
                    UpdateOnlineStatus(true, us.UserName);

                }
                else if (us.online == true) //us.online==true
                {
                    sw.WriteLine("");
                    sw.WriteLine("CantLogin");
                    sw.WriteLine(Exists.ToString());
                    //    sw.WriteLine("Friends");
                    sw.WriteLine("0");
                    //sw.WriteLine("FriendRequests");
                    sw.WriteLine("0");
                    sw.Flush();
                }

            }
            else
            {
                sw.WriteLine("");
                sw.WriteLine("CantLogin");
                sw.WriteLine(Exists.ToString());
                //    sw.WriteLine("Friends");
                sw.WriteLine("0");//גודל של Friends 
                //sw.WriteLine("FriendRequests");
                sw.WriteLine("0");//גודל של FriendsRequests
                sw.Flush();
            }




        }//login
        public void MatchUsers(ref User us, TcpClient Mishtamesh)//will match between users(synchronaztion purposes )
        {
            foreach (User UserP in users)
            {
                if (us.UserName == UserP.UserName)
                {
                    us = UserP;
                    break;
                }
                UserAndClient OnlineUser = new UserAndClient(us, Mishtamesh);
                foreach (UserAndClient UserClientA in Program.UserAndClientArray)
                {
                    if (OnlineUser.us.UserName == UserClientA.us.UserName)
                    {
                        UserClientA.Client = OnlineUser.Client;
                        break;
                    }
                }
            }
        }
        //login end
        //logingout
        public void LogingOut(string name)
        {
            this.us = null;
            User us = null;//for syncharnazation purposes.
            foreach (User UserH in users)
            {
                if (name == UserH.UserName)
                {
                    us = UserH;
                    break;
                }
            }
            UpdateOnlineStatus(false, name);
            foreach (UserAndClient OnlineUser in Program.UserAndClientArray)
            {
                if (OnlineUser.us.UserName == name)
                {
                    OnlineUser.Client = null;
                    break;
                }
            }
            Console.WriteLine("A user has Logged Out");
        }
        //logingout end
        #endregion Auxiliary methods
       
    }
}
