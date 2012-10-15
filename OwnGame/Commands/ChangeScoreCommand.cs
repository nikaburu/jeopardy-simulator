using System;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Controls.ViewModels;
using OwnGame.Messages;
using OwnGame.Models;
using OwnGame.Servicies;
using OwnGame.ViewModels;

namespace OwnGame.Commands
{
    public abstract class ChangeScoreCommand : CommandBase<int>
    {
        protected readonly CommandResultViewModel CommandResultViewModel;

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
