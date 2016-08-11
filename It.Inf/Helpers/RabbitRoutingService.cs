using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;

namespace It.Inf.Helpers
{
    class RabbitRoutingService : IRoutingService
    {
        public void ListenCommands(Func<IEvent, bool> callback)
        {
            throw new NotImplementedException();
        }

        public void ListenIssueCommands(Func<IEvent, bool> callback)
        {
            throw new NotImplementedException();
        }

        public void ListenProjectCommands(Func<IEvent, bool> callback)
        {
            throw new NotImplementedException();
        }

        public void ListenUserCommands(Func<IEvent, bool> callback)
        {
            throw new NotImplementedException();
        }

        public void PublishIssues(ICollection<Issue> issues)
        {
            throw new NotImplementedException();
        }

        public void PublishProjects(ICollection<Project> projects)
        {
            throw new NotImplementedException();
        }

        public void PublishStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public void PublishUsers(ICollection<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
