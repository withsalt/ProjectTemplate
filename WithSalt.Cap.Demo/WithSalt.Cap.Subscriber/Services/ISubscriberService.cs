using DotNetCore.CAP;

namespace WithSalt.Cap.Subscriber.Services
{
    interface ISubscriberService : ICapSubscribe
    {
        void ReceivedMessage(string content);
    }
}
