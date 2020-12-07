using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.Common;

namespace Insert_Query_Generator
{
    public interface IDataBase
    {
        DbConnection Conectar(String connectionString="none");

        void Desconectar();
    }
}
