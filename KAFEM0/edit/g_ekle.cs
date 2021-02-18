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
    public partial class g_ekle : Form
    {
        public g_ekle()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    GorevDao.gorevekle(textBox1.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Görev İsmi Bos Olamaz");
                    this.Close(); Personeller p = new Personeller(); p.Show();
                }
            }
            catch { MessageBox.Show("HATA - Gorev Ekle"); }

        }

        private void G_ekle_Load(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Personeller p = new Personeller();
            p.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
