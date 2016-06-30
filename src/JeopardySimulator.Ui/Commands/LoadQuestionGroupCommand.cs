using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JeopardySimulator.Ui.Commands.Base;
using JeopardySimulator.Ui.Controls.ViewModels;
using JeopardySimulator.Ui.Models;
using JeopardySimulator.Ui.Servicies;
using JeopardySimulator.Ui.ViewModels;

namespace JeopardySimulator.Ui.Commands
{
	public sealed class LoadQuestionGroupCommand : CommandBase<Func<IQuestionService, IEnumerable<QuestionGroup>>>
	{
		private readonly IQuestionService _questionService;
		private readonly QuestionTableViewModel _viewModel;

		public LoadQuestionGroupCommand(QuestionTableViewModel viewModel, IQuestionService questionService)
		{
			_viewModel = viewModel;
			_questionService = questionService;
		}

		private void LoadQuestionGroup(Func<IQuestionService, IEnumerable<QuestionGroup>> parameter)
		{
			_viewModel.QuestionGroupList = new ObservableCollection<QuestionGroupViewModel>();
			foreach (var questionGroup in parameter(_questionService))
			{
				_viewModel.QuestionGroupList.Add(new QuestionGroupViewModel(questionGroup));
			}
		}

		#region Overrides of CommandBase<Func<IQuestionService,IEnumerable<QuestionGroup>>>

		public override void Execute(Func<IQuestionService, IEnumerable<QuestionGroup>> parameter)
		{
			LoadQuestionGroup(parameter);
		}

		#endregion
	}
}