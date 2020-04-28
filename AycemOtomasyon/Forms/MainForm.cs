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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            var permissions = UserRepository.GetUserPages();
            var user = CurrentUser.LoginUser;
           

            if(permissions != null) 
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
}
