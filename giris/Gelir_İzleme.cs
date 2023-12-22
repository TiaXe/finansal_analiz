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
    public partial class Gelir_İzleme : Form
    {
        public Gelir_İzleme()
        {
            InitializeComponent();
            DisplayIncomes();
            DatagridviewSetting(GelirDGV);
            FillCategoryComboBox();


        }

        public void DatagridviewSetting(DataGridView datagridview)
        {
            GelirDGV.RowHeadersVisible = false;
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
            string Query = "select*from gelir";
            SqlDataAdapter sda = new SqlDataAdapter(Query, baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            GelirDGV.DataSource = ds.Tables[0];
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
                SqlCommand command = new SqlCommand("select DISTINCT gelirKategori from gelir", baglan);
                SqlDataReader reader = command.ExecuteReader();
                GlrKatCB.Items.Add("Tüm Kategoriler");

                while (reader.Read())
                {
                    GlrKatCB.Items.Add(reader["gelirKategori"].ToString());
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

                
                string query = "SELECT * FROM gelir WHERE 1 = 1";

                if (!string.IsNullOrEmpty(enteredName))
                {
                    query += $" AND gelirAd LIKE '{enteredName}%'";
                }

                if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Tüm Kategoriler")
                {
                    query += $" AND gelirKategori = '{selectedCategory}'";
                }
                if (selectedDate != DateTime.MinValue)
                {
                    string formattedDate = selectedDate.ToString("dd.MM.yyyy");
                    query += $" AND gelirTarih = CONVERT(datetime, '{formattedDate}', 104)";
                }

                SqlDataAdapter sda = new SqlDataAdapter(query, baglan);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();

                
                if (GelirDGV.DataSource != null)
                {
                    ((DataTable)GelirDGV.DataSource).Clear();
                }

                
                sda.Fill(ds, "gelir");

                
                GelirDGV.DataSource = ds.Tables["gelir"];
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










        private void Gelir_İzleme_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form2 göstergepeneli = new Form2();
            göstergepeneli.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form2 göstergepeneli = new Form2();
            göstergepeneli.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Gelir gelir = new Gelir();
            gelir.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Gelir gelir = new Gelir();
            gelir.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Gider gider = new Gider();
            gider.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Gider gider = new Gider();
            gider.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Gider_İzleme izleme2 = new Gider_İzleme();
            izleme2.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Gider_İzleme izleme2 = new Gider_İzleme();
            izleme2.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Güncel_Kur kur = new Güncel_Kur();
            kur.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Güncel_Kur kur = new Güncel_Kur();
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

        private void GelirDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enteredName = GlrİsTb.Text;
            string selectedCategory = GlrKatCB.SelectedItem?.ToString();

            DateTime selectedDate = TarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
        }

        private void GlrİsTb_TextChanged(object sender, EventArgs e)
        {
            string enteredName = GlrİsTb.Text;
            string selectedCategory = GlrKatCB.SelectedItem?.ToString();

            DateTime selectedDate = TarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
        }

        private void TarDtp_ValueChanged(object sender, EventArgs e)
        {
            string enteredName = GlrİsTb.Text;
            string selectedCategory = GlrKatCB.SelectedItem?.ToString();

            DateTime selectedDate = TarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);

        }
    }
}
