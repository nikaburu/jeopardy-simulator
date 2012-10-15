using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using OwnGame.Commands;
using OwnGame.Models;

namespace OwnGame.ViewModels
{
    public class CommandResultsViewModel : ViewModelBase
    {
        public CommandResultsViewModel()
        {
            InitializeCommands(5);
        }
        
        public ObservableCollection<CommandResultViewModel> CommandResults { get; set; }

        public void InitializeCommands(int commandsCount)
        {
            CommandResults = new ObservableCollection<CommandResultViewModel>();
            for (int commandNumber = 1; commandNumber <= commandsCount; commandNumber++)
            {
                CommandResults.Add(new CommandResultViewModel(string.Format("Band {0}", commandNumber)));
            }
        }
    }
}