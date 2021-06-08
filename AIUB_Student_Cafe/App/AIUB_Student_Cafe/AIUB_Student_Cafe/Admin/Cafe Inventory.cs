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
    public partial class Cafe_Inventory : Form
    {
        public String ind;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public Cafe_Inventory()
        {
            InitializeComponent();
            ItemDB();
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
  

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Main main = new Main();
            main.Show();
        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            Close();
        }

        private void showSellDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cafeInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Cafe_Inventory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Remonve();
            MessageBox.Show("An Item deleted ");
        }
        public void Remonve()
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
    }
}
