using System.Windows.Controls;
using UI.Tools.Navigation;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl,INavigatable
    {
        public RegistrationView()
        {
            InitializeComponent();
            DataContext =  new RegistrationViewModel();
        }
    }
}
