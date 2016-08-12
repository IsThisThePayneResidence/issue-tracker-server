﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;
using Entity = MongoRepository.Entity;

namespace It.Data.Dto
{
    public class Version : Entity
    {
        public string Name { get; set; }

        public VersionState State { get; set; }
    }
}
