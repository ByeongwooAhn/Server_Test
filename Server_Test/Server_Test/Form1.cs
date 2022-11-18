using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace Server_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void MariaDB_Test()
        {
            string connstr = "Server = 127.0.0.1;Port=3306;Database=member;Uid=root;Pwd=root";
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand cmd = conn.CreateCommand();
            string sql = "Select*from member_name";
            cmd.CommandText = sql;

            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                
            }

            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                textBox1.Text = reader["이름"].ToString();
                textBox2.Text = reader["성별"].ToString();
            }
        }

        public void InsertDB()
        {
            string connstr = "Server = 127.0.0.1;Port=3306;Database=member;Uid=root;Pwd=root";
            string sql = "Insert Into member_name (이름, 성별) values (test2, 여자)";

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MariaDB_Test();
        }

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {
            InsertDB();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
