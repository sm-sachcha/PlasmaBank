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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");
        private void Employee_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
           // Emp
            EmpName.Text = "";
            EmpPass.Text = "";
            EmpAge.Text = "";
          //  EmpID.Text = "";
            EmpPhone.Text = "";
            EmpAdress.Text = "";
            key = 0;
        }

        private void populate()
        {
            Con.Open();
            string Query = "select* from EmpTB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            _ = sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpPass.Text == "" || EmpAge.Text == ""  || EmpPhone.Text == "" || EmpAdress.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query ="insert into EmpTB values('"+ EmpName.Text+"','"+ EmpPass.Text + "','"+EmpAge.Text+"','"+EmpPhone.Text+"','"+EmpAdress.Text+"')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Saved");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close(); 
                }

            }
        }
        int key = 0;
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpName.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
           EmpPass.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
          EmpAge.Text = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
           EmpPhone.Text = EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
           EmpAdress.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();


            if (EmpName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmpDGV.SelectedRows[0].Cells[3].Value.ToString()); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpPass.Text == "" || EmpAge.Text == "" || EmpPhone.Text == "" || EmpAdress.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "Update EmpTB set EmpName='" + EmpName.Text + "',EmpPass='" + EmpPass.Text + "',EmpAge='" + EmpAge.Text + "',EmpPhone='" + EmpPhone.Text+ "',EmpAdress='" + EmpAdress.Text+ "'Where EmpID=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Employee Successfully Updated");
                    Con.Close();
                    Reset();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select the Employee for delete");
            }
            else
            {
                try
                {
                    string query = "Delete from EmpTB where EmpID =" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Deleted");
                    Con.Close();
                    Reset();
                    populate();
                    
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to Logout?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EmpPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
