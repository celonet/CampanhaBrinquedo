using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class GodFather : EntityBase
    {
        public string Name { get; private set; }
        public Community Community { get; private set; }
        public string Telephone { get; private set; }
        public string CellPhone { get; private set; }
        public string Email { get; private set; }

        protected GodFather() { }

        public GodFather(string name, Community community, string telephone)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Community = community;
            this.Telephone = telephone;
        }

        public GodFather(string name, Community community, string telephone, string cellphone)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Community = community;
            this.Telephone = telephone;
            this.CellPhone = cellphone;
        }

        public GodFather(Guid id, string name, Community community, string telephone, string cellphone)
        {
            this.Id = id;
            this.Name = name;
            this.Community = community;
            this.Telephone = telephone;
            this.CellPhone = cellphone;
        }

        public GodFather(Guid id, string name, Community community, string telephone, string cellphone, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Community = community;
            this.Telephone = telephone;
            this.CellPhone = cellphone;
        }
    }
}