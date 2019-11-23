using System.Windows;
using System.Windows.Controls;
using UI.Tools.Managers;
using UI.Tools.Navigation;
using UI.ViewModels;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Login);
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
