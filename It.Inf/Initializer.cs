using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.App;
using It.Data.Dto;
using It.Inf.Helpers;
using It.Inf.Mappers;
using It.Model.Domain;
using It.Model.Interfaces;
using Version = It.Model.Domain.Version;

namespace It.Inf
{
    public class Initializer : IInitializer
    {

        private readonly IUserRepository _userRepository;

        private readonly IIssueRepository _issueRepository;

        private readonly IProjectRepository _projectRepository;

        private readonly IStatusRepository _statusRepository;

        private readonly IRoutingService _routingService;

        private IIssueTrackerService _issueTrackerService;

        public Initializer(
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

        public void Initialize()
        {
            InitializeRabbitMQ();

            _issueTrackerService = new IssueTrackerService(_userRepository, _issueRepository, _projectRepository, _statusRepository, _routingService);

            _routingService.ListenIssueCommands(eventObj =>
            {
                var dto = (IssueDto) eventObj.GetData();
                var issue = AutomapperConfiguration.Mapper.Map<IssueDto, Issue>(dto);
                if (eventObj.IsCreate())
                {
                    _issueTrackerService.AddProjectIssue(dto.Project.Guid, issue);
                }
                else if (eventObj.IsUpdate())
                {
                    _issueTrackerService.UpdateIssueStatus(dto.Guid, issue.State);
                }
                return true;
            });

            _routingService.ListenProjectCommands(eventObj =>
            {
                var dto = (ProjectDto) eventObj.GetData();
                var project = AutomapperConfiguration.Mapper.Map<ProjectDto, Project>(dto);
                if (eventObj.IsCreate())
                {
                    _issueTrackerService.AddProject(project);
                }
                else if (eventObj.IsUpdate())
                {
                    if (project.Issues != null)
                    {
                        foreach (var issue in project.Issues)
                        {
                            _issueTrackerService.AddProjectIssue(project.Id, issue);
                        }
                    } else if (project.Projects != null)
                    {
//                        foreach (var subproject in project.Projects)
//                        {
//                            _issueTrackerService.AddProjectIssue(project.Id, subproject);
//                        }
                    } else if (project.Users != null)
                    {
                        foreach (var user in project.Users)
                        {
                            _issueTrackerService.AddProjectUser(project.Id, user);
                        }
                    }
                }
                return true;
            });

            _routingService.ListenVersionCommands(eventObj =>
            {
                var dto = (VersionDto) eventObj.GetData();
                var version = AutomapperConfiguration.Mapper.Map<VersionDto, Version>(dto);
                if (eventObj.IsCreate())
                {
                    _issueTrackerService.AddProjectVersion(version.Project.Id, version);
                }
                return true;
            });

            _routingService.ListenUserCommands(eventObj =>
            {
                var dto = (UserDto) eventObj.GetData();
                var user = AutomapperConfiguration.Mapper.Map<UserDto, User>(dto);
                if (eventObj.IsUpdate())
                {
                    foreach (var project in user.Projects)
                    {
                        _issueTrackerService.AddProjectUser(project.Id, user);
                    }
                }
                return true;
            });
        }

        private void InitializeRabbitMQ()
        {
//            RabbitRoutingHelper.GetForward();
        }
    }
}
