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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");
        private void Reset()
        {
            // Emp
            PName.Text = "";
            PAge.Text = "";
            PPhone.Text = "";
            PGender.SelectedIndex = -1;
            PGroup.SelectedIndex = -1;
            PAdress.Text = "";
            PPass.Text = "";
            key = 0;

        }
        private void Patient_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
        private void populate()
        {
            Con.Open();
            string Query = "select* from PatientsTB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            _ = sda.Fill(ds);
            PatientDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PAge.Text == "" || PPhone.Text == "" || PGender.SelectedIndex == -1 || PGroup.SelectedIndex == -1 ||PAdress.Text==""||PPass.Text=="")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query = "insert into PatientsTB values('" + PName.Text + "','" + PAge.Text + "','"  + PPhone.Text + "','" + PGender.Text + "','" + PGroup.Text + "','" + PAdress.Text+ "','"+PPass.Text+ "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Saved");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PAge.Text == "" || PPhone.Text == "" || PGender.SelectedIndex == -1 || PGroup.SelectedIndex == -1 || PAdress.Text == ""||PPass.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "Update PatientsTB set PName='" + PName.Text + "',PAge='" + PAge.Text + "',PPhone='" + PPhone.Text + "',PGender='" + PGender.SelectedItem + "',PGroup='" + PGroup.SelectedItem + "',PAddress='" + PAdress.Text + "',PPass='" + PPass.Text + "'Where PNum=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Updated");
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
        int key = 0;
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PName.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAge.Text = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
            PPhone.Text = PatientDGV.SelectedRows[0].Cells[3].Value.ToString();
            PGender.SelectedItem = PatientDGV.SelectedRows[0].Cells[4].Value.ToString();
            PGroup.SelectedItem = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
            PAdress.Text = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();
            PPass.Text = PatientDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (PName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select the Patient for delete");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientsTB where PNum=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Deleted");
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

        private void PAge_TextChanged(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {
            Transfer_Plasma tp = new Transfer_Plasma();
            tp.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            View_Doner obj1 = new View_Doner();
            obj1.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
