using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Infrastructure;
using OwnGame.Messages;

namespace OwnGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Visibility _questionTableVisibility;
        private Visibility _questionProcessVisibility;
        private int _roundNo = 1;

        public MainWindow()
        {
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            InitializeComponent();

            Messenger.Default.Register<LoadQuestionMessage>(this, ChangeMasterDetailState);
            Messenger.Default.Register<UnloadQuestionMessage>(this, ChangeMasterDetailState);

            Messenger.Default.Register<RoundEndedMessage>(this, ShowResults);
            Messenger.Default.Register<NextRoundMessage>(this, OnNextRound);
        }

        private void OnNextRound(NextRoundMessage message)
        {
            questionTableView.Visibility = _questionTableVisibility;
            questionProcessView.Visibility = _questionProcessVisibility;
            
            if (++_roundNo < 3) 
                ChangeMasterDetailState(null);
            
            resultsWindowView.Visibility = Visibility.Visible;
            resultsView.Visibility = Visibility.Hidden;
        }

        private void ChangeMasterDetailState(MessageBase message)
        {
            if (questionTableView.Visibility != questionProcessView.Visibility)
            {
                questionTableView.Visibility = questionProcessView.Visibility;
                questionProcessView.Visibility = RevertVisibility(questionProcessView.Visibility);
            }
        }

        private static Visibility RevertVisibility(Visibility visibility)
        {
            return Visibility.Collapsed.Equals(visibility) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ShowResults(RoundEndedMessage message)
        {
            _questionTableVisibility = questionTableView.Visibility;
            questionTableView.Visibility = Visibility.Collapsed;

            _questionProcessVisibility = questionProcessView.Visibility;
            questionProcessView.Visibility = Visibility.Collapsed;

            resultsWindowView.Visibility = Visibility.Collapsed;
            resultsView.Visibility = Visibility.Visible;
        }
    }
}
