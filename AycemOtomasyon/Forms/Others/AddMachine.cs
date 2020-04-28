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
    public partial class AddMachine : Form
    {
        public AddMachine()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var machineName = textBox1.Text;
            var productionCapacity = textBox2.Text.ToString();
            var productionFail = textBox3.Text.ToString();
            var result = MachineRepository.CreateMachine(machineName,Int32.Parse(productionCapacity) , Int32.Parse(productionFail));
            if (result)
            {
                MessageBox.Show("Kullanıcı başarıyla eklendi.");
                this.Close();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text == "Makine Adı" ? "" : textBox1.Text;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text == "" ? "Makine Adı" : textBox1.Text;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text == "Üretim Kapasitesi" ? "" : textBox2.Text;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text == "" ? "Üretim Kapasitesi " : textBox1.Text;
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text == "Hatalı Ürün Oranı" ? "" : textBox3.Text;
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text == "" ? "Hatalı Ürün Oranı" : textBox3.Text;
        }

    }
}
