using System;
using CampanhaBrinquedo.Domain.Entities.User;

namespace CampanhaBrinquedo.Domain.Entities.Campaign.State
{
    public class Open : ICampaignActionState
    {
        public void Close(Campaign campaign, User.User user) => campaign.ChangeState(new Closed(), CampaignState.Closed);

        public void Reopen(Campaign campaign, User.User user) => throw new Exception("Campanha em aberto não pode ser reaberta!");

        void ICampaignActionState.Open(Campaign campaign, User.User user) => throw new Exception("Campanha em aberto não pode ser aberta novamente");
    }
}