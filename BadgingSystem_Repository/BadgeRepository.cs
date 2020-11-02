using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static BadgingSystem_Repository.Badge;

namespace BadgingSystem_Repository
{
    public class BadgeRepository
    {
        private Dictionary<int, DoorNames> _badgeDictionary = new Dictionary<int, DoorNames>();

        //Create

        public bool AddBadgeToDirectory(int badgeID, DoorNames door)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(badgeID, door);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public Dictionary<int, DoorNames> GetDictionaryAll()
        {
            return _badgeDictionary;
        }
        //helper
        /*
        public KeyValuePair<int, DoorNames> GetBadgeByKey(int badgeID)
        {

            foreach (KeyValuePair<int, DoorNames> kvp in _badgeDictionary)
            {

                if (_badgeDictionary.ContainsKey(badgeID))
                {
                    return kvp;
                }
            }
            return  
        }

        //Update
        public bool UpdateExistingBadge()
        {

        }

            //Delete
        */




    }
}

