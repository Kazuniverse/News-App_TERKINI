using News_App.Admin_Page;
using System.Windows.Forms;

namespace News_App
{
    public partial class Form1 : Form
    {
        UserDashboard user = new UserDashboard();
        AdminDashboard admin = new AdminDashboard();
        LoginPage login = new LoginPage();
        RegisterPage register = new RegisterPage();
        public Form1()
        {
            InitializeComponent();

            LoadPage(login);
        }

        public void LoadPage(UserControl page)
        {
            this.Controls.Clear();
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }
    }
}
