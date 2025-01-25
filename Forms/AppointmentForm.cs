using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace C969___Axl_Nunez.Forms
{
    public partial class AppointmentForm : Form
    {
        private readonly string connectionString;

        public AppointmentForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            LoadAppointments();
            LoadCustomers();
            LoadTypes();
            dgvAppointments.ClearSelection();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
        }

        private void LoadAppointments()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    a.appointmentId AS `AppointmentId`,
                    a.title AS `Title`,
                    c.customerName AS `Customer`,
                    a.start AS `Start Time`,
                    a.end AS `End Time`,
                    a.type AS `Type`
                FROM appointment a
                INNER JOIN customer c ON a.customerId = c.customerId";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);

                        // Convert times to local time zone
                        foreach (DataRow row in dt.Rows)
                        {
                            row["Start Time"] = ConvertFromUtc((DateTime)row["Start Time"]);
                            row["End Time"] = ConvertFromUtc((DateTime)row["End Time"]);
                        }

                        dgvAppointments.DataSource = dt;
                    }
                }

                if (dgvAppointments.Columns.Contains("AppointmentId"))
                {
                    dgvAppointments.Columns["AppointmentId"].Visible = false;
                }

                dgvAppointments.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }


        private void LoadCustomers()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT customerId, customerName FROM customer";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbCustomer.Items.Clear();
                        while (reader.Read())
                        {
                            cmbCustomer.Items.Add(new { Id = reader.GetInt32("customerId"), Name = reader.GetString("customerName") });
                        }
                        cmbCustomer.DisplayMember = "Name";
                        cmbCustomer.ValueMember = "Id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}");
            }
        }

        private void LoadTypes()
        {
            cmbType.Items.Clear();
            cmbType.Items.Add("Consultation");
            cmbType.Items.Add("Follow-Up");
            cmbType.Items.Add("Review");
            cmbType.Items.Add("Other");
        }

        private DateTime ConvertToUtc(DateTime localTime)
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local; // User's local time zone
            return TimeZoneInfo.ConvertTimeToUtc(localTime, localZone);
        }

        private DateTime ConvertFromUtc(DateTime utcTime)
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local; // User's local time zone
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, localZone);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAppointment())
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = @"
                            INSERT INTO appointment (customerId, userId, title, description, location, contact, type, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
                            VALUES (@customerId, 1, @title, @description, 'Default Location', 'Default Contact', @type, @start, @end, NOW(), 'system', NOW(), 'system')";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@customerId", ((dynamic)cmbCustomer.SelectedItem).Id);
                            cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@type", cmbType.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@start", ConvertToUtc(dtpStartTime.Value));
                            cmd.Parameters.AddWithValue("@end", ConvertToUtc(dtpEndTime.Value));

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Appointment added successfully!");
                    ClearFields();
                    LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding appointment: {ex.Message}");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAppointments.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to update.");
                    return;
                }

                if (ValidateAppointment())
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = @"
                            UPDATE appointment
                            SET title = @title, description = @description, type = @type, start = @start, end = @end
                            WHERE appointmentId = @appointmentId";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            var selectedRow = dgvAppointments.SelectedRows[0];
                            cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@type", cmbType.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@start", dtpStartTime.Value);
                            cmd.Parameters.AddWithValue("@end", dtpEndTime.Value);
                            cmd.Parameters.AddWithValue("@appointmentId", selectedRow.Cells["AppointmentId"].Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Appointment updated successfully!");
                    ClearFields();
                    LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating appointment: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAppointments.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to delete.");
                    return;
                }

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        var selectedRow = dgvAppointments.SelectedRows[0];
                        cmd.Parameters.AddWithValue("@appointmentId", selectedRow.Cells["AppointmentId"].Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Appointment deleted successfully!");
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting appointment: {ex.Message}");
            }
        }


        private DateTime AdjustToTimeZone(DateTime dateTime)
        {
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, est);
        }

        private bool ValidateAppointment()
        {
            if (cmbCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.");
                return false;
            }

            if (dtpStartTime.Value >= dtpEndTime.Value)
            {
                MessageBox.Show("Start time must be earlier than end time.");
                return false;
            }

            if (!IsWithinBusinessHours(dtpStartTime.Value, dtpEndTime.Value))
            {
                MessageBox.Show("Appointments must be scheduled during business hours (9:00 AM to 5:00 PM, Monday–Friday).");
                return false;
            }

            if (CheckOverlappingAppointments(dtpStartTime.Value, dtpEndTime.Value))
            {
                MessageBox.Show("The appointment overlaps with an existing one.");
                return false;
            }

            return true;
        }

        private bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            var startOfDay = new TimeSpan(9, 0, 0);
            var endOfDay = new TimeSpan(17, 0, 0);

            return start.TimeOfDay >= startOfDay && end.TimeOfDay <= endOfDay &&
                   start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday;
        }
        private bool CheckOverlappingAppointments(DateTime start, DateTime end)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT COUNT(*)
                        FROM appointment
                        WHERE @start < end AND @end > start AND customerId = @customerId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@start", AdjustToTimeZone(start));
                        cmd.Parameters.AddWithValue("@end", AdjustToTimeZone(end));
                        cmd.Parameters.AddWithValue("@customerId", ((dynamic)cmbCustomer.SelectedItem).Id);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking overlapping appointments: {ex.Message}");
                return false;
            }
        }

        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvAppointments.SelectedRows[0];

                // Populate the form controls
                txtTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                cmbCustomer.SelectedIndex = cmbCustomer.FindStringExact(selectedRow.Cells["Customer"].Value.ToString());
                cmbType.SelectedIndex = cmbType.FindStringExact(selectedRow.Cells["Type"].Value.ToString());

                dtpStartTime.Value = DateTime.Parse(selectedRow.Cells["Start Time"].Value.ToString());
                dtpEndTime.Value = DateTime.Parse(selectedRow.Cells["End Time"].Value.ToString());
            }
        }

        public void CheckForUpcomingAppointments(string username)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    a.title, 
                    a.start 
                FROM appointment a
                INNER JOIN user u ON a.userId = u.userId
                WHERE u.username = @username
                AND TIMESTAMPDIFF(MINUTE, NOW(), a.start) BETWEEN 0 AND 15";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string title = reader["title"].ToString();
                                    DateTime start = ConvertFromUtc((DateTime)reader["start"]);
                                    MessageBox.Show($"Upcoming Appointment: {title} at {start}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for upcoming appointments: {ex.Message}");
            }
        }



        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        private void ClearFields()
        {
            cmbCustomer.SelectedIndex = -1;
            txtTitle.Text = "";
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
            cmbType.SelectedIndex = -1;
            txtDescription.Text = "";
        }
    }
}
