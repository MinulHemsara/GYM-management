using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gym_Management_System_0._0
{
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        { 
        }

        private void NewMember_Load(object sender, EventArgs e)
        { 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String fname = txtFirstName.Text;
                String lname = txtLastName.Text;
                String gender = "";

                bool isChacked = radioButton1.Checked;
                if (isChacked)
                {
                    gender = radioButton1.Text;
                }
                else
                {
                    gender = radioButton2.Text;
                }

                String dob = dateTimePickerDOB.Text;
                int mobile = Convert.ToInt32(txtMobile.Text);
                String email = txtEmail.Text;
                string joindate = dateTimePickerJoinDate.Text;
                string gymtime = comboBoxGymTime.Text;
                string address = txtAddress.Text;
                string membership = ComboBoxMembership.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-R1TI7EBQ;Initial Catalog=gym;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "insert into NewMember (Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Gymtime,Maddress,MemberShipTime) values ('" + fname + "', '" + lname + "', '" + gender + "', '" + dob + "', '" + mobile + "', '" + email + "', '" + joindate + "', '" + gymtime + "', '" + address + "', '" + membership + "')";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("Data Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
             catch (Exception)
            {
                MessageBox.Show("Pleace Check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            radioButton1.Checked= false;
            radioButton2.Checked= false;
            txtMobile.Clear();
            txtEmail.Clear();
            comboBoxGymTime.ResetText();
            ComboBoxMembership.ResetText();
            txtAddress.Clear();

            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJoinDate.Value = DateTime.Now;

        }

        private void dateTimePickerJoinDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
