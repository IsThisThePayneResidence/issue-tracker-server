using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using It.Model.Interfaces;
using Version = It.Model.Domain.Version;

namespace It.App
{
    public class IssueTrackerService : IIssueTrackerService
    {
        private readonly IUserRepository _userRepository;

        private readonly IIssueRepository _issueRepository;

        private readonly IProjectRepository _projectRepository;

        private readonly IStatusRepository _statusRepository;

        private readonly IRoutingService _routingService;

        public IssueTrackerService(
            IUserRepository userRepository, 
            IIssueRepository issueRepository, 
            IProjectRepository projectRepository, 
            IStatusRepository statusRepository, 
            IRoutingService routingService)
        {
            _userRepository = userRepository;
            _issueRepository = issueRepository;
            _projectRepository = projectRepository;
            _statusRepository = statusRepository;
            _routingService = routingService;
        }

        public void AddProject(Project project)
        {
            _projectRepository.Insert(new Project());
        }

        public void AddProjectVersion(Guid projectId, Version version)
        {
            throw new NotImplementedException();
        }

        public void AddProjectUser(Guid projectId, User user)
        {
            throw new NotImplementedException();
        }

        public void AddProjectIssue(Guid projectId, Issue issue)
        {
            throw new NotImplementedException();
        }

        public void UpdateIssueStatus(Guid issueId, IssueState newState)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
