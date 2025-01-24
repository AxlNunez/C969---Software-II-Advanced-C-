using System;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969___Axl_Nunez.Forms
{
    public partial class CalendarForm : Form
    {
        private readonly string connectionString;
        private DateTime selectedDate;

        public CalendarForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            selectedDate = DateTime.Now;
            lblMonthYear.Text = selectedDate.ToString("MMMM yyyy");
            dgvAppointments.ClearSelection();
            _ = LoadAppointmentsAsync(selectedDate);
        }

        private async Task LoadAppointmentsAsync(DateTime date)
        {
            string query = @"
        SELECT 
            TIME_FORMAT(start, '%h:%i %p') AS `Time`, 
            title AS `Title`, 
            description AS `Description`
        FROM appointment
        WHERE DATE(start) = @date";

            try
            {
                using var connection = new MySqlConnection(connectionString);
                await connection.OpenAsync();

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@date", date.Date);

                var dt = new DataTable();
                using var reader = await cmd.ExecuteReaderAsync();
                dt.Load(reader);

                dgvAppointments.DataSource = dt;
                dgvAppointments.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnPrevMonth_Click(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddMonths(-1);
            lblMonthYear.Text = selectedDate.ToString("MMMM yyyy");
            _ = LoadAppointmentsAsync(selectedDate);
        }

        private void BtnNextMonth_Click(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddMonths(1);
            lblMonthYear.Text = selectedDate.ToString("MMMM yyyy");
            _ = LoadAppointmentsAsync(selectedDate);
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            _ = LoadAppointmentsAsync(selectedDate);
        }
    }
}
