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
namespace PlasmaBank
{
    public partial class Transfer_Plasma : Form
    {
        public Transfer_Plasma()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string Query = "select* from DonerTB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            _ = sda.Fill(ds);
            DonerDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void bloodStock()
        {
            Con.Open();
            string Query = "select* from BloodTB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            _ = sda.Fill(ds);
            BloodDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            Con.Open();
            string Query = "select * from BloodTB where BGroup='"+ Bgroup +"'";
            SqlCommand sda = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sda);
            var ds = new DataSet();
            _ = sd.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
 
            Con.Close();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Transfer_Plasma tp = new Transfer_Plasma();
            tp.Show();
            this.Hide();
        }

        private void Transfer_Plasma_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

       
        private void DonerDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DName.Text = DonerDGV.SelectedRows[0].Cells[1].Value.ToString();
            DGroup.Text = DonerDGV.SelectedRows[0].Cells[5].Value.ToString();
            GetStock(DGroup.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void reset()
        {
            DName.Text = "";
            DGroup.Text = "";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(DName.Text=="")
            {
                MessageBox.Show("Select A Doner");
            }
            else
            {
                try
                {
                    int stock = oldstock+ 1;
                    string query = "Update BloodTB set BStock=" + stock +"where BGroup='"+DGroup.Text+ "';";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Donation Successfully ");
                    Con.Close();
                   reset();
                    bloodStock();
                  

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
               

            }
        }

        private void BloodDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddDoner ad = new AddDoner();
            ad.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            View_Doner vd = new View_Doner();
            vd.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainDash obj1 = new MainDash();
            obj1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Patient obj1 = new Patient();
            obj1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
