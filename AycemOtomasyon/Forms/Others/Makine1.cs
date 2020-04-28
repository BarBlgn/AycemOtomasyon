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
    public partial class Makine1 : Form
    {
        public Makine1()
        {
            InitializeComponent();
            AycemEntities aycemEntities = new AycemEntities();
            var result = MachineRepository.GetMachine();
            dataGridView1.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MachinesForm machinesForm = new MachinesForm();
            machinesForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
