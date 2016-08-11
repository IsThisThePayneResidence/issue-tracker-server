using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public class Status
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
    }
}
