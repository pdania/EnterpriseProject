using System.Windows.Controls;
using UI.Tools.Navigation;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Логика взаимодействия для DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl,INavigatable
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext =new  DashboardViewModel();
        }
    }
}
