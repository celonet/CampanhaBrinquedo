namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Printed : Rastreabillity
    {
        public Printed(int year, bool printed) : base(year) => HasPrinted = printed;
        public bool HasPrinted { get; set; }
    }
}