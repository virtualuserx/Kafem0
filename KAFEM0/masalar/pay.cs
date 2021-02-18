using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.masalar
{
    public partial class pay : Form
    {
        int a_id;
        double para;
        int p_id;
        int m_id;
        public pay(int a_id,double para,int p_id,int m_id)
        {
            this.a_id = a_id;
            this.para = para;
            this.p_id = p_id;
            this.m_id = m_id;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Urunler_Adisyon urunler_Adisyon = new Urunler_Adisyon(m_id, p_id);
            urunler_Adisyon.Show();
        }

        private void Pay_Load(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Dao.Hesap_Odemeleri.hesapode(a_id, para, 1);
            Dao.MasalarDao.bosalt(m_id);
            Dao.AdisyonDao.bosalt(a_id);
            Dao.Satislar.bosalt(a_id);
            this.Close();
            Masalar masalar = new Masalar(p_id);
            masalar.Show();
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Dao.Hesap_Odemeleri.hesapode(a_id, para, 2);
            Dao.MasalarDao.bosalt(m_id);
            Dao.AdisyonDao.bosalt(a_id);
            Dao.Satislar.bosalt(a_id);
            this.Close();
            Masalar masalar = new Masalar(p_id);
            masalar.Show();
        }
    }
}
