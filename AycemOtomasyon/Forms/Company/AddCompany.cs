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

namespace AycemOtomasyon.Forms.Company
{
    public partial class AddCompany : Form
    {
        public AddCompany()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var phone = textBox2.Text;

            if(CompanyRepository.CreateCompany(name, phone)) 
            {
                var addOrderForm = new AddOrderForm();
                addOrderForm.FillCompanies();
                MessageBox.Show("Eklendi.");
            }
            else 
            {
                MessageBox.Show("Hata.");
            }
        }
    }
}
