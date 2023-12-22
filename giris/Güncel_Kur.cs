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
    public partial class Güncel_Kur : Form
    {
        public Güncel_Kur()
        {
            InitializeComponent();
        }

        private void Güncel_Kur_Load(object sender, EventArgs e)
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

        private void label22_Click(object sender, EventArgs e)
        {

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

        private void btnBozdurma_Click(object sender, EventArgs e)
        {
            kur = Convert.ToDouble(txtKur.Text);
            int miktar = Convert.ToInt32(txtMiktar.Text);
            int tutar = Convert.ToInt32(miktar/kur);
            txtTutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            txtKalan.Text = kalan.ToString();
                
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form2 göstergepeneli = new Form2();
            göstergepeneli.Show();
            Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form2 göstergepeneli = new Form2();
            göstergepeneli.Show();
            Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Gelir gelir = new Gelir();
            gelir.Show();
            Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Gelir gelir = new Gelir();
            gelir.Show();
            Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Gider gider = new Gider();
            gider.Show();
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Gider gider = new Gider();
            gider.Show();
            Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Gelir_İzleme izleme = new Gelir_İzleme();
            izleme.Show();
            Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Gelir_İzleme izleme = new Gelir_İzleme();
            izleme.Show();
            Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Gider_İzleme izleme2 = new Gider_İzleme();
            izleme2.Show();
            Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Gider_İzleme izleme2 = new Gider_İzleme();
            izleme2.Show();
            Close();
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

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            kur = Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = miktar * kur;
            txtTutar.Text = tutar.ToString();
        }
    }
}
