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
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = " ";
            }
        }

        void Filter()
        {
            using (NewsEntities db = new NewsEntities())
            {
                string text = textBox1.Text;
                DateTime tgl = dateTimePicker1.Value.Date;
                int role = (int)(comboBox1.SelectedValue ?? -1);
                var nextDay = tgl.AddDays(1);

                var fil = db.Accounts
                    .Where(u => (string.IsNullOrEmpty(text) || u.FullName.Contains(text) || u.Username.Contains(text) || u.Email.Contains(text)) &&
                                (role == -1 || u.Role.RoleID == role) && (dateTimePicker1.Format != DateTimePickerFormat.Custom ? (u.CreatedAt >= tgl && u.CreatedAt < nextDay) : true))
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var user = (string)dataGridView1.CurrentRow.Cells["usernameDataGridViewTextBoxColumn"].Value;
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["userIDDataGridViewTextBoxColumn"].Value);

            using (NewsEntities db = new NewsEntities())
            {
                var slct = db.Accounts.FirstOrDefault(u => u.UserID == id);

                DialogResult result = MessageBox.Show($"Are You Sure To Delete User \"{user}\"?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.Accounts.Remove(slct);
                    db.SaveChanges();
                    MessageBox.Show("Delete Successfully!");
                }
                else
                {
                    MessageBox.Show("Delete Cancelled!");
                }
                LoadData();
            }
        }
    }
}
