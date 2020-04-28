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
    public partial class Depo : Form
    {
        public Depo()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMaterialForm materialStock = new AddMaterialForm();
            materialStock.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Makine1 machinesForm = new Makine1();
            machinesForm.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            updateUser.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
