namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Clothing : Rastreabillity
    {
        public Clothing(int year, string description) : base(year) 
            => Description = description;

        public string Description { get; set; }
    }
}