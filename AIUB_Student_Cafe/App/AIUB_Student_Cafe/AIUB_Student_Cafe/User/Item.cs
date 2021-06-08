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
    public partial class Item : Form
    {
        SqlCommand com;
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public Item()
        {
            InitializeComponent();
        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewItem v = new ViewItem();
            v.Show();
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        public int i = 110;

        private void button4_Click(object sender, EventArgs e)
        {
            i++;
            con.Open();
            com = new SqlCommand("INSERT INTO Selli (Count,Number,Name,quantity,Price) values (@Count,@Number,@Name,@quantity,@Price)", con);
            com.Parameters.AddWithValue("@Count", i);
            com.Parameters.AddWithValue("@Number", 1111);
            com.Parameters.AddWithValue("@quantity",1);
            com.Parameters.AddWithValue("@Name", "Offer-1");
            com.Parameters.AddWithValue("@Price", 125);
            // com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("An Item Added.");
                int p = 125;
                Payment payment = new Payment();
                payment.b(p);
                Close();
            }
            con.Close();
            MessageBox.Show("Your Iteam have been added.");
            try
            {
              
                    con.Open();
                    com = new SqlCommand("INSERT INTO AllSelli (Count,Number,Name,quantity,Price) values (@Count,@Number,@Name,@quantity,@Price)", con);
                    com.Parameters.AddWithValue("@Count", i);
                com.Parameters.AddWithValue("@Number", 1111);
                com.Parameters.AddWithValue("@quantity", 1);
                    com.Parameters.AddWithValue("@Name", "Offer-1");
                    com.Parameters.AddWithValue("@Price", 125);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
