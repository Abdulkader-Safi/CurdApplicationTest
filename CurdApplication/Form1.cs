using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CurdApplication.Models;
using CurdApplication.Controller;



namespace CurdApplication
{
    public partial class Form1 : Form
    {
        accountsContraller contraller;
        public Form1()
        {
            InitializeComponent();
            contraller = new accountsContraller();
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
                accounts account = new accounts(tbxFirstName.Text, tbxLastName.Text, tbxEmail.Text, Convert.ToInt32(tbxPhoneNumber.Text), comboGender.Text);
                contraller.addAccount(account);
                tbxFirstName.Text = String.Empty;
                tbxLastName.Text = String.Empty;
                tbxEmail.Text = String.Empty;
                tbxPhoneNumber.Text = String.Empty;
                comboGender.Text = String.Empty;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var accounts = contraller.getAccounts();
            dataGridView.DataSource = accounts;
        }
    }
}
