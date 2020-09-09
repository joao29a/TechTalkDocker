using Microsoft.AspNetCore.SignalR.Client;
using SignalrCommon;
using System;
using System.Threading.Tasks;

namespace SignalrClient
{
    public class Client : ITechClient
    {
        private readonly HubConnection _hubConnection;

        public Client(int port, string user)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:{port}/hubs/chat?user={user}")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", ReceiveMessage);
            _hubConnection.On<string>("Joined", Joined);
            _hubConnection.On<string>("Unjoined", Unjoined);
        }

        public async Task Start()
        {
            await _hubConnection.StartAsync();
        }

        public async Task Stop()
        {
            await _hubConnection.StopAsync();
        }

        public Task Joined(string user)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"{user} entrou na sala!");
            Console.ResetColor();
            return Task.CompletedTask;
        }

        public Task Unjoined(string user)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{user} saiu da sala!");
            Console.ResetColor();
            return Task.CompletedTask;
        }

        public Task ReceiveMessage(string user, string message)
        {
            Console.WriteLine($"{user}: {message}");
            return Task.CompletedTask;
        }

        public async Task SendMessage(string message)
        {
            await _hubConnection.SendAsync("SendMessage", message);
        }
    }
}
