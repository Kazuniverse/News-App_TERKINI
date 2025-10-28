using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace News_App.Admin_Page
{
    public partial class AdminDashboard : UserControl
    {
        ShowUser user = new ShowUser();
        ShowContent content = new ShowContent();
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadPage(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPage(user);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadPage(content);
        }

        void LoadPage(UserControl page)
        {
            panel1.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panel1.Controls.Add(page);
        }
    }
}
