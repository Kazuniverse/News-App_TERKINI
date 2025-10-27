using System.Windows.Forms;

namespace News_App.Component
{
    public partial class NewsCard : UserControl
    {
        public NewsCard()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public string Author
        {
            get => label3.Text;
            set => label3.Text = value;
        }

        public string PublishTime
        {
            get => label2.Text;
            set => label2.Text = value;
        }
    }
}
