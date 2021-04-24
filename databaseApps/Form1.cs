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
namespace databaseApps
{
    public partial class Form1 : Form
    {
        SqlConnection sqlconn;
        string str;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str = @"data source=.; initial catalog=Latihan_DB; integrated security= true";
            sqlconn = new SqlConnection(str);
            sqlconn.Open();
            MessageBox.Show("Berhasil connect ke database");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlconn.Close();
            MessageBox.Show("Berhasil Disconnect ke database");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataReader reader;
            SqlCommand sqlCommand;
            string sql = "", output="";
            sql = "select * from mahasiswa";
            sqlCommand = new SqlCommand(sql, sqlconn);
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                output += reader["nim"].ToString() + "\t" + reader["nama"].ToString() + "\n";

            }
            MessageBox.Show(output);
            sqlCommand.Dispose();
            reader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string sql;
            sql = "insert into mahasiswa " +
                "values('" +
                textBox1.Text + "','" +
                textBox2.Text + "')";
            command = new SqlCommand(sql, sqlconn);
            command.ExecuteNonQuery();
            MessageBox.Show("data berhasil di simpan");
            command.Dispose();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string sql;
            sql = "update mahasiswa set nama = '" +textBox4.Text + "' where nim = '" + textBox3.Text + "'";
            command = new SqlCommand(sql, sqlconn);
            command.ExecuteNonQuery();
            MessageBox.Show("data berhasil di update");
            command.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string sql;
            sql = "delete from mahasiswa where nim='"+
                textBox5.Text + "'";
            command = new SqlCommand(sql, sqlconn);
            command.ExecuteNonQuery();
            MessageBox.Show("data berhasil dihapus");
            command.Dispose();
        }
    }
}
