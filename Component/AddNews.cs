using System.Windows.Forms;

namespace News_App
{
    public partial class AddNews : UserControl
    {
        private string role = Session.Role;
        public AddNews()
        {
            InitializeComponent();

            if (role == "ADMIN")
            {
                button3.Visible = true;
            }
        }
    }
}
