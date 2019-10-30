namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Age : Rastreabillity
    {
        public Age(int year, string value) : base(year) => Value = value;

        public string Value { get; set; }
    }
}