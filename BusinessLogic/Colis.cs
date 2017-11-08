using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Colis
    {
        #region Variables

        int _ID_Colis, _IDLivraison_Colis;
        string _Size ;
        float _Price;

        #endregion


        #region GetSet

        public int ID_Colis
        {
            get { return _ID_Colis; }
            set { _ID_Colis = value; }
        }

        public int IDLivraison_Colis
        {
            get { return _IDLivraison_Colis; }
            set { _IDLivraison_Colis = value; }
        }

        public float Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string Size
        {
            get
            {
                return _Size;
            }

            set
            {
                _Size = value;
            }
        }

        #endregion

        public Colis(int id, int idLivraison, float price, string size)
        {
            _ID_Colis = id;
            _IDLivraison_Colis = idLivraison;
            _Price = price;
            Size = size;
        }
    }
}
