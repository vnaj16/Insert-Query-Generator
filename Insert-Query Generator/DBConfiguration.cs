using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public class DBConfiguration : IDBConfiguration
    {
        //APLICAR SINGLETON

        private static IDBConfiguration instance = null;
        public static IDBConfiguration GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new DBConfiguration();
                return instance;
            }
        }

        private string ConnectionString = null;

        public string GetConnectionString()
        {
            if (ConnectionString is null)
            {
                throw new Exception("ConnectionString empty");
            }
            return ConnectionString;
        }

        public IDBConfiguration SetConnectionString(string DataSource, string InitialCatalog)
        {
            if (IsValidDataSource(DataSource))
            {
                ConnectionString = $"Data Source={DataSource}; Initial Catalog= {InitialCatalog}; Integrated Security=True";
            }
            else
            {
                ConnectionString = $"Data Source={FixDataSource(DataSource)}; Initial Catalog= {InitialCatalog}; Integrated Security=True";
            }
            return GetInstance;
        }

        public bool IsValidDataSource(string DataSource)
        {
            if (DataSource.Contains("\\"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FixDataSource(string DataSource)
        {
            return DataSource.Replace(@"\","\\");
        }
    }
}
