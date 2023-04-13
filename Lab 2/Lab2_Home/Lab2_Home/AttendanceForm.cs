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
    public partial class AttendanceForm : Form
    {
        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            showCombo();
        }
        private void showGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select (StudentRegNo) from Enrollments", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void showCombo()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select (Name) from Course", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            da.Fill(dt);
            cmbCourse.ValueMember = "Name";
            cmbCourse.DataSource = dt;
        }

        private void cmbCourse_TextChanged(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT StudentRegNo FROM Enrollments WHERE CourseName = @CourseName", con);
            cmd.Parameters.AddWithValue("@CourseName", cmbCourse.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtreg.Text = dataGridView1.CurrentRow.Cells["StudentRegNo"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Attendance values (@StudentRegNo, @CourseName, @TimeStamp ,@Status)", con);
            cmd.Parameters.AddWithValue("@StudentRegNo", txtreg.Text);
            cmd.Parameters.AddWithValue("@CourseName", cmbCourse.Text);
            cmd.Parameters.AddWithValue("@TimeStamp", DateTime.Parse(txtdate.Text));
            cmd.Parameters.AddWithValue("@Status", true);
            cmd.ExecuteNonQuery();
        }

        private void btnAbsent_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Attendance values (@StudentRegNo, @CourseName, @TimeStamp ,@Status)", con);
            cmd.Parameters.AddWithValue("@StudentRegNo", txtreg.Text);
            cmd.Parameters.AddWithValue("@CourseName", cmbCourse.Text);
            cmd.Parameters.AddWithValue("@TimeStamp",DateTime.Parse(txtdate.Text));
            cmd.Parameters.AddWithValue("@Status", false);
            cmd.ExecuteNonQuery();
           // MessageBox.Show("Successfully Added");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage main = new MainPage();
            main.Show();
        }
    }
}
