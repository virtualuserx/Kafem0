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
    public partial class Personeller : Form
    {
        public Personeller()
        {
            InitializeComponent();
        }

        private void Personeller_Load(object sender, EventArgs e)
        {
            
           
          DataTable  table = new PersonelDao().getallpersonel();
            DataRowCollection collection = table.Rows;
            foreach(DataRow row in collection)
            {
                Button p_buton = new Button();
                p_buton.Name = row["ID"].ToString();
                p_buton.Text = (row["Ad"].ToString()+"\n\n"+row["Soyad"]).ToUpper();
                p_buton.Size = new Size(100, 100);
                if (Convert.ToBoolean(row["Durum"]))
                {

                    p_buton.BackColor = Color.DarkRed; p_buton.ForeColor = Color.WhiteSmoke;
                }
                else p_buton.BackColor = Color.Beige;
                 p_buton.Click += P_buton_Click;


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




                p_buton.ContextMenuStrip = contextMenuStrip1;
                p_buton.ContextMenuStrip.ResumeLayout();

                sil.Click += sil_click;
                guncelle.Click += guncelle_clicl;



                #endregion





                flowLayoutPanel1.Controls.Add(p_buton);

            }

        }

        private void guncelle_clicl(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as ToolStripMenuItem).Name);
            p_edit personelupdate = new p_edit(id);
            this.Close();
            personelupdate.Show();
        }

        private void sil_click(object sender, EventArgs e)
        {
            int id;
            DialogResult res = MessageBox.Show("Silmek istediğinize emin misiniz", "Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {

                id = Convert.ToInt32((sender as ToolStripMenuItem).Name);
                this.Close();
                PersonelDao.personelsil(id);
            }
            if (res == DialogResult.Cancel)
            {
            }

        }

        private void P_buton_Click(object sender, EventArgs e)
        {

            //// takibi buraya yapabiliriz /////

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            p_ekle personelekle = new p_ekle();
            this.Close();
            personelekle.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Kategoriler frm = new Kategoriler();
            frm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            takip takip1 = new takip();
            takip1.Show();
        }
    }
}
