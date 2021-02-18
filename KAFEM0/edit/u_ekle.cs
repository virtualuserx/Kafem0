using KAFEM0.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.edit
{
   
    public partial class u_ekle : Form
    {
        int kategoriid=0;

        public u_ekle(int kategoriid)
        {
            this.kategoriid = kategoriid;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                   
                    UrunDao.urunekle(kategoriid, textBox1.Text.Trim().ToUpper(), Convert.ToDouble(textBox2.Text.Replace(',','.')));
                    this.Close(); //Urunler urunler = new Urunler(kategoriid); urunler.Show();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else MessageBox.Show("İsim ve Fiyat Kısmı Bos Olamaz"); {
                this.Close(); //Urunler urunler = new Urunler(kategoriid); urunler.Show();
        }

            Urunler frm = new Urunler(kategoriid);
            frm.Show();

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void U_ekle_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Urunler frm = new Urunler(kategoriid);
            frm.Show();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
