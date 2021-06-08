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

    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");
        public Admin()
        {
            InitializeComponent();
            userDB();

        }

        public String ind;

        public void userDB()
        {


            SqlDataAdapter da = null;
            DataTable dt1 = new DataTable();
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM SignUp "  , con);

            da.Fill(dt1);
            dataGridView2.DataSource = dt1;
            con.Close();
        }

        private char v1;
        private char v2;
        private char v3;
        private char v4;
        private char v5;
        private String id;
        

        public void setV1(char v1)
        {
            this.v1 = v1;
        }

        public void setV2(char v2)
        {
            this.v2 = v2;
        }

        public void setV3(char v3)
        {
            this.v3 = v3;
        }
        public void setV4(char v4)
        {
            this.v4 = v4;
        }

        public void setV5(char v5)
        {
            this.v5 = v5;
        }
        public char getV1()
        {
            return v1;
        }
        public char getV2()
        {
            return v2;
        }
        public char getV3()
        {
            return v3;
        }
        public char getV4()
        {
            return v4;
        }
        public char getV5()
        {
            return v5;
        }
        public String getId()
        {
            return id;
        }


        private void cafeInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cafe_Inventory ci = new Cafe_Inventory();
            ci.Show();
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Main main = new Main();
            main.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showSellDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selldtls selldtls = new Selldtls();
            selldtls.Show();
        }
        public bool IdVerification(String id)
        {
            this.id = id;
            try
            {
                char[] array = getId().ToCharArray();
                //Converting string to array...toCharArray is a default method for converting string to array..
                setV4(array[0]);
                setV5(array[1]);
                setV1(array[2]);
                setV2(array[8]);
                setV3(array[9]);
            }
            catch (Exception e)
            {
                MessageBox.Show("App Id is Not created");
                return false;
            }

            if (getV1() == '-')
            {
                if (getV2() == '-')
                {
                    if (getV3() == '1' || getV3() == '2' || getV3() == '3')
                    {
                        if (getV4() == '1')
                        {
                            if (getV5() >= '6' && getV5() <= '9')
                            {
                                MessageBox.Show("This User Aiub Id is valid.");
                                return true;
                               
                            }
                            else
                            {
                                MessageBox.Show("This User Aiub Id is Not valid.");
                                return false;
                            }
                        }
                        else if (getV4() == '2')
                        {
                            if (getV5() == '0')
                            {
                                MessageBox.Show("This User Aiub Id is valid.");
                                return true;

                            }
                            else
                            {
                                MessageBox.Show("This User Aiub Id is Not valid.");
                                return false;
                            }

                        }
                        else
                        {

                            MessageBox.Show("This User Aiub Id is Not valid.");
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("This User Aiub Id is Not valid.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("This User Aiub Id is Not valid.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("This User Aiub Id is Not valid.");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmpol addEmpol = new AddEmpol();
            addEmpol.Show();

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
                    SqlCommand com = new SqlCommand("DELETE FROM SignUp WHERE id= '" + int.Parse(ind) + "'", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
          
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Remonve();
            MessageBox.Show("An USER deleted ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            Main main = new Main();
            main.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            userDB();

            con.Close();
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ind = dataGridView2.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        }
    }
}
