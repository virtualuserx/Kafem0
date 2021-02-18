using KAFEM0.edit;
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
    class UrunDao
    {

        public DataTable geturunDataTable(int kategoriid)
        {
            try
            {
                DatabaseConnectionUtil.open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select * from urunler where KategoriID='{kategoriid}'", DatabaseConnectionUtil.connection);
                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);
                return table;
            }
            catch (Exception hata)
            {
                throw new Exception($"Urun tablosunda veri çekerken hata oluştu {hata.Message}");
            }
            finally
            {
                DatabaseConnectionUtil.close();
            }


        }


        public static void urunekle( int k_id,string u_ad,double fiyat)
        {
            try
            {
                DatabaseConnectionUtil.open();

                SqlCommand cmd = new SqlCommand($"insert into  urunler  (KategoriID,UrunAd,Fiyat) values ({k_id},'{u_ad}',{fiyat})", DatabaseConnectionUtil.connection);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {


                    MessageBox.Show("İşlem Başarılı");
                }



            }
            catch (Exception hata) { throw new Exception($"Kategori eklerken hata oluştu {hata.Message}"); }
            finally
            {
                DatabaseConnectionUtil.close();
               
            }

        }


        public static void urunsil(int id)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cc = new SqlCommand($"delete from urunler where ID = {id} ; ", DatabaseConnectionUtil.connection);

            cc.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
            
        }


        public DataTable urungetir(int id)
        {
            try
            {
                DatabaseConnectionUtil.open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select * from urunler where ID={id}", DatabaseConnectionUtil.connection);
                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);
                return table;
            }
            catch (Exception hata)
            {
                throw new Exception($"Kategori tablosunda veri çekerken hata oluştu {hata.Message}");
            }
            finally
            {
                DatabaseConnectionUtil.close();

            }


        }

           public static void urunupdate(string ad, string aciklama,double fiyat, bool durum, int id)
             {

                 try
                 {
                     DatabaseConnectionUtil.open();

                     SqlCommand cmd = new SqlCommand($"update urunler set urunAd='{ad}',Aciklama='{aciklama}',Fiyat={fiyat},Durum={Convert.ToByte(durum)} where ID={id}", DatabaseConnectionUtil.connection); cmd.ExecuteNonQuery();
               


            }
                 catch (Exception hata)
                 {
                     throw new Exception($"Kategori tablosunda veri güncellerken hata oluştu {hata.Message}");
                 }
                 finally
                 {
                     DatabaseConnectionUtil.close();
                

            }


             }
             

    }
}
