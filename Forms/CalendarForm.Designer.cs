namespace C969___Axl_Nunez.Forms
{
    partial class CalendarForm
    {
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.Label lblAppointments;

        private void InitializeComponent()
        {
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.lblAppointments = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(30, 70);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateSelected);

            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(30, 300);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(740, 150);
            this.dgvAppointments.TabIndex = 1;
            this.dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.ClearSelection();

            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Location = new System.Drawing.Point(30, 20);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(75, 30);
            this.btnPrevMonth.TabIndex = 2;
            this.btnPrevMonth.Text = "<< Prev";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.BtnPrevMonth_Click);

            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(680, 20);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(75, 30);
            this.btnNextMonth.TabIndex = 3;
            this.btnNextMonth.Text = "Next >>";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.BtnNextMonth_Click);

            // 
            // lblMonthYear
            // 
            this.lblMonthYear.AutoSize = true;
            this.lblMonthYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMonthYear.Location = new System.Drawing.Point(330, 25);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(111, 21);
            this.lblMonthYear.TabIndex = 4;
            this.lblMonthYear.Text = "January 2025";

            // 
            // lblAppointments
            // 
            this.lblAppointments.AutoSize = true;
            this.lblAppointments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAppointments.Location = new System.Drawing.Point(30, 270);
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.Size = new System.Drawing.Size(227, 19);
            this.lblAppointments.TabIndex = 5;
            this.lblAppointments.Text = "Appointments for Selected Date:";

            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblAppointments);
            this.Controls.Add(this.lblMonthYear);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPrevMonth);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.monthCalendar);
            this.Name = "CalendarForm";
            this.Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
