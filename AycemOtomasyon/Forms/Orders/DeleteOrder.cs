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
    public partial class DeleteOrder : Form
    {
        public DeleteOrder()
        {
            InitializeComponent();

            var order = OrderRepository.ShowOrders(new DTO.OrderDTO());
            dataGridView1.DataSource = order.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        public void DeleteCurrentRow()
        {
            var currentCell = dataGridView1.SelectedRows[0].Cells[0];
            var a = currentCell.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var currentCell = dataGridView1.SelectedRows[0].Cells["OrderId"];
            var a = currentCell.Value;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var user = OrderRepository.DeleteOrder(new Guid());
            dataGridView1.Refresh();
        }
    }
}
