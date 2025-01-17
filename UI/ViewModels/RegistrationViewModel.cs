﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
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
        private string _mailHint;
        private string _password;
        private string _confirmPassword;
        private RelayCommand<object> _signUp;
        private string _surname;
        private string _name;
        private Brush _hintColor;


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

        public string MailHint
        {
            get { return _mailHint; }
            set
            {
                _mailHint = value;
                OnPropertyChanged();
            }
        }


        public Brush HintColor
        {
            get { return _hintColor; }
            set
            {
                _hintColor = value;
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
            MailHintChange();
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(ConfirmPassword) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Email)) return false;
            return (ConfirmPassword.Equals(Password)) && IsCorrectEmail();
        }

        private bool IsCorrectEmail()
        {
            return new EmailAddressAttribute().IsValid(Email);
        }
        private void MailHintChange()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                HintColor = Brushes.Gray;
                MailHint = "Enter valid email up here";
                return;
            }
            if (!IsCorrectEmail())
            {
                HintColor = Brushes.Red;
                MailHint = "Email is incorrect";
                return;
            }

            HintColor = Brushes.Green;
            MailHint = "Email is correct";


        }

        private async void SignUpImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                IEnumerable<User> users;
                try
                {
                    users = RestApi.GetAllUsers();
                }
                catch(Exception e)
                {
                    StationManager.Logging.WriteInFile($"{DateTime.Now}-Registration. Error, server connection failed.\r\n Reason: "+e);
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
            LoaderManager.Instance.HideLoader();
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