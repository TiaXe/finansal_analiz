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
    public partial class admin_paneli : Form
    {
        public admin_paneli()
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

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");
        private void GetTotInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(gelirDeger)from gelir ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                ATotGlrLbl.Text = dt.Rows[0][0].ToString() + " TL ";

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
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(giderDeger)from gider" , baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                ATotGdrLbl.Text = dt.Rows[0][0].ToString() + " TL ";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetBalance()
        {
            double Bal = Inc - Exp;
            ABalansLbl.Text = Bal + " TL";

        }
        private void GetNumExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*)from gider ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ANumGdrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetNumInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*)from gelir ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ANumGlrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetIncLDate()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(gelirTarih)from gelir ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ATarGlrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetExpLDate()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(giderTarih)from gider ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ATarGdrLbl.Text = dt.Rows[0][0].ToString();
                ATarGdrLbl1.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMacInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(gelirDeger)from gelir ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                AMaxGlrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMinInc()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(gelirDeger)from gelir ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                AMinGlrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMaxExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(giderDeger)from gider ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                AMaxGdrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetMinExp()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(giderDeger)from gider ", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                AMinGdrLbl.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
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
                ABestGlrLbl.Text = dt.Rows[0][0].ToString();
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetIncLDate2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select TOP(1) gelirDeger from gelir order by gelirTarih desc", baglan);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                ATarGlrLbl1.Text = dt1.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }
        private void GetExpLDate2()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select TOP(1) giderDeger from gider  order by giderTarih desc", baglan);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ATarGdrLbl1.Text = dt.Rows[0][0].ToString() + " TL";
                baglan.Close();
            }
            catch (Exception Ex)
            {
                baglan.Close();
            }

        }




























        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            A_Güncel_Kur kur = new A_Güncel_Kur();
            kur.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            A_Gider_İzleme gid = new A_Gider_İzleme();
            gid.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme gel = new A_Gelir_İzleme();
            gel.Show();
            this.Hide();
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

        private void label11_Click(object sender, EventArgs e)
        {
            Çalışan cal = new Çalışan();
            cal.Show();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Çalışan cal = new Çalışan();
            cal.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            A_Güncel_Kur kur = new A_Güncel_Kur();
            kur.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme gel = new A_Gelir_İzleme();
            gel.Show();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void admin_paneli_Load(object sender, EventArgs e)
        {

        }
    }
}
