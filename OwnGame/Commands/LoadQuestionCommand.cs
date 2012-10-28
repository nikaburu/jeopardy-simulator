using System;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands.Base;
using OwnGame.Controls.ViewModels;
using OwnGame.Messages;

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
            if (!_viewModel.Questions.Any(rec => rec.Model.Cost == parameter))
                throw new ArgumentOutOfRangeException("parameter " + parameter);
            
            Dispatcher uiDispather = Dispatcher.CurrentDispatcher;
            (new Thread(() =>
                            {
                                Thread.Sleep(2000);
                                uiDispather.Invoke(new Action(() => LoadQuestion(parameter)));
                            })).Start();
        }

        #endregion
    }
}
