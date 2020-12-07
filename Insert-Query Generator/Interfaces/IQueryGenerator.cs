using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public interface IQueryGenerator
    {
        List<String> GetQuery();

        IQueryGenerator SetParameters(List<List<string>> Data, List<string> Colums, string TableName);
    }
}
