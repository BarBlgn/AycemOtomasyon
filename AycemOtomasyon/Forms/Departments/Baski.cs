using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AycemOtomasyon.Forms.Departments
{
    public partial class Baski : Form
    {
        public Baski()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Makine1 makine1 = new Makine1();
            makine1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddMaterialForm addmaterialForm = new AddMaterialForm();
            addmaterialForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }
    }
}
