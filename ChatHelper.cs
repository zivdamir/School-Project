using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class ChatHelper//the goal of this class is to help the privatechat 
    {
      public   List<string> Chat{get;set;}
       public string Participant1{get;set;}
       public string Participant2{get;set;}
       public ChatHelper(List<string> Chat, string Participant1, string Participant2)
       {
           this.Chat = Chat;
           this.Participant1 = Participant1;
           this.Participant2 = Participant2;
       }
    }
}
