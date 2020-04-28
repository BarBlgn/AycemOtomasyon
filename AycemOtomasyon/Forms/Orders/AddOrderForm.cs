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

namespace AycemOtomasyon
{
    public partial class AddOrderForm : Form
    {
        public AddOrderForm()
        {
            InitializeComponent();
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            var productname = comboBox2.SelectedItem.ComboboxSelectedValue();
            var productcolour = comboBox3.SelectedItem.ComboboxSelectedValue();
            var quantity = QuantityTextBox.Text.ToString();

            dataGridView1.Rows.Add(productname, quantity, productcolour);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createCompany = new AddCompany();
            createCompany.Show();
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            FillCompanies();
            FillColours();
            FillProducts();
        }

        public void FillCompanies()
        {
            var companies = CompanyRepository.GetCompanies();

            foreach (var item in companies)
            {
                var comboBoxItem = new ComboBoxItem { Text = item.CompanyName, Value = item.CompanyId };
                comboBox1.Items.Add(comboBoxItem);
            }
        }
        public void FillColours()
        {
            var colours = ColourRepository.GetColours();

            foreach (var color in colours)
            {
                var comboBoxItem = new ComboBoxItem { Text = color.ColourName, Value = color.ColourId };
                comboBox2.Items.Add(comboBoxItem);
            }
        }
        public void FillProducts()
        {
            var products = ProductRepository.GetProducts();

            foreach (var product in products)
            {
                var comboBoxItem = new ComboBoxItem { Text = product.ProductName, Value = product.ProductId };
                comboBox3.Items.Add(comboBoxItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var roleId = new Guid(((ComboBoxItem)comboBox1.SelectedItem).Value.ToString());
            var order = new OrderDTO
            {
                OrderId = Guid.NewGuid(),
                CompanyId = new Guid(((ComboBoxItem)comboBox1.SelectedItem).Value.ToString()),
                OrderExpiryDate = dateTimePicker1.Value,
                ModifierRoleId = CurrentUser.LoginUser.UserId,
                ColourId = new Guid(((ComboBoxItem)comboBox2.SelectedItem).Value.ToString()),
                ProductId = new Guid(((ComboBoxItem)comboBox3.SelectedItem).Value.ToString())

            };

            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                var orderItem = new OrderItemDTO
                {
                    OrderId = order.OrderId,
                    OrderItemId = Guid.NewGuid(),
                    ProductId = new Guid(dataGridView1.Rows[rows].Cells["ProductId"].ToString()),
                    Quantity = Convert.ToInt32(dataGridView1.Rows[rows].Cells["ProductId"])
                };

                order.Items.Add(orderItem);
            }

            OrderRepository.CreateOrder(order);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddOrderButton_Click_1(object sender, EventArgs e)
        {
            {
                var productname = ((ComboBoxItem)comboBox3.SelectedItem).Text;
                var productcolour = ((ComboBoxItem)comboBox2.SelectedItem).Text;
                var quantity = QuantityTextBox.Text.ToString();

                dataGridView1.Rows.Add(productname, quantity, productcolour);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var order = new OrderDTO
            {
                OrderId = Guid.NewGuid(),
                CompanyId = new Guid(((ComboBoxItem)comboBox1.SelectedItem).Value.ToString()),
                OrderExpiryDate = dateTimePicker1.Value,
                ModifierRoleId = CurrentUser.LoginUser.UserId,
                Items = new List<OrderItemDTO>()
            };

            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                if (dataGridView1.Rows[rows].Cells["ProductName"].Value != null)
                {
                    var orderItem = new OrderItemDTO
                    {
                        OrderId = order.OrderId,
                        OrderItemId = Guid.NewGuid(),
                        ProductId = comboBox3.GetValueByText(dataGridView1.Rows[rows].Cells["ProductName"].Value.ToString()),
                        ColourId = comboBox2.GetValueByText(dataGridView1.Rows[rows].Cells["ColorName"].Value.ToString())
                    };

                    order.Items.Add(orderItem);
                }
            }

            OrderRepository.CreateOrder(order);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var createCompany = new AddCompany();
            createCompany.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
