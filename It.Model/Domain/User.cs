﻿using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public enum UserRole
    {
        DEVELOPER = 1,
        PROJECT_MANAGER = 2,
        REPORTER = 3
    }

    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserRole Role { get; set; }
    }
}
