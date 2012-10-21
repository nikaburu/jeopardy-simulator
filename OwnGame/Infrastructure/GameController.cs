using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Messages;

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

            Messenger.Default.Register<RoundEndedMessage>(this, OnRoundEnded);
        }

        private void OnRoundEnded(RoundEndedMessage msg)
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
            CurrentRound = GameRound.SecondRound;

            ViewModelLocator.QuestionTable.LoadDataCommand.Execute((service) => service.GetQuestionGroupList(2));
        }

        private void StartNextRound()
        {
            switch (CurrentRound)
            {
                case GameRound.FirstRound:
                    InitializeSecondRound();
                    break;
                case GameRound.SecondRound:
                    //todo super
                    ShowResults();
                    break;
                case GameRound.SuperRound:
                    ShowResults();
                    break;
            }
        }

        private void ShowResults()
        {
            Messenger.Default.Send(new GameEndedMessage());
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
