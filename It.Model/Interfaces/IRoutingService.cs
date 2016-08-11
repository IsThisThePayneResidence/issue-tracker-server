using It.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Interfaces
{
    public interface IRoutingService
    {
        void ListenUserCommands(Func<IEvent, bool> callback);

        void ListenIssueCommands(Func<IEvent, bool> callback);

        void ListenProjectCommands(Func<IEvent, bool> callback);

        void ListenCommands(Func<IEvent, bool> callback);

        void PublishUsers(ICollection<User> users);

        void PublishProjects(ICollection<Project> projects);

        void PublishIssues(ICollection<Issue> issues);

        void PublishStatus(Status status);
    }
}
