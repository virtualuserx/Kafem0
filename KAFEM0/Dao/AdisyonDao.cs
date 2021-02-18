using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.Dao
{
   public static class AdisyonDao
    {
        public static string getpersonelname(int a_id)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"select * from personeller where ID=(select PersonelID from adisyon where ID={a_id} and Durum='False')", DatabaseConnectionUtil.connection);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            string name = dr["Ad"].ToString() + "   " + dr["Soyad"];
            DatabaseConnectionUtil.close();
            return name;
        }

        public  static void olustur(int m_id,int p_id)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cc = new SqlCommand($"insert into adisyon (MasaID,PersonelID) values ({m_id},{p_id})", DatabaseConnectionUtil.connection);
            cc.ExecuteNonQuery();
            DatabaseConnectionUtil.close();

         



        }

        public static bool control(int m_id, int p_id)
        {
            bool control = false;
            DatabaseConnectionUtil.open();
            SqlCommand cc = new SqlCommand($"select PersonelID from adisyon where MasaID={m_id}", DatabaseConnectionUtil.connection);
            SqlDataReader dr = cc.ExecuteReader();
            while (dr.Read())
            {
                if (p_id.ToString() == dr["PersonelID"].ToString())
                {
                    control = true;
                }
            }
            DatabaseConnectionUtil.close();
            return control;
        }

        public static string  bul(int m_id)
        {
            string id;
            DatabaseConnectionUtil.open();
            SqlCommand cc = new SqlCommand($"select ID from adisyon where MasaID={m_id} and Durum='False'", DatabaseConnectionUtil.connection);
            SqlDataReader dr = cc.ExecuteReader();dr.Read();
           id=  dr["ID"].ToString();

                    DatabaseConnectionUtil.close();
                return id;
        }

        public static void bosalt(int a_id)
        {

            DatabaseConnectionUtil.open();

            SqlCommand cmd = new SqlCommand($"update adisyon set Durum='True' where ID={a_id} ", DatabaseConnectionUtil.connection);
            cmd.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
        }

    }
}
