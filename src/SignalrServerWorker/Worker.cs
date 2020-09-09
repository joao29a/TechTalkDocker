using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SignalrCommon;
using SignalrServerWorker.Configurations;
using SignalrServerWorker.Hubs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalrServerWorker
{
    public class Worker : BackgroundService
    {
        private readonly IHubContext<TechTalkChatHub, ITechClient> _hubContext;
        private readonly List<UserConfiguration> _userConfigurations;

        public Worker(
            IHubContext<TechTalkChatHub, ITechClient> hubContext,
            IConfiguration configuration)
        {
            _hubContext = hubContext;
            _userConfigurations = configuration.GetSection("Users")
                .Get<List<UserConfiguration>>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var user = GetRandomUser();
                await _hubContext.Clients.All.ReceiveMessage(user.Name, user.GetRandomSentence());
                await Task.Delay(5000, stoppingToken);
            }
        }

        private UserConfiguration GetRandomUser()
        {
            var random = new Random();
            var index = random.Next(_userConfigurations.Count);
            return _userConfigurations[index];
        }
    }
}
