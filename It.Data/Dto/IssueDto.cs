using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using Newtonsoft.Json;
using Entity = MongoRepository.Entity;

namespace It.Data.Dto
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IssueDto : Entity
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Guid { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public UserDto Author { get; set; }

        [JsonProperty]
        public IssueType Type { get; set; }

        [JsonProperty]
        public IssueState State { get; set; }

        [JsonProperty]
        public UserDto Assignee { get; set; }

        [JsonProperty]
        public ProjectDto Project { get; set; }
    }
}
