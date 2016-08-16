using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using Version = It.Model.Domain.Version;

namespace It.Model.Interfaces
{
    public interface IIssueTrackerService
    {
        void AddProject(Project project);

        void AddProjectVersion(Guid projectId, Version version);

        void AddProjectUser(Guid projectId, User user);

        void AddProjectIssue(Guid projectId, Issue issue);

        void UpdateIssueStatus(Guid issueId, IssueState newState);

        //Optional

        void AddUser(User user);
    }
}
