using News_App.Component;
using System;
using System.Linq;
using System.Windows.Forms;

namespace News_App
{
    public partial class NewsList : UserControl
    {
        public NewsList()
        {
            InitializeComponent();
        }

        void LoadPage()
        {
            using (NewsEntities db = new NewsEntities())
            {
                flowLayoutPanel1.Controls.Clear();

                var contents = db.Contents.ToList();

                foreach (var content in contents)
                {
                    NewsCard card = new NewsCard
                    {
                        Title = content.Title,
                        Author = content.Account.Username,
                        PublishTime = content.CreatedAt.ToString()
                    };

                    flowLayoutPanel1.Controls.Add(card);
                    card.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }
            }
        }

        private void NewsList_Load(object sender, EventArgs e)
        {
            NewsContent news = new NewsContent();
            flowLayoutPanel1.Controls.Add(news);
        }

        private void FlowLayoutPanel1_Layout(object sender, LayoutEventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                ctrl.Width = flowLayoutPanel1.ClientSize.Width - 10;
            }
        }
    }
}
