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

        
    }
}
