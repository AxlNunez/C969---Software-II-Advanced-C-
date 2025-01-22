using C969___Axl_Nunez.Servicers;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace C969___Axl_Nunez.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService = new UserService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_userService.Authenticate(username, password))
            {
                string location = RegionInfo.CurrentRegion.DisplayName;
                MessageBox.Show($"Login successful. Detected location: {location}");

                _userService.LogLogin(username);
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                string errorMessage = TranslateMessage("Invalid username or password.", "es");
                MessageBox.Show(errorMessage);
            }
        }

        private string TranslateMessage(string message, string language)
        {
            if (language == "es")
            {
                if (message == "Invalid username or password.")
                    return "Usuario o contraseña inválidos.";
            }

            return message;
        }
    }
}
