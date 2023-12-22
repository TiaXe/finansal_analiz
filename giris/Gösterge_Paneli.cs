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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            GetTotInc();
            GetTotExp();
            GetNumExp();
            GetNumInc();
            GetIncLDate();
            GetExpLDate();
            GetMacInc();
            GetMinInc();
            GetMaxExp();
            GetMinExp();
            GetBalance();
            GetMaxIncCar();
            GetIncLDate2();
            GetExpLDate2();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");
        private void GetTotInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(gelirDeger)from gelir ", baglan);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                Inc = Convert.ToInt32(dt1.Rows[0][0].ToString());
                TotGlrLbl.Text = dt1.Rows[0][0].ToString() + " TL ";
               
                baglan.Close();

            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        int Inc, Exp;
        private void GetTotExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(giderDeger)from gider where giderKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotGdrLbl.Text = dt.Rows[0][0].ToString() + " TL ";
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetBalance()
        {
            double Bal = Inc - Exp;
            BalansLbl.Text = Bal+ " TL" ;

        }
        private void GetNumExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*)from gider where giderKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumGdrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close(); 
            }

        }
        private void GetNumInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*)from gelir where gelirKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumGlrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetIncLDate()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(gelirTarih)from gelir where gelirKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                TarGlrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetExpLDate()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(giderTarih)from gider where giderKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                TarGdrLbl.Text = dt.Rows[0][0].ToString();
                TarGdrLbl1.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMacInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(gelirDeger)from gelir where gelirKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxGlrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMinInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(gelirDeger)from gelir where gelirKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinGlrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMaxExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(giderDeger)from gider where giderKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxGdrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMinExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(giderDeger)from gider where giderKullanıcı='" + Form1.User + "'", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinGdrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMaxIncCar()
        {
            try
            {
                baglan.Open();
                string InnerQuery = "select Max(gelirDeger)from gelir";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, baglan);
                sda1.Fill(dt1);
                string Query = "select gelirKategori from gelir where gelirDeger='" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BestGlrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetIncLDate2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select TOP(1) gelirDeger from gelir where gelirKullanıcı = '" + Form1.User + "' order by gelirTarih desc", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                TarGlrLbl1.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetExpLDate2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select TOP(1) giderDeger from gider where giderKullanıcı = '" + Form1.User + "' order by giderTarih desc", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                TarGdrLbl1.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }catch(Exception Ex)
            {
                baglan.Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Gelir_İzleme izleme = new Gelir_İzleme();
            izleme.Show();
            Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Gelir gelir = new Gelir();
            gelir.Show();
            Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Gider gider = new Gider();
            gider.Show();
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Gelir gelir = new Gelir();
            gelir.Show();
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Gider gider = new Gider();
            gider.Show();
            Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Gelir_İzleme izleme = new Gelir_İzleme();
            izleme.Show();
            Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Gider_İzleme izleme2 = new Gider_İzleme();
            izleme2.Show();
            Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Güncel_Kur kur = new Güncel_Kur();
            kur.Show();
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }
    }
}
