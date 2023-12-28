using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectClasses;
using System.Net.Sockets;

namespace Server
{
   public class UserAndClient
    {//מטרה:לתאם בין 
        public User us { get; set; }
        public  TcpClient Client { get; set; }
        public UserAndClient(User us, TcpClient Client)
        {
            this.us = us;
            this.Client = Client;
        }
    }
}
