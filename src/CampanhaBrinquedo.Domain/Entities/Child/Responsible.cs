using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Responsible : Rastreabillity
    {
        public string Name { get; private set; }
        public string RG { get; private set; }

        public Responsible(int year, string nome, string rg)
            : base(year)
        {
            Name = nome;
            RG = rg;
        }

        public Responsible(Guid id, string nome, string rg)
            : base(year)
        {
            Name = nome;
            RG = rg;
        }
    }
}