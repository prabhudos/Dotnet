using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using signalR = Microsoft.AspNet.SignalR;

namespace ChatBOT.WebAPI
{
    public class ChatHub : signalR.Hub
    {
        public void Join(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }

        public void Leave(string room)
        {
            Groups.Remove(Context.ConnectionId, room);
        }
    }
}