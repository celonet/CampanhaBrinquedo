namespace CampanhaBrinquedo.Domain.Entities.Campaign
{
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
}
