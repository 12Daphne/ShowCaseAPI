using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        try
        {
            
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        catch (Exception ex)
        {
            
            Console.WriteLine("Error in SendMessage method:", ex.Message);
            throw; 
        }
    }

    public async Task SendChatMessage(string user, string sended, string message)
    {
        try
        {
            await Clients.All.SendAsync("ReceiveChatMessage", user, sended, message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in SendMessage method:", ex.Message);
        }
    }
}