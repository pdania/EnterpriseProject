﻿
using System.Windows;
using UI.Tools;
using UI.Tools.Managers;

namespace UI.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        #region Fields
        private Visibility _loaderVisibility = Visibility.Collapsed;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}
