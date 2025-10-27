using System;
using System.Windows.Forms;

namespace News_App
{
    public partial class UserDashboard : UserControl
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            NewsList news = new NewsList();
            news.Dock = DockStyle.Fill;
            panel1.Controls.Add(news);
        }
    }
}
