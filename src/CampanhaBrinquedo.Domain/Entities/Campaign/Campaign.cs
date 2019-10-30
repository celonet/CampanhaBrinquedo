using CampanhaBrinquedo.Domain.Entities.Campaign.State;
using System;

namespace CampanhaBrinquedo.Domain.Entities.Campaign
{
    public class Campaign : EntityBase
    {
        public int Year { get; private set; }
        public string Description { get; private set; }
        public int ChildrensQty { get; private set; }
        public ICampaignActionState CampaignActionState { get; private set; }
        public CampaignState State { get; private set; }

        protected Campaign() { }

        public Campaign(int ano, string descricao)
        {
            Id = Guid.NewGuid();
            Year = ano;
            Description = descricao;
            ChildrensQty = 0;
            State = CampaignState.NotStarted;
            CampaignActionState = new NotStarted();
        }

        public Campaign(int ano, string descricao, int qtdeCriancas)
        {
            Id = Guid.NewGuid();
            Year = ano;
            Description = descricao;
            ChildrensQty = qtdeCriancas;
            State = CampaignState.NotStarted;
            CampaignActionState = new NotStarted();
        }

        public Campaign(Guid id, int ano, string descricao, int qtdeCriancas, string state)
        {
            Id = id;
            Year = ano;
            Description = descricao;
            ChildrensQty = qtdeCriancas;
            State = Enum.Parse<CampaignState>(state);
            CampaignActionState = SetCampaignActionState(State);
        }

        public void IncreasesNumberOfChildren() => ChildrensQty++;

        public void Open(User.User user) => CampaignActionState.Open(this, user);

        public void Close(User.User user) => CampaignActionState.Close(this, user);

        public void Reopen(User.User user) => CampaignActionState.Reopen(this, user);

        public void ChangeState(ICampaignActionState campaignState, CampaignState state)
        {
            CampaignActionState = campaignState;
            State = state;
        }

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

    public class CampaignInformation
    {
        public int Year { get; private set; }
        public CampaignAnalitics CampaignAnalitics { get; private set; }
        public GenderAnalitcs GenderAnalitcs { get; private set; }

        public CampaignInformation(int year, CampaignAnalitics campaignAnalitics, GenderAnalitcs genderAnalitcs)
        {
            Year = year;
            CampaignAnalitics = campaignAnalitics;
            GenderAnalitcs = genderAnalitcs;
        }
    }

    public class CampaignAnalitics
    {
        public int Capacity { get; set; }
        public int ChildrenQty { get; set; }
        public int GodFatherQty { get; set; }
        public int CommunityQty { get; set; }

        public CampaignAnalitics()
        {

        }

        public CampaignAnalitics(int capacity, int childrenQty, int godFatherQty, int communityQty)
        {
            Capacity = capacity;
            ChildrenQty = childrenQty;
            GodFatherQty = godFatherQty;
            CommunityQty = communityQty;
        }
    }

    public struct GenderAnalitcs
    {
        public int MaleQty { get; set; }
        public int FemaleQty { get; set; }
    }
}
