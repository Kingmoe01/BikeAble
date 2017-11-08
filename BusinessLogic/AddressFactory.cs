using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AddressFactory
    {
        private string _cnnStr;

        public AddressFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }

        public Address[] GetAll()
        {
            List<Address> addressList = new List<Address>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM address";

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_address"].ToString());
                        int Address = Convert.ToInt32(mySqlReader["no_address"].ToString());
                        string App = mySqlReader["app_address"].ToString();
                        string Street = mySqlReader["street_address"].ToString();
                        string PostalCode = mySqlReader["postalCode_address"].ToString();
                        string City = mySqlReader["city_address"].ToString();
                        string Province = mySqlReader["province_address"].ToString();
                        int IDUsager = Convert.ToInt32(mySqlReader["idUsager_address"].ToString());
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_address"]);

                        DateTime DeletedDate;
                        if (mySqlReader["deletedDate_address"] == DBNull.Value)
                            DeletedDate = DateTime.MinValue;
                        else
                            DeletedDate = DateTime.Parse(mySqlReader["deletedDate_address"].ToString());

                        addressList.Add(new Address(ID, Address, App, Street, PostalCode, City, Province, IDUsager, CreatedDate, DeletedDate));
                    }
                }

                return addressList.ToArray();
            }
        }

        public Address GetByID(int id)
        {
            Address address = null;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM address WHERE ID_address = @Id;";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_address"].ToString());
                        int Address = Convert.ToInt32(mySqlReader["no_address"].ToString());
                        string App = mySqlReader["app_address"].ToString();
                        string Street = mySqlReader["street_address"].ToString();
                        string PostalCode = mySqlReader["postalCode_address"].ToString();
                        string City = mySqlReader["city_address"].ToString();
                        string Province = mySqlReader["province_address"].ToString();
                        int IDUsager;
                        Int32.TryParse(mySqlReader["idUsager_address"].ToString(), out IDUsager);
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_address"]);

                        DateTime DeletedDate;
                        if (mySqlReader["deletedDate_address"] == DBNull.Value)
                            DeletedDate = DateTime.MinValue;
                        else
                            DeletedDate = DateTime.Parse(mySqlReader["deletedDate_address"].ToString());

                        address = new Address(ID, Address, App, Street, PostalCode, City, Province, IDUsager, CreatedDate, DeletedDate);
                    }
                }
            }

            return address;
        }

        public Address GetByUserID(int id)
        {
            
            Address address = null;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM address WHERE idUsager_address = @Id;";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_address"].ToString());
                        int Address = Convert.ToInt32(mySqlReader["no_address"].ToString());
                        string App = mySqlReader["app_address"].ToString();
                        string Street = mySqlReader["street_address"].ToString();
                        string PostalCode = mySqlReader["postalCode_address"].ToString();
                        string City = mySqlReader["city_address"].ToString();
                        string Province = mySqlReader["province_address"].ToString();
                        int IDUsager = Convert.ToInt32(mySqlReader["idUsager_address"].ToString());
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_address"]);

                        DateTime DeletedDate;
                        if (mySqlReader["deletedDate_address"] == DBNull.Value)
                            DeletedDate = DateTime.MinValue;
                        else
                            DeletedDate = DateTime.Parse(mySqlReader["deletedDate_address"].ToString());

                        address = new Address(ID, Address, App, Street, PostalCode, City, Province, IDUsager, CreatedDate, DeletedDate);
                    }
                }
            }

            return address;
        }


        public Address GetByAddress(int _No, string _App, string _Street, string _PostalCode)
        {

            Address address = null;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM address WHERE no_address = @No AND app_address = @App AND street_address = @Street AND postalCode_address = @PostalCode";
                mySqlCmd.Parameters.AddWithValue("@No", _No);
                mySqlCmd.Parameters.AddWithValue("@App", _App);
                mySqlCmd.Parameters.AddWithValue("@Street", _Street);
                mySqlCmd.Parameters.AddWithValue("@PostalCode", _PostalCode);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_address"].ToString());
                        int Address = Convert.ToInt32(mySqlReader["no_address"].ToString());
                        string App = mySqlReader["app_address"].ToString();
                        string Street = mySqlReader["street_address"].ToString();
                        string PostalCode = mySqlReader["postalCode_address"].ToString();
                        string City = mySqlReader["city_address"].ToString();
                        string Province = mySqlReader["province_address"].ToString();
                        int IDUsager; int.TryParse((mySqlReader["idUsager_address"].ToString()),out IDUsager);
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_address"]);

                        DateTime DeletedDate;
                        if (mySqlReader["deletedDate_address"] == DBNull.Value)
                            DeletedDate = DateTime.MinValue;
                        else
                            DeletedDate = DateTime.Parse(mySqlReader["deletedDate_address"].ToString());

                        address = new Address(ID, Address, App, Street, PostalCode, City, Province, IDUsager, CreatedDate, DeletedDate);
                    }
                }
            }

            return address;
        }


        public void InsertAddress(int Address, string App, string Street, string PostalCode, string City, string Province, int IDUsager)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@Address", Address));
            parameters.Add(new MySqlParameter("@Street", Street));
            parameters.Add(new MySqlParameter("@PostalCode", PostalCode));
            parameters.Add(new MySqlParameter("@City", City));
            parameters.Add(new MySqlParameter("@Province", Province));


            if (App != "") { parameters.Add(new MySqlParameter("@App", App)); }
            else { parameters.Add(new MySqlParameter("@App", null)); }

            if (IDUsager != 0) { parameters.Add(new MySqlParameter("@IDUsager", IDUsager)); }
            else{ parameters.Add(new MySqlParameter("@IDUsager", null)); }

            ExecuteSqlCommand("INSERT INTO address (no_address, app_address, street_address, postalCode_address, city_address, province_address, idUsager_address) VALUES(@Address, @App, @Street, @PostalCode, @City, @Province, @IDUsager)", parameters);
        }

        public void InsertAddress(int Address, string App, string Street, string PostalCode, string City, string Province)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@Address", Address));
            parameters.Add(new MySqlParameter("@Street", Street));
            parameters.Add(new MySqlParameter("@PostalCode", PostalCode));
            parameters.Add(new MySqlParameter("@City", City));
            parameters.Add(new MySqlParameter("@Province", Province));
            parameters.Add(new MySqlParameter("@App", App));

            ExecuteSqlCommand("INSERT INTO address (no_address, app_address, street_address, postalCode_address, city_address, province_address) VALUES(@Address, @App, @Street, @PostalCode, @City, @Province)", parameters);
        }

        public void EditAddress(int ID, int Address, string App, string Street, string PostalCode, string City, string Province, int IDUsager, DateTime CreatedDate, DateTime DeletedDate)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                string query = "UPDATE address SET no_address=@Address, app_address=@App, street_address=@Street, postalCode_address=@PostalCode, city_address=@City, province_address=@Province, idUsager_address=@IDUsager, createdDate_address=@CreatedDate, deletedDate_address=@DeletedDate WHERE ID_address=@ID";
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("@ID", ID));
                parameters.Add(new MySqlParameter("@Address", Address));
                parameters.Add(new MySqlParameter("@App", App));
                parameters.Add(new MySqlParameter("@Street", Street));
                parameters.Add(new MySqlParameter("@PostalCode", PostalCode));
                parameters.Add(new MySqlParameter("@City", City));
                parameters.Add(new MySqlParameter("@Province", Province));
                parameters.Add(new MySqlParameter("@IDUsager", IDUsager));
                parameters.Add(new MySqlParameter("@CreatedDate", CreatedDate));
                parameters.Add(new MySqlParameter("@DeletedDate", DeletedDate));

                ExecuteSqlCommand(query, parameters);

            }
        }




        //Execute la commande Sql qu'on y envoie avec ses parametres.
        private void ExecuteSqlCommand(string _command, List<MySqlParameter> _parameters)
        {
            using (MySqlConnection MySqlCnn = new MySqlConnection(_cnnStr))
            {
                MySqlCnn.Open();

                MySqlCommand cmd = MySqlCnn.CreateCommand();
                cmd.CommandText = _command;

                foreach (MySqlParameter p in _parameters)
                {
                    cmd.Parameters.Add(p);
                }

                cmd.ExecuteNonQuery();
            }
        }



    }
}
