using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
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
        }

        public ObservableCollection<CommandResult> CommandResults { get; set; }

        public void InitializeCommands(int commandsCount)
        {
            CommandResults = new ObservableCollection<CommandResult>();
            for (int commandNumber = 1; commandNumber <= commandsCount; commandNumber++)
            {
                CommandResults.Add(new CommandResult(string.Format("Band {0}", commandNumber)));
            }
        }
    }
}