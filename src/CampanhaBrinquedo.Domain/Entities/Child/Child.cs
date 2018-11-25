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

        public Child(
            string name, 
            IList<Age> ages, 
            IList<Clothing> clothings, 
            IList<Community> communities,
            IList<GodFather> godfathers,
            IList<Responsible> responsiblies, 
            IList<Campaign.Campaign> campaigns, 
            IList<Printed> printed,
            Gender gender,
            bool pcd)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = ages;
            Clothings = clothings;
            Communities = communities;
            Godfathers = godfathers;
            Responsiblies = responsiblies;
            Campaigns = campaigns;
            Printed = printed;
            Gender = gender;
            PcD = pcd;
        }

        public Child(
            Guid id, 
            string name, 
            IList<Age> ages, 
            IList<Clothing> clothings,
            IList<Community> communities,
            IList<GodFather> godfathers,
            IList<Responsible> responsiblies, 
            IList<Campaign.Campaign> campaigns, 
            IList<Printed> printed,
            Gender gender,
            bool pcd)
        {
            Id = id;
            Name = name;
            Age = ages;
            Clothings = clothings;
            Communities = communities;
            Godfathers = godfathers;
            Responsiblies = responsiblies;
            Campaigns = campaigns;
            Printed = printed;
            Gender = gender;
            PcD = pcd;
        }

        public void IsPcD() => PcD = true;
    }
}