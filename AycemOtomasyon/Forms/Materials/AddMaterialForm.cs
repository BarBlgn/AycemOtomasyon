using AycemOtomasyon.DTO;
using AycemOtomasyon.Forms.Company;
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
    public partial class AddMaterialForm : Form
    {
        public AddMaterialForm()
        {
            InitializeComponent();
            GetMaterialList();

            var colors = ColourRepository.GetColours();

            foreach (var color in colors)
            {
                var item = new ComboBoxItem { Text = color.ColourName, Value = color.ColourId };
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var materialname = MaterialNameTextBox.Text;
            var materialquantity = MaterialQuantityTextBox.Text.ToString().ToInt();
            var materialcolour = ((ComboBoxItem)comboBox1.SelectedItem).Text;
            var colourId = new Guid(((ComboBoxItem)comboBox1.SelectedItem).Value.ToString());
            var materialprice = Convert.ToDecimal(MaterialPriceTextBox.Text.ToString());

            var material = new MaterialDTO 
            {
                MaterialId = Guid.NewGuid(),
                MaterialName = materialname,
                ColourId = colourId,
                MaterialPrice = materialprice,
                MaterialQuantity = materialquantity
            };

            var result = MaterialRepository.CreateMaterial(material);

            if (result) 
            {
                MessageBox.Show("Materyal eklendi.");
                dataGridView1.Rows.Add(Guid.NewGuid().ToString(), materialname, materialquantity, materialcolour, materialprice);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var material = new MaterialDTO()
            {
                MaterialId = Guid.NewGuid(),
                MaterialName = MaterialNameTextBox.Text,
                ColourId = new Guid(((ComboBoxItem)comboBox1.SelectedItem).Value.ToString()),
                MaterialQuantity = Convert.ToInt32(MaterialQuantityTextBox.Text),
                MaterialPrice = Convert.ToInt32(MaterialPriceTextBox.Text)
            };

            MaterialRepository.CreateMaterial(material);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetMaterialList() 
        {
            var materials = MaterialRepository.GetMaterials();

            foreach (var item in materials)
            {
                dataGridView1.Rows.Add(Guid.NewGuid().ToString(), item.MaterialName, item.MaterialQuantity, item.ColorName, item.MaterialPrice);
            }
        }
    }
}
