using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Data.Dto
{
    public class ProjectDto : Entity
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<VersionDto> Versions { get; set; }

        public List<UserDto> Users { get; set; }

        public List<IssueDto> Issues { get; set; }

        public List<ProjectDto> Projects { get; set; }
    }
}
