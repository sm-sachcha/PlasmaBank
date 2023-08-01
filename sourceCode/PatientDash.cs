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
    public partial class PatientDash : Form
    {
        public PatientDash()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PName.Text))
            {
                MessageBox.Show("Please enter your UserID.");
                return;
            }
            if (string.IsNullOrWhiteSpace(Ppass.Text))
            {
                MessageBox.Show("Please enter your Password.");
                return;
            }
            if (string.IsNullOrWhiteSpace(Ppass.Text) && string.IsNullOrWhiteSpace(Ppass.Text))
            {
                MessageBox.Show("Please enter your UserID and Password.");
                return;
            }


            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PatientsTB where PName='" + PName.Text + "'and PPass='" + Ppass.Text + "'", Con);
            DataTable dt = new DataTable();
            //int v = sda.FillError;
            _ = sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                PatientDash2 Main = new PatientDash2();
                Main.Show();
                this.Hide();
                Con.Close();


            }
            else
            {
                MessageBox.Show("Wrong UserID or Password");
            }
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Ppass.PasswordChar == '\0')
            {
                button4.BringToFront();
                Ppass.PasswordChar = '*';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Ppass.PasswordChar == '*')
            {
                button3.BringToFront();
                Ppass.PasswordChar = '\0';
            }
        }

        private void EmpPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PatientDash_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to back?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
