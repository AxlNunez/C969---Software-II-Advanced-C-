using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Axl_Nunez.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            new CustomerForm().Show();
        }

        private void btnManageAppointments_Click(object sender, EventArgs e)
        {
            new AppointmentForm().Show();
        }

        private void btnViewCalendar_Click(object sender, EventArgs e)
        {
            new CalendarForm().Show();
        }
    }
}
