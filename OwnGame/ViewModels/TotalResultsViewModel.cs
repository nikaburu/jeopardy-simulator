using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OwnGame.Messages;

namespace OwnGame.ViewModels
{
    public class TotalResultsViewModel : ViewModelBase
    {
        public TotalResultsViewModel()
        {
            MessengerInstance.Register<RoundEndedMessage>(this, OnRoundEnded);
        }

        private void OnRoundEnded(RoundEndedMessage message)
        {
            IsGameEnded = message.IsGameEnded;
            NextRoundCommand = new RelayCommand(() => MessengerInstance.Send(new NextRoundMessage()));
        }

        public bool IsGameEnded
        {
            get {
                return _isGameEnded;
            }
            set {
                _isGameEnded = value;
                RaisePropertyChanged(() => IsGameEnded);
            }
        }

        private RelayCommand _nextRoundCommand;
        private bool _isGameEnded;

        public RelayCommand NextRoundCommand
        {
            get { return _nextRoundCommand; }
            set
            {
                _nextRoundCommand = value;
                RaisePropertyChanged(() => NextRoundCommand);
            }
        }
    }
}