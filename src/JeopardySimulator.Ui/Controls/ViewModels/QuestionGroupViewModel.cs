using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using JeopardySimulator.Ui.Commands;
using JeopardySimulator.Ui.Commands.Base;
using JeopardySimulator.Ui.Messages;
using JeopardySimulator.Ui.Models;

namespace JeopardySimulator.Ui.Controls.ViewModels
{
	public class QuestionGroupViewModel : ViewModelBase
	{
		private readonly QuestionGroup _model;

		private bool _isFinished;

		private IEnumerable<QuestionViewModel> _questions;

		public QuestionGroupViewModel(QuestionGroup questionGroup)
		{
			_model = questionGroup;
			LoadQuestionCommand = new LoadQuestionCommand(this, _model.Id);

			MessengerInstance.Register<CancelQuestionMessage>(this, OnCancelQuestion);
			MessengerInstance.Register<UnloadQuestionMessage>(this, msg =>
			{
				IsFinished =
					_questions.All(rec => rec.IsAnswered);
			});
		}

		public int Id
		{
			get { return _model.Id; }
		}

		public string Name
		{
			get { return _model.Name; }
		}

		public bool IsFinished
		{
			get { return _isFinished; }
			private set
			{
				_isFinished = value;
				RaisePropertyChanged(() => IsFinished);
			}
		}

		public IEnumerable<QuestionViewModel> Questions
		{
			get
			{
				if (_questions == null)
				{
					_questions = new List<QuestionViewModel>(
						_model.Questions.Select(question => new QuestionViewModel(question)));
				}

				return _questions;
			}
		}

		public CommandBase<int> LoadQuestionCommand { get; private set; }

		private void OnCancelQuestion(CancelQuestionMessage message)
		{
			if (message.Content.QuestionGroupId == _model.Id)
			{
				Questions.First(rec => rec.Model == message.Content).IsAnswered = false;
				MessengerInstance.Send(new UnloadQuestionMessage());
			}
		}
	}
}