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

namespace giris
{
    public partial class Karşılaştırma : Form
    {
        public Karşılaştırma()
        {
            InitializeComponent();
            MaxMaas();
            MinMaas();
            Maxİzin();
            Minİzin();
            MaxSaat();
            MinSaat();
            MaxMaas2();
            MinMaas2();
            Maxİzin2();
            Minİzin2();
            MaxSaat2();
            MinSaat2();



        }
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");
        private void MaxMaas()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(CalisanMaas)from Calisan1", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxMaasLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }

        private void MinMaas()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(CalisanMaas)from Calisan1", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinMaasLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void Maxİzin()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(Calisanİzin)from Calisan1", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxİzLbl.Text = dt.Rows[0][0].ToString() + " Gün";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void Minİzin()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(Calisanİzin)from Calisan1", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinİzLbl.Text = dt.Rows[0][0].ToString() + " Gün";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void MaxSaat()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(CalisanSaat)from Calisan1", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxCSLbl.Text = dt.Rows[0][0].ToString() + " Saat";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }

        private void MinSaat()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(CalisanSaat)from Calisan1", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinCSLbl.Text = dt.Rows[0][0].ToString() + " Saat";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }

        private void MaxMaas2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 CONCAT(CalisanAd, ' ', CalisanSoyad) AS AdSoyad FROM Calisan1 ORDER BY CalisanMaas DESC", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    YüksekMALbl.Text = dt.Rows[0]["AdSoyad"].ToString();
                }
                else
                {
                    YüksekMALbl.Text = "Hiçbir çalışan bulunamadı.";
                }

                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
                // Hata durumuyla ilgili işlemleri yapabilirsiniz.
            }
        }
        private void MinMaas2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 CONCAT(CalisanAd, ' ', CalisanSoyad) AS AdSoyad FROM Calisan1 ORDER BY CalisanMaas ASC", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ASD.Text = dt.Rows[0]["AdSoyad"].ToString();
                }
                else
                {
                    ASD.Text = "Hiçbir çalışan bulunamadı.";
                }

                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
                
            }
        }
        private void Maxİzin2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 CONCAT(CalisanAd, ' ', CalisanSoyad) AS AdSoyad FROM Calisan1 ORDER BY Calisanİzin DESC", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    CokİzALbl.Text = dt.Rows[0]["AdSoyad"].ToString();
                }
                else
                {
                    CokİzALbl.Text = "Hiçbir çalışan bulunamadı.";
                }

                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
                
            }
        }
        private void Minİzin2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 CONCAT(CalisanAd, ' ', CalisanSoyad) AS AdSoyad FROM Calisan1 ORDER BY Calisanİzin ASC", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    AzİzALbl.Text = dt.Rows[0]["AdSoyad"].ToString();
                }
                else
                {
                    AzİzALbl.Text = "Hiçbir çalışan bulunamadı.";
                }

                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();

            }
        }
        private void MaxSaat2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 CONCAT(CalisanAd, ' ', CalisanSoyad) AS AdSoyad FROM Calisan1 ORDER BY CalisanSaat DESC", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    YüksekCaALbl.Text = dt.Rows[0]["AdSoyad"].ToString();
                }
                else
                {
                    YüksekCaALbl.Text = "Hiçbir çalışan bulunamadı.";
                }

                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
                // Hata durumuyla ilgili işlemleri yapabilirsiniz.
            }
        }
        private void MinSaat2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 CONCAT(CalisanAd, ' ', CalisanSoyad) AS AdSoyad FROM Calisan1 ORDER BY CalisanSaat ASC", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    AzCaALbl.Text = dt.Rows[0]["AdSoyad"].ToString();
                }
                else
                {
                    AzCaALbl.Text = "Hiçbir çalışan bulunamadı.";
                }

                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
                // Hata durumuyla ilgili işlemleri yapabilirsiniz.
            }
        }



















        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Çalışan cal = new Çalışan();
            cal.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Bilgi_Güncelle gncl = new Bilgi_Güncelle();
            gncl.Show();
            this.Hide();
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

        private void Karşılaştırma_Load(object sender, EventArgs e)
        {

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

        private void label9_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme asd = new A_Gelir_İzleme();
            asd.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme asd = new A_Gelir_İzleme();
            asd.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            A_Gider_İzleme asd = new A_Gider_İzleme();
            asd.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            A_Gider_İzleme asd = new A_Gider_İzleme();
            asd.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            A_Güncel_Kur asd = new A_Güncel_Kur();
            asd.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            A_Güncel_Kur asd = new A_Güncel_Kur();
            asd.Show();
            this.Hide();
        }

        private void label21_Click_1(object sender, EventArgs e)
        {
            Çalışan asd = new Çalışan();
            asd.Show();
            this.Hide();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            Bilgi_Güncelle asd = new Bilgi_Güncelle();
            asd.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Güncelle_Sil asd = new Güncelle_Sil();
            asd.Show();
            this.Hide();
        }
    }
}
