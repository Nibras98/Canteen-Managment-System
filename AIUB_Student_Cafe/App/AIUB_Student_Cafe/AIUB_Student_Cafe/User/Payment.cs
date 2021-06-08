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
    public partial class Payment : Form
    {
        public String bill=null;
        int bb = 0;
        int bx = 0;
        SqlDataAdapter da = null;
        DataTable dt1 = new DataTable();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public Payment()
        {
            InitializeComponent();
            cartDB();
            richTextBox1.Text = "Total Price : " + bill;
        }
        public void cartDB()
        {
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM Selli", con);
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();
            
        }
        public void b(int b)
        {
            bb = b;
            bx = bx + bb;
            bill = bx.ToString();
            MessageBox.Show(bill);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thake you.");
            da = new SqlDataAdapter("DELETE FROM Selli", con);
            da.Fill(dt1);
            cartDB();
            //Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thake you.\n01750096696 this is our bkash number\n DO makepayment on that number.\n");
            MessageBox.Show("Thake you.");

            da = new SqlDataAdapter("DELETE FROM Selli", con);
            da.Fill(dt1);
            cartDB();
           // Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewcart viewcart = new Viewcart();
            viewcart.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Main main = new Main();
            main.Show();
        }
    }
}
