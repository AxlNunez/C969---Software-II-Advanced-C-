using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969___Axl_Nunez.Forms
{
    public partial class LoginForm : Form
    {
        private readonly string connectionString;

        public LoginForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            SetLanguage("en-US");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (Authenticate(username, password))
            {
                string location = new CultureInfo("en-US").DisplayName;
                string loginMessage = string.Format(GetTranslatedMessage("LoginSuccessWithLocation"), location);
                MessageBox.Show(loginMessage);

                var appointmentForm = new AppointmentForm();
                appointmentForm.CheckForUpcomingAppointments(username);

                LogActivity(username);
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                string errorMessage = GetTranslatedMessage("LoginError");
                MessageBox.Show(errorMessage);
            }
        }

        private bool Authenticate(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                using (var cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                    return userCount > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
                return false;
            }
        }

        private string GetTranslatedMessage(string key)
        {
            try
            {
                var rm = new System.Resources.ResourceManager("C969___Axl_Nunez.Resources.Strings", typeof(LoginForm).Assembly);
                return rm.GetString(key, CultureInfo.CurrentCulture) ?? key;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Translation error: {ex.Message}");
                return key;
            }
        }

        private void LogActivity(string username)
        {
            string logEntry = $"{DateTime.Now}: {username} logged in.";
            System.IO.File.AppendAllText("Login_History.txt", logEntry + Environment.NewLine);
        }

        private void SetLanguage(string cultureCode)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            SetLanguage("en-US");
            MessageBox.Show("Language switched to English.");
        }

        private void btnSpanish_Click(object sender, EventArgs e)
        {
            SetLanguage("es-ES");
            MessageBox.Show("Idioma cambiado a Español.");
        }
    }
}
