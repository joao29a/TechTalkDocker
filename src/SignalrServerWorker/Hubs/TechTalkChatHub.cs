using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalrCommon;
using System;
using System.Threading.Tasks;

namespace SignalrServerWorker.Hubs
{
    public class TechTalkChatHub : Hub<ITechClient>
    {
        private readonly ILogger<TechTalkChatHub> _logger;

        public TechTalkChatHub(ILogger<TechTalkChatHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            var user = Context.UserIdentifier;
            await Clients.Others.Joined(user);
            _logger.LogInformation($"Usuario {user} entrou!");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            var user = Context.UserIdentifier;
            await Clients.Others.Unjoined(user);
            _logger.LogInformation($"Usuario {user} saiu!");
            await base.OnDisconnectedAsync(ex);
        }

        public async Task SendMessage(string message)
        {
            await Clients.Others.ReceiveMessage(Context.UserIdentifier, message);
        }
    }
}
