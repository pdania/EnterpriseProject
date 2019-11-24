using System;
using System.Collections.Generic;
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
    public class DashboardViewModel : BaseViewModel
    {
        #region Fields

        private RelayCommand<object> _generateCommand;
        private RelayCommand<object> _exitCommand;
        private string _startRange;
        private string _endRange;
        private List<int> _result;
        private RelayCommand<object> _loginCommand;
        private RelayCommand<object> _historyCommand;
        private string _user;

        //Implementing singletone pattern to be able to change properties of this class from outside
        private static readonly DashboardViewModel Instance = new DashboardViewModel();

        #endregion

        #region Properties

        public string StartRange
        {
            get { return _startRange; }
            set
            {
                _startRange = value;
                OnPropertyChanged();
            }
        }

        public string EndRange
        {
            get { return _endRange; }
            set
            {
                _endRange = value;
                OnPropertyChanged();
            }
        }

        public List<int> Result
        {
            get { return _result; }
            private set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public string User
        {
            get => _user;
            private set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand<object> GenerateCommand
        {
            get
            {
                return _generateCommand ?? (_generateCommand = new RelayCommand<object>(
                           GenerateImplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<object> ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => Environment.Exit(0))); }
        }

        public RelayCommand<object> LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand =
                           new RelayCommand<object>(o =>
                           {
                               SetNull();
                               NavigationManager.Instance.Navigate(ViewType.Login);
                           }));
            }
        }

        public RelayCommand<object> HistoryCommand
        {
            get
            {
                return _historyCommand ?? (_historyCommand = new RelayCommand<object>(o =>
                {
                    InformationViewModel.GetInstance().UpdateFields();
                    NavigationManager.Instance.Navigate(ViewType.Information);
                }));
            }
        }

        private bool CanExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(StartRange) || string.IsNullOrWhiteSpace(EndRange)) return false;
            if (!EndRange.All(char.IsDigit) || !StartRange.All(char.IsDigit)) return false;
            return Int32.Parse(StartRange) < Int32.Parse(EndRange);
        }

        #endregion

        private void SetNull()
        {
            StartRange = null;
            EndRange = null;
            Result = null;
        }
        private DashboardViewModel()
        {}

        public void UpdateFields()
        {
            User = $"User: {StationManager.CurrentUser.Name} {StationManager.CurrentUser.Surname}";
        }
        public static DashboardViewModel GetInstance()
        {
            return Instance;
        }
        private async void GenerateImplementation(object obj)
        {
            int start = Int32.Parse(StartRange);
            int end = Int32.Parse(EndRange);
            var l = Enumerable.Range(start, end - start);
            LoaderManeger.Instance.ShowLoader();
            var shuffledList = await Task.Run(() => RandomShuffle(l));
            await Task.Run(() =>
            {
                try
                {
                    RestApi.AddRequest(StationManager.CurrentUser.Guid,
                        new Request(Int32.Parse(StartRange), Int32.Parse(EndRange), StationManager.CurrentUser.Guid));
                }
                catch
                {
                    MessageBox.Show("An error occured while adding new request.");
                }
            });
            LoaderManeger.Instance.HideLoader();
            Result = shuffledList;
        }


        private List<T> RandomShuffle<T>(IEnumerable<T> list)
        {
            var random = new Random();
            var shuffle = new List<T>(list);
            for (var i = 2; i < shuffle.Count; ++i)
            {
                var temp = shuffle[i];
                var nextRandom = random.Next(i - 1);
                shuffle[i] = shuffle[nextRandom];
                shuffle[nextRandom] = temp;
            }


            return shuffle;
        }
    }
}