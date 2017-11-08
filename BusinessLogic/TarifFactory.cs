using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TarifFactory
    {
        private string _cnnStr;

        public TarifFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }

        public Tarif Get()
        {
            Tarif basicTarif = null; 

            using (MySqlConnection mySqlCnn = new MySqlConnection(_cnnStr))
            {
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tarif";

                using (MySqlDataReader mySqlReader = mySqlCmd.ExecuteReader())
                {
                    while (mySqlReader.Read())
                    {
                        int ID = Convert.ToInt32(mySqlReader["ID_tarif"].ToString());
                        double tarifLettre = Convert.ToDouble(mySqlReader["tarifLettre_tarif"].ToString());
                        double tarifPetit = Convert.ToDouble(mySqlReader["tarifPetit_tarif"].ToString());
                        double tarifMoyen = Convert.ToDouble(mySqlReader["tarifMoyen_tarif"].ToString());
                        double tarifGros = Convert.ToDouble(mySqlReader["tarifGros_tarif"].ToString());
                        double tarifKM = Convert.ToDouble(mySqlReader["tarifKM_tarif"].ToString());
                        DateTime CreatedDate = Convert.ToDateTime(mySqlReader["createdDate_tarif"]);
                        DateTime DeletedDate = Convert.ToDateTime(mySqlReader["deletedDate_tarif"]);

                        basicTarif = new Tarif(ID, tarifLettre, tarifPetit, tarifMoyen, tarifGros, tarifKM, CreatedDate, DeletedDate);
                    }
                }

                return basicTarif;

            }
        }

        public void TarifEdit(int ID, double tarifLettre, double tarifPetit, double tarifMoyen, double tarifGros, double tarifKM)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@ID", ID));
            parameters.Add(new MySqlParameter("@tarifLettre", tarifLettre));
            parameters.Add(new MySqlParameter("@tarifPetit", tarifPetit));
            parameters.Add(new MySqlParameter("@tarifMoyen", tarifMoyen));
            parameters.Add(new MySqlParameter("@tarifGros", tarifGros));
            parameters.Add(new MySqlParameter("@tarifKM", tarifKM));

            ExecuteSqlCommand("UPDATE tarif SET tarifLettre_tarif=@tarifLettre,tarifPetit_tarif=@tarifPetit, tarifMoyen_tarif=@tarifMoyen, tarifGros_tarif=@tarifGros, tarifKM_tarif=@tarifKM WHERE ID_tarif=@ID", parameters);
        }

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
