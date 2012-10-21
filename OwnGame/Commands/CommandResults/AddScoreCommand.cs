using OwnGame.Models;
using OwnGame.ViewModels;

namespace OwnGame.Commands.CommandResults
{
    class AddScoreCommand : ChangeScoreCommand
    {
        public AddScoreCommand(CommandResultViewModel commandResultViewModel)
            : base(commandResultViewModel)
        {
        }

        #region Overrides of ChangeScoreCommand

        protected override void ChangeScore(int count)
        {
            CommandResultViewModel.AddScore(count);
        }

        #endregion
    }
}