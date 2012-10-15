using System;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Controls.ViewModels;
using OwnGame.Messages;
using OwnGame.Models;
using OwnGame.Servicies;
using OwnGame.ViewModels;

namespace OwnGame.Commands
{
    public sealed class CancelQuestionCommand : CommandBase
    {
        public QuestionProcessViewModel QuestionViewModel { get; set; }

        public CancelQuestionCommand(QuestionProcessViewModel questionViewModel)
        {
            QuestionViewModel = questionViewModel;
        }

        private void UnLoadQuestion()
        {
            Messenger.Default.Send(new CancelQuestionMessage(QuestionViewModel.Model));
            Messenger.Default.Send(new ChangeMasterDetailStateMessage());
        }
        
        #region Overrides of CommandBase<int>

        public override void Execute()
        {
            if (QuestionViewModel.Model != null)
            {
                UnLoadQuestion();   
            }
        }

        #endregion
    }
}
