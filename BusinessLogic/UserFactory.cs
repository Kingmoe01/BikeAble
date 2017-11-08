using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserFactory
    {
        private string _cnnStr;

        public UserFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }

        public User[] GetAll()
        {
            List<User> userList = new List<User>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager";

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string Email = mySqlReader["email_usager"].ToString();
                        bool IsCoursier = Convert.ToBoolean(mySqlReader["isCoursier_usager"].ToString());
                        bool IsAdmin = Convert.ToBoolean(mySqlReader["isAdmin_usager"].ToString());
                        Byte[] Salt = (byte[])mySqlReader["salt"];
                        Byte[] Hash = (byte[])mySqlReader["hash"];
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_usager"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_usager"]);
                        string Telnum = mySqlReader["telNum_usager"].ToString();

                        userList.Add(new User(ID, LastName, FirstName, Email, IsCoursier, IsAdmin, Salt, Hash, CreatedDate, DeletedDate, Telnum));
                    }
                }

                return userList.ToArray();

            }
        }

        

        public User GetByEmail(string email)
        {
            User user = null;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager WHERE email_usager = @email;";
                mySqlCmd.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string Email = mySqlReader["email_usager"].ToString();
                        bool IsCoursier = Convert.ToBoolean(mySqlReader["isCoursier_usager"].ToString());
                        bool IsAdmin = Convert.ToBoolean(mySqlReader["isAdmin_usager"].ToString());
                        Byte[] Salt = (byte[])mySqlReader["salt"];
                        Byte[] Hash = (byte[])mySqlReader["hash"];
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_usager"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_usager"]);
                        string Telnum = mySqlReader["telNum_usager"].ToString();

                        user = new User(ID, LastName, FirstName, Email, IsCoursier, IsAdmin, Salt, Hash, CreatedDate, DeletedDate,Telnum);

                    }
                }
            }

            return user;
        }

        public User GetByID(int id)
        {
            User user = null;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager WHERE ID_usager = @Id;";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string Email = mySqlReader["email_usager"].ToString();
                        bool IsCoursier = Convert.ToBoolean(mySqlReader["isCoursier_usager"].ToString());
                        bool IsAdmin = Convert.ToBoolean(mySqlReader["isAdmin_usager"].ToString());
                        Byte[] Salt = (byte[])mySqlReader["salt"];
                        Byte[] Hash = (byte[])mySqlReader["hash"];
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_usager"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_usager"]);
                        string Telnum = mySqlReader["telNum_usager"].ToString();

                        user = new User(ID, LastName, FirstName, Email, IsCoursier, IsAdmin, Salt, Hash, CreatedDate, DeletedDate,Telnum);

                    }
                }
            }

            return user;
        }

        public User[] GetFriends(int id)
        {
            List<User> users = new List<User>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "Select u.id_usager, u.lastName_usager, u.firstName_usager, u.email_usager from ami a " +
                                        "join usager u on a.ami = u.ID_usager " +
                                        "where a.client = @Id and a.pendingRequest = 0";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {

                        int idUser = int.Parse(mySqlReader­["id_Usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string email = mySqlReader­["email_usager"].ToString();

                        users.Add(new User(idUser, LastName, FirstName, email));

                    }
                }
            }

            return users.ToArray();
        }

        public User[] GetPendingRequest(int id)
        {
            List<User> users = new List<User>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "Select u.id_usager, u.lastName_usager, u.firstName_usager, u.email_usager from ami a " +
                                        "join usager u on a.client = u.ID_usager  " +
                                        "where a.ami = @Id and a.pendingRequest = 1";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {

                        int idUser = int.Parse(mySqlReader­["id_Usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string email = mySqlReader­["email_usager"].ToString();

                        users.Add(new User(idUser, LastName, FirstName, email));

                    }
                }
            }

            return users.ToArray();
        }

        public User[] GetWithAddress(int id)
        {
            List<User> users = new List<User>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "Select u.firstName_usager, u.lastName_usager, ad.* from ami a " +
                                        "join usager u on a.ami = u.ID_usager " +
                                        "join address ad on ad.idUsager_address = u.ID_usager " +
                                        "where a.client = @Id and a.pendingRequest = false";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {

                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        int idAdresse = int.Parse(mySqlReader­["ID_address"].ToString());
                        int idUser = int.Parse(mySqlReader­["idUsager_address"].ToString());
                        int no = int.Parse(mySqlReader­["no_address"].ToString());
                        string street = mySqlReader­["street_address"].ToString();
                        string postalCode = mySqlReader­["postalCode_address"].ToString();
                        string province = mySqlReader­["province_address"].ToString();
                        string city = mySqlReader­["city_address"].ToString();
                        string app = mySqlReader­["app_address"].ToString();
                        DateTime createdDate = DateTime.Parse(mySqlReader­["createdDate_address"].ToString());
                        DateTime deletedDate;

                        if (mySqlReader­["deletedDate_address"] == DBNull.Value)
                            deletedDate = DateTime.MinValue;
                        else
                            deletedDate = DateTime.Parse(mySqlReader­["deletedDate_address"].ToString());
                        Address adresse = new Address(idAdresse, no, app, street, postalCode, city, province, idUser, createdDate, deletedDate);

                        users.Add(new User(idUser, LastName, FirstName, adresse));

                    }
                }
            }

            return users.ToArray();
        }

        public string UserExists(string email)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager WHERE email_usager = @email;";
                mySqlCmd.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        return "Yup";
                    }
                    else
                    {
                        return "Nope";
                    }
                }
            }
        }

        public void falseDeleteUser(int ID)
        {
            DateTime now = DateTime.Now;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                string query = "UPDATE usager SET deletedDate_usager=@now WHERE ID_usager=@ID";
                using (MySqlCommand mySqlCmd = new MySqlCommand(query))
                {
                    mySqlCmd.Connection = mySqlCnn;
                    mySqlCmd.Parameters.AddWithValue("@now", now);

                    mySqlCmd.Parameters.AddWithValue("@ID", ID.ToString());
                    mySqlCnn.Open();
                    mySqlCmd.ExecuteNonQuery();
                    mySqlCnn.Close();
                }
            }
        }

        public bool InsertUser(string lastName, string firstName, string email, bool isCoursier, bool isAdmin, byte[] salt, byte[] hash, DateTime createdDate, string tel)
        {

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO usager (lastName_usager, firstName_usager, email_usager, isCoursier_usager, isAdmin_usager, salt, hash, createdDate_usager, deletedDate_usager, telNum_usager) VALUES (@lastName, @firstName, @email, @isCoursier, @isAdmin, @salt, @hash, @createdDate, @deletedDate, @Tel)";
                mySqlCmd.Parameters.AddWithValue("@lastName", lastName);
                mySqlCmd.Parameters.AddWithValue("@firstName", firstName);
                mySqlCmd.Parameters.AddWithValue("@email", email);
                mySqlCmd.Parameters.AddWithValue("@isCoursier", isCoursier);
                mySqlCmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                mySqlCmd.Parameters.AddWithValue("@salt", salt);
                mySqlCmd.Parameters.AddWithValue("@hash", hash);
                mySqlCmd.Parameters.AddWithValue("@createdDate", createdDate);
                mySqlCmd.Parameters.AddWithValue("@deletedDate", "0000-00-00 00:00:00");
                mySqlCmd.Parameters.AddWithValue("@Tel", tel);

                mySqlCmd.ExecuteNonQuery();
                mySqlCnn.Close();
                return true;
            }
        }

       

        public User GetAdminByLogin(string login)
        {
            User user = null;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager WHERE isAdmin_usager = true AND email_usager = @login;";
                mySqlCmd.Parameters.AddWithValue("@login", login);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string Email = mySqlReader["email_usager"].ToString();
                        bool IsCoursier = Convert.ToBoolean(mySqlReader["isCoursier_usager"].ToString());
                        bool IsAdmin = Convert.ToBoolean(mySqlReader["isAdmin_usager"].ToString());
                        Byte[] Salt = (byte[])mySqlReader["salt"];
                        Byte[] Hash = (byte[])mySqlReader["hash"];
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_usager"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_usager"]);
                        string Tel = mySqlReader["telNum_usager"].ToString();

                        user = new User(ID, LastName, FirstName, Email, IsCoursier, IsAdmin, Salt, Hash, CreatedDate, DeletedDate,Tel);
                    }
                }
            }

            return user;

        }

        public User GetUserByLogin(string login)
        {
            User user = null;

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager WHERE email_usager = @login;";
                mySqlCmd.Parameters.AddWithValue("@login", login);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string Email = mySqlReader["email_usager"].ToString();
                        bool IsCoursier = Convert.ToBoolean(mySqlReader["isCoursier_usager"].ToString());
                        bool IsAdmin = Convert.ToBoolean(mySqlReader["isAdmin_usager"].ToString());
                        Byte[] Salt = (byte[])mySqlReader["salt"];
                        Byte[] Hash = (byte[])mySqlReader["hash"];
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_usager"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_usager"]);
                        string Tel = mySqlReader["telNum_usager"].ToString();

                        user = new User(ID, LastName, FirstName, Email, IsCoursier, IsAdmin, Salt, Hash, CreatedDate, DeletedDate, Tel);
                    }
                }
            }

            return user;
        }

        public User[] GetAllCoursiers()
        {
            List<User> userList = new List<User>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager WHERE isCoursier_usager ='1' AND deletedDate_usager='0000-00-00 00:00:00';";

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string Email = mySqlReader["email_usager"].ToString();
                        bool IsCoursier = Convert.ToBoolean(mySqlReader["isCoursier_usager"].ToString());
                        bool IsAdmin = Convert.ToBoolean(mySqlReader["isAdmin_usager"].ToString());
                        Byte[] Salt = (byte[])mySqlReader["salt"];
                        Byte[] Hash = (byte[])mySqlReader["hash"];
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_usager"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_usager"]);
                        string Tel = mySqlReader["telNum_usager"].ToString();

                        userList.Add(new User(ID, LastName, FirstName, Email, IsCoursier, IsAdmin, Salt, Hash, CreatedDate, DeletedDate, Tel));
                    }
                }

                return userList.ToArray();

            }
        }

        public User[] GetAllClients()
        {
            List<User> userList = new List<User>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM usager WHERE isCoursier_usager !='1' AND isAdmin_usager !='1' AND deletedDate_usager='0000-00-00 00:00:00';";

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_usager"].ToString());
                        string LastName = mySqlReader["lastName_usager"].ToString();
                        string FirstName = mySqlReader­["firstName_usager"].ToString();
                        string Email = mySqlReader["email_usager"].ToString();
                        bool IsCoursier = Convert.ToBoolean(mySqlReader["isCoursier_usager"].ToString());
                        bool IsAdmin = Convert.ToBoolean(mySqlReader["isAdmin_usager"].ToString());
                        Byte[] Salt = (byte[])mySqlReader["salt"];
                        Byte[] Hash = (byte[])mySqlReader["hash"];
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_usager"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_usager"]);
                        string Tel = mySqlReader["telNum_usager"].ToString();

                        userList.Add(new User(ID, LastName, FirstName, Email, IsCoursier, IsAdmin, Salt, Hash, CreatedDate, DeletedDate, Tel));
                    }
                }

                return userList.ToArray();

            }
        }


        public void EditUserAndPWD(int ID, string lastName, string firstName, string email, bool isCoursier, bool isAdmin, byte[] salt, byte[] hash, string tel)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@ID", ID));
            parameters.Add(new MySqlParameter("@lastName", lastName));
            parameters.Add(new MySqlParameter("@firstName", firstName));
            parameters.Add(new MySqlParameter("@email", email));
            parameters.Add(new MySqlParameter("@isCoursier", isCoursier));
            parameters.Add(new MySqlParameter("@isAdmin", isAdmin));
            parameters.Add(new MySqlParameter("@salt", salt));
            parameters.Add(new MySqlParameter("@hash", hash));
            parameters.Add(new MySqlParameter("@Tel", tel));

            ExecuteSqlCommand("UPDATE usager SET lastName_usager=@lastName,telNum_usager=@Tel, firstName_usager=@firstName, email_usager=@email, isCoursier_usager=@isCoursier, isAdmin_usager=@isAdmin, salt=@salt, hash=@hash WHERE ID_usager=@ID",parameters);
        }


        public void EditUser(int ID, string lastName, string firstName, string email, bool isCoursier, bool isAdmin, string tel)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@ID", ID));
            parameters.Add(new MySqlParameter("@lastName", lastName));
            parameters.Add(new MySqlParameter("@firstName", firstName));
            parameters.Add(new MySqlParameter("@email", email));
            parameters.Add(new MySqlParameter("@isCoursier", isCoursier));
            parameters.Add(new MySqlParameter("@isAdmin", isAdmin));
            parameters.Add(new MySqlParameter("@Tel", tel));

            ExecuteSqlCommand("UPDATE usager SET lastName_usager=@lastName,telNum_usager=@Tel, firstName_usager=@firstName, email_usager=@email, isCoursier_usager=@isCoursier, isAdmin_usager=@isAdmin WHERE ID_usager=@ID", parameters);
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
