using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class GodFather : Rastreabillity
    {
        public string Name { get; private set; }
        public Community Community { get; private set; }
        public string Telephone { get; private set; }
        public string CellPhone { get; private set; }
        public string Email { get; private set; }

        protected GodFather() { }

        public GodFather(string name, Community community, string telephone)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
        }

        public GodFather(string name, Community community, string telephone, string cellphone)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
        }

        public GodFather(Guid id, string name, Community community, string telephone, string cellphone)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
        }

        public GodFather(Guid id, string name, Community community, string telephone, string cellphone, string email)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
        }
    }
}