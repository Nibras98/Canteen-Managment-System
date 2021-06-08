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
    public partial class AddItem : Form
    {
        public string ind;
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");

        public AddItem()
        {
            InitializeComponent();
            ItemDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO Item (ID,Name,quantity,Price) values (@ID,@Name,@quantity,@Price)", con);
                    com.Parameters.AddWithValue("@ID", this.textBox2.Text.ToString());
                    com.Parameters.AddWithValue("@quantity", numericUpDown1.Value.ToString());
                    com.Parameters.AddWithValue("@Name", this.textBox3.Text.ToString());
                    com.Parameters.AddWithValue("@Price", this.textBox1.Text.ToString());
                    // com.ExecuteNonQuery();
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("An Item Added.");
                        Close();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                 con.Close();
                }
        
        }
        public void ItemDB()
        {
            SqlDataAdapter da = null;
            DataTable dt2 = new DataTable();
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM Item ", con);
            da.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemDB();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ind == null)
                {
                    MessageBox.Show("Not selected");
                }

                else
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("DELETE FROM Item WHERE id= '" + int.Parse(ind) + "'", con);

                    com.ExecuteNonQuery();
                    MessageBox.Show("An Item deleted ");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ind = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          /*  try
            {*/
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE Item ('quantity') values ('@quantity') WHERE id= '" + int.Parse(ind) + "'", con);
                com.Parameters.AddWithValue("@quantity", numericUpDown1.Value.ToString());
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("An Item Updated. ");
                    Close();
                }
                con.Close();
           /* }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
                con.Close();
            }*/
        }
    }
}
