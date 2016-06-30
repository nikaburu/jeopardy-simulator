using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Messages;
using JeopardySimulator.Ui.ViewModels;

namespace JeopardySimulator.Ui.Commands.CommandResults
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