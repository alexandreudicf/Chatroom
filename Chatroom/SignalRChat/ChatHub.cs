﻿using System;
using System.Web;
using Microsoft.AspNetCore.SignalR;

namespace Chatroom.SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            //Clients.All.addNewMessageToPage(name, message);
        }
    }
}