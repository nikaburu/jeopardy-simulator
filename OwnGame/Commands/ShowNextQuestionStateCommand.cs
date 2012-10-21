using System;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands.Base;
using OwnGame.Controls.ViewModels;
using OwnGame.Messages;
using OwnGame.ViewModels;

namespace OwnGame.Commands
{
    public sealed class ShowNextQuestionStateCommand : CommandBase
    {
        private readonly QuestionProcessViewModel _viewModel;
        private readonly ICommand _successCommand;
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
                    SetViewModelContent("Раскрыть вопрос", string.Format("{0} - {1}", _viewModel.Model.QuestionGroup.Name, _viewModel.Model.Cost));
                    break;
                case QuestionState.QuestionShown:
                    SetViewModelContent("Раскрыть ответ", _viewModel.Model.Text);
                    break;
                case QuestionState.AnswerShown:
                    SetViewModelContent("Продолжить", _viewModel.Model.Answer);
                    break;
            }

            _currentState = questionState;
        }

        private void SetViewModelContent(string nextStateActionText, string contentText)
        {
            _viewModel.NextStateActionText = nextStateActionText;
            _viewModel.ContentText = contentText;
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
