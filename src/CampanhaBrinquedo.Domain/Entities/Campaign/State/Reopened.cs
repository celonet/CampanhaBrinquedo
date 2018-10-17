using System;

namespace CampanhaBrinquedo.Domain.Entities.Campaign.State
{
    public class Reopened : ICampaignState
    {
        public void Close(Campaign campaign, User.User user) => campaign.State = new Closed();

        public void Open(Campaign campaign, User.User user) => throw new Exception("Campanha com status Reaberta não pode ir pra status Open!");

        public void Reopen(Campaign campaign, User.User user) => throw new Exception("Campanha já esta com status Reopen");
    }
}