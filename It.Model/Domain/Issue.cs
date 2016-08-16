using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public enum IssueType
    {
        Task = 1,
        Bug = 2,
        Enhancement = 3
    }

    public enum IssueState
    {
        New = 1,
        Open = 2,
        InWork = 3,
        Done = 4,
        Closed = 5
    }

    public class Issue : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public User Author { get; set; }

        public IssueType Type { get; set; }

        public IssueState State { get; set; }

        public User Assignee { get; set; }

        public Project Project { get; set; }

        public Issue(string name, string description, User author, IssueType type, IssueState state, User assignee, Project project)
        {
            Name = name;
            Description = description;
            Author = author;
            Type = type;
            State = state;
            Assignee = assignee;
            Project = project;
        }

        public Issue(Issue issue) : base(issue)
        {
            Name = issue.Name;
            Description = issue.Description;
            Author = issue.Author;
            Type = issue.Type;
            State = issue.State;
            Assignee = issue.Assignee;
            Project = issue.Project;
        }
    }
}
