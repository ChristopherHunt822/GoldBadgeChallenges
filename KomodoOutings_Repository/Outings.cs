using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_Repository
{
    public class Outings
    {
        // public string NameOfEvent { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public decimal EventCost { get; set; }
        public int Attendance { get; set; }
        public decimal CostPerPerson { get; set; }


        public Outings () { }
        public Outings (DateTime date, EventType type, decimal eventCost, int attendance, decimal costPerPerson)
        {
            Date = date;
            Type = type;
            EventCost = eventCost;
            Attendance = attendance;
            CostPerPerson = costPerPerson;
        }

        public enum EventType { GOLF = 1, BOWLING, AMUSEMENTPARK, CONCERT}
    }
}
