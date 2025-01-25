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
            cmbCustomer = new ComboBox();
            txtTitle = new TextBox();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            cmbType = new ComboBox();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvAppointments = new DataGridView();
            lblCustomer = new Label();
            lblTitle = new Label();
            lblStartTime = new Label();
            lblEndTime = new Label();
            lblType = new Label();
            lblDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // cmbCustomer
            // 
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.Location = new Point(120, 20);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(200, 23);
            cmbCustomer.TabIndex = 1;
            cmbCustomer.ValueMember = "Id";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(120, 60);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(120, 100);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(200, 23);
            dtpStartTime.TabIndex = 5;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(120, 140);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(200, 23);
            dtpEndTime.TabIndex = 7;
            // 
            // cmbType
            // 
            cmbType.Items.AddRange(new object[] { "Consultation", "Follow-Up", "Meeting" });
            cmbType.Location = new Point(120, 180);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(200, 23);
            cmbType.TabIndex = 9;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(120, 220);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 60);
            txtDescription.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 300);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 30);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(120, 300);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 30);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(220, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(320, 300);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 30);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.Click += BtnClear_Click;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.Location = new Point(20, 350);
            dgvAppointments.MultiSelect = false;
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(760, 200);
            dgvAppointments.TabIndex = 16;
            dgvAppointments.SelectionChanged += dgvAppointments_SelectionChanged;
            // 
            // lblCustomer
            // 
            lblCustomer.Location = new Point(20, 20);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(80, 20);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer:";
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(20, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title:";
            // 
            // lblStartTime
            // 
            lblStartTime.Location = new Point(20, 100);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(80, 20);
            lblStartTime.TabIndex = 4;
            lblStartTime.Text = "Start Time:";
            // 
            // lblEndTime
            // 
            lblEndTime.Location = new Point(20, 140);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(80, 20);
            lblEndTime.TabIndex = 6;
            lblEndTime.Text = "End Time:";
            // 
            // lblType
            // 
            lblType.Location = new Point(20, 180);
            lblType.Name = "lblType";
            lblType.Size = new Size(80, 20);
            lblType.TabIndex = 8;
            lblType.Text = "Type:";
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(20, 220);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(80, 20);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Description:";
            // 
            // AppointmentForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(lblCustomer);
            Controls.Add(cmbCustomer);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblStartTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblEndTime);
            Controls.Add(dtpEndTime);
            Controls.Add(lblType);
            Controls.Add(cmbType);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvAppointments);
            Name = "AppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Appointment Management";
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
