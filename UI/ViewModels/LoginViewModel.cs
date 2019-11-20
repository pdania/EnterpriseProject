﻿using System;
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
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private string _email;
        private string _password;

        #endregion

        #region Commands

        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _closeCommand;
        private RelayCommand<object> _signUpCommand;

        #endregion

        #region Properties

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
                _password = Cipher.Encrypt(value);
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand<object> SignInCommand
        {
            get

            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(
                           SignInImplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<object> SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Registration))); }
        }

        public RelayCommand<object> CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0))); }
        }

        #endregion


        private bool CanExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password)) return false;
            return new EmailAddressAttribute().IsValid(Email);
        }

        private async void SignInImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();


            var result = await Task.Run(() =>
            {
                var users = RestApi.GetAllUsers();
                var user = (from userIterator in users
                    where userIterator.Email == Email && userIterator.Password == Password
                    select userIterator).First();
                if (user == null)
                {
                    MessageBox.Show(
                        $"Sign in failed fo user {Email}. Reason:{Environment.NewLine}User doesn't exist, sign up first");
                    return false;
                }

                StationManager.CurrentUser = user;
                MessageBox.Show($"Sign In successfull fo user {Email}.");
                return true;
            });
            if (result)
            {
                NavigationManager.Instance.Navigate(ViewType.Dashboard);
            }
        }
    }
}