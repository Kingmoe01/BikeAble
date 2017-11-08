using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Livraison
    {
        int id;
        float distance;
        DateTime elapsedTime;
        string status, nomCommande;
        DateTime dateCreation;

        #region getSet
        public int ID
        {
            get  {  return id; }
            set{ id = value; }
        }


        public float Distance
        {
            get { return distance; }

            set{ distance = value; }
        }

        public DateTime ElapsedTime
        {
            get{ return elapsedTime; }

            set{ elapsedTime = value;}
        }

        public string Status
        {
            get { return status; }

            set { status = value; }
        }

        public string Nom
        {
            get { return nomCommande; }

            set { nomCommande = value; }
        }

        public DateTime DateCreation
        {
            get { return dateCreation; }

            set { dateCreation = value; }
        }
        #endregion
        public Livraison(float _distance, DateTime _elapsedTime, string _status, DateTime createdDate)
        {
            Distance = _distance;
            ElapsedTime = _elapsedTime;
            Status = _status;
            dateCreation = createdDate;
        }
        public Livraison(int _id, float _distance, DateTime _elapsedTime, string _status, DateTime createdDate, string _nomCommande = null)
        {
            id = _id;
            Distance = _distance;
            ElapsedTime = _elapsedTime;
            Status = _status;
            dateCreation = createdDate;
            nomCommande = _nomCommande;
        }

        public Livraison(int _id, float _distance, DateTime _elapsedTime, string _status)
        {
            id = _id;
            Distance = _distance;
            ElapsedTime = _elapsedTime;
            Status = _status;
        }
    }
}
