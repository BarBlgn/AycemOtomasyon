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

namespace AycemOtomasyon.Forms
{
    public partial class MaterialStock : Form
    {
        public MaterialStock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var material = MaterialRepository.ShowMaterials(new MaterialDTO());
            //dataGridView1.DataSource = material.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
