using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Messages;
using OwnGame.Models;

namespace OwnGame.ViewModels
{
    public class QuestionProcessViewModel : ViewModelBase
    {
        public QuestionProcessViewModel()
        {
            Messenger.Default.Register<GenericMessage<Question>>(this, OnLoadQuestion);
            Messenger.Default.Register<CancelQuestionMessage>(this, OnUnloadQuestion);
            
            MakeAnsweredCommand = new RelayCommand(() =>
                                                       {
                                                           IsAnswered = true;
                                                       });

            UnLoadQuestionCommand = new CancelQuestionCommand(this);
        }

        private void OnUnloadQuestion(CancelQuestionMessage obj)
        {
            IsAnswered = false;
            Model = null;
        }

        private void OnLoadQuestion(GenericMessage<Question> message)
        {
            Model = message.Content;
            IsAnswered = false;
        }

        public RelayCommand MakeAnsweredCommand { get; private set; }
        public CommandBase UnLoadQuestionCommand { get; private set; }
        

        private bool _isAnswered;
        public bool IsAnswered
        {
            get { return _isAnswered; }
            private set
            {
                _isAnswered = value;
                RaisePropertyChanged(() => IsAnswered);
            }
        }

        private Question _model;
        public Question Model
        {
            get { return _model; }
            private set
            {
                _model = value;
                RaisePropertyChanged(() => Model);
            }
        }
    }
}