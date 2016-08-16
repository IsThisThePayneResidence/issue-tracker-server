﻿using System;
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
    public class UserDto : Entity
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Guid { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public UserRole Role { get; set; }

        [JsonProperty]
        public List<ProjectDto> Projects { get; set; }
    }
}
