using System;

namespace CampanhaBrinquedo.Domain.Entities.Child
{
    public class Note
    {
        public Note(string observation)
        {
            Date = DateTime.Now;
            Observation = observation;
        }

        public DateTime Date { get; private set; }
        public string Observation { get; private set; }
    }
}