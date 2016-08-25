using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace It.Data.Dto
{
    [JsonObject(MemberSerialization.OptIn)]
    public class StatusDto : Entity
    {
        [JsonProperty(PropertyName = "Id")]
        public string Guid { get; set; }

        [JsonProperty]
        public string AppName;

        [JsonProperty]
        public DateTime StartTime;

        [JsonProperty]
        public long Uptime;

        [JsonProperty]
        public long NumberOfEvents;

        [JsonProperty]
        public long NumberOfGetEvents;

        [JsonProperty]
        public long NumberOfCreateEvents;

        [JsonProperty]
        public long NumberOfUpdateEvents;

        [JsonProperty]
        public long NumberOfDeleteEvents;

        [JsonProperty]
        public UserDto LastProcessedUser;

        [JsonProperty]
        public ProjectDto LastProcessedProject;

        [JsonProperty]
        public IssueDto LastProcessedIssue;
    }
}
