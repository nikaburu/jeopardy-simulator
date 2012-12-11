using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Messages;
using OwnGame.Models;

namespace OwnGame.Infrastructure
{
    public sealed class GameController
    {
        private ViewModelLocator ViewModelLocator { get; set; }
        private GameRound CurrentRound { get; set; }

        public GameController(ViewModelLocator modelLocator)
        {
            ViewModelLocator = modelLocator;
            ViewModelLocator.GameControllerSetup(this);

            Messenger.Default.Register<NextRoundMessage>(this, OnRoundEnded);
        }

        private void OnRoundEnded(NextRoundMessage msg)
        {
            StartNextRound();
        }

        public void InitializeNewGame(int commandsCount)
        {
            CurrentRound = GameRound.FirstRound;

            ViewModelLocator.Initialize();
            ViewModelLocator.QuestionTable.LoadDataCommand.Execute((service) => service.GetQuestionGroupList());
            ViewModelLocator.CommandResults.InitializeCommands(commandsCount);
        }

        private void InitializeSecondRound()
        {
            ViewModelLocator.QuestionTable.LoadDataCommand.Execute((service) => service.GetQuestionGroupList(2));
        }

        private void StartNextRound()
        {
            switch (CurrentRound)
            {
                case GameRound.FirstRound:
                    ShowResults();
                    CurrentRound = GameRound.Results;
                    break;
            }
        }

        private void InitializeSuperRound()
        {
            Messenger.Default.Unregister<UnloadQuestionMessage>(ViewModelLocator.QuestionTable);
            Messenger.Default.Unregister<CancelQuestionMessage>(ViewModelLocator.QuestionTable);
            foreach (var groupViewModel in ViewModelLocator.QuestionTable.QuestionGroupList)
            {
                Messenger.Default.Unregister<UnloadQuestionMessage>(groupViewModel);
                Messenger.Default.Unregister<CancelQuestionMessage>(groupViewModel);
            }
            //unregister MainVindow
            Messenger.Default.Unregister<LoadQuestionMessage>(Application.Current.MainWindow);
            Messenger.Default.Unregister<UnloadQuestionMessage>(Application.Current.MainWindow);

            Messenger.Default.Register<UnloadQuestionMessage>(this, OnUnloadQuestion);
            _superRoundQuestionGroup = ViewModelLocator.QuestionService.GetQuestionGroupList(3).First();
            foreach (var question in _superRoundQuestionGroup.Questions) question.Cost = 0;

            OnUnloadQuestion(null);

            Messenger.Default.Send(new SupperRoundStartedMessage());
        }

        private QuestionGroup _superRoundQuestionGroup;
        private int _currentQuestion = 0;
        
        private void OnUnloadQuestion(UnloadQuestionMessage obj)
        {
            if (_currentQuestion > _superRoundQuestionGroup.Questions.Count() -1)
            {
                OnRoundEnded(null);
            }
            else
            {
                Question question = _superRoundQuestionGroup.Questions.ElementAtOrDefault(_currentQuestion++);
                Messenger.Default.Send(new LoadQuestionMessage(question));   
            }
        }

        private static void ShowResults()
        {
            Messenger.Default.Send(new RoundEndedMessage(true));
        }

        enum GameRound
        {
            FirstRound,
            SecondRound,
            SuperRound,
            Results
        }
    }
}
