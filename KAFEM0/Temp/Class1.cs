
/*TextBox txt = new TextBox();
txt.Name = "TextBoxControl";
            DialogResult res = MessageBox.Show("Silmek istediğinize emin misiniz", "Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Tamam düğmesini tıkladınız");
                // Bazı görevler…  
            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("İptal Düğmesine Tıkladınız");
                // Bazı görevler…  
            }
*/









/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAFEM0.Temp
   { 
    class Class1
    {

        public static string con = "Data Source=DESKTOP-AQ1SDH2;Initial Catalog=kafe1;Integrated Security=True";
        SqlConnection cgr = new SqlConnection(con);
        public void aa()
        {
            SqlConnection cgr = new SqlConnection(con);
        }
        public void o()
        {
            if (cgr.State == ConnectionState.Closed) cgr.Open();
        }
        public void c()
        {
            if (cgr.State == ConnectionState.Open) cgr.Close();
        }
        public int _personelID;

    }


    class cpersoneller
    {
        //  Form1 form1 = new Form1();
        cgiris cgr = new cgiris();
        SqlConnection sql_personeller = new SqlConnection("Data Source = DESKTOP-AQ1SDH2; Initial Catalog = kafe1; Integrated Security = true");



        #region Private degiskenler
        private int _PersonelID;
        private int _GorevID;
        private string _Ad;
        private string _Soyad;
        private int _Parola;
        private string _KullaniciAdi;
        private bool _Durum;
        #endregion



        #region Personeller get-set
        public int PersonelID { get => _PersonelID; set => _PersonelID = value; }
        public int GorevID { get => _GorevID; set => _GorevID = value; }
        public string Ad { get => _Ad; set => _Ad = value; }
        public string Soyad { get => _Soyad; set => _Soyad = value; }
        public int Parola { get => _Parola; set => _Parola = value; }
        public string KullaniciAdi { get => _KullaniciAdi; set => _KullaniciAdi = value; }
        public bool Durum { get => _Durum; set => _Durum = value; }
        #endregion



        #region FONKSİYONLAR

        public bool Personelentrycontrol(int userid, int password)
        {
            bool result = false;

            try
            {
                cgr.o();
                SqlCommand cmd_personeller = new SqlCommand("select * from personeller where ID=@Id and Parola=@password", sql_personeller);
                cmd_personeller.Parameters.Add("@Id", SqlDbType.Int);
                cmd_personeller.Parameters["@Id"].Value = userid;
                cmd_personeller.Parameters.Add("@password", SqlDbType.Int);
                cmd_personeller.Parameters["@password"].Value = password;
                result = Convert.ToBoolean(cmd_personeller.ExecuteScalar());
                cgr.c();


            }
            catch (Exception hata)
            {
                string HATA = hata.Message;
            }

            return result;



        }


        public void personelgetir(ComboBox kullaniciadi)
        {
            try
            {
                cgr.o();
                SqlCommand c_pgetir = new SqlCommand("select*from personeller", sql_personeller);
                SqlDataReader dr = c_pgetir.ExecuteReader();
                while (dr.Read())
                {

                    cpersoneller cp = new cpersoneller();
                    cp._PersonelID = Convert.ToInt32(dr["ID"]);
                    cp._GorevID = Convert.ToInt32(dr["GOREVID"]);
                    cp._Ad = Convert.ToString(dr["Ad"]);
                    cp._Soyad = Convert.ToString(dr["Soyad"]);
                    cp._Parola = Convert.ToInt32(dr["Parola"]);
                    cp._KullaniciAdi = Convert.ToString(dr["KullaniciAdi"]);

                }


                cgr.c();
            }
            catch (Exception hata)
            {
                string HATA = hata.Message;
            }


        }
        #endregion


    }



}
*/