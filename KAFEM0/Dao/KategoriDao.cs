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
    class KategoriDao
    {

        public static DataTable getKategoriDataTable()
        {
            try
            {
                DatabaseConnectionUtil.open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from kategoriler", DatabaseConnectionUtil.connection);
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

        public static bool kategoriekle(string k_ad)
        {
            bool control=true;
            try
            {
               
       
                if (control == true)
                {
                    DatabaseConnectionUtil.open();

                    SqlCommand cmd = new SqlCommand($"insert into kategoriler (KategoriAdi) values ('{k_ad}')", DatabaseConnectionUtil.connection);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {


                        control = true;
                    }
                }
                else { MessageBox.Show("Aynı isme sahip 2 Kategori Olamaz"); control = false; }
                return control;
                

            }
            catch(Exception hata) {
                if(hata.Message.Contains("UNIQUE"))
                {
                    MessageBox.Show("Böyle bir kategori zaten var.");
                } else
                {
                    MessageBox.Show($"Kategori eklerken hata oluştu {hata.Message}");
                }

            }
            finally
            {
                DatabaseConnectionUtil.close();
                
            }

            return false;

        }


        public static void kategorisil(int id)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cc = new SqlCommand($"delete from urunler where KategoriID = {id} ; delete from kategoriler where ID = '{id}'", DatabaseConnectionUtil.connection);

            cc.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
            Kategoriler kg = new Kategoriler();
            kg.Show();
        }


        public DataTable kategorigetir(int id)
        {
            try
            {
                DatabaseConnectionUtil.open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select * from kategoriler where ID={id}", DatabaseConnectionUtil.connection);
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

        public static void  kategoriupdate(string ad,string aciklama,bool durum,int id)
        {
           
            try
            {
                DatabaseConnectionUtil.open();
             
                    SqlCommand cmd = new SqlCommand($"update kategoriler set KategoriAdi='{ad}',Aciklama='{aciklama}',Durum={Convert.ToByte(durum)} where ID={id}", DatabaseConnectionUtil.connection); cmd.ExecuteNonQuery(); 
            


               }
               catch (Exception hata)
              {
                throw new Exception($"Kategori tablosunda veri güncellerken hata oluştu {hata.Message}");
              }
               finally
               {
            DatabaseConnectionUtil.close();

                Kategoriler kategoriler = new Kategoriler();
                kategoriler.Show();
            }


        }

    }
}
