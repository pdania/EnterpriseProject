using System;
using System.Linq;
using System.Windows;
using UI.Tools;
using UI.Tools.Managers;
using UI.Tools.Navigation;

namespace UI.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        #region Fields

        private string _login;
        private string _password;
        private string _information;

        #endregion

        #region Commands

        private RelayCommand<object> _loginCommand;
        private RelayCommand<object> _registrCommand;
        private RelayCommand<object> _closeCommand;

        #endregion

        #region Properties

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Information
        {
            get { return _information; }
            set => _information = value;
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands

        public RelayCommand<object> SignInCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand<object>(
                           LoginImplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<object> SignUpCommand
        {
            get
            {
                return _registrCommand ?? (_registrCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Registration)));
            }
        }

        public RelayCommand<object> CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0))); }
        }

        #endregion


        private bool CanExecuteCommand()
        {
            return true;
            if (string.IsNullOrWhiteSpace(Password)) return false;
            return  CanExecutePin();
            ;
        }

        

        private bool CanExecutePin()
        {
            return Password.All(char.IsDigit) && Password.Length == 4;
        }

        
        private async void LoginImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Dashboard);
        }
    }
}