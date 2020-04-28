using AycemOtomasyon.DTO;
using AycemOtomasyon.Forms;
using AycemOtomasyon.Forms.Departments;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            var user = UserRepository.Login(username, password);
            if (user == null || user.UserId == Guid.Empty)
                MessageBox.Show("Yanlış Bilgi", "Hata", MessageBoxButtons.OK);
            else
            {
                var permissions = UserRepository.GetUserPages();

                if (permissions != null)
                {
                    var page = permissions.FirstOrDefault();

                    switch (page.Title.Trim())
                    {
                        case "Depo":
                            var depo = new Depo();
                            depo.Show();
                            break;
                        case "Dikimhane":
                            var dikimhane = new Dikimhane();
                            dikimhane.Show();
                            break;
                        case "Kesimhane":
                            var kesimhane = new Kesimhane();
                            kesimhane.Show();
                            break;
                        case "Baskı":
                            var baski = new Baski();
                            baski.Show();
                            break;
                        case "Boya":
                            var boya = new Boya();
                            boya.Show();
                            break;
                        case "Lojistik":
                            var lojistik = new Lojistik();
                            lojistik.Show();
                            break;
                        case "Admin":
                            var adminform = new AdminForm();
                            adminform.Show();
                            break;
                        case "Teknik Personel":
                            var technicForm = new TechnicForm();
                            technicForm.Show();
                            break;
                        case "Usta Başı":
                            var makine1 = new Makine1();
                            makine1.Show();
                            break;
                        default:
                            break;
                    }
                }

                if (permissions == null)
                {
                    MessageBox.Show("Hata Saptandı", "Hata", MessageBoxButtons.OK);
                }
                else
                    UserRepository.GetUserPages();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var addUser = new DeleteUser();
            addUser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePass change = new ChangePass();
            change.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
            }
        }
    }
}
