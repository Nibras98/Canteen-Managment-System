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
    public partial class Viewcart : Form
    {
        public String ind;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public Viewcart()
        {
            InitializeComponent();
            cartDB();
        }
        public void cartDB()
        {

            SqlDataAdapter da = null;
            DataTable dt1 = new DataTable();
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM Selli", con);
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            p.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewItem viewItem = new ViewItem();
            viewItem.Show();
            Close();
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
                    SqlCommand com = new SqlCommand("DELETE FROM Selli WHERE Number= '" + int.Parse(ind) + "'", con);

                    com.ExecuteNonQuery();
                    MessageBox.Show("An item deleted ");
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
            ind = dataGridView1.Rows[e.RowIndex].Cells["Number"].Value.ToString();
            if(ind!=null)
            {
                MessageBox.Show("Sellected");
            }
        }
    }
}
