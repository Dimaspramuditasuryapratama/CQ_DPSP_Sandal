using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PraktikumSqlServer
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Koneksi()
        {
            conn = new SqlConnection(
                "LAPTOP-2QET043V\\DIMAS;Initial Catalog=DBAkademiADO;Integrated Security=True");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                MessageBox.Show("Koneksi ke database berhasil");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); conn.Open();
                string query = "SELECT COUNT(*) FROM Mahasiswa";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // Praktikum 3
        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); conn.Open();
                string query = "SELECT COUNT(*) FROM MataKuliah";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); conn.Open();
                string query = "UPDATE Mahasiswa SET Alamat='Yogyakarta' WHERE NIM='23110100001'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); conn.Open();
                cmd = new SqlCommand("SELECT COUNT(*) FROM Dosen", conn);
                txtHasil.Text = ((int)cmd.ExecuteScalar()).ToString();
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUpdateSKS_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); conn.Open();
                cmd = new SqlCommand("UPDATE MataKuliah SET SKS=4 WHERE KodeMK='IF210101'", conn);
                MessageBox.Show("Baris terpengaruh: " + cmd.ExecuteNonQuery());
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnInsertProdi_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); conn.Open();
                cmd = new SqlCommand("INSERT INTO ProgramStudi VALUES ('MI01','Manajemen Informatika')", conn);
                MessageBox.Show("Data ditambahkan. Baris: " + cmd.ExecuteNonQuery());
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
