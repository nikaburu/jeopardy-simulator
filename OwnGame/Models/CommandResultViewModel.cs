using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Messages;

namespace OwnGame.Models
{
    public class CommandResultViewModel : ViewModelBase
    {
        public CommandResultViewModel(string name)
        {
            Name = name;
            Score = 0;

            AddScoreCommand = new RelayCommand<int>(scr => Messenger.Default.Send(new PopupActivateMessage(new Tuple<ChangeScoreCommand, int>(new AddScoreCommand(this), scr))));
            SubstractScoreCommand = new RelayCommand<int>(scr => Messenger.Default.Send(new PopupActivateMessage(new Tuple<ChangeScoreCommand, int>(new SubstractScoreCommand(this), scr))));
        }

        public RelayCommand<int> AddScoreCommand { get; set; }
        public RelayCommand<int> SubstractScoreCommand { get; set; }

        public string Name { get; private set; }
        private int _score;
        public int Score
        {
            get { return _score; }
            private set
            {
                _score = value;
                RaisePropertyChanged(() => Score);
            }
        }

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

    }
}