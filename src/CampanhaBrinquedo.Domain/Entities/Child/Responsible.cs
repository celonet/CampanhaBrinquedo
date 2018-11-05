using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Responsible
    {
        public string Name { get; private set; }
        public string RG { get; private set; }

        protected Responsible() { }

        public Responsible(string nome, string rg)
        {
            Name = nome;
            RG = rg;
        }

        public Responsible(Guid id, string nome, string rg)
        {
            Name = nome;
            RG = rg;
        }
    }
}