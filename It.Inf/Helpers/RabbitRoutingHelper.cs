using System.Configuration;

namespace It.Inf.Helpers
{
    public static class RabbitRoutingHelper
    {
        private static readonly string AppName = ConfigurationManager.AppSettings["AppName"];

        private static readonly string Status = ConfigurationManager.AppSettings["RabbitStatus"];

        private static readonly string Issue = ConfigurationManager.AppSettings["RabbitIssue"];

        private static readonly string User = ConfigurationManager.AppSettings["RabbitUser"];

        private static readonly string Project = ConfigurationManager.AppSettings["RabbitProject"];

        private static readonly string Version = ConfigurationManager.AppSettings["RabbitVersion"];

        private static readonly string CommandQueueTemplate =
            ConfigurationManager.AppSettings["RabbitCommandQueueTemplate"];

        private static readonly string CommandRoutingKeyTemplate =
            ConfigurationManager.AppSettings["RabbitCommandRoutingKeyTemplate"];

        private static readonly string FeedRoutingKeyTemplate =
            ConfigurationManager.AppSettings["RabbitFeedRoutingKeyTemplate"];

        private static readonly string FeedExchangeTemplate =
            ConfigurationManager.AppSettings["RabbitFeedExchangeTemplate"];

        private static readonly string Forward = ConfigurationManager.AppSettings["RabbitForward"];

        public static string GetForward()
        {
            return Forward;
        }

        public static string GetStatusFeed()
        {
            return string.Format(FeedExchangeTemplate, Status, AppName);
        }

        public static string GetUserFeed()
        {
            return string.Format(FeedExchangeTemplate, User, AppName);
        }

        public static string GetIssueFeed()
        {
            return string.Format(FeedExchangeTemplate, Issue, AppName);
        }

        public static string GetProjectFeed()
        {
            return string.Format(FeedExchangeTemplate, Project, AppName);
        }

        public static string GetUserCommandQueue()
        {
            return string.Format(CommandQueueTemplate, User, AppName);
        }

        public static string GetIssueCommandQueue()
        {
            return string.Format(CommandQueueTemplate, Issue, AppName);
        }

        public static string GetVersionCommandQueue()
        {
            return string.Format(CommandQueueTemplate, Version, AppName);
        }

        public static string GetProjectCommandQueue()
        {
            return string.Format(CommandQueueTemplate, Project, AppName);
        }

        public static string GetUserCommandRoutingKey()
        {
            return string.Format(CommandRoutingKeyTemplate, User, AppName);
        }

        public static string GetIssueCommandRoutingKey()
        {
            return string.Format(CommandRoutingKeyTemplate, Issue, AppName);
        }

        public static string GetProjectCommandRoutingKey()
        {
            return string.Format(CommandRoutingKeyTemplate, Project, AppName);
        }

        public static string GetVersionCommandRoutingKey()
        {
            return string.Format(CommandRoutingKeyTemplate, Version, AppName);
        }

        public static string GetStatusFeedRoutingKey()
        {
            return string.Format(FeedRoutingKeyTemplate, Status, AppName);
        }

        public static string GetUserFeedRoutingKey()
        {
            return string.Format(FeedRoutingKeyTemplate, User, AppName);
        }

        public static string GetIssueFeedRoutingKey()
        {
            return string.Format(FeedRoutingKeyTemplate, Issue, AppName);
        }

        public static string GetProjectFeedRoutingKey()
        {
            return string.Format(FeedRoutingKeyTemplate, Project, AppName);
        }
    }
}