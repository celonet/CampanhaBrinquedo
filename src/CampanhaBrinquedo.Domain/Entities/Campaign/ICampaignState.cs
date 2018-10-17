namespace CampanhaBrinquedo.Domain.Entities.Campaign
{
    public interface ICampaignState
    {
        void Open(Campaign campaign, User.User user);
        void Close(Campaign campaign, User.User user);
        void Reopen(Campaign campaign, User.User user);
    }
}