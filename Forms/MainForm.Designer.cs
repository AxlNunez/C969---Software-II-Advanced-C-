namespace C969___Axl_Nunez.Forms
{
    partial class MainForm
    {
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageAppointments;
        private System.Windows.Forms.Button btnViewCalendar;

        private void InitializeComponent()
        {
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageAppointments = new System.Windows.Forms.Button();
            this.btnViewCalendar = new System.Windows.Forms.Button();

            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.Location = new System.Drawing.Point(100, 50);
            this.btnManageCustomers.Size = new System.Drawing.Size(200, 30);
            this.btnManageCustomers.Text = "Manage Customers";
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);

            // 
            // btnManageAppointments
            // 
            this.btnManageAppointments.Location = new System.Drawing.Point(100, 100);
            this.btnManageAppointments.Size = new System.Drawing.Size(200, 30);
            this.btnManageAppointments.Text = "Manage Appointments";
            this.btnManageAppointments.Click += new System.EventHandler(this.btnManageAppointments_Click);

            // 
            // btnViewCalendar
            // 
            this.btnViewCalendar.Location = new System.Drawing.Point(100, 150);
            this.btnViewCalendar.Size = new System.Drawing.Size(200, 30);
            this.btnViewCalendar.Text = "View Calendar";
            this.btnViewCalendar.Click += new System.EventHandler(this.btnViewCalendar_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnManageAppointments);
            this.Controls.Add(this.btnViewCalendar);
            this.Text = "Main Menu";
        }
    }
}
