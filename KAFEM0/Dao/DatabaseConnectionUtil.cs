using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace KAFEM0.Dao
{
    class DatabaseConnectionUtil
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AQ1SDH2;Initial Catalog=kafe1;Integrated Security=True");
        public static void open()
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
        }
        public static void close()
        {
            if (connection.State == ConnectionState.Open) connection.Close();
        }


    }
}
