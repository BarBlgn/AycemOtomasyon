using AycemOtomasyon.DTO;
using AycemOtomasyon.DTO.Enum;
using AycemOtomasyon.Forms;
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
    public partial class ShowOrders : Form
    {
        public ShowOrders()
        {
            InitializeComponent();
            GetCompanyList();
            GetProductList();
            Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var order = OrderRepository.ShowOrders(new OrderDTO());
            dataGridView1.DataSource = order.ToList();
        }

        private void GetCompanyList()
        {
            var companies = CompanyRepository.GetCompanies();

            foreach (var company in companies)
            {
                var item = new ComboBoxItem { Text = company.CompanyName, Value = company.CompanyId };
                comboBox1.Items.Add(item);
            }
        }

        private void GetProductList()
        {
            var products = ProductRepository.GetProducts();

            foreach (var product in products)
            {
                var item = new ComboBoxItem { Text = product.ProductName, Value = product.ProductId };
                comboBox2.Items.Add(item);
            }
        }

        private void Search()
        {
            var companyId = Guid.Empty;
            var productId = Guid.Empty;

            if (comboBox1.SelectedItem != null)
            {
                var comboBoxItem = (ComboBoxItem)comboBox1.SelectedItem;
                companyId = new Guid(comboBoxItem.Value.ToString());
            }

            if (comboBox2.SelectedItem != null)
            {
                var comboBoxItem = (ComboBoxItem)comboBox2.SelectedItem;
                productId = new Guid(comboBoxItem.Value.ToString());
            }

            var list = OrderRepository.GetOrderList(companyId: companyId, productId: productId);
            dataGridView1.DataSource = list;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("İptal etmek istediğiniz siparişi seçiniz.");
            }
            else
            {
                var orderItemId = new Guid(dataGridView1.SelectedRows[0].Cells["OrderItemId"].Value.ToString());
                var status = OrderItemStatus.Canceled;
                var result = ChangeOrderItemStatus(orderItemId, status);

                if (result)
                {
                    MessageBox.Show("Sipariş iptal edildi.");
                    Search();
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Tamamlamak istediğiniz siparişi seçiniz.");
            }
            else
            {
                var orderItemId = new Guid(dataGridView1.SelectedRows[0].Cells["OrderItemId"].Value.ToString());
                var status = OrderItemStatus.Completed;
                var result = ChangeOrderItemStatus(orderItemId, status);

                if (result)
                {
                    MessageBox.Show("Sipariş tamamlandı.");
                    Search();
                }
            }
        }

        private bool ChangeOrderItemStatus(Guid orderItemId, OrderItemStatus status)
        {
            return OrderRepository.ChangeOrderItemStatus(orderItemId, status);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
           if (e.StateChanged == DataGridViewElementStates.Selected && dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                var status = dataGridView1.SelectedRows[0].Cells["OrderItemStatus"].Value.ToString();

                if (status != OrderItemStatus.Created.GetDescription())
                {
                    AddOrderButton.Visible = false;
                    button1.Visible = false;
                }
                else
                {
                    AddOrderButton.Visible = true;
                    button1.Visible = true;
                }
            }
        }
    }
}
