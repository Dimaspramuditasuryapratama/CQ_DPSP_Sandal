using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PraktikumMysql
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }
        private void koneksi()
        {
            conn = new MySqlConnection(
                "Server=127.0.0.1;database=DBAkademiADO;UID=root;Password=;");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                MessageBox.Show("Message", "Koneksi ke Database Berhasil",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message", ex.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "select count(*) from Mahasiswa";
                cmd = new MySqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message", ex.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "select count(*) from MataKuliah";
                cmd = new MySqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message", ex.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi();
                conn.Open();
                string query = "update mahasiswa set Alamat = 'Yogyakarta' where NIM = '23110100001'";
                cmd = new MySqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Message", "Jumlah baris terpengaruh : " + hasil,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message", ex.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi(); conn.Open();
                string query = "select count(*) from Dosen";
                cmd = new MySqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUpdateSKS_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi(); conn.Open();
                string query = "UPDATE MataKuliah SET SKS = 4 WHERE KodeMK = 'IF210101'";
                cmd = new MySqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Baris terpengaruh: " + hasil);
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnInsertProdi_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi(); conn.Open();
                string query = "INSERT INTO ProgramStudi VALUES ('MI01','Manajemen Informatika')";
                cmd = new MySqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan. Baris terpengaruh: " + hasil);
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

}