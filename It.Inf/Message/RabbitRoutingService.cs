using System;
using System.Collections.Generic;
using System.Linq;
using It.Data.Dto;
using It.Inf.Helpers;
using It.Inf.Mappers;
using It.Model.Domain;
using It.Model.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Version = It.Model.Domain.Version;

namespace It.Inf.Message
{
    public class RabbitRoutingService : IRoutingService
    {
        private readonly IMessageService _messageService;

        public RabbitRoutingService()
        {
            //TODO: Replace with Dependency Injection
            _messageService = new RabbitMessageService();
        }

        public void ListenIssueCommands(Func<IEvent, bool> callback)
        {
            _messageService.Listen(
                criteria: new ListenCriteria
                {
                    Source = RabbitRoutingHelper.GetForward(),
                    FilteringTag = RabbitRoutingHelper.GetIssueCommandRoutingKey()
                },
                callback: msg =>
                {
                    var jsonEvent = new JsonEvent<IssueDto>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetIssueCommandQueue());
        }

        public void ListenProjectCommands(Func<IEvent, bool> callback)
        {
            _messageService.Listen(
                criteria: new ListenCriteria
                {
                    Source = RabbitRoutingHelper.GetForward(),
                    FilteringTag = RabbitRoutingHelper.GetProjectCommandRoutingKey()
                },
                callback: msg =>
                {
                    var jsonEvent = new JsonEvent<ProjectDto>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetProjectCommandQueue());
        }

        public void ListenVersionCommands(Func<IEvent, bool> callback)
        {
            _messageService.Listen(
                criteria: new ListenCriteria
                {
                    Source = RabbitRoutingHelper.GetForward(),
                    FilteringTag = RabbitRoutingHelper.GetVersionCommandRoutingKey()
                },
                callback: msg =>
                {
                    var jsonEvent = new JsonEvent<VersionDto>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetVersionCommandQueue());
        }

        public void ListenUserCommands(Func<IEvent, bool> callback)
        {
            _messageService.Listen(
                criteria: new ListenCriteria
                {
                    Source = RabbitRoutingHelper.GetForward(),
                    FilteringTag = RabbitRoutingHelper.GetUserCommandRoutingKey()
                },
                callback: msg =>
                {
                    var jsonEvent = new JsonEvent<UserDto>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetUserCommandQueue());
        }

        public void PublishIssues(ICollection<Issue> issues)
        {
            var issueDtos = issues.Select(issue => AutomapperConfiguration.Mapper.Map<Issue, IssueDto>(issue)).ToList();
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(issueDtos)
            }, RabbitRoutingHelper.GetIssueFeed(), RabbitRoutingHelper.GetIssueFeedRoutingKey());
        }

        public void PublishProjects(ICollection<Project> projects)
        {
            var dtos = projects.Select(source => AutomapperConfiguration.Mapper.Map<Project, ProjectDto>(source)).ToList();
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(dtos)
            }, RabbitRoutingHelper.GetProjectFeed(), RabbitRoutingHelper.GetProjectFeedRoutingKey());
        }

        public void PublishStatus(Status status)
        {
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(AutomapperConfiguration.Mapper.Map<Status, StatusDto>(status))
            }, 
            RabbitRoutingHelper.GetStatusFeed(), RabbitRoutingHelper.GetStatusFeedRoutingKey());
        }

        public void PublishUsers(ICollection<User> users)
        {
            var dtos = users.Select(source => AutomapperConfiguration.Mapper.Map<User, UserDto>(source)).ToList();
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(dtos)
            }, 
            RabbitRoutingHelper.GetUserFeed(), RabbitRoutingHelper.GetUserFeedRoutingKey());
        }
    }
}