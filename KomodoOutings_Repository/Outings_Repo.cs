using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_Repository
{
    public class Outings_Repo
    {
        private List<Outings> _outingsDirectory = new List<Outings>();

        public bool AddOutingToDirectory(Outings outing)
        {
            int startingCount = _outingsDirectory.Count;

            _outingsDirectory.Add(outing);

            bool wasAdded = (_outingsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Outings> GetOutingsList()
        {
            return _outingsDirectory;
        }
        /*
        public Outings GetOutingByEventName(string eventName)
        {
            foreach(Outings outing in _outingsDirectory)
            {
                if(outing.NameOfEvent.ToLower() == eventName.ToLower())
                {
                    return outing;
                }
            }
            return null;
        }
        */

        



    }
}
