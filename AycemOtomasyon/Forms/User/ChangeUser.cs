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

namespace AycemOtomasyon.Forms.User
{
    public partial class ChangeUser : Form
    {
        public Guid UserId = Guid.Empty;
        public ChangeUser()
        {
            InitializeComponent();

            var roles = UserRepository.GetRoleList();

            foreach (var item in roles)
            {
                var comboBoxItem = new ComboBoxItem { Text = item.Value, Value = item.Key };
                comboBox1.Items.Add(comboBoxItem);
            }
        }

        public void GetUser(Guid userId)
        {
            var user = UserRepository.GetUser(userId);
            txtUsername.Text = user.Username;
            txtFirstName.Text = user.FirstName;
            txtSurname.Text = user.Surname;
            txtPhone.Text = user.Phone;
            txtPassword.Text = user.Password;
            UserId = userId;

            comboBox1.SelectedIndex = comboBox1.FindStringExact(user.Role.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var comboBoxItem = (ComboBoxItem)comboBox1.SelectedItem;
            var roleId = new Guid(comboBoxItem.Value.ToString());

            var result = UserRepository.UpdateUser(UserId, txtUsername.Text, txtFirstName.Text, txtSurname.Text, txtPhone.Text, txtPassword.Text, roleId);

            if (result)
            {
                MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
