using System;

namespace CampanhaBrinquedo.Domain.Entities.Campaign.State
{
    public class Open : ICampaignState
    {
        public void Close(Campaign campaign, User.User user) => campaign.State = new Closed();

        public void Reopen(Campaign campaign, User.User user) => throw new Exception("Campanha em aberto não pode ser reaberta!");

        void ICampaignState.Open(Campaign campaign, User.User user) => throw new Exception("Campanha em aberto não pode ser aberta novamente");
    }
}