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

namespace Lab2_Home
{
    public partial class course : Form
    {
        public course()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage myForm = new MainPage();
            myForm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Course values (@Name,@Code)", con);
            cmd.Parameters.AddWithValue("@Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Code", txtcode.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Added");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCourse myForm = new ViewCourse();
            myForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM Course where Code = @Code", con);
            cmd.Parameters.AddWithValue("@Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Code", txtcode.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update Course SET Name= @Name  where Code = @Code ", con);
            cmd.Parameters.AddWithValue("@Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Code", txtcode.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
        }
    }
}
