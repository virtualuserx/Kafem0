using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.Dao
{
    class Satislar
    {

        public static void satislarr(int adisyonID,int masaID,int personelID,int urunID,double adet)
        {
           
            DatabaseConnectionUtil.open();

            SqlCommand cmd = new SqlCommand($"insert into satislar (AdisyonID,UrunID,MasaID,Adet) values ({adisyonID},{urunID},{masaID},{adet})", DatabaseConnectionUtil.connection);

            cmd.ExecuteNonQuery();



            DatabaseConnectionUtil.close();


        }

        public static void update(int adisyonID, double adet,int u_id)
        {

            DatabaseConnectionUtil.open();

            SqlCommand cmd = new SqlCommand($"update satislar set Adet={adet}  where AdisyonID={adisyonID} and UrunID={u_id} and Durum='False'", DatabaseConnectionUtil.connection);

            cmd.ExecuteNonQuery();



            DatabaseConnectionUtil.close();


        }

        public static void bosalt(int a_id)
        {

            DatabaseConnectionUtil.open();

            SqlCommand cmd = new SqlCommand($"update satislar set Durum='True' where AdisyonID={a_id} ", DatabaseConnectionUtil.connection);
            cmd.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
        }


    }
}
