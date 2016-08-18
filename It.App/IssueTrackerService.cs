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

        private readonly IMessagingService _messagingService;

        public IssueTrackerService(
            IUserRepository userRepository, 
            IIssueRepository issueRepository, 
            IProjectRepository projectRepository, 
            IStatusRepository statusRepository, 
            IMessagingService messagingService)
        {
            _userRepository = userRepository;
            _issueRepository = issueRepository;
            _projectRepository = projectRepository;
            _statusRepository = statusRepository;
            _messagingService = messagingService;
        }

        public void AddProject(Project project)
        {
            _projectRepository.Insert(project);
        }

        public void AddProjectVersion(Guid projectId, Version version)
        {
            var project = _projectRepository.GetById(projectId);
            project.Versions.Add(version);
            _projectRepository.Update(project);
        }

        public void AddProjectUser(Guid projectId, User user)
        {
            var project = _projectRepository.GetById(projectId);
            project.Users.Add(user);
            _projectRepository.Update(project);
            _userRepository.Insert(user);
        }

        public void AddProjectIssue(Guid projectId, Issue issue)
        {
            var project = _projectRepository.GetById(projectId);
            project.Issues.Add(issue);
            _projectRepository.Update(project);
            _issueRepository.Insert(issue);
        }

        public void UpdateIssueStatus(Guid issueId, IssueState newState)
        {
            var issue = _issueRepository.GetById(issueId);
            var project = _projectRepository.GetById(issue.Project.Id);
            project.Issues.Remove(issue);
            issue.State = newState;
            project.Issues.Add(issue);
            _projectRepository.Update(project);
            _issueRepository.Update(issue);
        }

        public void AddUser(User user)
        {
            _userRepository.Insert(user);
        }
    }
}
