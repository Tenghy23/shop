using Microsoft.AspNetCore.SignalR;

namespace Application.Services
{
    public class StockTickerHub : Hub
    {
        public async Task SendMessage(string stockSymbol, double price)
        {
            // Broadcasts the stock update to all connected clients
            // TODO: to implement frontend to see live data update
            await Clients.All.SendAsync("ReceiveMessage", stockSymbol, price);
        }
    }
}
