using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class AmiFactory
    {
        public static bool AjouterAmi(int myId, int amiId, string connectionString)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@idClient", myId));
            parameters.Add(new MySqlParameter("@idAmi", amiId));

            ExecuteSqlCommand("insert into ami VALUES (@idClient, @idAmi,true)", parameters, connectionString);
            return true;
        }

        public static bool AccepterAmi(int myId, int amiId, string connectionString)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@idClient", myId));
            parameters.Add(new MySqlParameter("@idAmi", amiId));

            ExecuteSqlCommand("insert into ami VALUES (@idClient, @idAmi,false)", parameters, connectionString);

            MAJ(myId, amiId, connectionString);
            return true;
        }

        public static bool MAJ(int myId, int amiId, string connectionString)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@idClient", myId));
            parameters.Add(new MySqlParameter("@idAmi", amiId));

            ExecuteSqlCommand("update ami SET pendingRequest = false Where client =  @idAmi and ami = @idClient", parameters, connectionString);
            return true;
        }

        private static void ExecuteSqlCommand(string _command, List<MySqlParameter> _parameters, string connectionString)
        {
            using (MySqlConnection MySqlCnn = new MySqlConnection(connectionString))
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
