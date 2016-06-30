using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Commands.CommandResults;
using JeopardySimulator.Ui.Messages;

namespace JeopardySimulator.Ui.ViewModels
{
	public class CommandResultViewModel : ObservableObject
	{
		public CommandResultViewModel(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("name");

			Name = name;
			Score = 0;

			#region Commands initialize

			AddScoreCommand = new AddScoreCommand(this);
			SubstractScoreCommand = new SubstractScoreCommand(this);

			AddScorePopupCommand = new RelayCommand<int>(
				delegate(int scr)
				{
					Messenger.Default.Send(
						new PopupActivateMessage(new PopupActivateArgs(AddScoreCommand, scr)));
				});

			SubstractScorePopupCommand = new RelayCommand<int>(
				delegate(int scr)
				{
					Messenger.Default.Send(
						new PopupActivateMessage(new PopupActivateArgs(SubstractScoreCommand, scr)));
				});

			#endregion
		}

		public CommandResultViewModel(string name, bool isActivated, bool isDisabled) : this(name)
		{
			IsActivated = isActivated;
			IsDisabled = isDisabled;
		}

		#region Commands

		public ChangeScoreCommand AddScoreCommand { get; }
		public ChangeScoreCommand SubstractScoreCommand { get; }

		public RelayCommand<int> AddScorePopupCommand { get; private set; }
		public RelayCommand<int> SubstractScorePopupCommand { get; private set; }

		#endregion

		#region Properties

		public string Name { get; private set; }
		private int _score;
		private bool _isActivated;

		public int Score
		{
			get { return _score; }
			private set
			{
				_score = value;
				RaisePropertyChanged(() => Score);
			}
		}

		public bool IsActivated
		{
			get { return _isActivated; }
			private set
			{
				_isActivated = value;
				RaisePropertyChanged(() => IsActivated);
			}
		}

		private int _currentBet;
		private bool _isDisabled;

		public int CurrentBet
		{
			get { return _currentBet; }
			set
			{
				_currentBet = value;
				RaisePropertyChanged(() => CurrentBet);
			}
		}

		public bool IsDisabled
		{
			get { return _isDisabled; }
			private set
			{
				_isDisabled = value;
				RaisePropertyChanged(() => IsDisabled);
			}
		}

		#endregion

		#region Public methods

		public void AddScore(int score)
		{
			if (score <= 0) throw new ArgumentException("score");

			Score += score;
		}

		public void SubstractScore(int score)
		{
			if (score <= 0) throw new ArgumentException("score");

			Score -= score;
		}

		public void Activate(int bet)
		{
			if (IsDisabled) return;

			IsActivated = true;
			CurrentBet = bet;
		}

		public void Deactivate()
		{
			IsActivated = false;
			CurrentBet = 0;
		}

		public void Disable()
		{
			IsDisabled = true;
		}

		#endregion
	}
}