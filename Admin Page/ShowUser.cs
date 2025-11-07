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

                var role = db.Roles
                    .Select(u => new
                    {
                        u.RoleID,
                        u.Name
                    })
                    .ToList();

                dataGridView1.DataSource = user;
                textBox1.Clear();
                comboBox1.DataSource = role;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "RoleID";
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
        }

        void Filter()
        {
            using (NewsEntities db = new NewsEntities())
            {
                string text = textBox1.Text;
                int role = (int)(comboBox1.SelectedValue ?? -1);

                var fil = db.Accounts
                    .Where(u => (string.IsNullOrEmpty(text) || u.FullName.Contains(text) || u.Username.Contains(text) || u.Email.Contains(text)) &&
                    (role == -1 || u.Role.RoleID == role) && (dateTimePicker1.Format != DateTimePickerFormat.Custom ? u.CreatedAt == dateTimePicker1.Value : true))
                    .Select(u => new
                    {
                        u.UserID,
                        u.Username,
                        u.FullName,
                        u.Email,
                        u.Role,
                        u.CreatedAt
                    })
                    .ToList();

                dataGridView1.DataSource = fil;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
