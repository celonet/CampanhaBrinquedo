using System;
using CampanhaBrinquedo.Domain.Entities.Campaign.State;

namespace CampanhaBrinquedo.Domain.Entities.Campaign
{
    public class Campaign : EntityBase
    {
        public int Year { get; private set; }
        public string Description { get; private set; }
        public int ChildrensQty { get; private set; }
        public ICampaignState State { get; set; }

        protected Campaign() { }

        public Campaign(int ano, string descricao)
        {
            this.Id = Guid.NewGuid();
            this.Year = ano;
            this.Description = descricao;
            this.ChildrensQty = 0;
            this.State = new NotStarted();
        }

        public Campaign(int ano, string descricao, int qtdeCriancas)
        {
            this.Id = Guid.NewGuid();
            this.Year = ano;
            this.Description = descricao;
            this.ChildrensQty = qtdeCriancas;
            this.State = new NotStarted();
        }

        public Campaign(Guid id, int ano, string descricao, int qtdeCriancas, ICampaignState state)
        {
            this.Id = id;
            this.Year = ano;
            this.Description = descricao;
            this.ChildrensQty = qtdeCriancas;
            this.State = state;
        }

        public void IncreasesNumberOfChildren() => this.ChildrensQty++;

        public void Open(User.User user) => State.Open(this, user);

        public void Close(User.User user) => this.State.Close(this, user);

        public void Reopen(User.User user) => this.State.Reopen(this, user);
    }
}
