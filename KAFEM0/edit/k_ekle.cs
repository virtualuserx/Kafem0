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
    public partial class k_ekle : Form
    {
        public k_ekle()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text != "")
            {

             if(KategoriDao.kategoriekle(textBox1.Text.Trim().ToUpper()))
                {
                  

                }
                this.Close();
             
            }
            else
            {
                MessageBox.Show("İsim Kısmı Bos Olamaz");
                this.Close();
     
            }

            Kategoriler kategoriler = new Kategoriler();
            kategoriler.Show();
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void K_ekle_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Kategoriler kategoriler = new Kategoriler();
            kategoriler.Show();
        }
    }
}
