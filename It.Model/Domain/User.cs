using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Domain
{
    public enum UserRole
    {
        Developer = 1,
        ProjectManager = 2,
        Reporter = 3
    }

    public class User : Entity
    {
        public string Name { get; set; }

        public UserRole Role { get; set; }
    
        public User(string name, UserRole role)
        {
            Name = name;
            Role = role;
        }

        public User(User user) : base(user)
        {
            Name = user.Name;
            Role = user.Role;
        }
    }
}
