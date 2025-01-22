using System;
using System.Data;
using System.Windows.Forms;

namespace C969___Axl_Nunez.Forms
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadAppointments();
            LoadCustomers();
        }

        private void LoadAppointments()
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Customer");
                dt.Columns.Add("Title");
                dt.Columns.Add("Start Time");
                dt.Columns.Add("End Time");
                dt.Columns.Add("Type");

                // Placeholder data - Replace with database query
                dt.Rows.Add("John Doe", "Meeting", "2025-01-21 10:00", "2025-01-21 11:00", "Consultation");
                dgvAppointments.DataSource = dt;
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
                // Placeholder data - Replace with database query
                cmbCustomer.Items.Add("John Doe");
                cmbCustomer.Items.Add("Jane Smith");
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
                if (ValidateAppointment())
                {
                    MessageBox.Show("Appointment added successfully!");
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
                if (ValidateAppointment())
                {
                    MessageBox.Show("Appointment updated successfully!");
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
                if (dgvAppointments.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Appointment deleted successfully!");
                    LoadAppointments();
                }
                else
                {
                    MessageBox.Show("Please select an appointment to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting appointment: {ex.Message}");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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
            // Placeholder logic - Replace with database query to check for overlaps
            return false;
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
