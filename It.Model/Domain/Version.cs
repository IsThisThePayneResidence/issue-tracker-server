using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public enum VersionState
    {
        Perspective = 1,
        Snapshot = 2,
        Release = 3
    }

    public class Version : Entity
    {
        public string Name { get; set; }

        public Project Project { get; set; }

        public VersionState State { get; set; }
        
        public Version(string name, Project project, VersionState state)
        {
            Name = name;
            Project = project;
            State = state;
        }

        public Version(Version version) : base(version)
        {
            Name = version.Name;
            Project = version.Project;
            State = version.State;
        }
    }
}
