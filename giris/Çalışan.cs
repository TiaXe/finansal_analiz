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
    public partial class Çalışan : Form
    {
        public Çalışan()
        {
            InitializeComponent();
            DatagridviewSetting(CalısanDGV);
            DisplayIncomes();
            FillCategoryComboBox();
        }



        private void FillCategoryComboBox()
        {

            try
            {
                baglan.Open();
                SqlCommand command = new SqlCommand("select DISTINCT CalisanRol from Calisan1", baglan);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CalisanRCb.Items.Add(reader["CalisanRol"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori yükleme hatası: " + ex.Message);
            }
            finally
            {
                baglan.Close();
            }
        }










        private void DisplayFilteredIncomes(string enteredName, string enteredName2 ,string selectedCategory)
        {
            try
            {
                baglan.Open();


                string query = "SELECT * FROM Calisan1 WHERE 1 = 1";

                if (!string.IsNullOrEmpty(enteredName))
                {
                    query += $" AND CalisanAd LIKE '{enteredName}%'";
                }

                if (!string.IsNullOrEmpty(enteredName2))
                {
                    query += $" AND CalisanSoyad LIKE '{enteredName2}%'";
                }


                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    query += $" AND CalisanRol = '{selectedCategory}'";
                }

                SqlDataAdapter sda = new SqlDataAdapter(query, baglan);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();


                if (CalısanDGV.DataSource != null)
                {
                    ((DataTable)CalısanDGV.DataSource).Clear();
                }


                sda.Fill(ds, "Calisan1");


                CalısanDGV.DataSource = ds.Tables["Calisan1"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri filtreleme hatası: " + ex.Message);
            }
            finally
            {
                baglan.Close();
            }
        }





        public void DatagridviewSetting(DataGridView datagridview)
        {
            CalısanDGV.RowHeadersVisible = false;
            datagridview.BorderStyle = BorderStyle.None;
            datagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            datagridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(1, 45, 45);
            datagridview.DefaultCellStyle.SelectionForeColor = Color.White;
            datagridview.EnableHeadersVisualStyles = false;
            datagridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(139, 58, 58);
            datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void DisplayIncomes()
        {
            baglan.Open();
            string Query = "select*from Calisan1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CalısanDGV.DataSource = ds.Tables[0];
            baglan.Close();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");






        private void label10_Click(object sender, EventArgs e)
        {
            Bilgi_Güncelle gncl = new Bilgi_Güncelle();
            gncl.Show();
            this.Hide();
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Karşılaştırma kar = new Karşılaştırma();
            kar.Show();
            this.Hide();
            

        }

        private void label9_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme glr = new A_Gelir_İzleme();
            glr.Show();
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            A_Gelir_İzleme glr = new A_Gelir_İzleme();
            glr.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            A_Gider_İzleme gid = new A_Gider_İzleme();
            gid.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            A_Gider_İzleme gid = new A_Gider_İzleme();
            gid.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            A_Güncel_Kur kur = new A_Güncel_Kur();
            kur.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            A_Güncel_Kur kur = new A_Güncel_Kur();
            kur.Show();
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

        private void label20_Click(object sender, EventArgs e)
        {
            Bilgi_Güncelle frm = new Bilgi_Güncelle();
            frm.Show();
            this.Hide();

        }

        private void GelirDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string enteredName = CalisanAtxt.Text;
            string enteredName2 = CalisanSTxt.Text;
            string selectedCategory = CalisanRCb.SelectedItem?.ToString();

            DisplayFilteredIncomes(enteredName, enteredName2, selectedCategory);
        }

        private void CalisanSTxt_TextChanged(object sender, EventArgs e)
        {
            string enteredName = CalisanAtxt.Text;
            string enteredName2 = CalisanSTxt.Text;
            string selectedCategory = CalisanRCb.SelectedItem?.ToString();

            DisplayFilteredIncomes(enteredName, enteredName2, selectedCategory);
        }

        private void CalisanRCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enteredName = CalisanAtxt.Text;
            string enteredName2 = CalisanSTxt.Text;
            string selectedCategory = CalisanRCb.SelectedItem?.ToString();

            DisplayFilteredIncomes(enteredName, enteredName2, selectedCategory);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Güncelle_Sil asd = new Güncelle_Sil();
            asd.Show();
            this.Hide();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            Karşılaştırma asd = new Karşılaştırma();
            asd.Show();
            this.Hide();
        }
    }
}
