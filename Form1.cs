using System.Windows.Forms;

namespace News_App
{
    public partial class Form1 : Form
    {
        UserDashboard user = new UserDashboard();
        public Form1()
        {
            InitializeComponent();

            LoadPage(user);
        }

        void LoadPage(UserControl page)
        {
            this.Controls.Clear();
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }
    }
}
