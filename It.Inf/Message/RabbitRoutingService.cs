using System;
using System.Collections.Generic;
using It.Inf.Helpers;
using It.Model.Domain;
using It.Model.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
                    var jsonEvent = new JsonEvent<Issue>(msg.Body);
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
                    var jsonEvent = new JsonEvent<Project>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetProjectCommandQueue());
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
                    var jsonEvent = new JsonEvent<User>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetUserCommandQueue());
        }

        public void PublishIssues(ICollection<Issue> issues)
        {
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(issues)
            }, RabbitRoutingHelper.GetIssueFeed(), RabbitRoutingHelper.GetIssueFeedRoutingKey());
        }

        public void PublishProjects(ICollection<Project> projects)
        {
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(projects)
            }, RabbitRoutingHelper.GetProjectFeed(), RabbitRoutingHelper.GetProjectFeedRoutingKey());
        }

        public void PublishStatus(Status status)
        {
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(status)
            }, RabbitRoutingHelper.GetStatusFeed(), RabbitRoutingHelper.GetStatusFeedRoutingKey());
        }

        public void PublishUsers(ICollection<User> users)
        {
            _messageService.Send(new Model.Interfaces.Message
            {
                Body = JsonSerializationHelper.Serialize(users)
            }, RabbitRoutingHelper.GetUserFeed(), RabbitRoutingHelper.GetUserFeedRoutingKey());
        }
    }
}