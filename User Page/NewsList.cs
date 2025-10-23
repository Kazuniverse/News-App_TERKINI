using News_App.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
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
                    NewsCard card = new NewsCard();

                    card.Title = content.Title;
                    card.Author = content.Account.Username;
                    card.PublishTime = content.CreatedAt.ToString();

                    flowLayoutPanel1.Controls.Add(card);
                    card.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }
            }
        }

        private void NewsList_Load(object sender, EventArgs e)
        {
            LoadPage();
        }
    }
}
