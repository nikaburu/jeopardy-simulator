using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands.Base;
using OwnGame.Messages;
using OwnGame.Models;
using OwnGame.ViewModels;

namespace OwnGame.Commands.CommandResults
{
    public abstract class ChangeScoreCommand : CommandBase<int>
    {
        protected readonly CommandResultViewModel CommandResultViewModel;
        
        public string CommandName
        {
            get { return CommandResultViewModel.Name; }
        }

        protected ChangeScoreCommand(CommandResultViewModel commandResultViewModel)
        {
            CommandResultViewModel = commandResultViewModel;
        }

        protected abstract void ChangeScore(int count);

        #region Overrides of CommandBase<int>

        public override void Execute(int parameter)
        {
            ChangeScore(parameter);
        }

        #endregion
    }
}
