using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using ProjectClasses;
using System.Net.Mail;
namespace Server
{
    enum StateOfClient
    {
        Login,
            Register,
        Exit,

    }
   //Client array=userandclient?
  public class Program
    {

      public static void adduser(List<string> names, ArrayList users)
      {
          try
          {
              foreach (User item in users)
              {
                  names.Add(item.UserName.ToString());
              }
          }
          catch
          {
              names = new List<string>();

          }
          
      }
      //server
      public static  void StartServer()
      {
         
          Client.names = new List<string>();
          PubChatUsers = new ArrayList(100);
          Clients = new ArrayList(100);         
          try
          {
              fs1 = new FileStream(@"D:\data.bin", FileMode.Open);
              BinaryFormatter bf = new BinaryFormatter();
              Client.users = (ArrayList)bf.Deserialize(fs1);

          }

          catch (Exception e)
          {
              fs1 = new FileStream(@"D:\data.bin", FileMode.Create);
              Client.users = new ArrayList(100);
              Console.WriteLine("Creating a New DataBase");

          }
          finally
          {
              fs1.Close();
          }

          adduser(Client.names, Client.users);
          Controller.Start();
          Console.WriteLine("Server Is Online");
          while (true)
          {

              if (Controller.Pending() == true)
              {

                  TcpUser = Controller.AcceptTcpClient();
                  Mishtamesh = new Client(TcpUser);
                  Clients.Add(Mishtamesh);
                  File.Delete(@"D:\data.bin");
                  fs2 = new FileStream(@"D:\data.bin", FileMode.Create);
                  BinaryFormatter formatter = new BinaryFormatter();
                  try
                  {

                      formatter.Serialize(fs2, Client.users);
                      Client.MatchBetweenUserAndClient(ref UserAndClientArray, ref Client.users);

                  }
                  catch (SerializationException e)
                  {
                      Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                      throw;
                  }
                  finally
                  {
                      fs2.Close();
                  }

                  Console.WriteLine("client accpeted");

              }
          }

      }
      public static void DisconnectSpecificUSer(string name)
      {
           
      }//לא משומש,אמור לנתק משתמש ספציפי
      public static void DisconnectAll()// הופך את כל המשתמשים למנותקים וסוגר את כל החיבורים,לא סוגר את הסרבר.
      {
          foreach (User us in Client.users)
          {
              us.online = false;
          }
          foreach (Client Lakoah in Program.Clients)
          {
              Lakoah.connector.Close();
          }

      }
      public static void DisconnectSpecificUser(string name)
      {
          foreach (User us in Client.users)
          {
              if (us.UserName == name)
              {
                  us.online = false;
                  break;
              }

          }
          Console.WriteLine("User:"+name+"status is offline!");
      }
      public static string GetLocalIPAddress()
      {
          var host = Dns.GetHostEntry(Dns.GetHostName());
          foreach (var ip in host.AddressList)
          {
              if (ip.AddressFamily == AddressFamily.InterNetwork)
              {
                  return ip.ToString();
              }
          }
          throw new Exception("Local IP Address Not Found!");
      }
      public static void AdminCommand()//פקודות לאדמין
      {
          Console.WriteLine("Welcome Admin,I am an Advanced A.I program that  helps you manage this project!"+"\n"+"For Help,Type 'Help'");
          bool online = false;
          while (true)
          {
              string Command=Console.ReadLine();
              switch (Command)
              {
                  case "CloseServer":
                      DisconnectAll();
                      Server.Abort();
                      Controller.Stop();
                      online = false;
                      break;
                  case "Offline":
                    Console.WriteLine("User To Turn Offline: ");
                    string user = Console.ReadLine();
                    switch (user)
                    {
                        case "All"://will make all users offline
                            DisconnectAll();
                            break;
                         default:

                            break;
                    }
                      break;
                  case "Kick":
                      break;
                  case "Start":
                      if (online == false)
                      {
                       
                              ip =IPAddress.Parse(GetLocalIPAddress());
                         
                         
                              Server.Start();


                            
                          
                           online = true;
                      }
                      else if (online == true)
                      {
                          Console.WriteLine("Error!Server is already Online!");
                      }

                      break;
                  case "Ban":
                      break;
                  case "BanIp":
                      break;
                  case "Help":
                      Console.WriteLine(HelpMsg);
                      break;
                  default:
                      Console.WriteLine("Such Command Doesn't exist,Please Try again!");
                      break;
              }

          }
      }
      #region variables
      public static ArrayList Clients;
         static string IpAdress;//נועד לקליטת ip 
         static IPAddress ip = IPAddress.Parse("0.0.0.0");
        static int port = 12346;
        static TcpListener Controller = new TcpListener(ip, port);//the server
        public static ArrayList PubChatUsers;
        static  Client Mishtamesh;
        public static TcpClient TcpUser;
        public static ArrayList UserAndClientArray;
      public static string HelpMsg="Here Is The List Of Commands"+"\n"+"'Start'-Starts The Server"+"\n"+"'CloseServer'-Closes The Server,Notice that after you close the server you have to restart the application if you want to start the server again"
          +"\n"+"'Kick'-Can Kick A specific user from the server,can also Kick all users if you type 'All'"+"\n"+"'Ban'-Bans Specific User"+"\n"+"'BanIp'-Bans Specific Ip of user"+"\n"+"'Offline'-makes specific user Offline,or all users In case you type 'All'"; 
        //admin
       public static  Thread Admin=new Thread(AdminCommand);//=new thread(AdminCommand);
       public static Thread Server = new Thread(StartServer);//starts the server
      //
        static FileStream fs1,fs2;
#endregion variables
        static void Main(string[] args)
        {
            Admin.Start();   
        }
    }
}
