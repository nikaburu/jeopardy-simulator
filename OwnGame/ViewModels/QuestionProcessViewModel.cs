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
            #region Designer mode
            if (IsInDesignMode)
            {
                Model = new Question()
                {
                    Answer = "Qanswer",
                    Cost = 100,
                    Id = 1,
                    QuestionGroupId = 1,
                    Text = "The World Wide Web has succeeded in large " +
                    "part because its software architecture has been designed " +
                    "to meet the needs of an Internet-scale distributed hypermedia system"
                };
                IsAnswered = true;
            }
            #endregion

            Messenger.Default.Register<LoadQuestionMessage>(this, OnLoadQuestion);
            Messenger.Default.Register<UnloadQuestionMessage>(this, OnUnloadQuestion);

            MakeAnsweredCommand = new RelayCommand(() => IsAnswered = true);
            CancelQuestionCommand = new RelayCommand(() => {
                                                               Messenger.Default.Send(new CancelQuestionMessage(Model));
                                                               Messenger.Default.Send(new UnloadQuestionMessage());
            });
        }

        private void OnUnloadQuestion(UnloadQuestionMessage obj)
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
        public RelayCommand CancelQuestionCommand { get; private set; }

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