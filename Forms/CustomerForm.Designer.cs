namespace C969___Axl_Nunez.Forms
{
    partial class CustomerForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPhone;

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            txtPhone = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvCustomers = new DataGridView();
            lblName = new Label();
            lblAddress = new Label();
            lblCity = new Label();
            lblCountry = new Label();
            lblPhone = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(120, 60);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 23);
            txtAddress.TabIndex = 3;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(120, 100);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 5;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(120, 140);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(200, 23);
            txtCountry.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(120, 180);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 220);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 30);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(120, 220);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 30);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(220, 220);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(320, 220);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 30);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear";
            btnClear.Click += BtnClear_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.Location = new Point(20, 270);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(760, 200);
            dgvCustomers.TabIndex = 14;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(80, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(20, 60);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(80, 20);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "Address:";
            // 
            // lblCity
            // 
            lblCity.Location = new Point(20, 100);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(80, 20);
            lblCity.TabIndex = 4;
            lblCity.Text = "City:";
            // 
            // lblCountry
            // 
            lblCountry.Location = new Point(20, 140);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(80, 20);
            lblCountry.TabIndex = 6;
            lblCountry.Text = "Country:";
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(20, 180);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(80, 20);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Phone:";
            // 
            // CustomerForm
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblCity);
            Controls.Add(txtCity);
            Controls.Add(lblCountry);
            Controls.Add(txtCountry);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvCustomers);
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Management";
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
