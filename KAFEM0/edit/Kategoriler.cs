using KAFEM0.Dao;
using KAFEM0.giris;
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
    public partial class Kategoriler : Form
    {
        public Kategoriler()
        {
            InitializeComponent();
        }

        public  void panel_dolur()
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable kategoriler =  KategoriDao.getKategoriDataTable();
            DataRowCollection collection = kategoriler.Rows;
            foreach (DataRow row in collection)
            {
                Button button = new Button();
                button.Size = new Size(140, 120);
                button.Text = row["KategoriAdi"].ToString().ToUpper();
                button.Name = row["ID"].ToString();
                if (Convert.ToByte(row["Durum"]) == 1) { button.BackColor = Color.DarkRed; button.ForeColor = Color.WhiteSmoke; }
                else button.BackColor = Color.Beige;
                button.Click += Button_Click;


                #region contextmennuuolusturma
                ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

                contextMenuStrip1.Name = row["ID"].ToString();
                contextMenuStrip1.Size = new Size(119, 70);

                ToolStripMenuItem sil = new ToolStripMenuItem();
                ToolStripMenuItem guncelle = new ToolStripMenuItem();
                ToolStripMenuItem bos = new ToolStripMenuItem();


                //   contextMenuStrip1 = ContextMenuStrip(components);

                contextMenuStrip1.SuspendLayout();
                this.SuspendLayout();

                contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sil, guncelle, bos });

                // 
                // bahattinToolStripMenuItem
                // 
                sil.Name = row["ID"].ToString();
                sil.Size = new Size(118, 22);
                sil.Text = "SİL";
                // 
                // aksoyToolStripMenuItem
                // 
                guncelle.Name = row["ID"].ToString();
                guncelle.Size = new Size(118, 22);
                guncelle.Text = "GÜNCELLE";
                // 
                // haydeeeToolStripMenuItem
                // 
                bos.Name = row["ID"].ToString();
                bos.Size = new Size(118, 22);
                bos.Text = "BOS";




                button.ContextMenuStrip = contextMenuStrip1;
                button.ContextMenuStrip.ResumeLayout();

                sil.Click += sil_click;
                guncelle.Click += guncelle_clicl;



                #endregion

                flowLayoutPanel1.Controls.Add(button);

            }
        }

        private void Kategoriler_Load(object sender, EventArgs e)
        {
            panel_dolur();
        }

        private void guncelle_clicl(object sender, EventArgs e)
        {
           int id = Convert.ToInt32((sender as ToolStripMenuItem).Name);
            this.Hide();
            k_edit kategoriupdate = new k_edit(id);
          
            kategoriupdate.Show();
        }

        private void sil_click(object sender, EventArgs e)
        {
            int id;
            DialogResult res = MessageBox.Show("Silmek istediğinize emin misiniz", "Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                
                id = Convert.ToInt32((sender as ToolStripMenuItem).Name);
                this.Hide();
                KategoriDao.kategorisil(id);
            }
            if (res == DialogResult.Cancel)
            {    
            }    
        }



        private void Button_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32((sender as Button).Name);
            this.Hide();
            Urunler urunler = new Urunler(id);
            urunler.Show();

        }
        

        private void Button1_Click(object sender, EventArgs e)
        {
            

            k_ekle kategoriekle_ac = new k_ekle();
            this.Hide();
            kategoriekle_ac.Show();

         //   panel_dolur();


        }

        private void sil(object sender, EventArgs e)
        {
          //  KategoriDao.kategorisil()
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            
        }

       
        private void Button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Personeller form1 = new Personeller();
            form1.Show();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
          
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            panel_dolur();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            takip takip1 = new takip();
            takip1.Show();
        }
    }
}
