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

        public GodFather(int year, string name, Community community, string telephone)
            : base(year)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
        }

        public GodFather(int year, string name, Community community, string telephone, string cellphone)
            : base(year)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
        }

        public GodFather(int year, string name, Community community, string telephone, string cellphone, string email)
            : base(year)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
        }

        public GodFather(int year, Guid id, string name, Community community, string telephone, string cellphone)
            : base(year)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
        }

        public GodFather(int year, Guid id, string name, Community community, string telephone, string cellphone, string email)
            : base(year)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
        }
    }
}