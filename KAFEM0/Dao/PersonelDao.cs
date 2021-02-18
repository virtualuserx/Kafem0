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
    class PersonelDao
    {

        public static string getpersonelname(int id)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"select * from personeller where ID={id}", DatabaseConnectionUtil.connection);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
           string name = dr["Ad"].ToString()+"   "+dr["Soyad"]; 
            DatabaseConnectionUtil.close();
            return name;
        }
        //İSME GÖRE PERSONEL DATABASE
        public DataTable p_table(string gorevad)
        {


            DatabaseConnectionUtil.open();
            SqlDataAdapter da = new SqlDataAdapter($"select * from personeller where GorevID=(select id from personel_gorev where Gorev='{gorevad}')", DatabaseConnectionUtil.connection);
            DataTable table = new DataTable();
            da.Fill(table);
            DatabaseConnectionUtil.close();
            return table;
            
        }

        //İD'YE GÖRE PERSONEL DATABASE
        public DataTable getpersonel(int id)
        {
            DataTable table = new DataTable();
            DatabaseConnectionUtil.open();
            SqlDataAdapter da = new SqlDataAdapter($"select * from personeller where ID={id}", DatabaseConnectionUtil.connection);
            da.Fill(table);
            DatabaseConnectionUtil.close();
            return table;
        }

        //TÜM PERSONEL DATABASE
        public  DataTable getallpersonel()
        {
            DataTable table = new DataTable();
            DatabaseConnectionUtil.open();
            SqlDataAdapter da = new SqlDataAdapter("select * from personeller", DatabaseConnectionUtil.connection);
            da.Fill(table);
            DatabaseConnectionUtil.close();
            return table;
        }

        public static void personelekle(string gorevi,string ad,string soyad,string kadi,int parola,bool durum)
        {

            try { 

                  bool control=true;
        //    int a = 0;
         
                DataTable table = new PersonelDao().getallpersonel();
                DataRowCollection collection = table.Rows;
                foreach (DataRow row in collection)
                {
                    if (kadi.ToUpper().Trim() == row["KullaniciAdi"].ToString().ToUpper().Trim())  control= false;

                }

                if (control)
                {
                    DatabaseConnectionUtil.open();
                    SqlCommand cmd = new SqlCommand($"insert into personeller (GorevID,Ad,Soyad,KullaniciAdi,Parola,Durum) values ((select ID from personel_gorev where Gorev = '{gorevi}'),'{ad}','{soyad}','{kadi}',{parola},{Convert.ToByte(durum)})", DatabaseConnectionUtil.connection);
                    cmd.ExecuteNonQuery();
                    DatabaseConnectionUtil.close();
                }
                else { MessageBox.Show("Aynı Kullanıcı Adı 1'den Fazla kişiye verilemez"); }
                Personeller frm = new Personeller();
                frm.Show();
            }catch(Exception hata) { MessageBox.Show("personel ekle HATA!!");  }
        }

        public static void upatepersonel(string gorevi, string ad, string soyad, string kadi, string parola, bool durum,int id)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"update personeller set GorevID=(select ID from personel_gorev where Gorev = '{gorevi}'),Ad='{ad}',Soyad='{soyad}',KullaniciAdi='{kadi}',Parola={Convert.ToInt32(parola)},Durum={Convert.ToByte(durum)} where ID={id}", DatabaseConnectionUtil.connection);
            cmd.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
            Personeller frm = new Personeller();
            frm.Show();
        }


        public static void personelsil(int id)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"delete from personeller where ID={id}", DatabaseConnectionUtil.connection);
            cmd.ExecuteNonQuery();
            DatabaseConnectionUtil.close();
            Personeller frm = new Personeller();
            frm.Show();

        }

        public DataTable getpersonelpassword(string ad)
        {
            DataTable table = new DataTable();
            DatabaseConnectionUtil.open();
            SqlDataAdapter da = new SqlDataAdapter($"select * from personeller where KullaniciAdi='{ad}'", DatabaseConnectionUtil.connection);
            da.Fill(table);
            DatabaseConnectionUtil.close();
            return table;
        }

        public static bool controllboss(int id)
        {
            bool control = false;
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"select Gorev from personel_gorev where ID=(select GorevID from personeller where ID={id})", DatabaseConnectionUtil.connection);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr["Gorev"].ToString() == "Patron")
            {
                control = true;
            }

            DatabaseConnectionUtil.close();
            return control;
        }
    }
}
