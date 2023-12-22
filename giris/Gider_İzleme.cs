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
    public partial class Gider_İzleme : Form
    {
        public Gider_İzleme()
        {
            InitializeComponent();
            DisplayExpenses();
            DatagridviewSetting(GiderDGV);
            FillCategoryComboBox();
        }
        public void DatagridviewSetting(DataGridView datagridview)
        {
            GiderDGV.RowHeadersVisible = false;
            datagridview.BorderStyle = BorderStyle.None;
            datagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            datagridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(1, 45, 45);
            datagridview.DefaultCellStyle.SelectionForeColor = Color.White;
            datagridview.EnableHeadersVisualStyles = false;
            datagridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(139, 58, 58);
            datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label18_Click(object sender, EventArgs e)
        {

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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
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
        private void DisplayExpenses()
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


        private void FillCategoryComboBox()
        {

            try
            {
                baglan.Open();
                SqlCommand command = new SqlCommand("select DISTINCT giderKategori from gider", baglan);
                SqlDataReader reader = command.ExecuteReader();
                GdrKatCB.Items.Add("Tüm Kategoriler");

                while (reader.Read())
                {
                    GdrKatCB.Items.Add(reader["giderKategori"].ToString());
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

                if (!string.IsNullOrEmpty(enteredName))
                {
                    query += $" AND giderAd LIKE '{enteredName}%'";
                }

                if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Tüm Kategoriler")
                {
                    query += $" AND giderKategori = '{selectedCategory}'";
                }
                if (selectedDate != DateTime.MinValue)
                {
                    string formattedDate = selectedDate.ToString("dd.MM.yyyy");
                    query += $" AND giderTarih = CONVERT(datetime, '{formattedDate}', 104)";
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





        private void GiderDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Gider_İzleme_Load(object sender, EventArgs e)
        {

        }

        private void GdrİsTb_TextChanged(object sender, EventArgs e)
        {
            string enteredName = GdrİsTb.Text;
            string selectedCategory = GdrKatCB.SelectedItem?.ToString();

            DateTime selectedDate = TarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
        }

        private void GdrKatCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enteredName = GdrİsTb.Text;
            string selectedCategory = GdrKatCB.SelectedItem?.ToString();

            DateTime selectedDate = TarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
        }

        private void TarDtp_ValueChanged(object sender, EventArgs e)
        {
            string enteredName = GdrİsTb.Text;
            string selectedCategory = GdrKatCB.SelectedItem?.ToString();

            DateTime selectedDate = TarDtp.Value;

            DisplayFilteredIncomes(enteredName, selectedCategory, selectedDate);
        }
    }
}
