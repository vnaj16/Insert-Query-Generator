using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public class Table : ITable
    {//PONERLE MEJOR CONSTRUCTOR
        IDataBase DataBase = null;
        public string tableName;
        List<string> columnNames = new List<string>();
        bool isCNComplete = false;

        public Table(IDataBase dataBase, string tableName)
        {
            this.DataBase = dataBase;
            this.tableName = tableName;
        }

        public List<string> GetColumnsName()
        {
            if (isCNComplete)
            {
                return columnNames;
            }
            else
            {
                throw new Exception("Column Names Undefined");
            }
        }

        public IDataBase GetDataBase()
        {
            if (DataBase is null)
            {
                throw new Exception("DataBase not implemented");
            }

            return DataBase;
        }

        public List<List<string>> GetFields()
        {
            if (tableName is null)
            {
                throw new Exception("Table name undefined");
            }

            List<List<string>> lista = new List<List<string>>();

            try
            {
                var Conexion = DataBase.Conectar();
                string select = $"SELECT * FROM {tableName}";
                DbCommand Comando = new SqlCommand(select, (SqlConnection)Conexion);
                DbDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    List<string> row = new List<string>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var value = Convert.ToString(reader[i]);

                        if (value != "")
                        {

                            var type = reader.GetFieldType(i).Name;
                            if (type == "String")
                            {
                                value = "'" + value + "'";
                            }

                            Console.WriteLine("Tipo de la columna " + i + " :" + type);
                            Console.WriteLine("Valor de la columa: " + value);
                        }
                        else
                        {
                            value = "NULL";
                            Console.WriteLine("Valor de la columa: " + "NULL");
                        }

                        row.Add(value);

                        if (!isCNComplete)
                        {
                            columnNames.Add(reader.GetName(i));   
                        }
                    }
                    isCNComplete = true;

                    lista.Add(row);
                }

                reader.Close();
                return lista;
            }
            catch (Exception e) { return null; }
            finally { DataBase.Desconectar(); }
        }

        public IDataBase SetDataBase(IDataBase dataBase)
        {
            DataBase = dataBase;

            return GetDataBase();
        }

        public void SetTableName(string name)
        {
            this.tableName = name;
        }

        public string GetTableName()
        {
            return tableName;
        }
    }
}
