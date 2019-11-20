using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Tools;
using UI.Tools.Managers;
using UI.Tools.Navigation;

namespace UI.ViewModels
{
    public class DashboardViewModel:BaseViewModel
    {
        private RelayCommand<object> _generateCommand;
        private RelayCommand<object> _exitCommand;
        private string _startRange;
        private string _endRange;
        private List<int> _result;

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
            get
            {
                return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.Login)));
            }
        }

        private bool CanExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(StartRange)|| string.IsNullOrWhiteSpace(EndRange)) return false;
            if (!EndRange.All(char.IsDigit) || !StartRange.All(char.IsDigit)) return false;
            return Convert.ToInt32(StartRange)< Convert.ToInt32(EndRange);
            ;
        }
        public List<int> Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        private void GenerateImplementation(object obj)
        {
            int start = Convert.ToInt32(StartRange);
            int end = Convert.ToInt32(EndRange);
            var l = Enumerable.Range(start,end-start+1 );
            var res = RandomShuffle(l);
//            string answer = "";
//            foreach (var num in res)
//            {
//                answer += num + " ";
//            }
            Result = (List<int>) res;
            
        }

       

        public static IList<T> RandomShuffle<T>(IEnumerable<T> list)
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