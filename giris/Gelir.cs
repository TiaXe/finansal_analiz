using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace giris
{
    public partial class Gelir : Form
    {
        public Gelir()
        {
            InitializeComponent();
            GetTotInc();
        }


        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gelir_Load(object sender, EventArgs e)
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
            GlrAdTb.Text = "";
            GlrDegTb.Text = "";
            GlrAckTb.Text = "";
            GlrKatTb.SelectedIndex = 0;
        }
        private void GetTotInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(gelirDeger)from gelir where gelirKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotGlrLbl1.Text = dt.Rows[0][0].ToString() + " TL ";

                baglan.Close();

            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (GlrAdTb.Text == "" || GlrDegTb.Text == "" || GlrAckTb.Text == "" || GlrKatTb.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz!");
            }
            else
            {
                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into gelir(gelirAd,gelirDeger,gelirKategori,gelirTarih,gelirAcıklama,gelirKullanıcı)values(@GA,@GD,@GK,@GT,@GAc,@GKullanıcı)", baglan);
                    cmd.Parameters.AddWithValue("@GA", GlrAdTb.Text);
                    cmd.Parameters.AddWithValue("@GD", GlrDegTb.Text);
                    cmd.Parameters.AddWithValue("@GK", GlrKatTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@GT", GlrTarTb.Value.Date);
                    cmd.Parameters.AddWithValue("@GAc", GlrAckTb.Text);
                    cmd.Parameters.AddWithValue("@GKullanıcı", Form1.User);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Gelir Eklendi ");
                    baglan.Close();
                    GetTotInc();
                    Clear();
                } catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

              
            }


            

        }
    }
}
