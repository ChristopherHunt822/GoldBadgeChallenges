using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgingSystem_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public DoorNames Door { get; set; }

        public Badge () { }
        public Badge (int badgeID, DoorNames door)
        {
            BadgeID = badgeID;
            Door = door;
        }

        public enum DoorNames { A1 = 1, A2, A3, A4, A5, B1, B2, B3, B4, B5}
    }
}
