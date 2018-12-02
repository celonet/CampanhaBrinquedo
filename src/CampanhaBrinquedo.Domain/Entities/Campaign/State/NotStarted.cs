using System;

namespace CampanhaBrinquedo.Domain.Entities.Campaign.State
{
    public class NotStarted : ICampaignActionState
    {
        public void Close(Campaign campaign, User.User user) => throw new Exception("Campanha com status NotStarted não pode ir para Closed");

        public void Open(Campaign campaign, User.User user) => campaign.ChangeState(new Open(), CampaignState.Open);

        public void Reopen(Campaign campaign, User.User user) => throw new Exception("Campanha com status NotStarted não pode ir para status Reopen");
    }
}