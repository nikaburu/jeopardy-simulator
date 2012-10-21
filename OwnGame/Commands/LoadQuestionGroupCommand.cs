using System.Collections.Generic;
using System.Collections.ObjectModel;
using OwnGame.Commands.Base;
using OwnGame.Controls.ViewModels;
using OwnGame.Models;
using OwnGame.Servicies;
using OwnGame.ViewModels;
using System;

namespace OwnGame.Commands
{
    public sealed class LoadQuestionGroupCommand : CommandBase<Func<IQuestionService, IEnumerable<QuestionGroup>>>
    {
        private readonly QuestionTableViewModel _viewModel;
        private readonly IQuestionService _questionService;

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
