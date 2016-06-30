using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using JeopardySimulator.Ui.Commands;
using JeopardySimulator.Ui.Commands.Base;
using JeopardySimulator.Ui.Controls.ViewModels;
using JeopardySimulator.Ui.Messages;
using JeopardySimulator.Ui.Models;
using JeopardySimulator.Ui.Servicies;

namespace JeopardySimulator.Ui.ViewModels
{
	public class QuestionTableViewModel : ViewModelBase
	{
		private readonly IQuestionService _questionService;
		private bool _isSkipRound;

		private ObservableCollection<QuestionGroupViewModel> _questionGroupList;

		public QuestionTableViewModel(IQuestionService questionService)
		{
			_questionService = questionService;

			QuestionGroupList = new ObservableCollection<QuestionGroupViewModel>();
			LoadDataCommand = new LoadQuestionGroupCommand(this, _questionService);

			if (IsInDesignMode)
			{
				LoadDataCommand.Execute(service => service.GetQuestionGroupList());
			}

			MessengerInstance.Register<UnloadQuestionMessage>(this, OnUnloadQuestion);
		}

		public ObservableCollection<QuestionGroupViewModel> QuestionGroupList
		{
			get { return _questionGroupList; }
			set
			{
				_questionGroupList = value;
				RaisePropertyChanged(() => QuestionGroupList);
			}
		}

		public CommandBase<Func<IQuestionService, IEnumerable<QuestionGroup>>> LoadDataCommand { get; }

		public bool IsSkipRound
		{
			get { return _isSkipRound; }
			set
			{
				_isSkipRound = value;
				RaisePropertyChanged(() => IsSkipRound);
			}
		}

		private void OnUnloadQuestion(UnloadQuestionMessage obj)
		{
			if (!IsSkipRound)
			{
				if (QuestionGroupList.All(group => group.Questions.All(question => question.IsAnswered)))
				{
					MessengerInstance.Send(new RoundEndedMessage());
				}
			}
			else
			{
				if (QuestionGroupList.Any(group => group.Questions.Any(question => question.IsAnswered)))
				{
					MessengerInstance.Send(new RoundEndedMessage());
				}
			}
		}
	}
}