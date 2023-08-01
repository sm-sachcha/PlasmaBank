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
    public partial class AddDoner : Form
    {
        public AddDoner()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");

        private void Reset()
        {
            // Emp
            DName.Text = "";
            DAge.Text = "";
            DPhone.Text = "";
            DAdress.Text = "";
            DGender.SelectedIndex = -1;
            DGroup.SelectedIndex = -1;
        
            
           
        }
        private void button6_Click(object sender, EventArgs e)
        {
            View_Doner vd = new View_Doner();
            vd.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddDoner_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (  DName.Text == "" || DPhone.Text == "" || DGroup.SelectedIndex == -1 || DAge.Text == "" || DAdress.Text==""||DGender.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query = "insert into DonerTB values('" +DName.Text + "','" + DAge.Text + "','"+DGender.Text+ "','"+DPhone.Text+ "','"+DGroup.Text + "','" + DAdress.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doner Successfully Saved");
                    Con.Close();
                    Reset();
                   // populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                }

            }
        }

        private void DAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDoner ad = new AddDoner();
            ad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Transfer_Plasma tp = new Transfer_Plasma();
            tp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            MainDash obj1 = new MainDash();
            obj1.Show();
        }
    }
}
