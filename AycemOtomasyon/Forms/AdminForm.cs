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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addUser = new CreateUser();
            addUser.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Infos infos = new Infos();
            infos.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm();
            addOrderForm.Show();
        }
    }
}
