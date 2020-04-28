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
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();

            GetUserList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = UserRepository.DeleteUser(new Guid());
            dataGridView1.Refresh();
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
            var userId = new Guid(dataGridView1.SelectedRows[0].Cells["UserId"].Value.ToString());
            var result = UserRepository.DeleteUser(userId);
            if (result) 
            {
                MessageBox.Show("Kullanıcı başarıyla silindi.");
                GetUserList();
            }
        }

        private void GetUserList() 
        {
            var res = UserRepository.GetUserList();
            dataGridView1.DataSource = res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
