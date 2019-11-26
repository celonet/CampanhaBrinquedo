using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Community : Rastreabillity
    {
        public string Name { get; private set; }
        public string Neighborhood { get; private set; }

        public Community(int year, Guid id, string name, string neighborhood)
            : base(year)
        {
            Name = name;
            Neighborhood = neighborhood;
        }

        public Community(int year, string name, string neighborhood)
            : base(year)
        {
            Name = name;
            Neighborhood = neighborhood;
        }
    }
}