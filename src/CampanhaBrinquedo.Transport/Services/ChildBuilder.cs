using CampanhaBrinquedo.Transport.Model;
using System;
using System.Collections.Generic;

namespace CampanhaBrinquedo.Transport
{
    public class ChildBuilder
    {
        private string _name;
        private string _gender;
        private bool _pcd;
        private IList<Printed> _printed;
        private IList<Clothing> _clothings;
        private IList<Age> _ages;
        private IList<Campaign> _campaigns;
        private Campaign _campaign;
        private IList<Community> _communities;
        private IList<GodFather> _godFathers;
        private IList<Responsible> _responsiblies;

        public ChildBuilder()
        {
            _clothings = new List<Clothing>();
            _ages = new List<Age>();
            _campaigns = new List<Campaign>();
            _communities = new List<Community>();
            _printed = new List<Printed>();
            _godFathers = new List<GodFather>();
            _responsiblies = new List<Responsible>();
        }

        internal ChildBuilder SetCampaign(Campaign campaign)
        {
            _campaign = campaign;
            return this;
        }

        internal ChildBuilder AddGodFathers(string padrinho, Community community, string telefone, string telefone2, string email)
        {
            _godFathers.Add(new GodFather(_campaign.Year, padrinho, community, telefone, telefone2, email));
            return this;
        }

        internal ChildBuilder AddResponsible(string name, string rg)
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                _responsiblies.Add(new Responsible(_campaign.Year, name, rg));
            }

            return this;
        }

        internal ChildBuilder AddCommunty(string community, string neighborhood)
        {
            _communities.Add(new Community(_campaign.Year, community, neighborhood));
            return this;
        }

        internal ChildBuilder AddPrinted(bool printed)
        {
            _printed.Add(new Printed(_campaign.Year, printed));
            return this;
        }

        internal ChildBuilder SetPCD(bool pcd)
        {
            _pcd = pcd;
            return this;
        }

        public ChildBuilder SetGender(string gender)
        {
            _gender = gender == "F" ? "Woman" : "Male";
            return this;
        }

        public ChildBuilder AddCampaign(int year, int qtde = 0, string description = "")
        {
            _campaigns.Add(new Campaign
            {
                Year = year,
                ChildrensQty = qtde,
                Description = "",
                State = "Closed"
            });
            return this;
        }

        public ChildBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ChildBuilder AddAge(string age)
        {
            _ages.Add(new Age(_campaign.Year, age));
            return this;
        }

        public Child Build()
        {
            return new Child
            {
                Id = Guid.NewGuid(),
                Name = _name,
                Ages = _ages,
                Clothings = _clothings,
                Gender = _gender,
                PCD = _pcd,
                Printed = _printed,
                Communities = _communities,
                Responsiblies = _responsiblies,
                Godfathers = _godFathers,
                Campaigns = _campaigns,
                RegisterDate = DateTime.Now
            };
        }

        public ChildBuilder AddClothing(string clothing)
        {
            _clothings.Add(new Clothing(_campaign.Year, clothing));
            return this;
        }
    }
}