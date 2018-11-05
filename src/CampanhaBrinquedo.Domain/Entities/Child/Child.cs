using System;
using System.Collections.Generic;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Child : EntityBase
    {
        public string Name { get; protected set; }
        public IList<Age> Age { get; set; }
        public IList<Clothing> Clothings { get; set; }
        public IList<Community> Communities { get; private set; }
        public IList<GodFather> Godfathers { get; private set; }
        public IList<Responsible> Responsiblies { get; private set; }
        public IList<Campaign.Campaign> Campaigns { get; private set; }
        public IList<Printed> Printed { get; private set; }
        public Gender Gender { get; private set; }
        public bool PcD { get; private set; }

        protected Child() { }

        public Child(string name, IList<Age> ages, IList<Clothing> clothings, Gender gender, IList<Community> communities, IList<Responsible> responsiblies, IList<Campaign.Campaign> campaigns, IList<Printed> printed)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = ages;
            Clothings = clothings;
            Gender = gender;
            Communities = communities;
            Responsiblies = responsiblies;
            Printed = printed;
            PcD = false;
            Campaigns = campaigns;
        }

        public Child(string name, IList<Age> ages, IList<Clothing> clothingies, Gender gender, IList<Community> communities, IList<Responsible> responsiblies, IList<Campaign.Campaign> campaigns, IList<Printed> printed, bool pcd)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = ages;
            Clothings = clothingies;
            Gender = gender;
            Communities = communities;
            Responsiblies = responsiblies;
            Printed = printed;
            PcD = pcd;
            Campaigns = campaigns;
        }

        public Child(Guid id, string name, IList<Age> ages, IList<Clothing> clothingies, Gender gender, IList<Community> communities, IList<Responsible> responsiblies, IList<Campaign.Campaign> campaigns, IList<Printed> printed, bool pcd)
        {
            Id = id;
            Name = name;
            Age = ages;
            Clothings = clothingies;
            Gender = gender;
            Communities = communities;
            Responsiblies = responsiblies;
            Printed = printed;
            PcD = pcd;
            Campaigns = campaigns;
        }

        public void Print()
        {
            //Printed = true;
        }

        public void IsPcD() => PcD = true;
    }
}