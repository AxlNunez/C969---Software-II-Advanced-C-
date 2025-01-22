using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Axl_Nunez.Forms
{
    public partial class CalendarForm : Form
    {
        private DateTime selectedDate;

        public CalendarForm()
        {
            InitializeComponent();
            selectedDate = DateTime.Now;
            lblMonthYear.Text = selectedDate.ToString("MMMM yyyy");
            LoadAppointmentsAsync(selectedDate);
        }

        private async void LoadAppointmentsAsync(DateTime date)
        {
            string connectionString = "Server=your-server;Database=your-database;User Id=your-username;Password=your-password;";
            string query = @"
                SELECT FORMAT(Time, 'hh:mm tt') AS Time, Title, Description 
                FROM Appointments 
                WHERE CAST(Time AS DATE) = @date";

            try
            {
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync(); // Async connection open

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date) { Value = date.Date });

                var dt = new DataTable();
                using var reader = await cmd.ExecuteReaderAsync(); // Async data reading
                dt.Load(reader);

                dgvAppointments.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private void BtnPrevMonth_Click(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddMonths(-1);
            lblMonthYear.Text = selectedDate.ToString("MMMM yyyy");
            LoadAppointmentsAsync(selectedDate);
        }

        private void BtnNextMonth_Click(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddMonths(1);
            lblMonthYear.Text = selectedDate.ToString("MMMM yyyy");
            LoadAppointmentsAsync(selectedDate);
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            LoadAppointmentsAsync(selectedDate);
        }
    }
}
