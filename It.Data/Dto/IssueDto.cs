using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using Entity = MongoRepository.Entity;

namespace It.Data.Dto
{
    public class IssueDto : Entity
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UserDto Author { get; set; }

        public IssueType Type { get; set; }

        public IssueState State { get; set; }

        public UserDto Assignee { get; set; }

        public ProjectDto ProjectDto { get; set; }
    }
}
