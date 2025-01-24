using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace C969___Axl_Nunez.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly string connectionString;

        public CustomerForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            LoadCustomers();
            dgvCustomers.ClearSelection();
        }

        private void LoadCustomers()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            c.customerId AS `CustomerId`,
                            c.customerName AS `Name`,
                            a.address AS `Address`,
                            ct.city AS `City`,
                            co.country AS `Country`,
                            a.phone AS `Phone`
                        FROM customer c
                        INNER JOIN address a ON c.addressId = a.addressId
                        INNER JOIN city ct ON a.cityId = ct.cityId
                        INNER JOIN country co ON ct.countryId = co.countryId";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dgvCustomers.DataSource = dt;
                    }
                }

                dgvCustomers.Columns["CustomerId"].Visible = false;
                dgvCustomers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}");
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCustomers.SelectedRows[0];

                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                txtCity.Text = selectedRow.Cells["City"].Value.ToString();
                txtCountry.Text = selectedRow.Cells["Country"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["Phone"].Value.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCustomer())
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = @"
                            INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                            VALUES (@name, @addressId, 1, NOW(), 'system', NOW(), 'system')";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            int addressId = GetAddressId(connection);

                            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@addressId", addressId);
                            cmd.ExecuteNonQuery();
                        }
                    }
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
                if (dgvCustomers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer to update.");
                    return;
                }

                if (ValidateCustomer())
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = @"
                            UPDATE customer 
                            SET customerName = @name 
                            WHERE customerId = @customerId";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            var selectedRow = dgvCustomers.SelectedRows[0];
                            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@customerId", selectedRow.Cells["CustomerId"].Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
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
                if (dgvCustomers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer to delete.");
                    return;
                }

                var selectedRow = dgvCustomers.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteAppointmentsQuery = "DELETE FROM appointment WHERE customerId = @customerId";
                    using (var cmd = new MySqlCommand(deleteAppointmentsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @customerId";
                    using (var cmd = new MySqlCommand(deleteCustomerQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Customer and related appointments deleted successfully!");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}");
            }
        }

        private int GetAddressId(MySqlConnection connection)
        {
            string query = @"
        SELECT addressId FROM address 
        WHERE address = @address AND cityId = @cityId AND phone = @phone";

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@cityId", GetCityId(connection));
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    string insertQuery = @"
                INSERT INTO address (address, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@address, @cityId, '00000', @phone, NOW(), 'system', NOW(), 'system');
                SELECT LAST_INSERT_ID();";

                    using (var insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@cityId", GetCityId(connection));
                        insertCmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        return Convert.ToInt32(insertCmd.ExecuteScalar());
                    }
                }
            }
        }

        private int GetCityId(MySqlConnection connection)
        {
            string query = "SELECT cityId FROM city WHERE city = @city";

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    string insertQuery = @"
                INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@city, 1, NOW(), 'system', NOW(), 'system');
                SELECT LAST_INSERT_ID();";

                    using (var insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
                        return Convert.ToInt32(insertCmd.ExecuteScalar());
                    }
                }
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
            dgvCustomers.ClearSelection();
        }
    }
}
