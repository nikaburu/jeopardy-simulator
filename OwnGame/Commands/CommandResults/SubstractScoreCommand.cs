using OwnGame.Models;
using OwnGame.ViewModels;

namespace OwnGame.Commands.CommandResults
{
    class SubstractScoreCommand : ChangeScoreCommand
    {
        public SubstractScoreCommand(CommandResultViewModel commandResultViewModel)
            : base(commandResultViewModel)
        {
        }

        #region Overrides of ChangeScoreCommand

        protected override void ChangeScore(int count)
        {
            CommandResultViewModel.SubstractScore(count);
        }

        #endregion
    }
}