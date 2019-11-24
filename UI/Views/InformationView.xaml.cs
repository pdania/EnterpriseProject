using System.Windows.Controls;
using UI.Tools.Navigation;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Логика взаимодействия для InformationView.xaml
    /// </summary>
    public partial class InformationView : UserControl, INavigatable
    {
        public InformationView()
        {
            InitializeComponent();
            DataContext = InformationViewModel.GetInstance();
        }
    }
}
