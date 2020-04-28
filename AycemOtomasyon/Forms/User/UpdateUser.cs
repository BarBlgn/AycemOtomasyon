using AycemOtomasyon.Forms.User;
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
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
            Search();
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

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            txtPhone.Text = txtPhone.Text == "Telefon Numarası" ? "" : txtPhone.Text;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            txtPhone.Text = txtPhone.Text == "" ? "Telefon Numarası" : txtPhone.Text;
        }

        private void Search()
        {
            var username = txtUsername.Text.Length > 2 && txtUsername.Text != "Kullanıcı Adı" ? txtUsername.Text : "";
            var phone = txtPhone.Text.Length > 2 && txtPhone.Text != "Telefon Numarası" ? txtPhone.Text : "";
            var firstName = txtFirstName.Text.Length > 2 && txtFirstName.Text != "İsim" ? txtFirstName.Text : "";
            var surname = txtSurname.Text.Length > 2 && txtSurname.Text != "Soyisim" ? txtSurname.Text : "";

            var result = UserRepository.GetUserList(username: username, phone: phone, firstName: firstName, surname: surname);
            dataGridView1.DataSource = result;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedUserId = new Guid(dataGridView1.SelectedRows[0].Cells["UserId"].Value.ToString());
            var changeUser = new ChangeUser();
            changeUser.Show();
            changeUser.GetUser(selectedUserId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
