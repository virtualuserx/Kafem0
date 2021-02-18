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
    public partial class Urunler : Form
    {
        int kategoriID = 0;
        public Urunler(int kategoriID)
        {
            this.kategoriID = kategoriID;
            InitializeComponent();
        }

        private void Urunler_Load(object sender, EventArgs e)
        {
  /*Çok Önemli*/ //     MessageBox.Show(kategoriID.ToString());


        //    Dao.DatabaseConnectionUtil.open();

            DataTable urunler = new UrunDao().geturunDataTable(kategoriID);
            DataRowCollection collection = urunler.Rows;
            foreach (DataRow row in collection)
            {
                Button button = new Button();
                button.Size = new Size(100, 100);
                button.Text = (row["UrunAd"].ToString() +"\n\n\nFiyat : " +row["Fiyat"].ToString()+"TL");
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




     //       Dao.DatabaseConnectionUtil.close(); 
        }




       private void guncelle_clicl(object sender, EventArgs e)
        {
            this.Close();
            int id = Convert.ToInt32((sender as ToolStripMenuItem).Name);
            
            u_edit urunupdate = new u_edit(kategoriID,id);

            urunupdate.Show();

        }
        
        private void sil_click(object sender, EventArgs e)
        {
            int id;
            DialogResult res = MessageBox.Show("Silmek istediğinize emin misiniz", "Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {

                id = Convert.ToInt32((sender as ToolStripMenuItem).Name);
                
                UrunDao.urunsil(id);
                this.Close();
                Urunler frm = new Urunler(kategoriID);
                frm.Show();


            }
            if (res == DialogResult.Cancel)
            {
            }
            
         
        }
        private void Button_Click(object sender, EventArgs e)
        {
       /*     int id = Convert.ToInt32((sender as Button).Name);
            Urunler urunler = new Urunler(id);
            urunler.Show();
            */
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            u_ekle urunekle_ac = new u_ekle(kategoriID);
            urunekle_ac.Show();

            //  this.Hide();
        }

        private void FlowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Kategoriler frm = new Kategoriler();
            frm.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Personeller frm = new Personeller();
            frm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            takip takip1 = new takip();
            takip1.Show();
        }
    }
}




        
