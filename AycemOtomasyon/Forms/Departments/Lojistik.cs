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
    public partial class Lojistik : Form
    {
        public Lojistik()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }
    }
}
