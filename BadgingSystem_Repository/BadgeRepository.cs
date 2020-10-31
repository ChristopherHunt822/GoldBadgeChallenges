using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgingSystem_Repository
{
    public class BadgeRepository
    {
        private Dictionary<int, string> _badgeDictionary = new Dictionary<int, string>();

        //Create
        /*
        public bool AddBadgeToDirectory(Badge badge)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(badge);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }
        */
        //Read
        public Dictionary<int, string> GetDictionaryAll()
        {
            return _badgeDictionary;
        }
        //Update


        //Delete


        
    }
}
