using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Query_Generator
{
    public class SqlFileWriter//Aca se le pasara la ruta y el contenido a escribir en un archivo .sql

        //GUIARSE DEL LIBRO C# / FILE HANDLING / Reading and Writing File
    {
        public void WriteQueryOnFileSql(List<string> lines, string fileName, string path = "" )
        {
            if (!fileName.Contains(".sql"))
            {
                fileName = fileName + ".sql";
            }

            string pathAbsolute = "";

            if (path != "")
            {
                pathAbsolute = path + "\\" + fileName;
            }
            else
            {
                pathAbsolute = fileName;
            }

            if (File.Exists($"{fileName}.sql"))
            {
                throw new Exception("This file already exists");
            }

            File.WriteAllText(pathAbsolute, "--INSERT Statements");//Escribe nuevo contenido

            foreach (var statement in lines)
            {
                File.AppendAllText(pathAbsolute, Environment.NewLine + statement);
            }
        }
    }
}
