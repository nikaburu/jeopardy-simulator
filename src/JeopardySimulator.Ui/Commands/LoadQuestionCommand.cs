using System;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Commands.Base;
using JeopardySimulator.Ui.Controls.ViewModels;
using JeopardySimulator.Ui.Messages;

namespace JeopardySimulator.Ui.Commands
{
	public sealed class LoadQuestionCommand : CommandBase<int>
	{
		private readonly QuestionGroupViewModel _viewModel;

		public LoadQuestionCommand(QuestionGroupViewModel viewModel, int id)
		{
			GroupId = id;
			_viewModel = viewModel;
		}

		public int GroupId { get; private set; }

		private void LoadQuestion(int questionCost)
		{
			QuestionViewModel question = _viewModel.Questions.First(rec => rec.Model.Cost == questionCost);
			if (question.IsAnswered)
			{
				return;
			}

			question.IsAnswered = true;

			Messenger.Default.Send(new LoadQuestionMessage(question.Model));
		}

		#region Overrides of CommandBase<int>

		public override void Execute(int parameter)
		{
			if (_viewModel.Questions.All(rec => rec.Model.Cost != parameter))
				throw new ArgumentOutOfRangeException("parameter " + parameter);

			Dispatcher uiDispather = Dispatcher.CurrentDispatcher;
			new Thread(() =>
			{
				Thread.Sleep(2000);
				uiDispather.Invoke(() => LoadQuestion(parameter));
			}).Start();
		}

		#endregion
	}
}