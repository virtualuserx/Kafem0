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
    public partial class takip : Form
    {
        public takip()
        {
            InitializeComponent();
        }

        private void Takip_Load(object sender, EventArgs e)
        {
            nakit_hesapla();
            kredi_hesapla();
            p_takip();
            u_takip();
            p_bul();
            u_bul();
        }

        public void p_bul()
        {
            double m = 0;
            int idx = 0;
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if(m< Convert.ToDouble(listView1.Items[i].SubItems[1].Text))
                {
                    m = Convert.ToDouble(listView1.Items[i].SubItems[1].Text);
                    idx = i;
                }
                

            }

            label7.Text = listView1.Items[idx].SubItems[0].Text;
        }

        public void u_bul()
        {
            double m = 0;
            int idx = 0;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (m < Convert.ToDouble(listView2.Items[i].SubItems[1].Text))
                {
                    m = Convert.ToDouble(listView2.Items[i].SubItems[1].Text);
                    idx = i;
                }


            }

            label8.Text = listView2.Items[idx].SubItems[0].Text;
        }

        public void nakit_hesapla()
        {

            label3.Text=Hesap_Odemeleri.n_hesapla().ToString();

        }
        public void kredi_hesapla()
        {

            label4.Text = Hesap_Odemeleri.k_hesapla().ToString();

        }
        public void p_takip()
        {
            
            listView1.Items.Clear();
            int satırlar = 0;

            DatabaseConnectionUtil.open();
            DataTable pt = new DataTable();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from Personeller", DatabaseConnectionUtil.connection);
            cmd.Fill(pt);

            DatabaseConnectionUtil.close();


            DataRowCollection collection_p = pt.Rows;
            foreach (DataRow rows1 in collection_p)
            {
                double para = 0;


                DatabaseConnectionUtil.open();
                listView1.Items.Add(rows1["Ad"].ToString() + "   " + rows1["Soyad"].ToString());
                DataTable at = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter($"select ID from adisyon where PersonelID={Convert.ToInt32(rows1["ID"])} and Durum='True'", DatabaseConnectionUtil.connection);
                cmd1.Fill(at);
                DatabaseConnectionUtil.close();
                DataRowCollection collection_a = at.Rows;
                foreach (DataRow rows2 in collection_a)
                {

                    DatabaseConnectionUtil.open();
                    DataTable mt = new DataTable();
                    SqlDataAdapter cmd2 = new SqlDataAdapter($"select ToplamTutar from hesap_odemeleri where AdisyonID=({Convert.ToInt32(rows2["ID"])})", DatabaseConnectionUtil.connection);
                    cmd2.Fill(mt);

                    DatabaseConnectionUtil.close();
                    DataRowCollection collection_m = mt.Rows;
                    foreach (DataRow rows3 in collection_m)
                    {
                        para += Convert.ToDouble(rows3["ToplamTutar"]);
                    }


                }
                listView1.Items[satırlar].SubItems.Add(para.ToString());
                satırlar++;
            }


            listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;



        }

        public void u_takip()
        {

            listView2.Items.Clear();
            int satırlar = 0;

            DatabaseConnectionUtil.open();
            DataTable pt = new DataTable();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from urunler", DatabaseConnectionUtil.connection);
            cmd.Fill(pt);

            DatabaseConnectionUtil.close();


            DataRowCollection collection_p = pt.Rows;
            foreach (DataRow rows1 in collection_p)
            {
                double miktar = 0;


                DatabaseConnectionUtil.open();
                listView2.Items.Add(rows1["UrunAd"].ToString() );
                DataTable at = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter($"select ID from adisyon where  Durum='True'", DatabaseConnectionUtil.connection);
                cmd1.Fill(at);
                DatabaseConnectionUtil.close();
                DataRowCollection collection_a = at.Rows;
                foreach (DataRow rows2 in collection_a)
                {

                    DatabaseConnectionUtil.open();
                    DataTable mt = new DataTable();
                    SqlDataAdapter cmd2 = new SqlDataAdapter($"select Adet from satislar where AdisyonID={Convert.ToInt32(rows2["ID"])} and UrunID={Convert.ToInt32(rows1["ID"])}", DatabaseConnectionUtil.connection);
                    cmd2.Fill(mt);

                    DatabaseConnectionUtil.close();
                    DataRowCollection collection_m = mt.Rows;
                    foreach (DataRow rows3 in collection_m)
                    {
                        miktar += Convert.ToDouble(rows3["Adet"]);
                    }


                }
                listView2.Items[satırlar].SubItems.Add(miktar.ToString());
                satırlar++;
            }


            listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;



        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Kategoriler kategoriler = new Kategoriler();
            kategoriler.Show();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
