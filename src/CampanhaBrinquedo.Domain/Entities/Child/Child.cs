using System;
using System.Collections.Generic;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Child : EntityBase
    {
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Clothing { get; private set; }
        public Gender Gender { get; private set; }
        public IList<Community> Communities { get; private set; }
        public IList<GodFather> Godfathers { get; private set; }
        public IList<Responsible> Responsiblies { get; private set; }
        public IList<Campaign.Campaign> Campaigns { get; private set; }
        public bool Printed { get; private set; }
        public bool PcD { get; private set; }

        protected Child() { }

        public Child(string name, string age, string clothing, Gender gender, IList<Community> communities, IList<Responsible> responsiblies, IList<Campaign.Campaign> campaigns)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Age = age;
            this.Clothing = clothing;
            this.Gender = gender;
            this.Communities = communities;
            this.Responsiblies = responsiblies;
            this.Printed = false;
            this.PcD = false;
            this.Campaigns = campaigns;
        }

        public Child(string name, string age, string clothing, Gender gender, IList<Community> communities, IList<Responsible> responsiblies, IList<Campaign.Campaign> campaigns, bool printed, bool pcd)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Age = age;
            this.Clothing = clothing;
            this.Gender = gender;
            this.Communities = communities;
            this.Responsiblies = responsiblies;
            this.Printed = printed;
            this.PcD = pcd;
            this.Campaigns = campaigns;
        }

        public Child(Guid id, string name, string age, string clothing, Gender gender, IList<Community> communities, IList<Responsible> responsiblies, IList<Campaign.Campaign> campaigns, bool printed, bool pcd)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Clothing = clothing;
            this.Gender = gender;
            this.Communities = communities;
            this.Responsiblies = responsiblies;
            this.Printed = printed;
            this.PcD = pcd;
            this.Campaigns = campaigns;
        }

        public void Print() => this.Printed = true;

        public void IsPcD() => this.PcD = true;
    }
}