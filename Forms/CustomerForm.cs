using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace C969___Axl_Nunez.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                // Simulated data; replace with database query
                var dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Address");
                dt.Columns.Add("City");
                dt.Columns.Add("Country");
                dt.Columns.Add("Phone");
                dt.Rows.Add("John Doe", "123 Main St", "New York", "USA", "123-456-7890");
                dgvCustomers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCustomer())
                {
                    // Simulated database insertion
                    MessageBox.Show("Customer added successfully!");
                    ClearFields();
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCustomer())
                {
                    // Simulated database update
                    MessageBox.Show("Customer updated successfully!");
                    ClearFields();
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.SelectedRows.Count > 0)
                {
                    // Simulated database deletion
                    MessageBox.Show("Customer deleted successfully!");
                    LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}");
            }
        }

        private bool ValidateCustomer()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("All fields are required.");
                return false;
            }

            if (!Regex.IsMatch(txtPhone.Text, @"^[\d-]+$"))
            {
                MessageBox.Show("Invalid phone number format.");
                return false;
            }

            return true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
        }
    }
}
