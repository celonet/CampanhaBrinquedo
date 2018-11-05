using CampanhaBrinquedo.Domain.Entities.Campaign.State;
using System;

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
            Id = Guid.NewGuid();
            Year = ano;
            Description = descricao;
            ChildrensQty = 0;
            State = new NotStarted();
        }

        public Campaign(int ano, string descricao, int qtdeCriancas)
        {
            Id = Guid.NewGuid();
            Year = ano;
            Description = descricao;
            ChildrensQty = qtdeCriancas;
            State = new NotStarted();
        }

        public Campaign(Guid id, int ano, string descricao, int qtdeCriancas, ICampaignState state)
        {
            Id = id;
            Year = ano;
            Description = descricao;
            ChildrensQty = qtdeCriancas;
            State = state;
        }

        public void IncreasesNumberOfChildren() => ChildrensQty++;

        public void Open(User.User user) => State.Open(this, user);

        public void Close(User.User user) => State.Close(this, user);

        public void Reopen(User.User user) => State.Reopen(this, user);
    }
}
