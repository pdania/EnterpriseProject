using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI.Tools.Navigation;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Логика взаимодействия для DashBoardView.xaml
    /// </summary>
    public partial class DashBoardView : Window,INavigatable
    {
        public DashBoardView()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }
    }
}
