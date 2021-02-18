using KAFEM0.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.edit
{
    public partial class k_edit : Form
    {
        int id;
        
        public k_edit(int id)
        {
            this.id = id;
            InitializeComponent();
        }
       


        private void K_edit_Load(object sender, EventArgs e)
        {
            DataTable kategoriler = new KategoriDao().kategorigetir(id);
            DataRowCollection collection = kategoriler.Rows;
            foreach (DataRow row in collection)
            {
                textBox1.Text = row["KategoriAdi"].ToString().ToUpper();
                textBox2.Text = row["Aciklama"].ToString();
                checkBox1.Checked = Convert.ToBoolean(row["Durum"]);
               
            }

            }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
       

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="") {
                KategoriDao.kategoriupdate(textBox1.Text, textBox2.Text, checkBox1.Checked, id);
                this.Close();
            } else {
                MessageBox.Show("isimsiz Kategori Olamaz");
            
                this.Close(); Kategoriler kategori = new Kategoriler();
                kategori.Show();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Kategoriler kategori = new Kategoriler();
            kategori.Show();
        }
    }
}
