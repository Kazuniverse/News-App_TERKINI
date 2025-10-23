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
