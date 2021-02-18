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

namespace KAFEM0.masalar
{
    public partial class Masalar : Form
    {
        int p_id;
        public Masalar(int id)
        {
            p_id = id;
            InitializeComponent();
        }

        private void Masalar_Load(object sender, EventArgs e)
        {
          

            label3.Text = PersonelDao.getpersonelname(p_id).ToString();
            if (PersonelDao.controllboss(p_id))
            {
                button6.Visible = true;
            }
            label2.Text = MasalarDao.control();
            DataTable masalar = new MasalarDao().masagetir();
            DataRowCollection rows = masalar.Rows;
            int i = 1;
            foreach (DataRow masa in rows)
            {
                Button buton = new Button();
                buton.Name = masa["ID"].ToString();
                buton.Text = i.ToString();
                buton.Size = new Size(200, 200);
                if (Convert.ToByte(masa["Durum"]) == 1)
                {
                    buton.BackColor = Color.Blue;
                }
                buton.Click += buton_Click;
                flowLayoutPanel1.Controls.Add(buton);
                i++;
            }

            
        }

        private void buton_Click(object sender, EventArgs e)
        {
            int m_id = Convert.ToInt32((sender as Button).Name);

            if (MasalarDao.controldurum(m_id) == false)
             {
                MasalarDao.doldur(m_id);
                AdisyonDao.olustur(m_id,p_id);
                this.Hide();
                Urunler_Adisyon urunler_Adisyon = new Urunler_Adisyon(m_id, p_id);
                urunler_Adisyon.Show();
            }
            else
            {
               // MessageBox.Show("Dolu masa!!!");
               
                if ((sender as Button).BackColor.ToString()=="Color [Blue]")
                {
                   if( AdisyonDao.control(m_id, p_id) || PersonelDao.controllboss(p_id))
                    {
                        this.Hide();
                        Urunler_Adisyon urunler_Adisyon = new Urunler_Adisyon(m_id, p_id);
                        urunler_Adisyon.Show();
                    }
                   

                }
                

               



            }
        }

      

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            edit.Kategoriler kategoriler = new edit.Kategoriler();
            kategoriler.Show();
        }
    }
}
