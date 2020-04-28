using AycemOtomasyon.Repository;
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
    public partial class ProductScreen : Form
    {
        public ProductScreen()
        {
            InitializeComponent();
            Search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowProducts showProducts = new ShowProducts();
            showProducts.Show();
        }

        public void Search()
        {
            var products = ProductRepository.GetProducts();
            dataGridView1.DataSource = products.Select(p => new { p.ProductName }).ToList();

            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}
