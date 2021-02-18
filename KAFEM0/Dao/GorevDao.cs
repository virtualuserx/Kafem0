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
    class GorevDao
    {
        public DataTable getpersonelgorev()
        {
            try
            {
                DatabaseConnectionUtil.open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from personel_gorev", DatabaseConnectionUtil.connection);
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

        public static void gorevekle(string gorevad)
        {
            DatabaseConnectionUtil.open();
            SqlCommand cmd = new SqlCommand($"insert into  personel_gorev (Gorev) values ('{gorevad}')", DatabaseConnectionUtil.connection);
                cmd.ExecuteNonQuery();

            DatabaseConnectionUtil.close();
            
            Personeller frm = new Personeller();
            frm.Show();
        }

        public static void gorevsil(string gorev)
        {
            try
            {
                DatabaseConnectionUtil.open();
                SqlCommand cmd = new SqlCommand($"delete from personeller where GorevID in (select id from personel_gorev where Gorev='{gorev}');delete from  personel_gorev where Gorev='{gorev}'", DatabaseConnectionUtil.connection);
                cmd.ExecuteNonQuery();

                DatabaseConnectionUtil.close();
            }
            catch
            {
                MessageBox.Show("Görev Silinemedi");
            }

        }

    }
}
