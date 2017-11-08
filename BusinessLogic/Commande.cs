using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Commande
    {
        #region Variables

        string nom_commande;
        int _ID_Commande, _IDCoursier_Commande, _IDClient_Commande, _IDClientRec_Commande, _IDLivraison_Commande, IDAddress_Commande;
        DateTime _createdDate_Commande, _deliveredDate_Commande , deletedDate_commande;
        Livraison livraison;

        #endregion

        #region GetSet 

        public int ID_Commande
        {
            get { return _ID_Commande; }
            set { _ID_Commande = value; }
        }

        public int IDCoursier_Commande
        {
            get { return _IDCoursier_Commande; }
            set { _IDCoursier_Commande = value; }
        }

        public int IDClient_Commande
        {
            get{ return _IDClient_Commande; }
            set{ _IDClient_Commande = value; }
        }

        public int IDClientRec_Commande
        {
            get{ return _IDClientRec_Commande; }
            set { _IDClientRec_Commande = value; }
        }

        public int IDLivraison_Commande
        {
            get
            { return _IDLivraison_Commande; }
            set { _IDLivraison_Commande = value; }
        }

        public DateTime CreatedDate_Commande
        {
            get { return _createdDate_Commande; }
            set { _createdDate_Commande = value; }
        }

        public DateTime DeliveredDate_Commande
        {
            get { return _deliveredDate_Commande; }
            set { _deliveredDate_Commande = value; }
        }

        public string Nom_commande
        {
            get { return nom_commande; }

            set { nom_commande = value; }
        }

        public Livraison Livraison
        {
            get { return livraison; }

            set { livraison = value; }
        }

        public int IDAddress_commande
        {
            get
            {
                return IDAddress_Commande;
            }

            set
            {
                IDAddress_Commande = value;
            }
        }

        public DateTime DeletedDate_commande
        {
            get
            {
                return deletedDate_commande;
            }

            set
            {
                deletedDate_commande = value;
            }
        }

        #endregion

        #region Methods
        public Commande(string nom, int ID, int IDCoursier, int IDClient, int IDClientRec, int IDLivraison, DateTime CreatedDate, DateTime DeliveredDate,int idaddress, DateTime deleted ,Livraison _livraison = null)
        {
            _ID_Commande = ID;
            _IDCoursier_Commande = IDCoursier;
            _IDClient_Commande = IDClient;
            _IDClientRec_Commande = IDClientRec;
            _IDLivraison_Commande = IDLivraison;
            _createdDate_Commande = CreatedDate;
            _deliveredDate_Commande = DeliveredDate;
            nom_commande = nom;
            livraison = _livraison;
            IDAddress_Commande = idaddress;
            DeletedDate_commande = deleted;
        }
        #endregion
    }
}
