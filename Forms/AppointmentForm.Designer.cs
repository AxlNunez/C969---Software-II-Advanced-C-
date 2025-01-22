namespace C969___Axl_Nunez.Forms
{
    partial class AppointmentForm
    {
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDescription;

        private void InitializeComponent()
        {
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // 
            // lblCustomer
            // 
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.Location = new System.Drawing.Point(20, 20);
            this.lblCustomer.Size = new System.Drawing.Size(80, 20);

            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(120, 20);
            this.cmbCustomer.Size = new System.Drawing.Size(200, 23);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Title:";
            this.lblTitle.Location = new System.Drawing.Point(20, 60);
            this.lblTitle.Size = new System.Drawing.Size(80, 20);

            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(120, 60);
            this.txtTitle.Size = new System.Drawing.Size(200, 23);

            // 
            // lblStartTime
            // 
            this.lblStartTime.Text = "Start Time:";
            this.lblStartTime.Location = new System.Drawing.Point(20, 100);
            this.lblStartTime.Size = new System.Drawing.Size(80, 20);

            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(120, 100);
            this.dtpStartTime.Size = new System.Drawing.Size(200, 23);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            // 
            // lblEndTime
            // 
            this.lblEndTime.Text = "End Time:";
            this.lblEndTime.Location = new System.Drawing.Point(20, 140);
            this.lblEndTime.Size = new System.Drawing.Size(80, 20);

            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(120, 140);
            this.dtpEndTime.Size = new System.Drawing.Size(200, 23);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            // 
            // lblType
            // 
            this.lblType.Text = "Type:";
            this.lblType.Location = new System.Drawing.Point(20, 180);
            this.lblType.Size = new System.Drawing.Size(80, 20);

            // 
            // cmbType
            // 
            this.cmbType.Location = new System.Drawing.Point(120, 180);
            this.cmbType.Size = new System.Drawing.Size(200, 23);

            // 
            // lblDescription
            // 
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(20, 220);
            this.lblDescription.Size = new System.Drawing.Size(80, 20);

            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 220);
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.Multiline = true;

            // 
            // btnAdd
            // 
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(20, 300);
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Location = new System.Drawing.Point(120, 300);
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(220, 300);
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // 
            // btnClear
            // 
            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(320, 300);
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // 
            // dgvAppointments
            // 
            this.dgvAppointments.Location = new System.Drawing.Point(20, 350);
            this.dgvAppointments.Size = new System.Drawing.Size(760, 200);
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // AppointmentForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvAppointments);
            this.Text = "Appointment Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
