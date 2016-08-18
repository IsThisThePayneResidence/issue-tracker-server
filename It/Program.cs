using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Inf;
using It.Inf.Message;
using It.Inf.Repository;
using It.Model.Interfaces;

namespace It
{
    class Program
    {
        static void Main(string[] args)
        {
            IInitializer initializer = new Initializer(new UserRepository(), new IssueRepository(),
                new ProjectRepository(), new StatusRepository(), new RabbitMessagingService());
            initializer.Initialize();
        }
    }
}
