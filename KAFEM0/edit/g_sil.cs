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
    public partial class g_sil : Form
    {
        public g_sil()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            

         DataTable   personeller = new PersonelDao().p_table(comboBox1.Text);
            DataRowCollection collection = personeller.Rows;
       
            StringBuilder b = new StringBuilder();
            foreach (DataRow row in collection)
            {
            
               b.Append("\n*" + row["Ad"].ToString());
            }






     ///////*****************************       // = string.Join("\n*", array);
            
            
               DialogResult res = MessageBox.Show("Silmek istediğinize emin misiniz Alttaki Kişilerde Silinecektir\n" + b, "Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
               if (res == DialogResult.OK)
               {

                   GorevDao.gorevsil(comboBox1.Text);
               }
               if (res == DialogResult.Cancel)
               {
               }
              
            this.Close();
            Personeller frm = new Personeller();
            frm.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void G_sil_Load(object sender, EventArgs e)
        {
            DataTable gorevler = new GorevDao().getpersonelgorev();
            DataRowCollection collection = gorevler.Rows;
            foreach (DataRow row in collection)
            {
                comboBox1.Items.Add(row["Gorev"]);
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
