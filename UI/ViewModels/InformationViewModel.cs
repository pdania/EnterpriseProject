using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
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

        public string User
        {
            get
            {
                return _user;
            }
            set => _user=value;
        }

        public List<Request> Requests
        {
            get => _requests;
            set
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
        public InformationViewModel()
        {
            User = $"User: {StationManager.CurrentUser.Name} {StationManager.CurrentUser.Surname}";
            GetRequests();
        }
        private async void GetRequests()
        {
            LoaderManeger.Instance.ShowLoader();
            var requests = await Task.Run(() =>
            {
                try
                {
                    return RestApi.GetAllRequests(StationManager.CurrentUser.Guid);
                    
                }
                catch
                {
                    MessageBox.Show($"An error occured while trying to get all requests");
                    return null;
                }
            });
            Requests = requests.OrderByDescending(x => x.RequestTime).ToList();
            LoaderManeger.Instance.HideLoader();
        }
    }
}