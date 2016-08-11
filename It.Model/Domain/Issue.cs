using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public enum IssueType
    {
        TASK = 1,
        BUG = 2,
        ENHANCEMENT = 3
    }

    public enum IssueState
    {
        NEW = 1,
        OPEN = 2,
        IN_WORK = 3,
        DONE = 4,
        CLOSED = 5
    }

    public class Issue
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User Author { get; set; }

        public IssueType Type { get; set; }

        public IssueState State { get; set; }

        public User Assignee { get; set; }

        public Project Project { get; set; }
    }
}
