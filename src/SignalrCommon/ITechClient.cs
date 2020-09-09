using System.Threading.Tasks;

namespace SignalrCommon
{
    public interface ITechClient
    {
        Task ReceiveMessage(string user, string message);
        Task Joined(string user);
        Task Unjoined(string user);
    }
}
