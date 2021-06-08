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
    public partial class ViewItem : Form
    {

        public int p;
        public String name;
        SqlCommand com;
        SqlDataReader dr;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public void userDB()
        {
            SqlDataAdapter da = null;
            DataTable dt2 = new DataTable();
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM Item ", con);
            da.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }
        public ViewItem()
        {
            InitializeComponent();
            userDB();
        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            p.Show();
            Close();
        }
        public int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            i++;

        con.Open();
            com = new SqlCommand("SELECT * FROM Item WHERE Id= " + int.Parse(textBox2.Text), con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                try
                {

                    String v = (dr["Name"].ToString());
                    if (v == "Coffee")
                    {
                        name = v;
                        MessageBox.Show("Your Coffee added to cart");
                        p = 50 * int.Parse(this.textBox1.Text);
                        Payment payment = new Payment();
                        payment.b(p);

                    }
                    else if (v == "Cake")
                    {
                        name = v;
                        MessageBox.Show("Your Cake added to cart");
                        p = 75 * int.Parse(this.textBox1.Text);
                        Payment payment = new Payment();
                        payment.b(p);
                    }
                    else
                    {
                        name = v;
                        MessageBox.Show("Your Burger added to cart");
                        p = 150 * int.Parse(this.textBox1.Text);
                        Payment payment = new Payment();
                        payment.b(p);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            con.Close();
            try
            {
                if (textBox2.Text == null)
                {
                    MessageBox.Show("Not selected");
                }
                else
                {
                    con.Open();
                    com = new SqlCommand("INSERT INTO Selli (Count,Number,Name,quantity,Price) values (@Count,@Number,@Name,@quantity,@Price)", con);
                    com.Parameters.AddWithValue("@Count", i);
                    com.Parameters.AddWithValue("@Number", int.Parse(textBox2.Text));
                    com.Parameters.AddWithValue("@quantity", int.Parse(this.textBox1.Text));
                    com.Parameters.AddWithValue("@Name", name);
                    com.Parameters.AddWithValue("@Price", p);
                    // com.ExecuteNonQuery();
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("An Item Added.");
                        i++;
                        Close();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            try
            {
                if (textBox2.Text == null)
                {
                    MessageBox.Show("Not selected");
                }
                else
                {
                    con.Open();
                    com = new SqlCommand("INSERT INTO AllSelli (Count,Number,Name,quantity,Price) values (@Count,@Number,@Name,@quantity,@Price)", con);
                    com.Parameters.AddWithValue("@Count", i);
                    com.Parameters.AddWithValue("@Number", int.Parse(textBox2.Text));
                    com.Parameters.AddWithValue("@quantity", int.Parse(this.textBox1.Text));
                    com.Parameters.AddWithValue("@Name", name);
                    com.Parameters.AddWithValue("@Price", p);
                    // com.ExecuteNonQuery();
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("An Item Added.");
                       
                        Close();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void viewCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewcart viewcart =new Viewcart();
            viewcart.Show();
            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
