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
    public partial class u_edit : Form
    {
        int id;
        int k_id;
        public u_edit(int k_id,int id)
        {
            this.k_id = k_id;
            this.id = id;
            InitializeComponent();
        }

        private void U_edit_Load(object sender, EventArgs e)
        {

            DataTable urunler = new UrunDao().urungetir(id);
            DataRowCollection collection = urunler.Rows;
            foreach (DataRow row in collection)
            {
                textBox1.Text = row["UrunAd"].ToString().ToUpper();
                textBox2.Text = row["Aciklama"].ToString();
                textBox3.Text = row["Fiyat"].ToString();
                checkBox1.Checked = Convert.ToBoolean(row["Durum"]);

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "")
            {
                try
                {
                    UrunDao.urunupdate(textBox1.Text, textBox2.Text,Convert.ToDouble( textBox3.Text), checkBox1.Checked, id);
                    this.Close();
                    Urunler frm = new Urunler(k_id);
                    frm.Show();

                }
                catch { MessageBox.Show("Fiyat Yalnızca Rakamlardan Olusabilir"); }
            }
            else
            {
                MessageBox.Show("KutulR bOS oLAMAZ");
               
            }
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Urunler urunler = new Urunler(k_id);
            urunler.Show();
        }
    }
}
