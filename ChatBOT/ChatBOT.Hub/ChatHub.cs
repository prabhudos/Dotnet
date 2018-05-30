using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using signalR = Microsoft.AspNet.SignalR;

namespace ChatBOT.Hub
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

        //public void Send(string name, string room, string message)
        //{
        //    Clients.Group(room).broadcastMessage(name, message);
        //    //Clients.All.broadcastMessage(name, message);
        //}
    }
}