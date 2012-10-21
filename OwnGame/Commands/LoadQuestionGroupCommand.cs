using OwnGame.Commands.Base;
using OwnGame.Controls.ViewModels;
using OwnGame.Servicies;
using OwnGame.ViewModels;

namespace OwnGame.Commands
{
    public sealed class LoadQuestionGroupCommand : CommandBase
    {
        private readonly QuestionTableViewModel _viewModel;
        private readonly IQuestionService _questionService;

        public LoadQuestionGroupCommand(QuestionTableViewModel viewModel, IQuestionService questionService)
        {
            _viewModel = viewModel;
            _questionService = questionService;
        }

        private void LoadQuestionGroup()
        {
            foreach (var questionGroup in _questionService.GetQuestionGroupList())
            {
                _viewModel.QuestionGroupList.Add(new QuestionGroupViewModel(questionGroup));
            }
        }

        #region Overrides of CommandBase

        public override void Execute()
        {
            LoadQuestionGroup();
        }

        #endregion
    }
}
