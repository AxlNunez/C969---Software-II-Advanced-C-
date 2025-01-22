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
            monthCalendar = new MonthCalendar();
            dgvAppointments = new DataGridView();
            btnPrevMonth = new Button();
            btnNextMonth = new Button();
            lblMonthYear = new Label();
            lblAppointments = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(30, 70);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            monthCalendar.DateSelected += MonthCalendar_DateSelected;
            // 
            // dgvAppointments
            // 
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Location = new Point(30, 300);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.Size = new Size(740, 150);
            dgvAppointments.TabIndex = 1;
            // 
            // btnPrevMonth
            // 
            btnPrevMonth.Location = new Point(30, 20);
            btnPrevMonth.Name = "btnPrevMonth";
            btnPrevMonth.Size = new Size(75, 30);
            btnPrevMonth.TabIndex = 2;
            btnPrevMonth.Text = "<< Prev";
            btnPrevMonth.UseVisualStyleBackColor = true;
            btnPrevMonth.Click += BtnPrevMonth_Click;
            // 
            // btnNextMonth
            // 
            btnNextMonth.Location = new Point(680, 20);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(75, 30);
            btnNextMonth.TabIndex = 3;
            btnNextMonth.Text = "Next >>";
            btnNextMonth.UseVisualStyleBackColor = true;
            btnNextMonth.Click += BtnNextMonth_Click;
            // 
            // lblMonthYear
            // 
            lblMonthYear.AutoSize = true;
            lblMonthYear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMonthYear.Location = new Point(330, 25);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(111, 21);
            lblMonthYear.TabIndex = 4;
            lblMonthYear.Text = "January 2025";
            // 
            // lblAppointments
            // 
            lblAppointments.AutoSize = true;
            lblAppointments.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAppointments.Location = new Point(30, 270);
            lblAppointments.Name = "lblAppointments";
            lblAppointments.Size = new Size(227, 19);
            lblAppointments.TabIndex = 5;
            lblAppointments.Text = "Appointments for Selected Date:";
            // 
            // CalendarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(lblAppointments);
            Controls.Add(lblMonthYear);
            Controls.Add(btnNextMonth);
            Controls.Add(btnPrevMonth);
            Controls.Add(dgvAppointments);
            Controls.Add(monthCalendar);
            Name = "CalendarForm";
            Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
