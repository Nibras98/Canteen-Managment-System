using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AIUB_Student_Cafe
{
    public partial class SignUpFor : Form
    {
        SqlCommand com;
        
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public SignUpFor()
        {
            InitializeComponent();
        }


        Admin admin = new Admin();
        private void Employee_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {

                com = new SqlCommand("INSERT INTO SignUp (ID,Name,password,mail,Phonenumber,UserType) values (@ID,@Name,@password,@mail,@Phonenumber,@UserType)", con);

                com.Parameters.AddWithValue("@ID", this.textBox2.Text.ToString());
                com.Parameters.AddWithValue("@Name", this.textBox1.Text);
                com.Parameters.AddWithValue("@password", this.textBox3.Text);
                com.Parameters.AddWithValue("@mail", this.textBox4.Text);
                com.Parameters.AddWithValue("@Phonenumber", this.textBox5.Text);
                com.Parameters.AddWithValue("@UserType", this.comboBox2.SelectedItem.ToString());
                com.ExecuteNonQuery();
                MessageBox.Show("Info Added");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            con.Close();

           /* if (textBox2.Text.Length == 10)
            {
                if (textBox3.Text != null || textBox4.Text != null || textBox5.Text != null || comboBox2.SelectedValue != null)
                {
                    if (admin.IdVerification(textBox2.Text) == true)
                    {
                        con.Open();
                        try
                        {

                            com = new SqlCommand("INSERT INTO SignUp (ID,Name,password,mail,Phonenumber,UserType) values (@ID,@Name,@password,@mail,@Phonenumber,@UserType)", con);
                            
                            com.Parameters.AddWithValue("@ID", this.textBox2.Text.ToString());
                            com.Parameters.AddWithValue("@Name", this.textBox1.Text);
                            com.Parameters.AddWithValue("@password", this.textBox3.Text);
                            com.Parameters.AddWithValue("@mail", this.textBox4.Text);
                            com.Parameters.AddWithValue("@Phonenumber", this.textBox5.Text);
                            com.Parameters.AddWithValue("@UserType", this.comboBox2.SelectedItem.ToString());
                            com.ExecuteNonQuery();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Close();
                        }
                        con.Close();
                    }
                    else if(admin.IdVerification(textBox2.Text)==false)
                    {
                        MessageBox.Show("Sign Up again....");
                    }

                }
           

                else
                {
                    MessageBox.Show("Fill all info");
                }


            }
            else
            {
                MessageBox.Show("Wrong ID. Only Aiub Id.");
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
        }
    }
}
