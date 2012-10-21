using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Commands.CommandResults;
using OwnGame.Messages;

namespace OwnGame.Models
{
    public class CommandResultViewModel : ViewModelBase
    {
        public CommandResultViewModel(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException("name");

            Name = name;
            Score = 0;

            AddScoreCommand = new AddScoreCommand(this);
            SubstractScoreCommand = new SubstractScoreCommand(this);

            AddScorePopupCommand = new RelayCommand<int>(
                delegate(int scr)
                    {
                        Messenger.Default.Send(
                            new PopupActivateMessage(new Tuple<ChangeScoreCommand, int>(AddScoreCommand, scr)));
                    });

            SubstractScorePopupCommand = new RelayCommand<int>(
                delegate(int scr)
                    {
                        Messenger.Default.Send(
                            new PopupActivateMessage(new Tuple<ChangeScoreCommand, int>(SubstractScoreCommand, scr)));
                    });
        }

        #region Commands
        public ChangeScoreCommand AddScoreCommand { get; private set; }
        public ChangeScoreCommand SubstractScoreCommand { get; private set; }

        public RelayCommand<int> AddScorePopupCommand { get; private set; }
        public RelayCommand<int> SubstractScorePopupCommand { get; private set; }
        #endregion

        #region Properties
        public string Name { get; private set; }
        private int _score;
        private bool _isActive;

        public int Score
        {
            get { return _score; }
            private set
            {
                _score = value;
                RaisePropertyChanged(() => Score);
            }
        }

        public bool IsActive
        {
            get {
                return _isActive;
            }
            private set {
                _isActive = value;
                RaisePropertyChanged(() => IsActive);
            }
        }

        private int _currentBet;
        public int CurrentBet
        {
            get { return _currentBet; }
            private set
            {
                _currentBet = value;
                RaisePropertyChanged(() => CurrentBet);
            }
        }

        #endregion

        public void AddScore(int score)
        {
            if (score <= 0) throw new ArgumentException("score");

            Score += score;
        }

        public void SubstractScore(int score)
        {
            if (score <= 0) throw new ArgumentException("score");

            Score -= score;

            if (Score < 0)
            {
                Score = 0;
            }
        }

        public void Activate(int bet)
        {
            IsActive = true;
            CurrentBet = bet;
        }

        public void Deactivate()
        {
            IsActive = false;
            CurrentBet = 0;
        }
    }
}