using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PraktikumMysql
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;

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
    }

}