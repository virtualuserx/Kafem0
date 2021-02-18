using KAFEM0.Dao;
using KAFEM0.masalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.giris
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
           


            PersonelDao personeller_isim = new PersonelDao();
            DataTable personelisimleri = personeller_isim.getallpersonel();
            DataRowCollection collection = personelisimleri.Rows;
            foreach(DataRow row in collection)
            {
                if (Convert.ToSByte(row["Durum"]) == 0)
                {
                    comboBoxKullaniciAdi.Items.Add(row["KullaniciAdi"]);
                }

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PersonelDao personeller_isim = new PersonelDao();
            DataTable personelisimleri = personeller_isim.getpersonelpassword(comboBoxKullaniciAdi.Text);
            DataRowCollection collection = personelisimleri.Rows;
            bool i = false;
            foreach (DataRow row in collection)
            {
                if (row["Parola"].ToString() == textParola.Text.Trim())
                {
                    i = true;
                    Masalar masalar = new Masalar(Convert.ToInt32(row["ID"]));
                    masalar.Show();

                }
               
            }
            if (i == false)
            {
                MessageBox.Show("Parola Yanliş");
            }

            comboBoxKullaniciAdi.Text = "";
            textParola.Text = "";

        }

        private void TextParola_TextChanged(object sender, EventArgs e)
        {

        }

  
    }
}
