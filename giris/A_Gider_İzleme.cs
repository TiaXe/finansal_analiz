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
    public partial class A_Gider_İzleme : Form
    {
        public A_Gider_İzleme()
        {
            InitializeComponent();
            DisplayIncomes();
            DatagridviewSetting(GiderDGV);
            FillCategoryComboBox();


        }

        public void DatagridviewSetting(DataGridView datagridview)
        {
            GiderDGV.RowHeadersVisible = false;
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
            string Query = "select*from gider";
            SqlDataAdapter sda = new SqlDataAdapter(Query, baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            GiderDGV.DataSource = ds.Tables[0];
            baglan.Close();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FillCategoryComboBox()
        {

            try
            {
                baglan.Open();
                SqlCommand command = new SqlCommand("select DISTINCT giderKategori from gider", baglan);
                SqlDataReader reader = command.ExecuteReader();
                AGDRKC.Items.Add("Tüm Kategoriler");

                while (reader.Read())
                {
                    AGDRKC.Items.Add(reader["giderKategori"].ToString());
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


        private void DisplayFilteredIncomes(string enteredName, string selectedCategory, DateTime selectedDate)
        {

            try
            {
                baglan.Open();


                string query = "SELECT * FROM gider WHERE 1 = 1";
                if (selectedDate != null)
                {
                    string formattedDate = selectedDate.ToString("dd.MM.yyyy");
                    query += $" AND giderTarih = CONVERT(datetime, '{formattedDate}', 104)";
                }

                if (!string.IsNullOrEmpty(enteredName))
                {
                    query += $" AND giderAd LIKE '{enteredName}%'";
                }

                if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Tüm Kategoriler")
                {
                    query += $" AND giderKategori = '{selectedCategory}'";
                }
               

                SqlDataAdapter sda = new SqlDataAdapter(query, baglan);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();


                if (GiderDGV.DataSource != null)
                {
                    ((DataTable)GiderDGV.DataSource).Clear();
                }


                sda.Fill(ds, "gider");


                GiderDGV.DataSource = ds.Tables["gider"];
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

        private void label9_Click(object sender, EventArgs e)
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

        private void GiderDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AGLRİT_TextChanged(object sender, EventArgs e)
        {
            string enteredName = AGDRİT.Text;
            string selectedCategory = AGDRKC.SelectedItem?.ToString();
            DateTime selectedDate = GiderTarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
            
        }

       

        private void TarDtp_ValueChanged(object sender, EventArgs e)
        {
            string enteredName = AGDRİT.Text;
            string selectedCategory = AGDRKC.SelectedItem?.ToString();
            DateTime selectedDate = GiderTarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
            
        }

        private void AGLRKC_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string enteredName = AGDRİT.Text;
            string selectedCategory = AGDRKC.SelectedItem?.ToString();
            DateTime selectedDate = GiderTarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
            
        }
        private bool userSelectedDate = false;
        private void A_Gider_İzleme_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
