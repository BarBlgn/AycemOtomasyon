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
    public partial class MaterialForm : Form
    {
        public MaterialForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMaterialForm addMaterialForm = new AddMaterialForm();
            addMaterialForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MaterialStock materialStock = new MaterialStock();
            materialStock.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
