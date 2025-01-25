namespace C969___Axl_Nunez.Forms
{
    partial class MainForm
    {
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageAppointments;
        private System.Windows.Forms.Button btnViewCalendar;

        private void InitializeComponent()
        {
            btnManageCustomers = new Button();
            btnManageAppointments = new Button();
            btnViewCalendar = new Button();
            SuspendLayout();
            // 
            // btnManageCustomers
            // 
            btnManageCustomers.Location = new Point(100, 50);
            btnManageCustomers.Name = "btnManageCustomers";
            btnManageCustomers.Size = new Size(200, 30);
            btnManageCustomers.TabIndex = 0;
            btnManageCustomers.Text = "Manage Customers";
            btnManageCustomers.Click += btnManageCustomers_Click;
            // 
            // btnManageAppointments
            // 
            btnManageAppointments.Location = new Point(100, 100);
            btnManageAppointments.Name = "btnManageAppointments";
            btnManageAppointments.Size = new Size(200, 30);
            btnManageAppointments.TabIndex = 1;
            btnManageAppointments.Text = "Manage Appointments";
            btnManageAppointments.Click += btnManageAppointments_Click;
            // 
            // btnViewCalendar
            // 
            btnViewCalendar.Location = new Point(100, 150);
            btnViewCalendar.Name = "btnViewCalendar";
            btnViewCalendar.Size = new Size(200, 30);
            btnViewCalendar.TabIndex = 2;
            btnViewCalendar.Text = "View Calendar";
            btnViewCalendar.Click += btnViewCalendar_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(400, 250);
            Controls.Add(btnManageCustomers);
            Controls.Add(btnManageAppointments);
            Controls.Add(btnViewCalendar);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            ResumeLayout(false);
        }
    }
}
