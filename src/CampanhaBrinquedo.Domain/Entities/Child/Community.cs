using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Community : EntityBase
    {
        public string Name { get; private set; }
        public string Neighborhood { get; private set; }

        protected Community() { }

        public Community(Guid id, string name, string neighborhood)
        {
            this.Id = id;
            this.Name = name;
            this.Neighborhood = neighborhood;
        }

        public Community(string name, string neighborhood)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Neighborhood = neighborhood;
        }
    }
}