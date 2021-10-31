using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.Hubs
{
    public class OrderCreatedNotificationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(NotificationMessage message)
        {
            await Clients.All.SendAsync("orderCreated", message);
        }
    }
    public class NotificationMessage
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Message { get; set; }
    }
}
