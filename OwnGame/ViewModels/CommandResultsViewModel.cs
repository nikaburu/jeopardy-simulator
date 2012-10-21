using System;
using System.Collections.ObjectModel;
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
            //if (IsInDesignMode)
            {
                InitializeCommands(5);
            }

            MessengerInstance.Register<LoadQuestionMessage>(this, OnLoadQuestion);
            MessengerInstance.Register<UnloadQuestionMessage>(this, OnUnloadQuestion);
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
                result.Activate(message.Content.Cost);
            }
        }
        #endregion

        public ObservableCollection<CommandResultViewModel> CommandResults { get; set; }

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