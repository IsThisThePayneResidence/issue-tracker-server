using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private readonly IMessagingService _messagingService;

        private IIssueTrackerService _issueTrackerService;

        public Initializer(
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

        public void Initialize()
        {
            _issueTrackerService = new IssueTrackerService(_userRepository, _issueRepository, _projectRepository, _statusRepository, _messagingService);
            
//            _messagingService.ListenIssueCommands(eventObj =>
//            {
//                if (eventObj.IsGet())
//                {
//                    return ResponseHelper.GetResponse("200", _issueRepository.GetAll());
//                }
//                var dto = (IssueDto) eventObj.GetData();
//                var issue = AutomapperConfiguration.Mapper.Map<IssueDto, Issue>(dto);
//                if (eventObj.IsCreate())
//                {
//                    _issueTrackerService.AddProjectIssue(dto.Project.Guid, issue);
//                    return ResponseHelper.GetResponse("200", new Dictionary<string, object>());
//                }
//                if (eventObj.IsUpdate())
//                {
//                    _issueTrackerService.UpdateIssueStatus(dto.Guid, issue.State);
//                    return ResponseHelper.GetResponse("200", new Dictionary<string, object>());
//                }
//                return ResponseHelper.GetResponse("405", new Dictionary<string, object>());
//            });

            _messagingService.ListenProjectCommands(eventObj =>
            {
                if (eventObj.IsGet())
                {
                    return ResponseHelper.GetResponse("200", _projectRepository.GetAll());
                }
                var dto = (ProjectDto) eventObj.GetData();
                var project = AutomapperConfiguration.Mapper.Map<ProjectDto, Project>(dto);
                if (eventObj.IsCreate())
                {
                    project.Id = Guid.NewGuid();
                    _issueTrackerService.AddProject(project);
                    return ResponseHelper.GetResponse("200", new Dictionary<string, object>());
                }
                if (eventObj.IsUpdate())
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
                    return ResponseHelper.GetResponse("200", new Dictionary<string, object>());
                }

                return ResponseHelper.GetResponse("405", new Dictionary<string, object>());
            });

//            _messagingService.ListenVersionCommands(eventObj =>
//            {
//                var dto = (VersionDto) eventObj.GetData();
//                var version = AutomapperConfiguration.Mapper.Map<VersionDto, Version>(dto);
//                if (eventObj.IsCreate())
//                {
//                    _issueTrackerService.AddProjectVersion(version.Project.Id, version);
//                    return ResponseHelper.GetResponse("200", new Dictionary<string, object>());
//                }
//                return ResponseHelper.GetResponse("405", new Dictionary<string, object>());
//            });

//            _messagingService.ListenUserCommands(eventObj =>
//            {
//                var dto = (UserDto) eventObj.GetData();
//                var user = AutomapperConfiguration.Mapper.Map<UserDto, User>(dto);
//
//                if (eventObj.IsGet())
//                {
//                    return ResponseHelper.GetResponse("200", _userRepository.GetAll());
//                }
//                if (eventObj.IsUpdate())
//                {
//                    foreach (var project in user.Projects)
//                    {
//                        _issueTrackerService.AddProjectUser(project.Id, user);
//                    }
//                    return ResponseHelper.GetResponse("200", new Dictionary<string, object>());
//                }
//                return ResponseHelper.GetResponse("405", new Dictionary<string, object>());
//            });

            SchedulingHelper.Schedule(() =>
            {
                _messagingService.PublishIssues(_issueRepository.GetAll());
                _messagingService.PublishProjects(_projectRepository.GetAll());
//                _messagingService.PublishStatus(_statusRepository.GetAll().FirstOrDefault());
                _messagingService.PublishUsers(_userRepository.GetAll());
                return true;
            },
            1);
        }
    }
}
