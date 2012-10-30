using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using OwnGame.Commands;
using OwnGame.Messages;
using OwnGame.Models;

namespace OwnGame.ViewModels
{
    public class CommandResultsViewModel : ViewModelBase
    {
        public CommandResultsViewModel()
        {
            if (IsInDesignMode)
            {
                InitializeCommands(5);
                OnLoadQuestion(new LoadQuestionMessage(new Question() {Cost = 500}));
            }

            MessengerInstance.Register<LoadQuestionMessage>(this, OnLoadQuestion);
            MessengerInstance.Register<UnloadQuestionMessage>(this, OnUnloadQuestion);

            MessengerInstance.Register<SupperRoundStartedMessage>(this, OnSupperRoundStarted);
        }

        #region Messages
        private void OnUnloadQuestion(UnloadQuestionMessage message)
        {
            foreach (var result in CommandResults)
            {
                result.Deactivate();
            }
        }

        private void OnLoadQuestion(LoadQuestionMessage message)
        {
            foreach (var result in CommandResults)
            {
                var cost = message.Content.Cost;
                if (cost == 0)
                {
                    var maxScore = CommandResults.Max(rec => rec.Score);
                    cost = maxScore != result.Score ? maxScore - result.Score : maxScore;
                }

                result.Activate(cost);
            }
        }

        private void OnSupperRoundStarted(SupperRoundStartedMessage message)
        {
            int place = 0;
            int currentScore = 0;
            foreach (var result in CommandResults.OrderByDescending(rec => rec.Score))
            {
                if (place > 3)
                {
                    result.Disable();
                }
                else
                {
                    if (currentScore != result.Score)
                    {
                        place++;
                        if (place > 3)
                        {
                            result.Disable();
                        }

                        currentScore = result.Score;
                    }
                }
            }

            IsScoreCanbeChanged = true;
        }
        #endregion

        private ObservableCollection<CommandResultViewModel> _commandResults;
        private bool _isScoreCanbeChanged;

        public ObservableCollection<CommandResultViewModel> CommandResults
        {
            get { return _commandResults; }
            set
            {
                _commandResults = value;
                RaisePropertyChanged(() => CommandResults);
            }
        }

        public bool IsScoreCanbeChanged
        {
            get {
                return _isScoreCanbeChanged;
            }
            private set {
                _isScoreCanbeChanged = value;
                RaisePropertyChanged(() => IsScoreCanbeChanged);
            }
        }

        public void InitializeCommands(int commandsCount)
        {
            CommandResults = new ObservableCollection<CommandResultViewModel>();
            for (int commandNumber = 1; commandNumber <= commandsCount; commandNumber++)
            {
                CommandResults.Add(new CommandResultViewModel(string.Format("Команда {0}", commandNumber)));
            }
        }
    }
}