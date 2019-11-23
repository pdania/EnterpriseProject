using UI.Tools;
using UI.Tools.Managers;
using UI.Tools.Navigation;

namespace UI.ViewModels
{
    public class InformationViewModel: BaseViewModel
    {
        private RelayCommand<object> _backCommand;
        private string _user;

        public string User
        {
            get
            {
                return _user;
            }
            set => _user=value;
        }

        public RelayCommand<object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Dashboard)));
            }
        }

        public InformationViewModel()
        {

        }
    }
}