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
    public partial class Empo : Form
    {
        
        public Empo()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=AIUB_Cafe;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Cafe_Inventory ci = new Cafe_Inventory();
            ci.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                ViewItem v = new ViewItem();
                v.Show();
            }
            else
            {
                MessageBox.Show("Enter Id for who you r ordaring");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

