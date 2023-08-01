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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(70, Color.Black);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, Color.White);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpName.Text))
            {
                MessageBox.Show("Please enter your UserID.");
                return;
            }
            if (string.IsNullOrWhiteSpace(EmpPass.Text))
            {
                MessageBox.Show("Please enter your Password.");
                return;
            }
            if (string.IsNullOrWhiteSpace(EmpName.Text) && string.IsNullOrWhiteSpace(EmpPass.Text))
            {
                MessageBox.Show("Please enter your UserID and Password.");
                return;
            }


            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmpTB where EmpName='" + EmpName.Text + "'and EmpPass='" + EmpPass.Text + "'",Con);
            DataTable dt = new DataTable();
            //int v = sda.FillError;
            _ = sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                MainDash Main = new MainDash();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(EmpPass.PasswordChar == '*')
            {
                button3.BringToFront();
                EmpPass.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpPass.PasswordChar == '\0')
            {
                button4.BringToFront();
                EmpPass.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin Adm = new AdminLogin();
            Adm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to exit Application", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void EmpPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            PatientDash Adm = new PatientDash();
            Adm.Show();
            this.Hide();
        }
    }
}
