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
namespace AIUB_Student_Cafe
{
    public partial class AddEmpol : Form
    {
        SqlCommand com;
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");

        public AddEmpol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            try
            {

                com = new SqlCommand("INSERT INTO SignUp (ID,Name,password,mail,Phonenumber,UserType) values (@ID,@Name,@password,@mail,@Phonenumber,@UserType)", con);

                com.Parameters.AddWithValue("@ID", this.textBox1.Text.ToString());
                com.Parameters.AddWithValue("@Name", this.textBox2.Text);
                com.Parameters.AddWithValue("@password", this.textBox3.Text);
                com.Parameters.AddWithValue("@mail", this.textBox4.Text);
                com.Parameters.AddWithValue("@Phonenumber", this.textBox5.Text);
                com.Parameters.AddWithValue("@UserType", "Employee".ToString());
                com.ExecuteNonQuery();
                MessageBox.Show("Info Added");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            con.Close();
        }
    }
    }

