using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using Entity = MongoRepository.Entity;

namespace It.Data.Dto
{
    public class VersionDto : Entity
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public VersionState State { get; set; }
    }
}
