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
    public partial class View_Doner : Form
    {
        public View_Doner()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=SM-SACHCHA\SQLEXPRESS;Initial Catalog=PlasmaBankDB;Integrated Security=True");

        public object DAdress { get; private set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            Con.Open();
            string Query = "select* from DonerTB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            _ = sda.Fill(ds);
            DonervDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void View_Doner_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void DonerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DName.Text = DonervDGV.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDoner ad = new AddDoner();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Doner vd = new View_Doner();
            vd.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transfer_Plasma tp = new Transfer_Plasma();
            tp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            AddDoner AD = new AddDoner();
            AD.Show();
        }
    }
}
