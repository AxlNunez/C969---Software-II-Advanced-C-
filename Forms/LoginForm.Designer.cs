namespace C969___Axl_Nunez.Forms
{
    partial class LoginForm
    {
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();

            // 
            // lblUsername
            // 
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(20, 30);

            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 30);

            // 
            // lblPassword
            // 
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(20, 70);

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 70);
            this.txtPassword.PasswordChar = '*';

            // 
            // btnLogin
            // 
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(120, 110);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Text = "Login";
        }
    }
}
