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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtUsername.PasswordChar = '*';
            errorProvider1 = new ErrorProvider();
            this.Shown += Form1_Shown;
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=SERKAN\SQLEXPRESS01;Initial Catalog=giris;Integrated Security=True");
        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static string User;
        public static string User2;
        public static string AdminUser;

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Lütfen bir kullanıcı adı girin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Lütfen bir şifre girin.");
                return;
            }

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM giris WHERE kullanici_Adi=@P1 AND sifre=@P2", baglan);
                cmd.Parameters.AddWithValue("@P1", textBox1.Text);
                cmd.Parameters.AddWithValue("@P2", txtUsername.Text);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int userType = Convert.ToInt32(dr["Kullanici_Tipi"]);

                        if (userType == 1) // Normal Kullanıcı
                        {
                            User = textBox1.Text;
                            Form2 frm = new Form2();
                            frm.Show();
                        }
                        else if (userType == 2) // Admin Kullanıcı
                        {
                            admin_paneli admin = new admin_paneli();
                            admin.Show();
                            MessageBox.Show("Admin girişi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Giriş bilgileri yanlış, lütfen tekrar deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Clear();
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            textBox1.Clear();
            textBox1.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.PasswordChar == '*')
            {
                txtUsername.PasswordChar = '\0'; // Şifreyi göster
             
            }
            else
            {
                txtUsername.PasswordChar = '*'; // Şifreyi gizle
          
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
