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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab2_Home
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@RegistrationNumber, @Name, @Department ,@Session ,@Address)", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", txtreg.Text);
            cmd.Parameters.AddWithValue("@Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Department", txtdept.Text);
            cmd.Parameters.AddWithValue("@Session", txtsess.Text);
            cmd.Parameters.AddWithValue("@Address", txtadd.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Added");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudent form = new ViewStudent();
            form.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM Student where RegistrationNumber = @RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", txtreg.Text);
            cmd.Parameters.AddWithValue("@Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Department", txtdept.Text);
            cmd.Parameters.AddWithValue("@Session", txtsess.Text);
            cmd.Parameters.AddWithValue("@Address", txtadd.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update Student SET Name= @Name,Department = @Department , Session = @Session , Address = @Address where RegistrationNumber = @RegistrationNumber ", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", txtreg.Text);
            cmd.Parameters.AddWithValue("@Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Department", txtdept.Text);
            cmd.Parameters.AddWithValue("@Session", txtsess.Text);
            cmd.Parameters.AddWithValue("@Address", txtadd.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage myForm = new MainPage();
            myForm.ShowDialog();
        }
    }
}
