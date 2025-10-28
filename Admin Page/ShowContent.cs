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
    public partial class ShowContent : UserControl
    {
        public ShowContent()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            using (NewsEntities db = new NewsEntities())
            {
                var content = db.Contents
                    .Select(u => new
                    {
                        u.ContentID,
                        u.Title,
                        u.Description,
                        AuthorID = u.Account.Username,
                        u.CreatedAt
                    })
                    .ToList();

                textBox1.Clear();
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dataGridView1.DataSource = content;
            }
        }

        private void ShowContent_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Filter(object sender, EventArgs e)
        {
            using (NewsEntities db = new NewsEntities())
            {
                string text = textBox1.Text;
                DateTime date = dateTimePicker1.Value;

                var content = db.Contents
                    .Where(u => (string.IsNullOrEmpty(text) || u.Title.ToLower().Contains(text) || u.Description.ToLower().Contains(text) || u.Account.Username.ToLower().Contains(text)) &&
                    (dateTimePicker1.Format != DateTimePickerFormat.Custom ? u.CreatedAt == date : true))
                    .Select(u => new
                    {
                        u.ContentID,
                        u.Title,
                        u.Description,
                        AuthorID = u.Account.Username,
                        u.CreatedAt
                    })
                    .ToList();

                dataGridView1.DataSource = content;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var title = (string)dataGridView1.CurrentRow.Cells["Title"].Value;
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Column1"].Value);

            using (NewsEntities db = new NewsEntities())
            {
                var content = db.Contents.FirstOrDefault(u => u.ContentID == id);

                DialogResult result = MessageBox.Show($"Are You Sure To Delete \"{title}\"?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.Contents.Remove(content);
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

        private void button2_Click(object sender, EventArgs e)
        {
            AddNews news = new AddNews();
            news.Show();
        }
    }
}
