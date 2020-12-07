using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public interface IDBConfiguration
    {
        string GetConnectionString();

        bool IsValidDataSource(string DataSource);

        string FixDataSource(string DataSource);

        IDBConfiguration SetConnectionString(string DataSource, string InitialCatalog); //This for SQL Server with Integrated Security
    }
}
