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

            AycemEntities entities = new AycemEntities();

            var res = entities.User.Include("Role").Select(u => new {
                UserName = u.Username,
                FirstName = u.FirstName,
                Surname = u.Surname,
                Phone = u.Phone,
                IsActive = u.Role.IsActive,
                RoleName = u.Role.Name,
                UserId = u.UserId
            }).ToList();
            dataGridView1.DataSource = res.ToList();


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
            var currentCell = dataGridView1.SelectedRows[0].Cells["UserName"];
            var a = currentCell.Value;
        }
    }
}
