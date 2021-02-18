using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAFEM0.Dao
{
    public static class Hesap_Odemeleri
    {
        public static void hesapode(int a_id,double para,int odeme_turu)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"insert into hesap_odemeleri(AdisyonID,ToplamTutar,OdemeTuruID,Durum) values ({a_id},{para},{odeme_turu},'True') ", DatabaseConnectionUtil.connection);
            cmd.ExecuteNonQuery();

           
            DatabaseConnectionUtil.close();


        }

        public static double n_hesapla()
        {
            double nakit=0;
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"select ToplamTutar from  hesap_odemeleri  where Durum='True' and OdemeTuruID=2", DatabaseConnectionUtil.connection);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nakit += Convert.ToDouble(dr["ToplamTutar"]);

            }


            DatabaseConnectionUtil.close();
            return nakit;


        }
        public static double k_hesapla()
        {
            double nakit = 0;
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"select ToplamTutar from  hesap_odemeleri  where Durum='True' and OdemeTuruID=1", DatabaseConnectionUtil.connection);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nakit += Convert.ToDouble(dr["ToplamTutar"]);

            }


            DatabaseConnectionUtil.close();
            return nakit;


        }


    }
}
