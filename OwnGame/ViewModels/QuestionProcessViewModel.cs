using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Commands.Base;
using OwnGame.Messages;
using OwnGame.Models;
using OwnGame.Servicies;

namespace OwnGame.ViewModels
{
    public class QuestionProcessViewModel : ViewModelBase
    {
        public Question Model { get; private set; }

        public QuestionProcessViewModel()
        {
            #region Designer mode
            if (IsInDesignMode)
            {
                var question = new Question()
                                   {
                                       Answer = "Qanswer",
                                       AnswerImage = DesignDataQuestionService.LoadImage(),
                                       Cost = 100,
                                       Id = 1,
                                       QuestionGroup = new QuestionGroup(1) {Name = "Test Group"},
                                       Text = "The World Wide Web has succeeded in large " +
                                              "part because its software architecture has been designed " +
                                              "to meet the needs of an Internet-scale distributed hypermedia system"
                                   };
                OnLoadQuestion(new LoadQuestionMessage(question));
                GoToNextStateCommand.Execute();
                GoToNextStateCommand.Execute();
            }
            #endregion

            MessengerInstance.Register<LoadQuestionMessage>(this, OnLoadQuestion);
            MessengerInstance.Register<UnloadQuestionMessage>(this, OnUnloadQuestion);

            CancelQuestionCommand = new RelayCommand(() => Messenger.Default.Send(new CancelQuestionMessage(Model)));
        }

        #region Messages
        private void OnUnloadQuestion(UnloadQuestionMessage obj)
        {
            Model = null;
            GoToNextStateCommand = null;
        }

        private void OnLoadQuestion(LoadQuestionMessage message)
        {
            Model = message.Content;
            RelayCommand successCommand = new RelayCommand(() => MessengerInstance.Send(new UnloadQuestionMessage()));
            GoToNextStateCommand = new ShowNextQuestionStateCommand(this, successCommand);
        }
        #endregion

        #region Commands

        private CommandBase _goToNextStateCommand;
        public CommandBase GoToNextStateCommand
        {
            get { return _goToNextStateCommand; }
            private set
            {
                _goToNextStateCommand = value;
                RaisePropertyChanged(() => GoToNextStateCommand);
            }
        }

        public RelayCommand CancelQuestionCommand { get; private set; }
        #endregion

        #region Properties

        private string _nextStateActionText;
        public string NextStateActionText
        {
            get { return _nextStateActionText; }
            set
            {
                _nextStateActionText = value;
                RaisePropertyChanged(() => NextStateActionText);
            }
        }

        private string _contentText;
        public string ContentText
        {
            get { return _contentText; }
            set
            {
                _contentText = value;
                RaisePropertyChanged(() => ContentText);
            }
        }

        private byte[] _imageData;
        public byte[] ImageData
        {
            get { return _imageData; }
            set
            {
                _imageData = value;
                RaisePropertyChanged(() => ImageData);
                RaisePropertyChanged(() => IsShowImage);
            }
        }

        public bool IsShowImage { get { return ImageData != null && ImageData.Length > 0; }}

        #endregion
    }
}