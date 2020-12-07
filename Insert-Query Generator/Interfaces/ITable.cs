using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public interface ITable
    {
        IDataBase SetDataBase(IDataBase dataBase);

        IDataBase GetDataBase();

        List<List<string>> GetFields();//Considerar poner un Map<Column, Data>

        void SetTableName(string name);

        string GetTableName();

        List<string> GetColumnsName();
    }
}
