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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();

            // 
            // lblName
            // 
            this.lblName.Text = "Name:";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Size = new System.Drawing.Size(80, 20);

            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 20);
            this.txtName.Size = new System.Drawing.Size(200, 23);

            // 
            // lblAddress
            // 
            this.lblAddress.Text = "Address:";
            this.lblAddress.Location = new System.Drawing.Point(20, 60);
            this.lblAddress.Size = new System.Drawing.Size(80, 20);

            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 60);
            this.txtAddress.Size = new System.Drawing.Size(200, 23);

            // 
            // lblCity
            // 
            this.lblCity.Text = "City:";
            this.lblCity.Location = new System.Drawing.Point(20, 100);
            this.lblCity.Size = new System.Drawing.Size(80, 20);

            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(120, 100);
            this.txtCity.Size = new System.Drawing.Size(200, 23);

            // 
            // lblCountry
            // 
            this.lblCountry.Text = "Country:";
            this.lblCountry.Location = new System.Drawing.Point(20, 140);
            this.lblCountry.Size = new System.Drawing.Size(80, 20);

            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(120, 140);
            this.txtCountry.Size = new System.Drawing.Size(200, 23);

            // 
            // lblPhone
            // 
            this.lblPhone.Text = "Phone:";
            this.lblPhone.Location = new System.Drawing.Point(20, 180);
            this.lblPhone.Size = new System.Drawing.Size(80, 20);

            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 180);
            this.txtPhone.Size = new System.Drawing.Size(200, 23);

            // 
            // btnAdd
            // 
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(20, 220);
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Location = new System.Drawing.Point(120, 220);
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(220, 220);
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // 
            // btnClear
            // 
            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(320, 220);
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // 
            // dgvCustomers
            // 
            this.dgvCustomers.Location = new System.Drawing.Point(20, 270);
            this.dgvCustomers.Size = new System.Drawing.Size(760, 200);
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);


            // 
            // CustomerForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvCustomers);
            this.Text = "Customer Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
