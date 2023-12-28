using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectClasses
{
    [Serializable]
   public class BasicUser
    {
        string username;
        string password;
        string email;
        public BasicUser(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
}
