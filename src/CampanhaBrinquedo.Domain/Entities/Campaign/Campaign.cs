using CampanhaBrinquedo.Domain.Entities.Campaign.State;
using System;

namespace CampanhaBrinquedo.Domain.Entities.Campaign
{
    public class Campaign : EntityBase
    {
        public int Year { get; private set; }
        public string Description { get; private set; }
        public int ChildrensQty { get; private set; }
        public ICampaignActionState CampaignActionState => Enum.IsDefined(typeof(CampaignState), State) ? SetCampaignActionState(State) : new NotStarted();
        public CampaignState State { get; private set; }

        protected Campaign() : base() { }

        public Campaign(int ano, string descricao)
        {
            Id = Guid.NewGuid();
            Year = ano;
            Description = descricao;
            ChildrensQty = 0;
            State = CampaignState.NotStarted;
        }

        public Campaign(int ano, string descricao, int qtdeCriancas) : base()
        {
            Id = Guid.NewGuid();
            Year = ano;
            Description = descricao;
            ChildrensQty = qtdeCriancas;
            State = CampaignState.NotStarted;
        }

        public Campaign(int ano, string descricao, int qtdeCriancas, string state) : base()
        {
            Year = ano;
            Description = descricao;
            ChildrensQty = qtdeCriancas;
            State = Enum.Parse<CampaignState>(state);
        }

        public Campaign(Guid id, int ano, string descricao, int qtdeCriancas, string state)
        {
            Id = id;
            Year = ano;
            Description = descricao;
            ChildrensQty = qtdeCriancas;
            State = Enum.Parse<CampaignState>(state);
        }

        public void IncreasesNumberOfChildren() => ChildrensQty++;

        public void Open(User.User user) => CampaignActionState.Open(this, user);

        public void Close(User.User user) => CampaignActionState.Close(this, user);

        public void Reopen(User.User user) => CampaignActionState.Reopen(this, user);

        public void ChangeState(CampaignState state) => State = state;

        private ICampaignActionState SetCampaignActionState(CampaignState state)
        {
            switch (state)
            {
                case CampaignState.Open:
                    return new Open();
                case CampaignState.Closed:
                    return new Closed();
                case CampaignState.Reopened:
                    return new Reopened();
                default:
                    return new NotStarted();
            }
        }
    }
}
