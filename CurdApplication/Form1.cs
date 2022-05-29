using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;


namespace CurdApplication
{
    public partial class Form1 : Form
    {

        string connection;

        public Form1()
        {
            InitializeComponent();
            connection = ConfigurationManager.ConnectionStrings["testCrud"].ConnectionString;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if(tbxFirstName.Text == String.Empty || tbxLastName.Text == String.Empty || tbxEmail.Text == String.Empty || tbxPhoneNumber.Text == String.Empty || comboGender.Text == String.Empty)
            {
                string message = "Enter all data";
                string title = "";
                MessageBox.Show(message, title);
            }
            else
            {
                using (var dbConnection = new SqlConnection(connection))
                {
                    using (var dbCommand = new SqlCommand())
                    {
                        dbConnection.Open();
                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = @"insert into accounts (fristName, lastName,email,phoneNumber,gender)
                                            values
                                            (@fName, @lName, @email, @phone, @gender)";
                        dbCommand.Parameters.Add("@fName", SqlDbType.VarChar).Value = tbxFirstName.Text;
                        dbCommand.Parameters.Add("@lName", SqlDbType.VarChar).Value = tbxLastName.Text;
                        dbCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = tbxEmail.Text;
                        dbCommand.Parameters.Add("@phone", SqlDbType.Int).Value = Convert.ToInt32(tbxPhoneNumber.Text);
                        dbCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = comboGender.Text;
                        dbCommand.ExecuteNonQuery();
                    }
                }
            }
            
        }
    }
}
