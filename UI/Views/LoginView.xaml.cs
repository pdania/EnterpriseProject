using System.Windows.Controls;
using UI.Tools.Navigation;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl,INavigatable
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
