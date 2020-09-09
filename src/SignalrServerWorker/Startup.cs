using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalrServerWorker.Hubs;

namespace SignalrServerWorker
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR()
                .AddStackExchangeRedis("localhost:9090");

            services.AddHostedService<Worker>();

            services.AddSingleton<IUserIdProvider, TechUserIdProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<TechTalkChatHub>("/hubs/chat");
            });
        }
    }
}
