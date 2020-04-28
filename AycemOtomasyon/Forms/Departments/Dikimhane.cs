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
    public partial class Dikimhane : Form
    {
        public Dikimhane()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Makine1 makine = new Makine1();
            makine.Show();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMaterialForm addMaterialForm = new AddMaterialForm();
            addMaterialForm.Show();
        }
    }
}
