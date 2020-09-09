using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalrClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var port = Convert.ToInt32(args[0]);

            Console.WriteLine("Digite o nome do usuario: ");
            var user = Console.ReadLine();

            var client = new Client(port, user);

            await client.Start();

            Console.WriteLine("Conectado!");

            while (true)
            {
                var message = Console.ReadLine();
                
                await client.SendMessage(message);
            }
        }
    }
}
