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
    public partial class Main : Form
    {
        SqlCommand com;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        SqlDataAdapter da2;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public Main()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            da1 = new SqlDataAdapter("DELETE FROM Selli", con);
            da2 = new SqlDataAdapter("DELETE FROM AllSelli", con);
            da1.Fill(dt1);
            da2.Fill(dt2);
            Close();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            con.Close();

            String aid = Convert.ToString(NameSI.Text);
            try
            {
                con.Open();
                com = new SqlCommand("SELECT * FROM SignUp WHERE Id= '" + NameSI.Text.ToString() + "'and Password='" + PassSI.Text.ToString() + "'", con);
                da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataReader dr = com.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    con.Close();
                    con.Open();
                    SqlCommand com = new SqlCommand("SELECT * FROM SignUp WHERE Id= " + int.Parse(NameSI.Text), con);
                    
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        try
                        {

                            String v = (dr["UserType"].ToString());
                            if (v == "Employee")
                            {
                                
                                Empo empo = new Empo();
                                empo.Show();
                               // this.Close();
                            }
                            else if (v == "Customer")
                            {
                                
                                ViewItem viewItem = new ViewItem();
                                viewItem.Show();
                                //this.Close();
                            }
                            else
                            {

                                Admin admin = new Admin();
                                admin.Show();
                                //this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Close();
                        }
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Your Id is not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUpFor s = new SignUpFor();
            s.Show();
            this.Hide();

        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We are AIUBian for you. We maintain our cafe by AIUBian students.\nLove to take your order if you want we can deliver to you.\nDelivery is only availabe in side university area. Not outside of this universty area");
        }

        private void cafeInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("01750096696 is our phone number.\nYou can find us beside of tong");
        }

        private void NameSI_TextChanged(object sender, EventArgs e)
        {

        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }
    }
}

