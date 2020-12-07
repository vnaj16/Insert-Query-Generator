using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public class DataBase : IDataBase
    {
        /*public DataBase(IDBConfiguration _dBConfiguration)
        {
            this.dBConfiguration = _dBConfiguration;
        }

        private IDBConfiguration dBConfiguration;*/
        private DbConnection connection;
        private string connectionString = null;

        public DbConnection Conectar(string connectionString)
        {
            if (connectionString != "none" && this.connectionString is null)
            {
                try
                {
                    this.connectionString = connectionString;
                    //string cadenaConexion = "Data Source=LAPTOP-3QGJ4FL5\\VNAJ_DB01; Initial Catalog= BankApp; Integrated Security=True";

                    connection = new SqlConnection(this.connectionString);

                    connection.Open();

                    return connection;
                }
                catch (Exception e) { return null; }
            }
            else if(!(this.connectionString is null) && connectionString =="none")
            {
                try
                {
                    //string cadenaConexion = "Data Source=LAPTOP-3QGJ4FL5\\VNAJ_DB01; Initial Catalog= BankApp; Integrated Security=True";

                    connection = new SqlConnection(this.connectionString);

                    connection.Open();

                    return connection;
                }
                catch (Exception e) { return null; }
            }
            else
            {
                throw new Exception("Something is wrong with the connection string");
            }
        }

        public void Desconectar()
        {
            connection.Close();
        }
    }
}
