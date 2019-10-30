namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Rastreabillity
    {
        public Rastreabillity(int year) => Year = year;

        public int Year { get; private set; }
    }
}