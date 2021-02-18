using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.Dao
{
    class MasalarDao
    {

        public DataTable masagetir()
        {
            DataTable masalar = new DataTable();

            DatabaseConnectionUtil.open();
            SqlDataAdapter datalar = new SqlDataAdapter($"select * from masalar",DatabaseConnectionUtil.connection);
            datalar.Fill(masalar);
            DatabaseConnectionUtil.close();
            return masalar;
        }

        public static string control()
        {
            int i = 0;
            DatabaseConnectionUtil.open();

            SqlCommand cmd = new SqlCommand("select Durum from masalar ", DatabaseConnectionUtil.connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (Convert.ToByte(dr["Durum"]) == 1) i++;
            }


            DatabaseConnectionUtil.close();



            return i.ToString();
        }
        public static bool controldurum(int id)
        {
            bool control=true;
            try
            {
                
                DatabaseConnectionUtil.open();
                SqlCommand cmd = new SqlCommand($"select Durum from masalar where ID={id}", DatabaseConnectionUtil.connection);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                control = Convert.ToBoolean(dr["Durum"]);

                DatabaseConnectionUtil.close();
                return control;
            }
            catch(Exception hata)
            {
                MessageBox.Show("Masa Durum KOntrol Bağlantısında Hata oluştu");
                return control;
            }
           
        } 

        public static void doldur(int m_id)
        {
            DatabaseConnectionUtil.open();

            SqlCommand cmd = new SqlCommand($"update masalar set Durum={1} where ID={m_id}", DatabaseConnectionUtil.connection);
            cmd.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
        }


        public static void bosalt(int m_id)
        {

            DatabaseConnectionUtil.open();

            SqlCommand cmd = new SqlCommand($"update masalar set Durum='False' where ID={m_id} ", DatabaseConnectionUtil.connection);
            cmd.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
        }
        }
}
