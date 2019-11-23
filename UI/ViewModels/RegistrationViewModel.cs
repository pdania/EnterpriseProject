using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;
using ClientSide;
using DBModels;
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
                if (value.Length != 0)
                    _password = null;
                else
                    _password = Cipher.Encrypt(value);
                OnPropertyChanged();
            }
        }
        public string ConfrimPassword
        {
            get { return _confrimPassword; }
            set
            {
                if (value.Length != 0)
                    _confrimPassword = null;
                else
                    _confrimPassword = Cipher.Encrypt(value);
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

        private async void SignUpImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                var users = RestApi.GetAllUsers();
                var user = (from userIterator in users
                    where userIterator.Email == Email
                    select userIterator).First();
                if (user != null)
                {
                    MessageBox.Show(
                        $"Sign up failed fo user {Email}. Reason:{Environment.NewLine}User with such email already exists");
                    return false;
                }
                RestApi.AddUser(new User());
                StationManager.CurrentUser = user;
                MessageBox.Show($"Sign In successfull fo user {Email}.");
                return true;
            });
            LoaderManeger.Instance.HideLoader();
            if (result)
            {
                NavigationManager.Instance.Navigate(ViewType.Login);
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Login))); }
        }
    }
}