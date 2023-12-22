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
    public partial class Bilgi_Güncelle : Form
    {
        public Bilgi_Güncelle()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Çalışan cal = new Çalışan();
            cal.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Karşılaştırma kar = new Karşılaştırma();
            kar.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");
        private void Clear()
        {
            CalisanMailTxt.Text ="";
            CalisanSaTxt.Text = "";
            CalisanTelTxt.Text = "";
            CalisanİsTxt.Text = "";
            CalisanMsTxt.Text = "";
            CalisanSaatTxt.Text = "";
            CalisanRolCb.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CalisanMailTxt.Text == "" || CalisanSaTxt.Text == "" || CalisanMsTxt.Text == "" || CalisanRolCb.SelectedIndex == -1 || CalisanTelTxt.Text == "" || CalisanİsTxt.Text == ""  || CalisanSaatTxt.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz!");
            }
            else
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into Calisan1(CalisanAd,CalisanSoyad,CalisanRol,CalisanMaas,CalisanTel,CalisanGiris,CalisanMail,CalisanSaat,Calisanİzin)values(@Cİ,@CS,@CR,@CM,@CT,@CG,@CMa,@CSa,NULL)", baglan);
                    cmd.Parameters.AddWithValue("@Cİ", CalisanİsTxt.Text);
                    cmd.Parameters.AddWithValue("@CS", CalisanSaTxt.Text);
                    cmd.Parameters.AddWithValue("@CR", CalisanRolCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CG", TarDtp.Value.Date);
                    cmd.Parameters.AddWithValue("@CM", CalisanMsTxt.Text);
                    cmd.Parameters.AddWithValue("@CT",CalisanTelTxt.Text);
                    cmd.Parameters.AddWithValue("@CMa", CalisanMailTxt.Text);
                    cmd.Parameters.AddWithValue("@CSa", CalisanSaatTxt.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Eklendi ");
                    baglan.Close();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {                
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Güncelle_Sil frm = new Güncelle_Sil();
            frm.Show();
            this.Hide();
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
    }
}
