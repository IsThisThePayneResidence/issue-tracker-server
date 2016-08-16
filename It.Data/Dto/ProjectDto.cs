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
    public class ProjectDto : Entity
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Guid { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public List<VersionDto> Versions { get; set; }

        [JsonProperty]
        public List<UserDto> Users { get; set; }

        [JsonProperty]
        public List<IssueDto> Issues { get; set; }

        [JsonProperty]
        public List<ProjectDto> Projects { get; set; }
    }
}
