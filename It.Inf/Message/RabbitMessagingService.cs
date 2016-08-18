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
    public class RabbitMessagingService : IMessagingService
    {
        private readonly IAmqpService _amqpService;

        public RabbitMessagingService()
        {
            //TODO: Replace with Dependency Injection
            _amqpService = new RabbitAmqpService();
        }

        public void ListenIssueCommands(Func<IRequest, IResponse> callback)
        {
            SetupForwardListener(RabbitRoutingHelper.GetIssueCommandQueue(),
                RabbitRoutingHelper.GetIssueCommandRoutingKey(), callback);
        }

        public void ListenProjectCommands(Func<IRequest, IResponse> callback)
        {
            SetupForwardListener(RabbitRoutingHelper.GetProjectCommandQueue(),
                RabbitRoutingHelper.GetProjectCommandRoutingKey(), callback);
        }

        public void ListenVersionCommands(Func<IRequest, IResponse> callback)
        {
            SetupForwardListener(RabbitRoutingHelper.GetVersionCommandQueue(),
                RabbitRoutingHelper.GetVersionCommandRoutingKey(), callback);
        }

        public void ListenAllCommands(Func<IRequest, IResponse> callback)
        {
            SetupForwardListener(RabbitRoutingHelper.GetAllCommandQueue(),
                "#", callback);
        }

        public void ListenUserCommands(Func<IRequest, IResponse> callback)
        {
            SetupForwardListener(RabbitRoutingHelper.GetUserCommandQueue(),
                RabbitRoutingHelper.GetUserCommandRoutingKey(), callback);
        }

        public void PublishIssues(ICollection<Issue> issues)
        {
            var issueDtos = issues.Select(issue => AutomapperConfiguration.Mapper.Map<Issue, IssueDto>(issue)).ToList();
            _amqpService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(issueDtos)
            }, RabbitRoutingHelper.GetIssueFeed(), RabbitRoutingHelper.GetIssueFeedRoutingKey());
        }

        public void PublishProjects(ICollection<Project> projects)
        {
            var dtos = projects.Select(source => AutomapperConfiguration.Mapper.Map<Project, ProjectDto>(source)).ToList();
            _amqpService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(dtos)
            }, RabbitRoutingHelper.GetProjectFeed(), RabbitRoutingHelper.GetProjectFeedRoutingKey());
        }

        public void PublishStatus(Status status)
        {
            _amqpService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(AutomapperConfiguration.Mapper.Map<Status, StatusDto>(status))
            }, 
            RabbitRoutingHelper.GetStatusFeed(), 
            RabbitRoutingHelper.GetStatusFeedRoutingKey());
        }

        public void PublishUsers(ICollection<User> users)
        {
            var dtos = users.Select(source => AutomapperConfiguration.Mapper.Map<User, UserDto>(source)).ToList();
            _amqpService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(dtos)
            }, 
            RabbitRoutingHelper.GetUserFeed(), RabbitRoutingHelper.GetUserFeedRoutingKey());
        }

        private void SetupForwardListener(string queueName, string routingKey, Func<IRequest, IResponse> callback)
        {
            _amqpService.Listen(queueName, new ListenCriteria
            {
                Source = RabbitRoutingHelper.GetForward(),
                FilteringTag = routingKey
            }, msg =>
            {
                var jsonEvent = new JsonRequestParser<IssueDto>(msg.Body);
                var response = callback(jsonEvent);
                return response.GetResponseMessage();
            });
        }
    }
}