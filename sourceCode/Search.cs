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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");
        public void SearchData(string vlToSe)
        {
           // SqlCommand("Select * from AccountTable where AccNum = @AccNum", conn);
        }
        private void TransferP_Click(object sender, EventArgs e)
        {
       
            
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DonerTB where DName = @DName", Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@DName", DonerName.Text);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

        }

        private void PName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDoner ad = new AddDoner();
            ad.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            View_Doner vd = new View_Doner();
            vd.Show();
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

        private void SearchPatient_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmdp = new SqlCommand("Select * from PatientsTB where PName = @PName", Con);
            SqlDataAdapter dap = new SqlDataAdapter(cmdp);
            cmdp.Parameters.AddWithValue("@PName", PatientName.Text);
            DataTable dataTable = new DataTable();
            dap.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            Con.Close();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainDash obj1 = new MainDash();
            obj1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
