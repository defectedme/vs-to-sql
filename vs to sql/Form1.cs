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



namespace vs_to_sql

{

    public  partial class Form1 : Form
    {


        //static string connectionString = "DESKTOP-6795RSE";
        SqlConnection con = new SqlConnection(@"Data Source=" + "DESKTOP-6795RSE" + ";Initial Catalog=master;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("asc");

        }

        private void button4_Click(object sender, EventArgs e)
        {


            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-6795RSE;Initial Catalog=master;Integrated Security=True");
            con.Open();

            



            SqlCommand cmd = new SqlCommand("insert into UserTab values (@ID, @Name, @Age)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));   
            cmd.Parameters.AddWithValue("@Name", (textBox2.Text));   
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully added. Thank You");




        }

        private void update_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-6795RSE;Initial Catalog=master;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update UserTab set Name=@Name, Age=@Age where  ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully updated. Thank You");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete FROM UserTab WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            //cmd.Parameters.AddWithValue("@Name", (textBox2.Text));
            //cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("deleted successfully");

        }


        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete FROM UserTab WHERE Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", (textBox2.Text));
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text.ToString();
            Form1 frmRem = new Form1();
            MessageBox.Show(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
