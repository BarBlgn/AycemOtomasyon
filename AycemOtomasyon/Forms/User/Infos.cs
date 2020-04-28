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
    public partial class Infos : Form
    {

        public Infos()
        {
            InitializeComponent();

            var roles = UserRepository.GetRoleList();

            foreach (var item in roles)
            {
                var comboBoxItem = new ComboBoxItem { Text = item.Value, Value = item.Key };
                comboBox1.Items.Add(comboBoxItem);//Burada sorun çıkabilir key-value'dan dolayı
            }

            AycemEntities entities = new AycemEntities();

            var res = UserRepository.GetUserList();

            //var res = (from p in entities.User
            //           join br in entities.Role on p.RoleId equals br.RoleId
            //           select new
            //           {
            //               p.FirstName,
            //               p.Surname,
            //               p.Phone,
            //               br.IsActive,
            //               br.Name
            //           }).ToList();
            dataGridView1.DataSource = res.Select(s => new { s.Username,s.FirstName,s.Surname,s.RoleName,s.Phone }).ToList();
            /* var user = from p in entities.User
                                    select new
                        {
                            firstName = p.FirstName,
                            surname = p.Surname,
                            phone = p.Phone,

                        };
             dataGridView1.DataSource = user.ToList();
             var role = from r in entities.Role
                      select new
                        {
                            roleName = r.Name,
                            isActive = r.IsActive
                        };
             dataGridView1.DataSource = role.ToList();
             */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Kullanıcı Adı")
            {
                txtUsername.Text = "";
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Kullanıcı Adı";
            }
        }

        private void Search()
        {
            var username = txtUsername.Text.Length > 2 && txtUsername.Text != "Kullanıcı Adı" ? txtUsername.Text : "";
            var phone = txtSurname.Text.Length > 2 && txtSurname.Text != "Telefon Numarası" ? txtSurname.Text : "";
            var roleId = comboBox1.SelectedItem != null ? new Guid(((ComboBoxItem)comboBox1.SelectedItem).Value.ToString()) : Guid.Empty;

            var result = UserRepository.GetUserList(username: username, phone: phone, department: roleId);
            dataGridView1.DataSource = result;
        }

        private void txtSurname_Enter(object sender, EventArgs e)
        {
            if (txtSurname.Text == "Telefon Numarası")
            {
                txtSurname.Text = "";
            }
        }

        private void txtSurname_Leave(object sender, EventArgs e)
        {
            if (txtSurname.Text == "")
            {
                txtSurname.Text = "Telefon Numarası";
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
