using Microsoft.AspNetCore.SignalR;  
using System.Threading.Tasks;  
  
namespace BlazorSignalRApp.Server.Hubs  
{
    public class OeeHub : Hub  
    {
        public async Task SendMessage()  
        {
            await Clients.All.SendAsync("ReceiveMessage");  
        }
    }
}