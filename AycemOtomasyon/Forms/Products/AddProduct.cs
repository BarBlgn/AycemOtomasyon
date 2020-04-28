using AycemOtomasyon.DTO;
using AycemOtomasyon.Forms.Company;
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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            var productName = textBox1.Text;

            var result = ProductRepository.CreateProduct(productName);

            if (result) 
            {
                MessageBox.Show("Ürün eklendi.");
                var productScreen = new ProductScreen();
                productScreen.Search();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
