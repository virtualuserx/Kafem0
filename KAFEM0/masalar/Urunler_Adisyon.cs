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
    public partial class Urunler_Adisyon : Form
    {
        int m_id;
        int p_id;
        int a_id;
        double toplam;
        public Urunler_Adisyon(int m_id,int p_id)
        {
            this.m_id = m_id;
            this.p_id = p_id;
            InitializeComponent();
        }

        public void panel_dolur()
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable kategoriler = KategoriDao.getKategoriDataTable();
            DataRowCollection collection = kategoriler.Rows;
            foreach (DataRow row in collection)
            {
                if (Convert.ToByte(row["Durum"]) == 0)
                {
                    Button button = new Button();
                    button.Size = new Size(140, 120);
                    button.Text = row["KategoriAdi"].ToString().ToUpper();
                    button.Name = row["ID"].ToString();

                    button.BackColor = Color.Beige;
                    button.Click += Button_Click;








                    flowLayoutPanel1.Controls.Add(button);
                }

            }
        }

        public void panel_doldur_urunler(int kategoriID)
        {
            flowLayoutPanel1.Controls.Clear();
            Button buton1 = new Button();
            buton1.Name = "Geri";
            buton1.Text = "geri";
            buton1.Size = new Size(100, 100);
            buton1.BackColor = Color.YellowGreen;
            buton1.Click += Button1_Click;
            flowLayoutPanel1.Controls.Add(buton1);

            DataTable urunler = new UrunDao().geturunDataTable(kategoriID);
            DataRowCollection collection = urunler.Rows;
            foreach (DataRow row in collection)
            {
                Button buttonu = new Button();
                buttonu.Size = new Size(100, 100);
                buttonu.Text = (row["UrunAd"].ToString() + "\n\n\nFiyat : " + row["Fiyat"].ToString() + "TL");
                buttonu.Name = row["ID"].ToString();
                if (Convert.ToByte(row["Durum"]) == 1) { buttonu.BackColor = Color.DarkRed; buttonu.ForeColor = Color.WhiteSmoke; }
                else buttonu.BackColor = Color.Beige;
                buttonu.Click += Buttonuu_Click;


            





                flowLayoutPanel1.Controls.Add(buttonu);
            }
        }
        int sayac = 0;
        private void Buttonuu_Click(object sender, EventArgs e)
        {
            

            string id = (sender as Button).Name.ToString();
            int sayac = listView1.Items.Count;
            string urunbilgi= (sender as Button).Text.ToString();
            string[] urunu = urunbilgi.Split('\n');
            char[] sil = { 'F', 'i', 'y', 'a', 't', ':', 'T', 'L', ' ' };
            double uf = Convert.ToDouble(urunu[3].Trim(sil));
            double miktar = Convert.ToDouble(textBox1.Text.Replace(',','.'));
            bool control = true;
            int uid=0;
            for (int i = 0; i < sayac; i++)
            {
               //////////////////////// listView1.Items.Find(urunu[0], true);
               if (listView1.Items[i].SubItems[3].Text.IndexOf(id)>-1) {
                    uid = i;
                    control = false;
                   
                }

               

            }

           

            if (control == true)
            {
                listView1.Items.Add(urunu[0]);

                listView1.Items[sayac].SubItems.Add("x" + (miktar).ToString());
               
                listView1.Items[sayac].SubItems.Add((uf * miktar).ToString());
                listView1.Items[sayac].SubItems.Add(id);

                Satislar.satislarr(Convert.ToInt32(label17.Text), m_id, p_id, Convert.ToInt32(id), Convert.ToDouble(miktar));
            }
                else
                {
                string yeni_miktar =(Convert.ToDouble(listView1.Items[uid].SubItems[1].Text.Trim('x')) + Convert.ToDouble(textBox1.Text.Replace(',', '.'))).ToString();
                listView1.Items[uid].SubItems[1].Text = yeni_miktar;
                   int a_id1 = Convert.ToInt32(label17.Text);
                 double y_miktar =Convert.ToDouble(yeni_miktar);
                    Satislar.update(a_id1,y_miktar,Convert.ToInt32(id)) ;
                  
                  
    

                }

            satislar_doldur();
            textBox1.Text = "1";

        }

        public void hesapla()
        {
           double toplam = 0;

            for(int i=0;i< listView1.Items.Count; i++)
            {
               
                toplam += Convert.ToDouble(listView1.Items[i].SubItems[2].Text.Trim('x'));
            }

            label15.Text = toplam.ToString();
            this.toplam = toplam;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            panel_dolur();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Button).Name);
            panel_doldur_urunler(id);
        }

        private void Urunler_Adisyon_Load(object sender, EventArgs e)
        {
            if (PersonelDao.controllboss(p_id)) { button3.Visible = true; }
            textBox1.Text = "1";
            label17.Text = AdisyonDao.bul(m_id);
            a_id = Convert.ToInt32(label17.Text);
            // TODO: This line of code loads data into the 'kafe1DataSet.adisyon' table. You can move, or remove it, as needed.
            label2.Text = AdisyonDao.getpersonelname(a_id);
     //////      // this.adisyonTableAdapter.Fill(this.RestorantDataSet.adisyon);
            panel_dolur();
            button6.Text = "\tS\n\tx1";
            button7.Text = "\tM\n\tx1.5";
            button8.Text = "\tL\n\tx2";

            satislar_doldur();
            hesapla();
            
        }

        public void satislar_doldur()
        {
            listView1.Items.Clear();
            DatabaseConnectionUtil.open();
            DataTable tb = new DataTable();
            SqlDataAdapter ap = new SqlDataAdapter($"select * from satislar where AdisyonID={Convert.ToInt32(label17.Text)}", DatabaseConnectionUtil.connection);

            ap.Fill(tb);
            DatabaseConnectionUtil.close();

            DataRowCollection collection = tb.Rows;
            int a = 0;
            foreach(DataRow row in collection)
            {
                DatabaseConnectionUtil.open();
                DataTable tb1 = new DataTable();
                SqlDataAdapter ap1 = new SqlDataAdapter($"select * from urunler where ID={Convert.ToInt32(row["UrunID"])}", DatabaseConnectionUtil.connection);

                ap1.Fill(tb1);
                DatabaseConnectionUtil.close();

                DataRowCollection collection1 = tb1.Rows;
               
                foreach (DataRow row1 in collection1)
                {
                    listView1.Items.Add(row1["UrunAd"].ToString());
                    listView1.Items[a].SubItems.Add(row["Adet"].ToString());
                    listView1.Items[a].SubItems.Add((Convert.ToDouble(row1["Fiyat"])*Convert.ToDouble(row["Adet"])).ToString());
                    listView1.Items[a].SubItems.Add(row1["ID"].ToString());
                }
                
               
               
                a++;

            }


            hesapla();

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Masalar masalar = new Masalar(p_id);
            masalar.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
             this.Close();
           
                pay pay = new pay(a_id, toplam, p_id, m_id);
                pay.Show();
            
          
            
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "1";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "1.5";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "2";
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0.5";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0.75";
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "2";
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "3";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "4";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "5";
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
