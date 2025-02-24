﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;

namespace Insert_Test
{
    public partial class Form1 : Form
    {
        string connstr = "Server = 127.0.0.1;Port=3306;Database=member;Uid=root;Pwd=root";
        public Form1()
        {
            InitializeComponent();
        }

        public void Signup()
        {
            string sql = "Insert Into member_name (이름, 성별) values ('" + textBox1.Text + "', '" + textBox2.Text + "')";

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { }
            }
        }

        public DataSet Search()
        {
            string sql = "select * from member_name where 이름 = '" + textBox5.Text + "' and 성별 = '" + textBox6.Text + "'";
            DataSet ds = new DataSet();

                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }

                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    try
                    {
                    
                        {
                            conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                            da.Fill(ds);
                        }
                  
                }
                    catch (Exception ex)
                    {

                    }
                }
            return ds;
        }

        public void Login(string ID, string PW)
        {
            DataSet ds;
            ds = Search();

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (ID == row["이름"].ToString() && PW == row["성별"].ToString())
                            {
                                dataGridView2.DataSource = ds.Tables[0];
                            }
                        }
                    }
                    else
                    {
                        label1.Text = "아이디와 패스워드를 확인하여 주십시오.";
                    }
                }
                catch (Exception ex) { }
            }

        }

        public void DeleteDB()
        {
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

        public void UpdateDB()
        {
            string sql = "Update member_name Set 이름 ='홍길동' where 이름 = 'test4'";

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

        public DataSet SelectDB()
        {
            string sql = "select * from member_name";
            DataSet ds = new DataSet();

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
                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    try
                    {
                        conn.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {

                    }
                }
           
            return ds;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds;
            ds = SelectDB();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Signup();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UpdateDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                Login(textBox5.Text, textBox6.Text);
            
        }
    }
}
