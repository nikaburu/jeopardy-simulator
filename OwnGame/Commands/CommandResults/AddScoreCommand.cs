using GalaSoft.MvvmLight.Messaging;
using OwnGame.Messages;
using OwnGame.Models;
using OwnGame.ViewModels;

namespace OwnGame.Commands.CommandResults
{
    public class AddScoreCommand : ChangeScoreCommand
    {
        public AddScoreCommand(CommandResultViewModel commandResultViewModel)
            : base(commandResultViewModel)
        {
        }

        #region Overrides of ChangeScoreCommand

        protected override void ChangeScore(int count)
        {
            CommandResultViewModel.AddScore(count);
            Messenger.Default.Send(new UnloadQuestionMessage());
        }

        #endregion
    }
}