using System;
using System.Linq;
using OwnGame.Controls.ViewModels;
using OwnGame.Servicies;
using OwnGame.ViewModels;

namespace OwnGame.Commands
{
    public sealed class LoadQuestionCommand : CommandBase<int>
    {
        public int GroupId { get; private set; }

        private readonly QuestionGroupViewModel _viewModel;
        public LoadQuestionCommand(QuestionGroupViewModel viewModel, int id)
        {
            GroupId = id;
            _viewModel = viewModel;
        }

        private void LoadQuestion(int questionCost)
        {
            QuestionViewModel question = _viewModel.Questions.First(rec => rec.Model.Cost == questionCost);
            question.IsAnswered = true;
        }
        
        #region Overrides of CommandBase<int>

        public override void Execute(int parameter)
        {
            if (!_viewModel.Questions.Any(rec => rec.Model.Cost == parameter)) 
                throw new ArgumentOutOfRangeException("parameter " + parameter);

            LoadQuestion(parameter);
        }

        #endregion
    }
}
