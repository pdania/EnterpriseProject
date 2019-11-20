using System;
using System.Linq;
using UI.Tools;
using UI.Tools.Managers;
using UI.Tools.Navigation;

namespace UI.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        #region Fields

        private string _cardNumber;
        private string _password;
        private string _information;

        #endregion

        #region Commands

        private RelayCommand<object> _loginCommand;
        private RelayCommand<object> _closeCommand;

        #endregion

        #region Properties

        public string CardNumber
        {
            get { return _cardNumber; }
            set
            {
                _cardNumber = value;
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

        public RelayCommand<object> LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand<object>(
                           LoginImplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<object> CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0))); }
        }

        #endregion


        private bool CanExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(Password)) return false;
            return CanExecuteCardNumber() && CanExecutePin();
            ;
        }

        private bool CanExecuteCardNumber()
        {
            return CardNumber.All(char.IsDigit) && CardNumber.Length == 16;
        }

        private bool CanExecutePin()
        {
            return Password.All(char.IsDigit) && Password.Length == 4;
        }

        
        private async void LoginImplementation(object obj)
        {
           
        }
    }
}