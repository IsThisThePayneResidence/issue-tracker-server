using System;

namespace It.Model.Domain
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Entity entity)
        {
            Id = entity.Id;
        }
    }
}
