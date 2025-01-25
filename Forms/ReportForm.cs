using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace C969___Axl_Nunez.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm(DataTable data, string title)
        {
            InitializeComponent();
            lblTitle.Text = title;
            dgvReport.DataSource = data;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ReadOnly = true;
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
        }
    }
}
