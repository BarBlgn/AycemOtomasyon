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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            GetErrorList();
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

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteUser deleteuser = new DeleteUser();
            deleteuser.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowOrders showOrders = new ShowOrders();
            showOrders.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteOrder deleteOrder = new DeleteOrder();
            deleteOrder.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddMaterialForm addmaterialForm = new AddMaterialForm();
            addmaterialForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ProductScreen productScreen = new ProductScreen();
            productScreen.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowReports showReports = new ShowReports();
            showReports.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            updateUser.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            MaterialForm materialForm = new MaterialForm();
            materialForm.Show();
        }

        private void btnClick(object sender, EventArgs e) 
        {
            var button = (CustomButton)sender;
            MessageBox.Show(button.MessageText);
        }

        private void GetErrorList()
        {
            var errors = ErrorRepository.GetErrorList();

            var i = 0;

            foreach (var item in errors)
            {
                var panel = new Panel();
                panel.Width = 250;
                panel.Height = 100;
                panel.Location = new Point(9, 40 + (i * 120));
                panel.BackColor = Color.DarkRed;

                var datePanel = new Panel();
                datePanel.BackColor = Color.White;
                datePanel.Location = new Point(0, 0);
                datePanel.Size = new Size(100, 20);

                var dateLabel = new Label();
                dateLabel.Text = item.CreateDate.ToLongDateString();
                dateLabel.ForeColor = Color.Black;

                datePanel.Controls.Add(dateLabel);

                var label = new Label();
                label.Text = item.Message;
                label.Size = new Size(230, 40);
                label.ForeColor = Color.White;
                label.Location = new Point(10, 30);
                label.Font = new Font("Microsoft Sans Serif", 10);

                var button = new CustomButton();
                button.Text = "Tamamını Oku";
                button.MessageText = item.Message;
                button.Click += new EventHandler(btnClick);
                button.BackColor = Color.Beige;
                button.Location = new Point(120, 70);
                button.Size = new Size(120, 25);

                panel.Controls.Add(button);
                panel.Controls.Add(label);
                panel.Controls.Add(datePanel);
                groupBox4.Controls.Add(panel);
                i++;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Makine1 makine1 = new Makine1();
            makine1.Show();
        }

      

        private void button6_Click_1(object sender, EventArgs e)
        {
            AddMachine addMachine = new AddMachine();
            addMachine.Show();
        }
    }
}
