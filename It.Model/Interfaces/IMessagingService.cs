using It.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Interfaces
{
    public interface IMessagingService
    {
        void ListenAllCommands(Func<IRequest, IResponse> callback);

        void ListenUserCommands(Func<IRequest, IResponse> callback);

        void ListenIssueCommands(Func<IRequest, IResponse> callback);

        void ListenProjectCommands(Func<IRequest, IResponse> callback);

        void ListenVersionCommands(Func<IRequest, IResponse> callback);
      
        void PublishUsers(ICollection<User> users);

        void PublishProjects(ICollection<Project> projects);

        void PublishIssues(ICollection<Issue> issues);

        void PublishStatus(Status status);
    }
}
