using AycemOtomasyon.DTO;
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

namespace AycemOtomasyon
{
    public partial class ChangePass : Form
    {
        public static UserDTO currentUser = null;

        public ChangePass()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void GirButton_Click(object sender, EventArgs e)
        {
            
        }

        private void AdSoyad_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var phone = textBox1.Text;
            var username = textBox2.Text;

            currentUser = UserRepository.ForgotPassword(username, phone);
            if (currentUser == null)
                MessageBox.Show("Bilgiler Hatalı", "Hata", MessageBoxButtons.OK);
            else
            {
                var resetPassword = new ResetPassword();
                resetPassword.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
