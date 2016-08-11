﻿using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public enum VersionState
    {
        PERSPECTIVE = 1,
        SNAPSHOT = 2,
        RELEASE = 3
    }

    public class Version : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public VersionState State { get; set; }
    }
}
