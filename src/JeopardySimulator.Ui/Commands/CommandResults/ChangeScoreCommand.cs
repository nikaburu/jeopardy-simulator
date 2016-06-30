using JeopardySimulator.Ui.Commands.Base;
using JeopardySimulator.Ui.ViewModels;

namespace JeopardySimulator.Ui.Commands.CommandResults
{
	public abstract class ChangeScoreCommand : CommandBase<int>
	{
		protected readonly CommandResultViewModel CommandResultViewModel;

		protected ChangeScoreCommand(CommandResultViewModel commandResultViewModel)
		{
			CommandResultViewModel = commandResultViewModel;
		}

		public string CommandName
		{
			get { return CommandResultViewModel.Name; }
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