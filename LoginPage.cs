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
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string fullname = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();

            using (NewsEntities db = new NewsEntities())
            {
                var acc = db.Accounts.SingleOrDefault(u => u.Email == email && u.FullName == fullname);

                if (acc == null)
                {
                    MessageBox.Show("Information Invalid!");
                    return;
                }

                bool valid = acc.PASSWORD == password;

                if (!valid)
                {
                    MessageBox.Show("Information Invalid!");
                    return;
                }

                Session.UserID = acc.UserID;
                Session.Role = acc.Role.Name.ToString();
                MessageBox.Show("Login Success!");

                var mainForm = (Form1)this.ParentForm;

                if (Session.Role.Equals("ADMIN", StringComparison.OrdinalIgnoreCase))
                {
                    mainForm.LoadPage(new Admin_Page.AdminDashboard());
                }
                else
                {
                    mainForm.LoadPage(new UserDashboard());
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var mainForm = (Form1)this.ParentForm;
            mainForm.LoadPage(new RegisterPage());
        }
    }
}
