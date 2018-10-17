using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Responsible : EntityBase
    {
        public string Name { get; private set; }
        public string RG { get; private set; }

        protected Responsible() { }

        public Responsible(string nome, string rg)
        {
            this.Id = Guid.NewGuid();
            this.Name = nome;
            this.RG = rg;
        }

        public Responsible(Guid id, string nome, string rg)
        {
            this.Id = id;
            this.Name = nome;
            this.RG = rg;
        }
    }
}