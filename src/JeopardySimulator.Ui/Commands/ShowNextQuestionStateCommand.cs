using System.Windows.Input;
using JeopardySimulator.Ui.Commands.Base;
using JeopardySimulator.Ui.ViewModels;

namespace JeopardySimulator.Ui.Commands
{
	public sealed class ShowNextQuestionStateCommand : CommandBase
	{
		private readonly ICommand _successCommand;
		private readonly QuestionProcessViewModel _viewModel;
		private QuestionState _currentState;

		public ShowNextQuestionStateCommand(QuestionProcessViewModel viewModel, ICommand successCommand)
		{
			_viewModel = viewModel;
			_successCommand = successCommand;

			GotoState(QuestionState.PreQuestionShown);
		}

		private void GotoState(QuestionState questionState)
		{
			switch (questionState)
			{
				case QuestionState.PreQuestionShown:
					SetViewModelContent("Раскрыть вопрос",
						string.Format(_viewModel.Model.Cost != 0 ? "{0} - {1}" : "{0}", _viewModel.Model.QuestionGroup.Name,
							_viewModel.Model.Cost));
					break;
				case QuestionState.QuestionShown:
					SetViewModelContent("Раскрыть ответ", _viewModel.Model.Text, _viewModel.Model.TextImage);
					break;
				case QuestionState.AnswerShown:
					SetViewModelContent("Продолжить", _viewModel.Model.Answer, _viewModel.Model.AnswerImage);
					break;
			}

			_currentState = questionState;
		}

		private void SetViewModelContent(string nextStateActionText, string contentText, byte[] image = null)
		{
			_viewModel.NextStateActionText = nextStateActionText;
			_viewModel.ContentText = contentText;
			_viewModel.ImageData = image;
		}

		private void GotoNextState()
		{
			switch (_currentState)
			{
				case QuestionState.PreQuestionShown:
					GotoState(QuestionState.QuestionShown);
					break;
				case QuestionState.QuestionShown:
					GotoState(QuestionState.AnswerShown);
					break;
				case QuestionState.AnswerShown:
					_successCommand.Execute(null);
					break;
			}
		}

		#region Overrides of CommandBase

		public override void Execute()
		{
			GotoNextState();
		}

		#endregion

		private enum QuestionState
		{
			PreQuestionShown,
			QuestionShown,
			AnswerShown
		}
	}
}