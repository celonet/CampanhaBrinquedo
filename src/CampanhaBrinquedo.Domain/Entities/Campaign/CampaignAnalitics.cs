namespace CampanhaBrinquedo.Domain.Entities.Campaign
{
    public class CampaignAnalitics
    {
        public int Capacity { get; set; }
        public int ChildrenQty { get; set; }
        public int GodFatherQty { get; set; }
        public int CommunityQty { get; set; }

        public CampaignAnalitics() { }

        public CampaignAnalitics(int capacity, int childrenQty, int godFatherQty, int communityQty)
        {
            Capacity = capacity;
            ChildrenQty = childrenQty;
            GodFatherQty = godFatherQty;
            CommunityQty = communityQty;
        }
    }
}
