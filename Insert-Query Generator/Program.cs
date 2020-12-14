using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string rpta = "";

            // TODO: Considerar los tipos String ('2018-10-10') en el Statement y los NULL en la clase Table line 70

            string DataSource = "";
            string Catalog = "";

            Console.Write("Ingrese el datasource: ");
            DataSource = Console.ReadLine();

            Console.Write("Ingrese el catalog: ");
            Catalog = Console.ReadLine();

            while (rpta != "+")
            {
                Console.Write("Ingrese el nombre de la tabla: ");
                rpta = Console.ReadLine();
                try
                {
                    IDataBase dataBase = new DataBase();
                    var connection = dataBase.Conectar(DBConfiguration.GetInstance.SetConnectionString(DataSource, Catalog).GetConnectionString());

                    Console.WriteLine("State of connection: " + connection.State);

                    ITable table = new Table(dataBase, rpta);

                    var queries = QueryGenerator.GetInstance.SetParameters(table.GetFields(), table.GetColumnsName(), table.GetTableName()).GetQuery();

                    foreach (string query in queries)
                    {
                        Console.WriteLine(query);
                    }

                    Console.WriteLine("Writing content in the file statements.sql");
                    SqlFileWriter sqlFileWriter = new SqlFileWriter();
                    sqlFileWriter.WriteQueryOnFileSql(queries, "statements");

                    dataBase.Desconectar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(); Console.WriteLine("//////////////////");
                Console.WriteLine();

                /*Console.WriteLine("State of dataBase: " + connection.State);

                connection.Close();

                Console.WriteLine("State of connection: " + connection.State);*/

                Console.ReadKey();
            }
        }
    }
}
