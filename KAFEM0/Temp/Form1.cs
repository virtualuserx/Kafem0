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

namespace KAFEM0.Temp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region fonksiyonlar
        SqlConnection bb = new SqlConnection("Data Source=DESKTOP-AQ1SDH2;Initial Catalog=kafe1;Integrated Security=True");
        public void o()
        {
            if (bb.State == ConnectionState.Closed) bb.Open();
        }
        public void c()
        {
            if (bb.State == ConnectionState.Open) bb.Close();
        }

        public void kategoriekle(string ke)
        {
            o();
            if (ke != "")
            {
                try
                {
                    SqlCommand komut = new SqlCommand($"insert into kategoriler(KategoriAdi) values ('{textBox1.Text}')", bb);
                    int sonkontrol = komut.ExecuteNonQuery();
                    //       if (sonkontrol > 0) { MessageBox.Show("kategori ekleme basarili"); }

                }
                catch (Exception hata) { MessageBox.Show("HATA"); }
            }
            else MessageBox.Show("Kutular bos bırakılamaz");
            c();
        }

        public void kategorigetir()
        {
            cbk.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            listBox1.Items.Clear();
            try
            {
                o();
                SqlCommand komut = new SqlCommand("select KategoriAdi from kategoriler", bb);
                /*reader1*/
                SqlDataReader reader1 = komut.ExecuteReader();
                /*reader2*/
                while (reader1.Read())
                {
                    listBox1.Items.Add(reader1["KategoriAdi"]);
                    comboBox1.Items.Add(reader1["KategoriAdi"]);
                    comboBox2.Items.Add(reader1["KategoriAdi"]);
                    comboBox5.Items.Add(reader1["KategoriAdi"]);
                    comboBox4.Items.Add(reader1["KategoriAdi"]);
                    cbk.Items.Add(reader1["KategoriAdi"]);

                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata");
            }

            c();

        }

        public void kategorisil(string ks)
        {
            int a;
            if (ks != "")
            {

                int b;
                string UserID;

                try
                {
                    o();
                    //     SqlCommand cc = new SqlCommand($"delete from urunler where KategoriID = (select ID from kategoriler where KategoriAdi='{comboBox4.Text}')", bb);
                    SqlCommand cc = new SqlCommand($"delete from urunler where KategoriID = (select ID from kategoriler where KategoriAdi='{ks}') ; delete from kategoriler where KategoriAdi = '{ks}'", bb);

                    cc.ExecuteNonQuery();
                    c();

                }
                catch (Exception hata) { MessageBox.Show("HATA"); }
            }
            else MessageBox.Show("Silmek istediğiniz Kategoriyi secmek zorundasiniz");
        }

        public void urunekle()
        {
            o();
            if (textBox2.Text != "" && comboBox1.SelectedItem != null)
            {
                try
                {
                    SqlCommand komut = new SqlCommand($"insert into urunler(KategoriID,UrunAd,Fiyat) values ( (select id from kategoriler where KategoriAdi='{comboBox1.Text}'),'{textBox2.Text}','{textBox3.Text}')", bb);
                    int sontest = komut.ExecuteNonQuery();
                    //     if (sontest > 0) { MessageBox.Show("urun ekleme islem basarili"); }


                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata");
                }
            }
            else MessageBox.Show("kutular bos bırakilamaz");

            c();

        }

        public void urungetir()
        {


            try
            {
                o();

 //*******//               this.urunlerTableAdapter.Fill(this.kafe1DataSet.urunler);

                SqlCommand komut = new SqlCommand("Select UrunAd from urunler", bb);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {


                }

                //       DataGridView();

                /*      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ID, KategoriID, UrunAd, Fiyat FROM urunler", bb);
                      DataSet set = new DataSet();
                      sqlDataAdapter.Fill(set, "Kategori");
                      dataGridView1.DataSource = set.Tables["Kategori"];
                      */
                //      dataGridView1.Update();
                //     dataGridView1.Refresh();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata");
            }
            c();
        }

        public void urungetira(params string[] KategoriAd)
        {

            cbu.Items.Clear();
            comboBox6.Items.Clear();


            if (KategoriAd != null)
            {
                try
                {
                    o();
                    foreach (string a in KategoriAd)
                    {
                        SqlCommand cc = new SqlCommand($"select UrunAd from urunler where KategoriID in (select id from kategoriler where KategoriAdi='{a}')", bb);
                        SqlDataReader dr = cc.ExecuteReader();
                        while (dr.Read())
                        {
                            cbu.Items.Add(dr["UrunAd"]);
                            comboBox6.Items.Add(dr["UrunAd"]);
                        }
                    }

                    c();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("HATA");
                }
            }
            else MessageBox.Show("Kategori seciniz1!!!!");
        }

        /*   public void urunsil(string kategori,string urun)
           {

               if (kategori != "" && urun != ""  )
               {
                   try
                   {
                       //
                       o();
                       MessageBox.Show(kategori);
                       SqlCommand cc = new SqlCommand($"select ID from kategoriler where KategoriAdi='{kategori}'", bb);
                       SqlDataReader dr = cc.ExecuteReader();
                       dr.Read();

                       int a =Convert.ToInt32( dr["ID"]);
                       cc.ExecuteNonQuery();
                       MessageBox.Show(a.ToString());

                      SqlCommand ccc = new SqlCommand($"delete from urunler where  UrunAd = '{urun}'", bb);
                       ccc.ExecuteNonQuery();

                       c();

                       cbu.Items.Clear();


                   }
                   catch (Exception hata)
                   {
                       MessageBox.Show("HATA");
                   }
               }
               else MessageBox.Show("Kategori seciniz1!!!!");
           }
           */

        public void urunsila(string urun)
        {
            if (urun != "")
            {
                try
                {
                    o();
                    SqlCommand uu = new SqlCommand($"delete from urunler where UrunAd='{urun}' ", bb);
                    uu.ExecuteNonQuery();


                    c();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("HATA");
                }
            }
            else MessageBox.Show("Lutfen urununuzu secinizzz");
        }


        public void fiyatdegistir(string k, string u, double f)
        {
            if (k != "" && u != "" && f != null)
            {
                try
                {
                    o();
                    SqlCommand cmd = new SqlCommand($"update urunler set Fiyat={f} where UrunAd='{u}'", bb);
                    cmd.ExecuteNonQuery();



                    c();

                }
                catch (Exception hata)
                {
                    MessageBox.Show("HAAT");
                }



            }
            else MessageBox.Show("kutuları doldur!!!");

        }

        public void kategoriisimdegistir(string eski, string yeni)
        {
            if (eski != "" && yeni != "")
            {
                try
                {
                    o();
                    SqlCommand cmd = new SqlCommand($"update kategoriler set KategoriAdi='{yeni}' where KategoriAdi='{eski}'", bb);
                    cmd.ExecuteNonQuery();



                    c();

                }
                catch (Exception hata) { }

            }
            else MessageBox.Show("kutuları doldur!!!");
        }

        /*     public void DataGridView()
             {
                 o();
                 SqlDataAdapter gr = new SqlDataAdapter("select * from urunler",bb);
                 DataSet ds = new DataSet();
                 gr.Fill(ds, "urunler");
                 dataGridView2.DataSource = ds;
                 dataGridView2.DataMember = "urunler";

                 c();
             }

         */
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {

            /*    this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                Rectangle cozunurluk = new Rectangle();
                cozunurluk = Screen.GetBounds(cozunurluk);
                float oranwidth = ((float)cozunurluk.Width / (float)width);
                float oranheight = ((float)cozunurluk.Height / (float)height);
                this.Scale(new SizeF(oranwidth, oranheight));
                */

            // TODO: This line of code loads data into the 'kafe1DataSet.urunler' table. You can move, or remove it, as needed.
 //*****//           this.urunlerTableAdapter.Fill(this.kafe1DataSet.urunler);

            //    DataGridView();


            urungetir();
            kategorigetir();
        }

        #region Buton vs,,
        private void Button1_Click(object sender, EventArgs e)
        {
            kategoriekle(textBox1.Text);
            textBox1.Clear();
            kategorigetir();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            urunekle();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedItem = null;
            urungetir();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.Items.Clear();
            listBox1.Items.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            kategorisil(comboBox4.Text);
            comboBox4.SelectedItem = null;
            kategorigetir();
            urungetir();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // urunsil();
            urungetir();
        }

        private void Cbk_SelectedIndexChanged(object sender, EventArgs e)
        {

            urungetira(cbk.Text);

        }



        private void Button6_Click(object sender, EventArgs e)
        {
            urunsila(cbu.Text);
            ////////////////////////////////////////////////////////////////
            cbu.SelectedItem = null;
            cbk.SelectedItem = null;

            urungetir();

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //   urungetira();
        }

        private void Button8_Click(object sender, EventArgs e)
        {

        /*    giris ac = new giris();

            ac.Show();
            //this.Hide();*/

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                fiyatdegistir(comboBox5.Text, comboBox6.Text, Convert.ToDouble(textBox4.Text));
            }
            catch (Exception hata) { MessageBox.Show("HATA"); }
            comboBox5.Text = "";
            comboBox6.Text = "";
            textBox4.Text = "";
            urungetir();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            urungetira(comboBox5.Text);
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {

            kategoriisimdegistir(comboBox2.Text, textBox5.Text);

            comboBox2.SelectedItem = null;
            textBox5.Text = "";

            kategorigetir();
        }

        private void Button12_Click(object sender, EventArgs e)
        {


     //       Personeller o = new Personeller();
       //     o.Show();
            this.Hide();
        }

        private void Button11_Click(object sender, EventArgs e)
        {


        }

        #endregion

        private void Button10_Click(object sender, EventArgs e)
        {

        }


    }
}
