using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands.CommandResults;
using OwnGame.Infrastructure;
using OwnGame.Messages;

namespace OwnGame
{
    public class GamePreloaderViewModel : ViewModelBase
    {
        public GamePreloaderViewModel()
        {
            StartGameCommand = new RelayCommand(StartGameCommandExecute);

            CommandsCount = 3;
        }

        #region Commands
        public RelayCommand StartGameCommand { get; private set; }

        private void StartGameCommandExecute()
        {
            InitializeApp();
            ShowMainWindow();
        }

        private static void ShowMainWindow()
        {
            MainWindow window = new MainWindow();
            window.Show();

            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = window;
        }

        private void InitializeApp()
        {
            ViewModelLocator locator = (ViewModelLocator)Application.Current.FindResource("Locator");
            if (locator == null)
                throw new NullReferenceException("There is no resource with name Locator and typeof(ViewModelLocator) in App.xaml.");

            GameController gameController = new GameController(locator);
            gameController.InitializeNewGame(CommandsCount);
        }

        #endregion

        private int _commandsCount;
        public int CommandsCount
        {
            get { return _commandsCount; }
            set
            {
                _commandsCount = value;
                RaisePropertyChanged(() => CommandsCount);
            }
        }
    }
}