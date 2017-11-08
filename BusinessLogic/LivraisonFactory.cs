using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class LivraisonFactory
    {
        string cnnStr;

        public LivraisonFactory(string _cnnStr)
        {
            cnnStr = _cnnStr;
        }

        public Livraison GetbyId(int _id)
        {
            using (MySqlConnection mySqlCo = new MySqlConnection(cnnStr))
            {
                mySqlCo.Open();

                MySqlCommand cmd = mySqlCo.CreateCommand();
                cmd.CommandText = "SELECT * FROM livraison l WHERE l.ID_Livraison = @id;";
                cmd.Parameters.AddWithValue("@id", _id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        DateTime elapsedTime;
                        int id = int.Parse(reader["ID_livraison"].ToString());
                        float distance = float.Parse(reader["distance_livraison"].ToString());

                        if (reader["elapsedTime_livraison"] == DBNull.Value)
                            elapsedTime = DateTime.MinValue;
                        else
                            elapsedTime = DateTime.Parse(reader["elapsedTime_livraison"].ToString());

                        string status = reader["status"].ToString();

                        return new Livraison(id, distance, elapsedTime,status);
                    }
                    else
                        return null;
                }
            }
        }



        public Livraison[] GetAll()
        {

            List<Livraison> livraisons = new List<Livraison>();
            using (MySqlConnection mySqlCo = new MySqlConnection(cnnStr))
            {
                mySqlCo.Open();

                MySqlCommand cmd = mySqlCo.CreateCommand();
                cmd.CommandText = "SELECT * FROM livraison;";

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime elapsedTime;

                        int id = int.Parse(reader["ID_livraison"].ToString());
                        float distance = float.Parse(reader["distance_livraison"].ToString());
                        if (reader["elapsedTime_livraison"] == DBNull.Value)
                            elapsedTime = DateTime.MinValue;
                        else
                            elapsedTime = DateTime.Parse(reader["elapsedTime_livraison"].ToString());
                        string status = reader["status"].ToString();

                        CommandeFactory CMF = new CommandeFactory(cnnStr);
                        Commande commande = CMF.GetByLivraisonID(id);

                        if(commande.IDCoursier_Commande == 0)
                            livraisons.Add(new Livraison(id, distance, elapsedTime, status));
                    }
                }
            }

            return livraisons.ToArray();
        }



        public Livraison[] GetAllByClient(int _idClient)
        {

            List<Livraison> livraisons = new List<Livraison>();
            using (MySqlConnection mySqlCo = new MySqlConnection(cnnStr))
            {
                mySqlCo.Open();

                MySqlCommand cmd = mySqlCo.CreateCommand();
                cmd.CommandText = "SELECT l.ID_livraison, l.distance_livraison, l.elapsedTime_livraison,c.deletedDate_commande, c.nom_commande, l.status, c.createdDate_commande FROM livraison l " +
                                    "join commande c on l.ID_livraison = c.idLivraison_commande " +
                                    "join usager u on u.ID_usager = c.idClient_commande " +
                                    "where u.ID_usager = @id;";

                cmd.Parameters.AddWithValue("@id", _idClient);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["ID_livraison"].ToString());
                        float distance = float.Parse(reader["distance_livraison"].ToString());
                        DateTime elapsedTime;


                        if (reader["elapsedTime_livraison"] == DBNull.Value)
                            elapsedTime = DateTime.MinValue;
                        else
                            elapsedTime = DateTime.Parse(reader["elapsedTime_livraison"].ToString());

                        string status = reader["status"].ToString(),
                            nom = reader["nom_commande"].ToString();
                        DateTime createdDate = DateTime.Parse(reader["createdDate_commande"].ToString());

                        DateTime deleted;
                        DateTime.TryParse(reader["deletedDate_commande"].ToString(), out deleted);

                        if (deleted.ToString() == "0001-01-01 00:00:00")
                            livraisons.Add(new Livraison(id, distance, elapsedTime, status,createdDate,nom));
                    }
                }

                
            }

            return livraisons.ToArray();
        }


        public Livraison GetAllByCoursier(int _idCoursier)
        {
            
            using (MySqlConnection mySqlCo = new MySqlConnection(cnnStr))
            {
                mySqlCo.Open();

                MySqlCommand cmd = mySqlCo.CreateCommand();
                cmd.CommandText = "SELECT c.ID_commande, l.distance_livraison, l.elapsedTime_livraison,c.deletedDate_commande, c.nom_commande, l.status, c.createdDate_commande FROM livraison l " +
                                    "join commande c on l.ID_livraison = c.idLivraison_commande " +
                                    "join usager u on u.ID_usager = c.idClient_commande " +
                                    "where c.idCoursier_commande = @id;";

                cmd.Parameters.AddWithValue("@id", _idCoursier);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = int.Parse(reader["ID_commande"].ToString());
                        float distance = float.Parse(reader["distance_livraison"].ToString());
                        DateTime elapsedTime;


                        if (reader["elapsedTime_livraison"] == DBNull.Value)
                            elapsedTime = DateTime.MinValue;
                        else
                            elapsedTime = DateTime.Parse(reader["elapsedTime_livraison"].ToString());

                        string status = reader["status"].ToString(),
                            nom = reader["nom_commande"].ToString();
                        DateTime createdDate = DateTime.Parse(reader["createdDate_commande"].ToString());

                        DateTime deleted;
                        DateTime.TryParse(reader["deletedDate_commande"].ToString(), out deleted);

                        if (deleted.ToString() == "0001-01-01 00:00:00")
                            return new Livraison(id, distance, elapsedTime, status, createdDate, nom);
                    }
                }
                return null;

            }
        }


        int CountLivraison()
        {
            using (MySqlConnection mySqlCo = new MySqlConnection(cnnStr))
            {
                mySqlCo.Open();

                MySqlCommand cmd = mySqlCo.CreateCommand();
                cmd.CommandText = "SELECT count(*) as Qte FROM livraison";

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int qte = int.Parse(reader["Qte"].ToString());
                        return qte + 1;
                    }
                }
            }
            return 0;
        }


        public int CreateLivraison(float distance, string status)
        {
            int id;
            distance = distance / 1000;
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@distance", distance));
            parameters.Add(new MySqlParameter("@status", status));
            parameters.Add(new MySqlParameter("@commande", status));

            id = ExecuteSqlCommandWithReturnID("insert into livraison (distance_livraison,status) VALUES (@distance,@status)", parameters);

            return id;
        }


        private void ExecuteSqlCommand(string _command, List<MySqlParameter> _parameters)
        {
            using (MySqlConnection MySqlCnn = new MySqlConnection(cnnStr))
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

        private int ExecuteSqlCommandWithReturnID(string _command, List<MySqlParameter> _parameters)
        {
            int id;
            using (MySqlConnection MySqlCnn = new MySqlConnection(cnnStr))
            {
                MySqlCnn.Open();

                MySqlCommand cmd = MySqlCnn.CreateCommand();
                cmd.CommandText = _command;

                foreach (MySqlParameter p in _parameters)
                {
                    cmd.Parameters.Add(p);
                }
                
                cmd.ExecuteNonQuery();
                id = (int)cmd.LastInsertedId;

            }

            return id;
        }
    }
}
