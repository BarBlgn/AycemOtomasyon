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
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        // Buradan itibaren combobox'tan role'ü seçenek olarak çıkaracağım
        //deneme

        private void CreateUser_Load(object sender, EventArgs e)
        {
            FillRoles();
        }

        public void FillRoles()
        {
            //var roles = UserRepository.GetRoleList();
            //comboBox1.DataSource = new BindingSource(UserRepository.GetRoleList(), null);
            //comboBox1.DisplayMember = "Key";
            //comboBox1.ValueMember = "Value";

            var roles = UserRepository.GetRoleList();

            foreach (var item in roles)
            {
                var comboBoxItem = new ComboBoxItem { Text = item.Value, Value = item.Key };
                comboBox1.Items.Add(comboBoxItem);
            }
        }
        //Buraya kadar.

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void CreateUser_Load_1(object sender, EventArgs e)
        {
            FillRoles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var firstName = txtFirstName.Text;
            var surname = txtSurname.Text;
            var phone = txtPhone.Text;
            var password = txtPassword.Text;

            var comboBoxItem = (ComboBoxItem)comboBox1.SelectedItem;
            var roleId = new Guid(comboBoxItem.Value.ToString());

            var result = UserRepository.CreateUser(username, firstName, surname, phone, password, roleId);

            if (result)
            {
                MessageBox.Show("Kullanıcı başarıyla eklendi.");
                this.Close();
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text == "Kullanıcı Adı" ? "" : txtUsername.Text;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text == "" ? "Kullanıcı Adı" : txtUsername.Text;
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            txtFirstName.Text = txtFirstName.Text == "İsim" ? "" : txtFirstName.Text;
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            txtFirstName.Text = txtFirstName.Text == "" ? "İsim" : txtFirstName.Text;
        }

        private void txtSurname_Enter(object sender, EventArgs e)
        {
            txtSurname.Text = txtSurname.Text == "Soyisim" ? "" : txtSurname.Text;
        }

        private void txtSurname_Leave(object sender, EventArgs e)
        {
            txtSurname.Text = txtSurname.Text == "" ? "Soyisim" : txtSurname.Text;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text == "Şifre" ? "" : txtPassword.Text;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text == "" ? "Şifre" : txtPassword.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
