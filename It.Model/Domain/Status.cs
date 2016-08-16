using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public class Status : Entity
    {
        public string AppName;

        public DateTime StartTime;

        public long Uptime;

        public long NumberOfEvents;

        public long NumberOfGetEvents;

        public long NumberOfCreateEvents;

        public long NumberOfUpdateEvents;

        public long NumberOfDeleteEvents;

        public User LastProcessedUser;

        public Project LastProcessedProject;

        public Issue LastProcessedIssue;

        public Status(string appName, DateTime startTime, long uptime, long numberOfEvents, long numberOfGetEvents, long numberOfCreateEvents, long numberOfUpdateEvents, long numberOfDeleteEvents, User lastProcessedUser, Project lastProcessedProject, Issue lastProcessedIssue)
        {
            AppName = appName;
            StartTime = startTime;
            Uptime = uptime;
            NumberOfEvents = numberOfEvents;
            NumberOfGetEvents = numberOfGetEvents;
            NumberOfCreateEvents = numberOfCreateEvents;
            NumberOfUpdateEvents = numberOfUpdateEvents;
            NumberOfDeleteEvents = numberOfDeleteEvents;
            LastProcessedUser = lastProcessedUser;
            LastProcessedProject = lastProcessedProject;
            LastProcessedIssue = lastProcessedIssue;
        }

        public Status(Status status) : base(status)
        {
            AppName = status.AppName;
            StartTime = status.StartTime;
            Uptime = status.Uptime;
            NumberOfEvents = status.NumberOfEvents;
            NumberOfGetEvents = status.NumberOfGetEvents;
            NumberOfCreateEvents = status.NumberOfCreateEvents;
            NumberOfUpdateEvents = status.NumberOfUpdateEvents;
            NumberOfDeleteEvents = status.NumberOfDeleteEvents;
            LastProcessedUser = status.LastProcessedUser;
            LastProcessedProject = status.LastProcessedProject;
            LastProcessedIssue = status.LastProcessedIssue;
        }
    }
}
