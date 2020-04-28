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

namespace AycemOtomasyon//.Forms.User
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var password = textBox1.Text;
            var user = ChangePass.currentUser;
            var userId = user.UserId;
            
            var user1 = UserRepository.ChangePassword(userId,password);
            MessageBox.Show("Şifreniz değiştirildi", "Başarılı", MessageBoxButtons.OK);

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
