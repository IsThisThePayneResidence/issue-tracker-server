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
    public class VersionDto : Entity
    {
        [JsonProperty(PropertyName = "Id")]
        public string Guid { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public ProjectDto Project { get; set; }

        [JsonProperty]
        public VersionState State { get; set; }
    }
}
