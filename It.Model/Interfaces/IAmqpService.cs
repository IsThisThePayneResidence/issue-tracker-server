using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Interfaces
{
    public class Message
    {
        public string Body { get; set; }
    }

    public class ListenCriteria
    {
        public string Source { get; set; }

        public string FilteringTag { get; set; }
    }

    public interface IAmqpService
    {
        void Send(Message message, string destination, string filteringTag);

        void Listen(ListenCriteria criteria, Func<Message, Message> callback);

        void Listen(string listeningPointName, ListenCriteria criteria, Func<Message, Message> callback);
    }
}
