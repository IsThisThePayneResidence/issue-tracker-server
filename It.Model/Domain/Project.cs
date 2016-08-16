using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public class Project : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Version> Versions { get; set; }

        public List<User> Users { get; set; }

        public List<Issue> Issues { get; set; }

        public List<Project> Projects { get; set; }

        public Project(string name, string description, List<Version> versions, List<User> users, List<Issue> issues, List<Project> projects)
        {
            Name = name;
            Description = description;
            Versions = versions;
            Users = users;
            Issues = issues;
            Projects = projects;
        }

        public Project(Project project) : base(project)
        {
            Description = project.Description;
            Versions = project.Versions;
            Users = project.Users;
            Issues = project.Issues;
            Projects = project.Projects;
        }
    }
}
