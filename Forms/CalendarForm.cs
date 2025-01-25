using System;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

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
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
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

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No appointments found for the selected date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

        private void BtnGenerateAppointmentTypesReport_Click(object sender, EventArgs e)
        {
            GenerateAppointmentTypesReport();
        }

        private void BtnGenerateUserScheduleReport_Click(object sender, EventArgs e)
        {
            GenerateUserScheduleReport();
        }

        private void BtnGenerateCustomReport_Click(object sender, EventArgs e)
        {
            GenerateCustomReport();
        }

        private void GenerateAppointmentTypesReport()
        {
            string query = @"
    SELECT 
        MONTHNAME(start) AS `Month`,
        type AS `Appointment Type`,
        COUNT(*) AS `Count`
    FROM appointment
    GROUP BY `Month`, `Appointment Type`";

            GenerateReport(query, "Appointment Types by Month");
        }

        private void GenerateUserScheduleReport()
        {
            string query = @"
    SELECT 
        u.username AS `User`,
        a.title AS `Appointment Title`,
        TIME_FORMAT(a.start, '%h:%i %p') AS `Start Time`,
        TIME_FORMAT(a.end, '%h:%i %p') AS `End Time`
    FROM appointment a
    INNER JOIN user u ON a.userId = u.userId
    ORDER BY `User`, `Start Time`";

            GenerateReport(query, "Schedule for Each User");
        }


        private void GenerateCustomReport()
        {
            string query = @"
    SELECT 
        location AS `Location`,
        COUNT(*) AS `Appointment Count`
    FROM appointment
    GROUP BY location";

            GenerateReport(query, "Appointments by Location");
        }


        private void GenerateReport(string query, string reportTitle)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                using var cmd = new MySqlCommand(query, connection);
                using var adapter = new MySqlDataAdapter(cmd);

                var dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"No data found for {reportTitle}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var reportForm = new ReportForm(dt, reportTitle);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
