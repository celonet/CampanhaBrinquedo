using System;
using System.Collections.Generic;
using System.Linq;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Child : EntityBase
    {
        public string Name { get; private set; }
        public IList<Age> Ages { get; private set; }
        public IList<Clothing> Clothings { get; private set; }
        public IList<Community> Communities { get; private set; }
        public IList<GodFather> GodFathers { get; private set; }
        public IList<Responsible> Responsiblies { get; private set; }
        public IList<Campaign.Campaign> Campaigns { get; private set; }
        public IList<Printed> Printeds { get; private set; }
        public Gender Gender { get; private set; }
        public bool PcD { get; private set; }
        public IList<Note> Notes { get; private set; }

        protected Child()
        {
            Ages = new List<Age>();
            Clothings = new List<Clothing>();
            Communities = new List<Community>();
            GodFathers = new List<GodFather>();
            Responsiblies = new List<Responsible>();
            Campaigns = new List<Campaign.Campaign>();
            Printeds = new List<Printed>();
            Notes = new List<Note>();
        }

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
            Ages = ages;
            Clothings = clothings;
            Communities = communities;
            GodFathers = godfathers;
            Responsiblies = responsiblies;
            Campaigns = campaigns;
            Printeds = printed;
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
            Ages = ages;
            Clothings = clothings;
            Communities = communities;
            GodFathers = godfathers;
            Responsiblies = responsiblies;
            Campaigns = campaigns;
            Printeds = printed;
            Gender = gender;
            PcD = pcd;
        }

        public void IsPcD() => PcD = true;

        public void AddNote(string note) => Notes.Add(new Note(note));

        public Child Merge(Child associateChild)
        {
            Campaigns = Campaigns.Union(associateChild.Campaigns).ToList();
            Ages = Ages.Union(associateChild.Ages).ToList();
            Clothings = Clothings.Union(associateChild.Clothings).ToList();
            Communities = Communities.Union(associateChild.Communities).ToList();
            GodFathers = GodFathers.Union(associateChild.GodFathers).ToList();
            Printeds = Printeds.Union(associateChild.Printeds).ToList();
            Responsiblies = Responsiblies.Union(associateChild.Responsiblies).ToList();
            Notes = Notes.Union(associateChild.Notes).ToList();

            Notes.Add(new Note($"Associate {Name} with {associateChild.Name}"));

            return this;
        }

        public void AddGodFathers(GodFather godFather) 
            => GodFathers.Add(godFather);

        public void AddPrinteds(Printed printed)
            => Printeds.Add(printed);
    }
}