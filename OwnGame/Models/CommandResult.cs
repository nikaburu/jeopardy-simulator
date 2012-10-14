using System;

namespace OwnGame.Models
{
    public class CommandResult
    {
        public CommandResult(string name)
        {
            Name = name;
            Score = 0;
        }

        public string Name { get; private set; }
        public int Score { get; private set; }

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