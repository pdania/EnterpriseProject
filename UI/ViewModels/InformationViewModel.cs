using System;
using System.Collections.Generic;
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
            set => _requests = value;
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
            LoaderManeger.Instance.ShowLoader();
            User = $"User: {StationManager.CurrentUser.Name} {StationManager.CurrentUser.Surname}";
            Requests = GetRequests().Result;
            LoaderManeger.Instance.HideLoader();
        }

        private async Task<List<Request>> GetRequests()
        {
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
            return requests;
        }
    }
}