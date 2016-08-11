using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using It.Inf.Helpers;
using Newtonsoft.Json;

namespace It.Inf.Message
{
    public class RabbitRoutingService : IRoutingService
    {
        IMessageService _messageService;
        
        public RabbitRoutingService()
        {
            //TODO: Replace with Dependency Injection
            _messageService = new RabbitMessageService();
        }

        public void ListenIssueCommands(Func<IEvent, bool> callback)
        {
            _messageService.Listen(
                criteria: new ListenCriteria()
                {
                    Source = RabbitRoutingHelper.GetForward(),
                    FilteringTag = RabbitRoutingHelper.GetIssueCommandRoutingKey()
                },
                callback: (Model.Interfaces.Message msg) => {
                    var jsonEvent = new JsonEvent<Issue>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetIssueCommandQueue());
        }

        public void ListenProjectCommands(Func<IEvent, bool> callback)
        {
            _messageService.Listen(
                criteria: new ListenCriteria()
                {
                    Source = RabbitRoutingHelper.GetForward(),
                    FilteringTag = RabbitRoutingHelper.GetProjectCommandRoutingKey()
                },
                callback: (Model.Interfaces.Message msg) => {
                    var jsonEvent = new JsonEvent<Project>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetProjectCommandQueue());
        }

        public void ListenUserCommands(Func<IEvent, bool> callback)
        {
            _messageService.Listen(
                criteria: new ListenCriteria()
                {
                    Source = RabbitRoutingHelper.GetForward(),
                    FilteringTag = RabbitRoutingHelper.GetUserCommandRoutingKey()
                },
                callback: (Model.Interfaces.Message msg) => {
                    var jsonEvent = new JsonEvent<User>(msg.Body);
                    callback(jsonEvent);
                    return true;
                },
                listeningPointName: RabbitRoutingHelper.GetUserCommandQueue());
        }

        public void PublishIssues(ICollection<Issue> issues)
        {
            _messageService.Send(
                message: new Model.Interfaces.Message()
                {
                    Body = JsonConvert.SerializeObject(issues)
                }, 
                destination: RabbitRoutingHelper.GetIssueFeed(),
                filteringTag: RabbitRoutingHelper.GetIssueFeedRoutingKey());
        }

        public void PublishProjects(ICollection<Project> projects)
        {
            _messageService.Send(
                message: new Model.Interfaces.Message()
                {
                    Body = JsonConvert.SerializeObject(projects)
                },
                destination: RabbitRoutingHelper.GetProjectFeed(),
                filteringTag: RabbitRoutingHelper.GetProjectFeedRoutingKey());
        }

        public void PublishStatus(Status status)
        {
            _messageService.Send(
                message: new Model.Interfaces.Message()
                {
                    Body = JsonConvert.SerializeObject(status)
                },
                destination: RabbitRoutingHelper.GetStatusFeed(),
                filteringTag: RabbitRoutingHelper.GetStatusFeedRoutingKey());
        }

        public void PublishUsers(ICollection<User> users)
        {
            _messageService.Send(
                message: new Model.Interfaces.Message()
                {
                    Body = JsonConvert.SerializeObject(users)
                },
                destination: RabbitRoutingHelper.GetUserFeed(),
                filteringTag: RabbitRoutingHelper.GetUserFeedRoutingKey());
        }
    }
}
