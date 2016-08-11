using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Data.Dto
{
    public enum VersionState
    {
        PERSPECTIVE = 1,
        SNAPSHOT = 2,
        RELEASE = 3
    }

    public class Version : Entity
    {
        public string Name { get; set; }

        public VersionState State { get; set; }
    }
}
