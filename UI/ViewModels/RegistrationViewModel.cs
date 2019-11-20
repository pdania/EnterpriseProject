using System;
using System.Net.Mail;
using UI.Tools;
using UI.Tools.Managers;
using UI.Tools.Navigation;


namespace UI.ViewModels
{
    public class RegistrationViewModel:BaseViewModel
    {
        private RelayCommand<object> _cancelCommand;
        private string _login;
        private string _email;
        private string _password;
        private string _confrimPassword;
        private RelayCommand<object> _signUp;


        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
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
        public string ConfrimPassword
        {
            get { return _confrimPassword; }
            set
            {
                _confrimPassword = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> SignUPCommand
        {
            get
            {
                return _signUp ?? (_signUp = new RelayCommand<object>(
                           SignUpImplementation, o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return (ConfrimPassword.Equals(Password)) && IsEmailValid(Email);
        }
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void SignUpImplementation(object obj)
        {
            throw new System.NotImplementedException();
        }

        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Login))); }
        }
    }
}