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
        int ID;
        public Form1()
        {
            InitializeComponent();
            contraller = new accountsContraller();
            tabContraller.TabPages.Remove(tabPage2);
            getData();
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
            if(btnAddAccount.Text == "Add Account")
            {
                if (tbxFirstName.Text == String.Empty || tbxLastName.Text == String.Empty || tbxEmail.Text == String.Empty || tbxPhoneNumber.Text == String.Empty || comboGender.Text == String.Empty)
                {
                    string message = "Enter all data";
                    string title = "";
                    MessageBox.Show(message, title);
                }
                else
                {
                    accounts account = new accounts(tbxFirstName.Text, tbxLastName.Text, tbxEmail.Text, Convert.ToInt32(tbxPhoneNumber.Text), comboGender.Text);
                    contraller.Add(account);

                    emptyFields();

                    tabContraller.TabPages.Add(tabPage1);
                    tabContraller.SelectedTab = tabPage1;
                    tabContraller.TabPages.Remove(tabPage2);
                    getData();
                }
            }
            else if (btnAddAccount.Text == "Update Account")
            {
                if (tbxFirstName.Text == String.Empty || tbxLastName.Text == String.Empty || tbxEmail.Text == String.Empty || tbxPhoneNumber.Text == String.Empty || comboGender.Text == String.Empty)
                {
                    string message = "Enter all data";
                    string title = "";
                    MessageBox.Show(message, title);
                }
                else
                {
                    accounts account = new accounts(tbxFirstName.Text, tbxLastName.Text, tbxEmail.Text, Convert.ToInt32(tbxPhoneNumber.Text), comboGender.Text);
                    contraller.Update(account, ID);

                    emptyFields();

                    tabContraller.TabPages.Add(tabPage1);
                    tabContraller.SelectedTab = tabPage1;
                    tabContraller.TabPages.Remove(tabPage2);
                    getData();
                }
            }
            
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            tabContraller.SelectedTab = tabPage2;
            tabContraller.TabPages.Add(tabPage2);
            tabContraller.TabPages.Remove(tabPage1);
            btnAddAccount.Text = "Add Account";
            insertDataPanel.Enabled = true;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            tabContraller.TabPages.Add(tabPage1);
            tabContraller.SelectedTab = tabPage1;

            emptyFields();

            tabContraller.TabPages.Remove(tabPage2);
            insertDataPanel.Enabled = false;
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                ID = Convert.ToInt32(row.Cells[0].Value);
                tbxFirstName.Text = row.Cells[1].Value.ToString();
                tbxLastName.Text = row.Cells[2].Value.ToString();
                tbxEmail.Text = row.Cells[3].Value.ToString();
                tbxPhoneNumber.Text = row.Cells[4].Value.ToString();
                comboGender.Text = row.Cells[5].Value.ToString();
            }

            tabContraller.TabPages.Add(tabPage2);
            tabContraller.SelectedTab = tabPage2;
            tabContraller.TabPages.Remove(tabPage1);

            btnAddAccount.Text = "Update Account";
            insertDataPanel.Enabled = true;
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                ID = Convert.ToInt32(row.Cells[0].Value);
                contraller.Delete(ID);
                getData();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(tbxSearchName.Text == String.Empty)
            {
                getData();
            }
            else
            {
                var accounts = contraller.Search(tbxSearchName.Text);
                dataGridView.DataSource = accounts;
                insertDataPanel.Enabled = false;
            }
        }

        public void getData()
        {
            var accounts = contraller.GetAll();
            dataGridView.DataSource = accounts;
            insertDataPanel.Enabled = false;
        }

        public void emptyFields()
        {         
            tbxFirstName.Text = String.Empty;
            tbxLastName.Text = String.Empty;
            tbxEmail.Text = String.Empty;
            tbxPhoneNumber.Text = String.Empty;
        }
    }
}
