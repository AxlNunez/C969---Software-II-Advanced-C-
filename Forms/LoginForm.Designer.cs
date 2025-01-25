namespace C969___Axl_Nunez.Forms
{
    partial class LoginForm
    {
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnSpanish;

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnSpanish = new System.Windows.Forms.Button();

            // 
            // lblUsername
            // 
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Text = "Username:";
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(20, 30);

            // 
            // txtUsername
            // 
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Location = new System.Drawing.Point(120, 30);
            this.txtUsername.Size = new System.Drawing.Size(150, 23);

            // 
            // lblPassword
            // 
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password:";
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 70);

            // 
            // txtPassword
            // 
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Location = new System.Drawing.Point(120, 70);
            this.txtPassword.Size = new System.Drawing.Size(150, 23);
            this.txtPassword.PasswordChar = '*';

            // 
            // btnLogin
            // 
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(120, 110);
            this.btnLogin.Size = new System.Drawing.Size(75, 30);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // 
            // btnEnglish
            // 
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Text = "English";
            this.btnEnglish.Location = new System.Drawing.Point(20, 160);
            this.btnEnglish.Size = new System.Drawing.Size(75, 30);
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);

            // 
            // btnSpanish
            // 
            this.btnSpanish.Name = "btnSpanish";
            this.btnSpanish.Text = "Español";
            this.btnSpanish.Location = new System.Drawing.Point(120, 160);
            this.btnSpanish.Size = new System.Drawing.Size(75, 30);
            this.btnSpanish.Click += new System.EventHandler(this.btnSpanish_Click);

            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.btnSpanish);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }
    }
}
