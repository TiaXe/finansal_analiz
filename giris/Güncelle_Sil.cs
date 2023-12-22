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
    public partial class Güncelle_Sil : Form
    {
        public Güncelle_Sil()
        {
            InitializeComponent();
            DisplayIncomes();
            DatagridviewSetting(GelirDGV);
            
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
            string Query = "select*from Calisan1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, baglan);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            GelirDGV.DataSource = ds.Tables[0];
            baglan.Close();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");


        private void GelirDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void GelirDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = GelirDGV.Rows[e.RowIndex];

                    // DataGridView'da seçilen satırdaki bilgileri TextBox ve ComboBox'lara yerleştir
                    CalisanİsTxt.Text = row.Cells["CalisanAd"].Value.ToString();
                    CalisanSaTxt.Text = row.Cells["CalisanSoyad"].Value.ToString();
                    CalisanRolCb.SelectedItem = row.Cells["CalisanRol"].Value.ToString();
                    CalisanMsTxt.Text = row.Cells["CalisanMaas"].Value.ToString();
                    CalisanTelTxt.Text = row.Cells["CalisanTel"].Value.ToString();
                    CalisanMailTxt.Text = row.Cells["CalisanMail"].Value.ToString();
                    object izinValue = row.Cells["Calisanİzin"].Value;

                    if (izinValue != DBNull.Value && izinValue != null)
                    {
                        CalisanİzTxt.Text = izinValue.ToString();
                    }
                    else
                    {
                        CalisanİzTxt.Text = string.Empty; // veya istediğiniz bir varsayılan değer
                    }
                    CalisanSaatTxt.Text = row.Cells["CalisanSaat"].Value.ToString();
                    object calisanGirisValue = row.Cells["CalisanGiris"].Value;

                    if (calisanGirisValue != DBNull.Value && calisanGirisValue != null)
                    {
                        TarDtp.Value = Convert.ToDateTime(calisanGirisValue);
                    }
                    else
                    {
                        TarDtp.Value = DateTime.Now; // Varsayılan bir değer atayabilirsiniz
                    }
                    CalisanMailTxt.Text = row.Cells["CalisanMail"].Value.ToString();
                    IDTxt.Text = row.Cells["CalisanId"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Karşılaştırma asd = new Karşılaştırma();
            asd.Show();
            this.Hide();
        }
        private void Clear()
        {
            CalisanMailTxt.Text = "";
            CalisanSaTxt.Text = "";
            CalisanTelTxt.Text = "";
            CalisanİsTxt.Text = "";
            CalisanMsTxt.Text = "";
            CalisanSaatTxt.Text = "";
            CalisanİzTxt.Text = "";
            CalisanRolCb.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CalisanMailTxt.Text == "" || CalisanSaTxt.Text == "" || CalisanMsTxt.Text == "" || CalisanRolCb.SelectedIndex == -1 || CalisanTelTxt.Text == "" || CalisanİsTxt.Text == "" || CalisanSaatTxt.Text == "" || string.IsNullOrEmpty(IDTxt.Text))
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz ve CalisanId değerini giriniz!");
            }
            else
            {
                try
                {
                    baglan.Open();

                    // Güncelleme işlemi
                    SqlCommand cmd = new SqlCommand("UPDATE Calisan1 SET CalisanAd=@Cİ, CalisanSoyad=@CS, CalisanRol=@CR, CalisanMaas=@CMa, CalisanTel=@CT,CalisanMail=@CM, Calisanİzin=@Cİz, CalisanSaat=@CSa, CalisanGiris=@CG WHERE CalisanId=@CalisanId", baglan);
                    cmd.Parameters.AddWithValue("@Cİ", CalisanİsTxt.Text);
                    cmd.Parameters.AddWithValue("@CS", CalisanSaTxt.Text);
                    cmd.Parameters.AddWithValue("@CR", CalisanRolCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CG", TarDtp.Value.Date);
                    cmd.Parameters.AddWithValue("@CMa", CalisanMsTxt.Text);
                    cmd.Parameters.AddWithValue("@CT", CalisanTelTxt.Text);
                    cmd.Parameters.AddWithValue("@CM", CalisanMailTxt.Text);
                    cmd.Parameters.AddWithValue("@Cİz", CalisanİzTxt.Text);
                    cmd.Parameters.AddWithValue("@CSa", CalisanSaatTxt.Text);
                    cmd.Parameters.AddWithValue("@CalisanId", Convert.ToInt32(IDTxt.Text));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Güncellendi ");
                    baglan.Close();
                    Clear();


                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Calisan1", baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GelirDGV.DataSource = dt;



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GelirDGV.SelectedRows.Count > 0)
            {
                // Kullanıcı bir satır seçmişse
                if (CalisanMailTxt.Text == "" || CalisanSaTxt.Text == "" || CalisanMsTxt.Text == "" || CalisanRolCb.SelectedIndex == -1 || CalisanTelTxt.Text == "" || CalisanİsTxt.Text == "" || CalisanSaatTxt.Text == "")
                {
                    MessageBox.Show("Lütfen Bilgileri Doldurunuz!");
                    return;
                }

                try
                {
                    baglan.Open();

                    // Seçilen satırın CalisanId değerini al
                    int calisanId = Convert.ToInt32(GelirDGV.SelectedRows[0].Cells["CalisanId"].Value);

                    // Silme işlemi
                    SqlCommand cmd = new SqlCommand("DELETE FROM Calisan1 WHERE CalisanId=@CalisanId", baglan);
                    cmd.Parameters.AddWithValue("@CalisanId", calisanId);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Çalışan Silindi ");
                        Clear();

                        // DataGridView'i güncelle
                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Calisan1", baglan);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GelirDGV.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Silme işlemi başarısız oldu.");
                    }

                    baglan.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Çalışanı Seçiniz!");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            admin_paneli asd = new admin_paneli();
            asd.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            admin_paneli asd = new admin_paneli();
            asd.Show();
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
            A_Güncel_Kur asd = new A_Güncel_Kur ();
            asd.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            A_Güncel_Kur asd = new A_Güncel_Kur();
            asd.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Form1 asd = new Form1();
            asd.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form1 asd = new Form1();
            asd.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label20_Click(object sender, EventArgs e)
        {
            Bilgi_Güncelle asd = new Bilgi_Güncelle();
            asd.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Çalışan asd = new Çalışan();
            asd.Show();
            this.Hide();
        }

        private void CalisanTelTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
