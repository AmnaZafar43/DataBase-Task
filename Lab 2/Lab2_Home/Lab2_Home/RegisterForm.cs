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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UnRegisterForm myForm = new UnRegisterForm();
            myForm.ShowDialog();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select (Name) from Course", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name",typeof(string));
            da.Fill(dt);
            cmbCourse.ValueMember = "Name";
            cmbCourse.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Enrollments values (@RegistrationNumber,@Course)", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", txtreg.Text);
            cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Registered");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage main=new MainPage();
            main.Show();
        }
    }
}
