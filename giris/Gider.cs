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
    public partial class Gider : Form
    {
        public Gider()
        {
            InitializeComponent();
            GetTotExp();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gider_Load(object sender, EventArgs e)
        {

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

        private void label7_Click(object sender, EventArgs e)
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

        private void label13_Click(object sender, EventArgs e)
        {
            Güncel_Kur kur = new Güncel_Kur();
            kur.Show();
            Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Güncel_Kur kur = new Güncel_Kur();
            kur.Show();
            Close();
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
            GdrAdTb.Text = "";
            GdrDegTb.Text = "";
            GdrAckTb.Text = "";
            GdrKatTb.SelectedIndex = 0;
        }
        private void GetTotExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(giderDeger)from gider where giderKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
               // Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotGdrLbl1.Text = dt.Rows[0][0].ToString() + " TL ";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }

        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (GdrAdTb.Text == "" || GdrDegTb.Text == "" || GdrAckTb.Text == "" || GdrKatTb.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz!");
            }
            else
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into gider(giderAd,giderDeger,giderKategori,giderTarih,giderAcıklama,giderKullanıcı)values(@GA,@GD,@GK,@GT,@GAc,@GKullanıcı)", baglan);
                    cmd.Parameters.AddWithValue("@GA", GdrAdTb.Text);
                    cmd.Parameters.AddWithValue("@GD", GdrDegTb.Text);
                    cmd.Parameters.AddWithValue("@GK", GdrKatTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@GT", GdrTarTb.Value.Date);
                    cmd.Parameters.AddWithValue("@GAc", GdrAckTb.Text);
                    cmd.Parameters.AddWithValue("@GKullanıcı", Form1.User);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Gider Eklendi ");
                    baglan.Close();
                    GetTotExp();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
    }
}
