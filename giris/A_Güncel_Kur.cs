using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace giris
{
    public partial class A_Güncel_Kur : Form
    {
        public A_Güncel_Kur()
        {
            InitializeComponent();
        }

        private void A_Güncel_Kur_Load(object sender, EventArgs e)
        {
            string bugun = "https://tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);
            string dolarAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolarAlısText.Text = dolarAlis;

            string dolarSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            dolarSatısText.Text = dolarSatis;

            string euroAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euroAlısText.Text = euroAlis;

            string euroSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euroSatısText.Text = euroSatis;
        }

        private void btndolarAlis_Click(object sender, EventArgs e)
        {
            txtKur.Text = dolarAlısText.Text;
        }

        private void btndolarSatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = dolarSatısText.Text;
        }

        private void btneuroAlis_Click(object sender, EventArgs e)
        {
            txtKur.Text = euroAlısText.Text;
        }

        private void btneuroSatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = euroSatısText.Text;
        }
        double kur, miktar, tutar;

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            kur = Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = miktar * kur;
            txtTutar.Text = tutar.ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            admin_paneli ad = new admin_paneli();
            ad.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            admin_paneli ad = new admin_paneli();
            ad.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Çalışan cal = new Çalışan();
            cal.Show();
            this.Hide();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Çalışan cal = new Çalışan();
            cal.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme glr = new A_Gelir_İzleme();
            glr.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme glr = new A_Gelir_İzleme();
            glr.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            A_Gider_İzleme glr = new A_Gider_İzleme();
            glr.Show();
            this.Hide();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme glr = new A_Gelir_İzleme();
            glr.Show();
            this.Hide();
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            txtKur.Text = txtKur.Text.Replace(".", ",");
        }

        private void btnBozdurma_Click(object sender, EventArgs e)
        {
            kur = Convert.ToDouble(txtKur.Text);
            int miktar = Convert.ToInt32(txtMiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            txtTutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            txtKalan.Text = kalan.ToString();
        }
    }
}
