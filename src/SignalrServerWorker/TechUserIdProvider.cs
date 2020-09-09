using Microsoft.AspNetCore.SignalR;

namespace SignalrServerWorker
{
    public class TechUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.GetHttpContext().Request.Query["user"].ToString();
        }
    }
}
