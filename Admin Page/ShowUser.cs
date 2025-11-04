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
    public partial class ShowUser : UserControl
    {
        public ShowUser()
        {
            InitializeComponent();
        }

        private void ShowUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            using (NewsEntities db = new NewsEntities())
            {
                var user = db.Accounts
                    .Select(u => new
                    {
                        u.UserID,
                        u.Username,
                        u.FullName,
                        u.Email,
                        Role = u.Role.Name,
                        u.CreatedAt
                    })
                    .ToList();

                dataGridView1.DataSource = user;
                textBox1.Controls.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
        }

        void Filter()
        {
            using (NewsEntities db = new NewsEntities())
            {
                var 
            }
        }
    }
}
