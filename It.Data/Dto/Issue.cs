using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using Entity = MongoRepository.Entity;

namespace It.Data.Dto
{
    public class Issue : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public User Author { get; set; }

        public IssueType Type { get; set; }

        public IssueState State { get; set; }

        public User Assignee { get; set; }

        public Project Project { get; set; }
    }
}
