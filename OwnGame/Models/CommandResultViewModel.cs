using System;
using GalaSoft.MvvmLight;
using OwnGame.Commands;

namespace OwnGame.Models
{
    public class CommandResultViewModel : ViewModelBase
    {
        public CommandResultViewModel(string name)
        {
            Name = name;
            Score = 0;

            AddScoreCommand = new AddScoreCommand(this);
            SubstractScoreCommand = new SubstractScoreCommand(this);
        }

        public CommandBase<int> AddScoreCommand { get; set; }
        public CommandBase<int> SubstractScoreCommand { get; set; }

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