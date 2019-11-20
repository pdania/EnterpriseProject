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

        private RelayCommand _googleCommand;
        private RelayCommand _closeCommand;

        #endregion

        #region Properties

        public string CardNumber
        {
            get { return _cardNumber; }
            set
            {
                _cardNumber = value;
                _googleCommand.RaiseCanExecuteChanged();
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
                _googleCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        public int Tries { get; set; }

        #region Commands

        public RelayCommand GoogleCommand
        {
            get
            {
                return _googleCommand ??
                       (_googleCommand = new RelayCommand(SignInImplementation, () => CanExecuteCommand()));
            }
        }

        public RelayCommand CloseCommand
        {
            get { return _closeCommand = new RelayCommand(); }
        }

        #endregion

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

        
        private async void SignInImplementation()
        {
           
        }
    }
}