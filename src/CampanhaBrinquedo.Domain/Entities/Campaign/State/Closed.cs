using System;

namespace CampanhaBrinquedo.Domain.Entities.Campaign.State
{
    public class Closed : ICampaignActionState
    {
        public void Close(Campaign campaign, User.User user) => throw new Exception("Campanha já fechada!");

        public void Open(Campaign campaign, User.User user) => throw new Exception("Campanha fechada não pode ir para status Open, utilize o Reopen!");

        public void Reopen(Campaign campaign, User.User user) => campaign.ChangeState(CampaignState.Reopened);
    }
}