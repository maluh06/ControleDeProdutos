
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeProdutos.DbApplication
{
     public class SQLServerClass
     {
        public string stringConection;
        public SqlConnection ConectionDb;


        public SQLServerClass()
        {
            stringConection = "Data Source=DESKTOP-V4IMUMS;Initial Catalog=EstoqueDb;Integrated Security=True;Encrypt=False";
            ConectionDb = new SqlConnection(stringConection);
            ConectionDb.Open();
        }

        public DataTable SQLQuery(string Sql)
        {
            DataTable dt = new DataTable();

            var Command = new SqlCommand(Sql, ConectionDb);
            Command.CommandTimeout = 0;
            dt.Load(Command.ExecuteReader());
            return dt;
        }

        public string SQLCommand(string Sql)
        {
            var Command = new SqlCommand(Sql, ConectionDb);
            Command.CommandTimeout = 0;
            var Reader = (Command.ExecuteReader());
            return "";
        }

        public void Close()
        {
            ConectionDb.Close();
        }





    }
}
