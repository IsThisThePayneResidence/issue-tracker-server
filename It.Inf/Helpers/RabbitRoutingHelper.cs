using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Inf.Helpers
{
    public static class RabbitRoutingHelper
    {
        private static string appName = ConfigurationManager.AppSettings["AppName"];

        private static string status = ConfigurationManager.AppSettings["RabbitStatus"];

        private static string issue = ConfigurationManager.AppSettings["RabbitIssue"];

        private static string user = ConfigurationManager.AppSettings["RabbitUser"];

        private static string project = ConfigurationManager.AppSettings["RabbitProject"];

        private static string commandQueueTemplate = ConfigurationManager.AppSettings["RabbitCommandQueueTemplate"];

        private static string commandRoutingKeyTemplate = ConfigurationManager.AppSettings["RabbitCommandRoutingKeyTemplate"];

        private static string feedRoutingKeyTemplate = ConfigurationManager.AppSettings["RabbitFeedRoutingKeyTemplate"];

        private static string feedExchangeTemplate = ConfigurationManager.AppSettings["RabbitFeedExchangeTemplate"];

        private static string forward = ConfigurationManager.AppSettings["RabbitForward"];

        public static string GetForward()
        {
            return forward;
        }

        public static string GetStatusFeed()
        {
            return String.Format(feedExchangeTemplate, status, appName);
        }

        public static string GetUserFeed()
        {
            return String.Format(feedExchangeTemplate, user, appName);
        }

        public static string GetIssueFeed()
        {
            return String.Format(feedExchangeTemplate, issue, appName);
        }

        public static string GetProjectFeed()
        {
            return String.Format(feedExchangeTemplate, project, appName);
        }

        public static string GetUserCommandQueue()
        {
            return String.Format(commandQueueTemplate, user, appName);
        }

        public static string GetIssueCommandQueue()
        {
            return String.Format(commandQueueTemplate, issue, appName);
        }

        public static string GetProjectCommandQueue()
        {
            return String.Format(commandQueueTemplate, project, appName);
        }

        public static string GetUserCommandRoutingKey()
        {
            return String.Format(commandRoutingKeyTemplate, user, appName);
        }

        public static string GetIssueCommandRoutingKey()
        {
            return String.Format(commandRoutingKeyTemplate, issue, appName);
        }

        public static string GetProjectCommandRoutingKey()
        {
            return String.Format(commandRoutingKeyTemplate, project, appName);
        }

        public static string GetStatusFeedRoutingKey()
        {
            return String.Format(feedRoutingKeyTemplate, status, appName);
        }

        public static string GetUserFeedRoutingKey()
        {
            return String.Format(feedRoutingKeyTemplate, user, appName);
        }

        public static string GetIssueFeedRoutingKey()
        {
            return String.Format(feedRoutingKeyTemplate, issue, appName);
        }

        public static string GetProjectFeedRoutingKey()
        {
            return String.Format(feedRoutingKeyTemplate, project, appName);
        }

    }
}
