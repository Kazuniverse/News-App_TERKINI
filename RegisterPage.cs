using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace News_App
{
    public partial class RegisterPage : UserControl
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (NewsEntities db = new NewsEntities())
            {
                string un = textBox1.Text.Trim();
                string fn = textBox2.Text.Trim();
                string em = textBox3.Text.Trim();
                string pass = textBox4.Text.Trim();
                string conpass = textBox5.Text.Trim();

                var reg = new Account
                {
                    Username = un,
                    FullName = fn,
                    Email = em,
                    PASSWORD = pass,
                    RoleID = 2
                };

                if (db.Accounts.Any(u => u.Email == reg.Email))
                {
                    MessageBox.Show("Email Is Already Taken!");
                }
                else if (db.Accounts.Any(u => u.Username == reg.Username))
                {
                    MessageBox.Show("Username Is Already Taken!");   
                }
                else if (string.IsNullOrWhiteSpace(un) || string.IsNullOrWhiteSpace(fn)  || string.IsNullOrWhiteSpace(em) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(conpass))
                {
                    MessageBox.Show("Some Information Are Missing!");
                }
                else if (conpass != pass)
                {
                    MessageBox.Show("Confirm Password Doesn't Match!");
                }
                else
                {
                    MessageBox.Show("Register Success!");
                    db.Accounts.Add(reg);
                    db.SaveChanges();
                    Session.UserID = reg.UserID;
                    Session.Role = reg.Role.Name.ToString();

                    var mainForm = (Form1)this.ParentForm;

                    if (Session.Role == "ADMIN")
                    {
                        mainForm.LoadPage(new Admin_Page.AdminDashboard());
                    }
                    else
                    {
                        mainForm.LoadPage(new UserDashboard());
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            var mainForm = (Form1)this.ParentForm;
            mainForm.LoadPage(new LoginPage());
        }
    }
}
