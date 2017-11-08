using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Address
    {
        #region Variables

        int _ID_Address;
        int _No_Address;
        string _App_Address;
        string _Street_Address;
        string _PostalCode_Address;
        string _City_Address;
        string _Province_Address;
        int _IDUsager_Address;
        DateTime _CreatedDate_Address;
        DateTime _DeletedDate_Address;

        #endregion

        #region GetSet

        public int ID_Address
        {
            get  { return _ID_Address; }
            set  {  _ID_Address = value; }
        }

        public int No_Address
        {
            get { return _No_Address; }
            set { _No_Address = value; }
        }

        public string App_Address
        {
            get { return _App_Address; }
            set { _App_Address = value; }
        }

        public string Street_Address
        {
            get { return _Street_Address; }
            set {  _Street_Address = value; }
        }

        public string PostalCode_Address
        {
            get { return _PostalCode_Address; }
            set { _PostalCode_Address = value; }
        }

        public string City_Address
        {
            get { return _City_Address; }
            set { _City_Address = value; }
        }

        public string Province_Address
        {
            get { return _Province_Address; }
            set { _Province_Address = value; }
        }

        public int IDUsager_Address
        {
            get { return _IDUsager_Address; }
            set { _IDUsager_Address = value; }
        }

        public DateTime CreatedDate_Address
        {
            get { return _CreatedDate_Address; }
            set { _CreatedDate_Address = value; }
        }

        public DateTime DeletedDate_Address
        {
            get { return _DeletedDate_Address; }
            set { _DeletedDate_Address = value; }
        }

        #endregion

        #region Methods

        public Address(int ID, int No, string App, string Street, string PostalCode, string City, string Province, int IDUsager, DateTime CreatedDate, DateTime DeletedDate)
        {
            _ID_Address = ID;
            _No_Address = No;
            _App_Address = App;
            _Street_Address = Street;
            _PostalCode_Address = PostalCode;
            _City_Address = City;
            _Province_Address = Province;
            _IDUsager_Address = IDUsager;
            _CreatedDate_Address = CreatedDate;
            _DeletedDate_Address = DeletedDate;
        }
        public Address(int No, string App, string Street, string PostalCode, string City, string Province, int IDUsager, DateTime CreatedDate)
        {
            _No_Address = No;
            _App_Address = App;
            _Street_Address = Street;
            _PostalCode_Address = PostalCode;
            _City_Address = City;
            _Province_Address = Province;
            _IDUsager_Address = IDUsager;
            _CreatedDate_Address = CreatedDate;
        }

        public Address(int No, string App, string Street, string PostalCode, string City, string Province)
        {
            _No_Address = No;
            _App_Address = App;
            _Street_Address = Street;
            _PostalCode_Address = PostalCode;
            _City_Address = City;
            _Province_Address = Province;
        }

        public Address()
        {

        }

        public override string ToString()
        {
            return _App_Address.ToString() + "," + _No_Address.ToString() + "," + _Street_Address.ToString() + "," + _City_Address.ToString() + "," + _Province_Address.ToString() + "," + _PostalCode_Address.ToString();
        }

        #endregion

    }
}
