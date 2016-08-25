using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Interfaces
{
    public class ListenCriteria
    {
        public string Source { get; set; }

        public string FilteringTag { get; set; }
    }

    public interface IAmqpService
    {
        void Send(string message, string destination, string filteringTag);

        void Listen(ListenCriteria criteria, Func<IRequest, IResponse> callback);

        void Listen(string listeningPointName, ListenCriteria criteria, Func<IRequest, IResponse> callback);
    }
}
