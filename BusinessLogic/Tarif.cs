using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Tarif
    {
        #region Variables

        int _ID_Tarif;
        double _tarifLettre_Tarif;
        double _tarifPetit_Tarif;
        double _tarifMoyen_Tarif;
        double _tarifGros_Tarif;
        double _tarifKM_Tarif;
        DateTime _createdDate_Tarif, _deletedDate_Tarif;

        #endregion

        #region GetSet

        public int ID_Tarif
        {
            get { return _ID_Tarif; }
            set { _ID_Tarif = value; }
        }

        public double TarifLettre_Tarif
        {
            get { return _tarifLettre_Tarif; }
            set { _tarifLettre_Tarif = value; }
        }

        public double TarifPetit_Tarif
        {
            get { return _tarifPetit_Tarif; }
            set { _tarifPetit_Tarif = value; }
        }

        public double TarifMoyen_Tarif
        {
            get { return _tarifMoyen_Tarif; }
            set { _tarifMoyen_Tarif = value; }
        }

        public double TarifGros_Tarif
        {
            get { return _tarifGros_Tarif; }
            set { _tarifGros_Tarif = value; }
        }
        public double TarifKM_Tarif
        {
            get { return TarifKM_Tarif1; }
            set { TarifKM_Tarif1 = value; }
        }

        public DateTime CreatedDate_Tarif
        {
            get { return _createdDate_Tarif; }
            set { _createdDate_Tarif = value; }
        }

        public DateTime DeletedDate_Tarif
        {
            get { return _deletedDate_Tarif; }
            set { _deletedDate_Tarif = value; }
        }

        public double TarifKM_Tarif1
        {
            get { return _tarifKM_Tarif; }
            set { _tarifKM_Tarif = value; }
        }

        #endregion

        #region Methods

        public Tarif(int ID, double tarifLettre, double tarifPetit, double tarifMoyen, double tarifGros, double tarifKM, DateTime CreatedDate, DateTime DeletedDate)
        {
            _ID_Tarif = ID;
            _tarifLettre_Tarif = tarifLettre;
            _tarifPetit_Tarif = tarifPetit;
            _tarifMoyen_Tarif = tarifMoyen;
            _tarifGros_Tarif = tarifGros;
            TarifKM_Tarif1 = tarifKM;
            _createdDate_Tarif = CreatedDate;
            _deletedDate_Tarif = DeletedDate;
        }

        #endregion
    }
}
