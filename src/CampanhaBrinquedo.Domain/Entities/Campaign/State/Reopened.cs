using System;

namespace CampanhaBrinquedo.Domain.Entities.Campaign.State
{
    public class Reopened : ICampaignActionState
    {
        public void Close(Campaign campaign, User.User user) => campaign.ChangeState(new Closed(), CampaignState.Closed);

        public void Open(Campaign campaign, User.User user) => throw new Exception("Campanha com status Reaberta não pode ir pra status Open!");

        public void Reopen(Campaign campaign, User.User user) => throw new Exception("Campanha já esta com status Reopen");
    }
}