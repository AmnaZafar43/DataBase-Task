using CrudOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab2_Home
{
    public partial class UnRegisterForm : Form
    {
        public UnRegisterForm()
        {
            InitializeComponent();
        }

        private void UnRegisterForm_Load(object sender, EventArgs e)
        {
            cmbfunc();
            viewGrid();
            
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteData();
            viewGrid();
            MessageBox.Show("Successfully Unregistered");
        }
        private void cmbfunc()
        {
            // load data in combo box
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select (Name) from Course", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            da.Fill(dt);
            cmbCourse.ValueMember = "Name";
            cmbCourse.DataSource = dt;
        }
        void viewGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Enrollments", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        void deleteData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM Enrollments where StudentRegNo = @StudentRegNo", con);
            cmd.Parameters.AddWithValue("@StudentRegNo", txtreg.Text);
            cmd.Parameters.AddWithValue("@CourseName", cmbCourse.Text);
            cmd.ExecuteNonQuery();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm myForm = new RegisterForm();
            myForm.ShowDialog();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
