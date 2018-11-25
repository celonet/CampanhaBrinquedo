using System.Linq;

namespace CampanhaBrinquedo.Transport
{
    public static class OptionUtils
    {
        public static CampaignConfiguration GetCurrentCampaign(this CampaignOptions options) => options.Campaigns.FirstOrDefault(_ => _.Year == options.CurrentYear);
    }
}
