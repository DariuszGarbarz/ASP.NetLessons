using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
