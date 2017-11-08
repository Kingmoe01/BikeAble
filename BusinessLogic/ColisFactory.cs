using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ColisFactory
    {
        private string _cnnStr;

        public ColisFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }


        public float GetPrice(string size,int livraisonId)
        {
            LivraisonFactory lFactory = new LivraisonFactory(_cnnStr);
            TarifFactory tFact = new TarifFactory(_cnnStr);
            float distance = lFactory.GetbyId(livraisonId).Distance;

            switch (size)
            {
                case "Petit":
                    return (float)tFact.Get().TarifPetit_Tarif + (distance * (float)tFact.Get().TarifKM_Tarif);
                case "Moyen":
                    return (float)tFact.Get().TarifMoyen_Tarif + (distance * (float)tFact.Get().TarifKM_Tarif);
                case "Gros":
                    return (float)tFact.Get().TarifGros_Tarif + (distance * (float)tFact.Get().TarifKM_Tarif);
                default:
                    return (float)tFact.Get().TarifLettre_Tarif + (distance * (float)tFact.Get().TarifKM_Tarif);
            }
        }

        public void CreateColis(string size, int idLivraison)
        {
            float price = GetPrice(size,idLivraison);
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@size", size));
            parameters.Add(new MySqlParameter("@price", price));
            parameters.Add(new MySqlParameter("@idLivraison", idLivraison));

            ExecuteSqlCommand("insert into colis (size_colis, price_colis,idLivraison_colis) VALUES (@size, @price,@idLivraison)", parameters);
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

        public Colis GetByLivrasonID(int id)
        {
            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM colis WHERE idLivraison_colis = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    if (mySqlReader.Read())
                    {
                        string size = mySqlReader["size_colis"].ToString();
                        float price = float.Parse(mySqlReader["price_colis"].ToString());
                        int idlivraison = Convert.ToInt32(mySqlReader["idLivraison_colis"].ToString());
                        int idcolis = Convert.ToInt32(mySqlReader["ID_colis"].ToString());

                        Colis colis = new Colis(idcolis, idlivraison, price, size);
                        return colis;
                    }
                    else
                        return null;
                }
            }
        }



    }
}
