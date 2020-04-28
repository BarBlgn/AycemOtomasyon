using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AycemOtomasyon.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowReports showReports = new ShowReports();
            showReports.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteReport deleteReport = new DeleteReport();
            deleteReport.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddReport addReport = new AddReport();
            addReport.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateReport updateReport = new UpdateReport();
            updateReport.Show();
        }
    }
}
