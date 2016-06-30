using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Infrastructure;
using JeopardySimulator.Ui.Messages;

namespace JeopardySimulator.Ui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Visibility _questionProcessVisibility;
		private Visibility _questionTableVisibility;
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
			QuestionTableView.Visibility = _questionTableVisibility;
			QuestionProcessView.Visibility = _questionProcessVisibility;

			if (++_roundNo < 3)
				ChangeMasterDetailState(null);

			ResultsWindowView.Visibility = Visibility.Visible;
			ResultsView.Visibility = Visibility.Hidden;
		}

		private void ChangeMasterDetailState(MessageBase message)
		{
			if (QuestionTableView.Visibility != QuestionProcessView.Visibility)
			{
				QuestionTableView.Visibility = QuestionProcessView.Visibility;
				QuestionProcessView.Visibility = RevertVisibility(QuestionProcessView.Visibility);
			}
		}

		private static Visibility RevertVisibility(Visibility visibility)
		{
			return Visibility.Collapsed.Equals(visibility) ? Visibility.Visible : Visibility.Collapsed;
		}

		private void ShowResults(RoundEndedMessage message)
		{
			_questionTableVisibility = QuestionTableView.Visibility;
			QuestionTableView.Visibility = Visibility.Collapsed;

			_questionProcessVisibility = QuestionProcessView.Visibility;
			QuestionProcessView.Visibility = Visibility.Collapsed;

			ResultsWindowView.Visibility = Visibility.Collapsed;
			ResultsView.Visibility = Visibility.Visible;
		}
	}
}