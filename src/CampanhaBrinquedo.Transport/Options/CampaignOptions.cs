using System.Collections.Generic;

namespace CampanhaBrinquedo.Transport
{
    public class CampaignOptions
    {
        public int CurrentYear { get; set; }
        public IList<CampaignConfiguration> Campaigns { get; set; }
    }
}
