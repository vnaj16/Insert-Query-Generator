using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public class QueryGenerator : IQueryGenerator
    {
        private static IQueryGenerator instance = null;
        public static IQueryGenerator GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new QueryGenerator();
                return instance;
            }
        }

        private List<List<string>> Data;
        private List<string> Colums;
        private string tableName;
        public List<string> GetQuery()
        {
            if (!(Data is null && Colums is null))
            {
                List<string> Queries = new List<string>();
                int size = Colums.Count;

                foreach (List<string> row in Data)
                {
                    string x = $"INSERT INTO {tableName} (";//CONSIDERAR MEJOR USAR EL STRING BUILDER

                    for (int i = 0; i < size; i++)
                    {
                        x += Colums[i];

                        if (i != size - 1)
                        {
                            x += ", ";
                        }
                    }

                    x += ") VALUES (";

                    for (int i = 0; i < size; i++)
                    {
                        x += row[i];

                        if (i != size - 1)
                        {
                            x += ", ";
                        }
                    }

                    x += ");";

                    Queries.Add(x);
                }

                return Queries;
            }
            else
            {
                throw new Exception("Something is wrong with the data");
            }
 
        }

        public IQueryGenerator SetParameters(List<List<string>> Data, List<string> Colums, string TableName)
        {
            this.Data = Data;
            this.Colums = Colums;
            this.tableName = TableName;

            return GetInstance;
        }
    }
}
