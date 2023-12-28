using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net.Sockets;
namespace ProjectClasses
{
    [Serializable]
    public class User:BasicUser
    {
       private  string  userName;
       private string password;
       private string email;
       public ArrayList friendRequests;//will contain the friend requests
       public ArrayList friends { get; set; }//will contain the friends of the user
       public bool online { get; set; }//determines whtere the user is online or not.
       public ArrayList FriendRequestsSent { get; set; }//will contain the friend requests the user sent(for synchronization purposes)
       public User(string userName,string password,string email):base(userName,password,email)
       {
           this.userName = userName;
           this.password = password;
           this.email = email;
           this.friends = new ArrayList(100);//capacity-100
           this.friendRequests = new ArrayList(100);//capacity-100
           this.FriendRequestsSent = new ArrayList(100);//capacity-100
       }

       public string Password
       {
           get { return password; }
           set { password = value; }
       }
       public string UserName
       {
           get { return userName; }
       }
       public string Email
       {
           get { return email; }
           set { email = value; }
       }
       public ArrayList FriendRequests
       {
           get { return friendRequests; }
           set { friendRequests = value; }

       }
      
        
    }
}
