using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClientSide;
using DBModels;
using UI.Tools;
using UI.Tools.Managers;
using UI.Tools.Navigation;

namespace UI.ViewModels
{
    public class InformationViewModel: BaseViewModel
    {
        private RelayCommand<object> _backCommand;
        private string _user;
        private List<Request> _requests;
        private RelayCommand<object> _refreshCommand;

        //Implementing singletone pattern to be able to change properties of this class from outside
        private static readonly InformationViewModel Instance = new InformationViewModel();

        public string User
        {
            get
            {
                return _user;
            }
            private set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public List<Request> Requests
        {
            get => _requests;
            private set
            {
                _requests = value; 
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Dashboard)));
            }
        }

        public RelayCommand<object> RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new RelayCommand<object>(o => GetRequests()));
            }
        }

        public void UpdateFields()
        {
            LoaderManeger.Instance.ShowLoader();
            User = $"User: {StationManager.CurrentUser.Name} {StationManager.CurrentUser.Surname}";
            GetRequests();
            LoaderManeger.Instance.HideLoader();
        }
        private InformationViewModel()
        {}
        public static InformationViewModel GetInstance()
        {
            return Instance;
        }
        private async void GetRequests()
        {
            var requests = await Task.Run(() =>
            {
                try
                {
                    return RestApi.GetAllRequests(StationManager.CurrentUser.Guid);
                    
                }
                catch(Exception e)
                {
                    StationManager.Logging.WriteInFile($"{DateTime.Now}-InformationView. An error occured while trying to get all requests.\r\n Reason: " +e.ToString());
                    MessageBox.Show("An error occured while trying to get all requests");
                    return null;
                }
            });
            Requests = requests.OrderByDescending(x => x.RequestTime).ToList();
        }
    }
}