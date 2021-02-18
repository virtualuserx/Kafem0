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
    public partial class p_ekle : Form
    {
        public p_ekle()
        {
            InitializeComponent();
        }

        private void P_ekle_Load(object sender, EventArgs e)
        {

            DataTable gorevler = new GorevDao().getpersonelgorev();
            DataRowCollection collection = gorevler.Rows;
            foreach (DataRow row in collection)
            {
                comboBox1.Items.Add(row["Gorev"]);
            }

                comboBox1.Items.Add("++ Yeni Gorev Ekle");
                 comboBox1.Items.Add("-- Yeni Gorev Sil");

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
         ////////////////////////////////////////////////////
         ///if (checkBox1.Checked) checkBox1.Font = new Font(FontStyle.Bold); 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && TextBox3.Text != "")
                {
                    PersonelDao.personelekle(comboBox1.Text, textBox1.Text, textBox2.Text, TextBox3.Text, Convert.ToInt32(TextBox4.Text), checkBox1.Checked);
                    this.Close();
                }
                else { MessageBox.Show("Kutular Bos olamaz "); }
            }
            catch { MessageBox.Show("Parola Yalnızca Rakamlardan olusabilir"); }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="++ Yeni Gorev Ekle")
            {
                this.Close();
                g_ekle gorevekle = new g_ekle();
                gorevekle.Show();
            }
            else if(comboBox1.SelectedItem.ToString() == "-- Yeni Gorev Sil")
            {
                g_sil gorevsil= new g_sil();
                gorevsil.Show();
            }
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Personeller p = new Personeller();
            p.Show();
        }
    }
}
