using System;
using System.Windows.Forms;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace Insert_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void InsertDB()
        {
            string connstr = "Server = 127.0.0.1;Port=3306;Database=member;Uid=root;Pwd=root";
            string sql = "Insert Into member_name (이름, 성별) values ('test4', '여장남장')";

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }

        }

        public void DeleteDB()
        {
            string connstr = "Server = 127.0.0.1;Port=3306;Database=member;Uid=root;Pwd=root";
            string sql = "Delete From member_name Where 이름 = 'test4'";

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            InsertDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteDB();
        }
    }
}
