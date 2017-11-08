using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CommandeFactory
    {
        private string _cnnStr;

        public CommandeFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }

        public Commande[] GetAll()
        {
            List<Commande> commandeList = new List<Commande>();

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM commande WHERE deliveredDate_commande != 0000-00-00 00:00:00";


                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        string nomCommande = mySqlReader["nom_commande"].ToString();
                        int ID = Convert.ToInt32(mySqlReader["ID_commande"].ToString()),
                            IDCoursier = Convert.ToInt32(mySqlReader["idCoursier_commande"].ToString()),
                            IDClient = Convert.ToInt32(mySqlReader["idClient_commande"].ToString()),
                            IDClientRec = Convert.ToInt32(mySqlReader["idClientRec_commande"].ToString()),
                            IDLivraison = Convert.ToInt32(mySqlReader["idLivraison_commande"].ToString()),
                            IDAddress = int.Parse(mySqlReader["idAddress"].ToString());

                        DateTime CreatedDate = DateTime.Parse(mySqlReader["createdDate_commande"].ToString());
                        DateTime deleted;
                        DateTime.TryParse(mySqlReader["deletedDate_commande"].ToString(), out deleted);

                        DateTime DeliveredDate;
                        if (mySqlReader["deliveredDate_commande"] == DBNull.Value)
                            DeliveredDate = DateTime.MinValue;
                        else
                            DeliveredDate = DateTime.Parse(mySqlReader["deliveredDate_commande"].ToString());
                        if(deleted.ToString() == "0001-01-01 00:00:00")
                            commandeList.Add(new Commande(nomCommande, ID, IDCoursier, IDClient, IDClientRec, IDLivraison, CreatedDate, DeliveredDate,IDAddress, deleted));
                    }
                }

            }

            return commandeList.ToArray();
        }

        public Commande GetByID(int id)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM commande WHERE ID_commande = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {

                        string nomCommande = mySqlReader["nom_commande"].ToString();
                        int ID = int.Parse(mySqlReader["ID_commande"].ToString()),
                            IDClient = int.Parse(mySqlReader["idClient_commande"].ToString()),
                            IDLivraison = int.Parse(mySqlReader["idLivraison_commande"].ToString()),
                            IDClientRec, IDCoursier, IDAddress;

                        int.TryParse(mySqlReader["idAddress"].ToString(),out IDAddress);
                        int.TryParse(mySqlReader["idClientRec_commande"].ToString(),out IDClientRec);
                        int.TryParse(mySqlReader["idCoursier_commande"].ToString(), out IDCoursier);

                        DateTime CreatedDate = DateTime.Parse(mySqlReader["createdDate_commande"].ToString());
                        DateTime deleted;
                        DateTime.TryParse(mySqlReader["deletedDate_commande"].ToString(), out deleted);

                        DateTime DeliveredDate;
                        if (mySqlReader["deliveredDate_commande"] == DBNull.Value)
                            DeliveredDate = DateTime.MinValue;
                        else
                            DeliveredDate = DateTime.Parse(mySqlReader["deliveredDate_commande"].ToString());

                        return new Commande(nomCommande, ID, IDCoursier, IDClient, IDClientRec, IDLivraison, CreatedDate, DeliveredDate , IDAddress, deleted);
                    }
                    else
                        return null;
                }
            }
        }


        public Commande GetByLivraisonID(int id)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM commande WHERE idLivraison_commande = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        int IDCoursier;
                        int IDClientRec;
                        int IDAddress;
                        string nomCommande = mySqlReader["nom_commande"].ToString();
                        int ID = int.Parse(mySqlReader["ID_commande"].ToString()),
                            IDClient = Convert.ToInt32(mySqlReader["idClient_commande"].ToString()),
                            IDLivraison = Convert.ToInt32(mySqlReader["idLivraison_commande"].ToString());
                        Int32.TryParse(mySqlReader["idCoursier_commande"].ToString(), out IDCoursier);
                        Int32.TryParse(mySqlReader["idClientRec_commande"].ToString(), out IDClientRec);
                        int.TryParse(mySqlReader["idAddress"].ToString(),out IDAddress);

                        DateTime CreatedDate = DateTime.Parse(mySqlReader["createdDate_commande"].ToString());

                        DateTime deleted;
                        DateTime.TryParse(mySqlReader["deletedDate_commande"].ToString(), out deleted);

                        DateTime DeliveredDate;
                        if (mySqlReader["deliveredDate_commande"] == DBNull.Value)
                            DeliveredDate = DateTime.MinValue;
                        else
                            DeliveredDate = DateTime.Parse(mySqlReader["deliveredDate_commande"].ToString());

                        return new Commande(nomCommande, ID, IDCoursier, IDClient, IDClientRec, IDLivraison, CreatedDate, DeliveredDate, IDAddress ,deleted);
                    }
                    else
                        return null;
                }
            }
        }


        public Commande GetByLivraisonNameAddresse(int idAdresse, string name)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM commande WHERE idAddress = @id AND nom_commande = @name";
                mySqlCmd.Parameters.AddWithValue("@id", idAdresse);
                mySqlCmd.Parameters.AddWithValue("@name", name);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        int IDCoursier;
                        int IDClientRec;
                        string nomCommande = mySqlReader["nom_commande"].ToString();
                        int ID = int.Parse(mySqlReader["ID_commande"].ToString()),
                            IDClient = Convert.ToInt32(mySqlReader["idClient_commande"].ToString()),
                            IDLivraison = Convert.ToInt32(mySqlReader["idLivraison_commande"].ToString());
                        Int32.TryParse(mySqlReader["idCoursier_commande"].ToString(), out IDCoursier);
                        Int32.TryParse(mySqlReader["idClientRec_commande"].ToString(), out IDClientRec);
                        int IDAddress = int.Parse(mySqlReader["idAddress"].ToString());

                        DateTime CreatedDate = DateTime.Parse(mySqlReader["createdDate_commande"].ToString());

                        DateTime deleted;
                        DateTime.TryParse(mySqlReader["deletedDate_commande"].ToString(), out deleted);

                        DateTime DeliveredDate;
                        if (mySqlReader["deliveredDate_commande"] == DBNull.Value)
                            DeliveredDate = DateTime.MinValue;
                        else
                            DeliveredDate = DateTime.Parse(mySqlReader["deliveredDate_commande"].ToString());

                        return new Commande(nomCommande, ID, IDCoursier, IDClient, IDClientRec, IDLivraison, CreatedDate, DeliveredDate, IDAddress, deleted);
                    }
                    else
                        return null;
                }
            }
        }



        //creé la commande du client.
        public void CreateCommandeWithIDs(int clientId, int clientRecId,string nomCommande,int idLivraison)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@idClient_commande", clientId));
            parameters.Add(new MySqlParameter("@idClientRec_commande", clientRecId));
            parameters.Add(new MySqlParameter("@nomCommande", nomCommande));
            parameters.Add(new MySqlParameter("@livraisonId", idLivraison));

            ExecuteSqlCommand("insert into commande (idClient_commande, idClientRec_commande,nom_commande,idLivraison_commande) VALUES (@idClient_commande, @idClientRec_commande,@nomCommande,@livraisonId)", parameters);
        }

        public void CreateCommandeWithAddress(int clientId, int addressId, string nomCommande,int idLivraison)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@clientId", clientId));
            parameters.Add(new MySqlParameter("@addressId", addressId));
            parameters.Add(new MySqlParameter("@nomCommande", nomCommande));
            parameters.Add(new MySqlParameter("@livraisonId", idLivraison));

            ExecuteSqlCommand("insert into commande (idClient_commande, idAddress,nom_commande,idLivraison_commande) VALUES (@clientId, @addressId,@nomCommande,@livraisonId)", parameters);
        }

        public bool CheckIfReservation(int IDCoursier)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT* FROM commande WHERE idCoursier_commande = @id";
                mySqlCmd.Parameters.AddWithValue("@id", IDCoursier);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public int GetLastCommandeFromUser(int IDClient)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT ID_commande FROM commande WHERE idClient_commande=@id ORDER BY ID_commande DESC LIMIT 1 ";
                mySqlCmd.Parameters.AddWithValue("@id", IDClient);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        return Convert.ToInt32(mySqlReader["ID_commande"]);
                    }
                    else
                        return 0;
                }
            }
        }
        public bool ClientAndCommandExists(int idClient,int idCommande)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.Parameters.AddWithValue("@idClient", idClient);
                mySqlCmd.Parameters.AddWithValue("@id", idCommande);

                mySqlCmd.CommandText = "SELECT ID_commande FROM commande WHERE idClient_commande = @idClient AND ID_commande = @id ";

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        return true;
                    }
                    else
                        return false;
                }
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


        public void UpdateName(int id,string name)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@name", name));
            parameters.Add(new MySqlParameter("@ID", id));

            ExecuteSqlCommand("UPDATE commande SET nom_commande = @name WHERE ID_commande = @ID", parameters);
        }
        public void falseDeleteCommande(int ID)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@now", DateTime.Now));
            parameters.Add(new MySqlParameter("@ID", ID.ToString()));


            ExecuteSqlCommand("UPDATE commande SET deletedDate_commande=@now WHERE ID_commande=@ID",parameters);
        }

        public void ReserveCommande(int IDCoursier, int IDCommande, int IDLivraison)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@IDCommande", IDCommande));
            parameters.Add(new MySqlParameter("@IDCoursier", IDCoursier));

            List<MySqlParameter> parameters2 = new List<MySqlParameter>();

            parameters2.Add(new MySqlParameter("@IDLivraison", IDLivraison));

            ExecuteSqlCommand("UPDATE commande SET idCoursier_commande= @IDCoursier WHERE ID_commande=@IDCommande", parameters);
            ExecuteSqlCommand("UPDATE livraison SET status = 'Réservé' WHERE ID_livraison=@IDLivraison", parameters2);
        }

        public bool GetByIDAndClientRec(int IDClientRec, int IDCommande)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM commande WHERE deliveredDate_commande IS NULL AND idClientRec_commande=@IDClientRec AND ID_commande=@IDCommande";
                mySqlCmd.Parameters.AddWithValue("@IDClientRec", IDClientRec);
                mySqlCmd.Parameters.AddWithValue("@IDCommande", IDCommande);


                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void CommandeLivreCoursier(int IDLivraison)
        {
            List<MySqlParameter> parameters2 = new List<MySqlParameter>();

            parameters2.Add(new MySqlParameter("@IDLivraison", IDLivraison));

            ExecuteSqlCommand("UPDATE livraison SET status = 'Livré' WHERE ID_livraison=@IDLivraison", parameters2);
        }

        public void UpdateCommandePwd(string pwd)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@pwd", pwd));

            ExecuteSqlCommand("UPDATE livraison SET status = 'Livré' WHERE password=@pwd", parameters);
        }  
    }
}
