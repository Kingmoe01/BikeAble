using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{
    public class Itineraire
    {
        string duree;
        int distance;


        public string Duree
        {
            get   { return duree; }

            set { duree = value; }
        }

        public int Distance
        {
            get { return distance; }

            set { distance = value; }
        }

        public Itineraire()
        {

        }

        public Itineraire(string _duree, int _distance)
        {
            Duree = _duree;
            Distance = _distance;
        }
    }
}
