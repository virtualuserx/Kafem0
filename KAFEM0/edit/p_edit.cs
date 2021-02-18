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
    public partial class p_edit : Form
    {
        int id;
        int gorevid;
        public p_edit(int id)
        {
            this.id=id;

            InitializeComponent();
        }

        private void P_edit_Load(object sender, EventArgs e)
        {
           

            DataTable personel = new PersonelDao().getpersonel(id);
            DataRowCollection collection1 = personel.Rows;
            foreach (DataRow row in collection1)
            {
                textBox6.Text = row["Ad"].ToString(); 
                textBox5.Text = row["Soyad"].ToString();
                maskedTextBox2.Text = row["KullaniciAdi"].ToString();
                maskedTextBox1.Text = row["Parola"].ToString();
                checkBox2.Checked = Convert.ToBoolean(row["Durum"]);
                this.gorevid = Convert.ToInt32(row["GorevID"]);

            }

            DataTable gorevler = new GorevDao().getpersonelgorev();
            DataRowCollection collection = gorevler.Rows;
            foreach (DataRow row in collection)
            {
                if (gorevid == Convert.ToInt32(row["ID"])) { comboBox1.Text = row["Gorev"].ToString(); }
                    comboBox1.Items.Add(row["Gorev"]);
            }

            comboBox1.Items.Add("++ Yeni Gorev Ekle");
            comboBox1.Items.Add("-- Yeni Gorev Sil");

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "++ Yeni Gorev Ekle")
            {
                this.Close();
                g_ekle gorevekle = new g_ekle();
                gorevekle.Show();
            }
            else if (comboBox1.SelectedItem.ToString() == "-- Yeni Gorev Sil")
            {
                
                g_sil gorevsil = new g_sil();
                gorevsil.Show();
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                if (comboBox1.Text != "" && textBox6.Text != "" && textBox5.Text != "" && maskedTextBox2.Text != ""&& maskedTextBox1.Text!="")
                {
                    PersonelDao.upatepersonel(comboBox1.Text, textBox6.Text, textBox5.Text, maskedTextBox2.Text, maskedTextBox1.Text, checkBox2.Checked, id);
                    this.Close();
                }
                else { MessageBox.Show("Kutular Bos olamaz "); }
            }
            catch { MessageBox.Show("Parola Yalnızca Rakamlardan olusabilir"); }


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Personeller p = new Personeller();
            p.Show();
        }
    }
}
