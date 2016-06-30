using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JeopardySimulator.Ui.Messages;

namespace JeopardySimulator.Ui.ViewModels
{
	public class TotalResultsViewModel : ViewModelBase
	{
		private bool _isGameEnded;

		private RelayCommand _nextRoundCommand;

		public TotalResultsViewModel()
		{
			MessengerInstance.Register<RoundEndedMessage>(this, OnRoundEnded);
		}

		public bool IsGameEnded
		{
			get { return _isGameEnded; }
			set
			{
				_isGameEnded = value;
				RaisePropertyChanged(() => IsGameEnded);
			}
		}

		public RelayCommand NextRoundCommand
		{
			get { return _nextRoundCommand; }
			set
			{
				_nextRoundCommand = value;
				RaisePropertyChanged(() => NextRoundCommand);
			}
		}

		private void OnRoundEnded(RoundEndedMessage message)
		{
			IsGameEnded = message.IsGameEnded;
			NextRoundCommand = new RelayCommand(() => MessengerInstance.Send(new NextRoundMessage()));
		}
	}
}