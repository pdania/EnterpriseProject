using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class RegistrationViewModel:BaseViewModel
    {
        private RelayCommand<object> _cancelCommand;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private RelayCommand<object> _signUp;
        private string _surname;
        private string _name;


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
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
                _password = string.IsNullOrWhiteSpace(value) ? null : Cipher.Encrypt(value);
                OnPropertyChanged();
            }
        }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = string.IsNullOrWhiteSpace(value) ? null : Cipher.Encrypt(value);
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> SignUpCommand
        {
            get
            {
                return _signUp ?? (_signUp = new RelayCommand<object>(
                           SignUpImplementation, o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(ConfirmPassword) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Email)) return false;
            return (ConfirmPassword.Equals(Password)) && new EmailAddressAttribute().IsValid(Email);
        }

        private async void SignUpImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                IEnumerable<User> users;
                try
                {
                    users = RestApi.GetAllUsers();
                }
                catch
                {
                    MessageBox.Show(
                        "Error, server connection failed");
                    return false;
                }
                var user = (from userIterator in users
                    where userIterator.Email == Email
                    select userIterator).FirstOrDefault();
                if (user != null)
                {
                    MessageBox.Show(
                        $"Sign up failed fo user {Email}. Reason:{Environment.NewLine}User with such email already exists");
                    Password = null;
                    ConfirmPassword = null;
                    return false;
                }
                RestApi.AddUser(new User(Name,Surname,Email,Password));
                MessageBox.Show($"Sign Up successful for user {Name} {Surname}.");
                return true;
            });
            LoaderManeger.Instance.HideLoader();
            if (result)
            {
                SetNull();
                NavigationManager.Instance.Navigate(ViewType.Login);
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(o =>
                             {
                                 SetNull();
                                 NavigationManager.Instance.Navigate(ViewType.Login);
                             })); }
        }

        private void SetNull()
        {
            Email = null;
            Password = null;
            ConfirmPassword = null;
            Name = null;
            Surname = null;
        }
    }
}