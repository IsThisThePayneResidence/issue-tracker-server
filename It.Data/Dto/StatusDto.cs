using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Data.Dto 
{
    public class StatusDto : Entity
    {
        public Guid Guid { get; set; }

        public string AppName;

        public DateTime StartTime;

        public long Uptime;

        public long NumberOfEvents;

        public long NumberOfGetEvents;

        public long NumberOfCreateEvents;

        public long NumberOfUpdateEvents;

        public long NumberOfDeleteEvents;

        public UserDto LastProcessedUserDto;

        public ProjectDto LastProcessedProjectDto;

        public IssueDto LastProcessedIssueDto;
    }
}
