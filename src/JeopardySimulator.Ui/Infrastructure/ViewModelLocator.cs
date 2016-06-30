using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JeopardySimulator.Ui.Servicies;
using JeopardySimulator.Ui.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace JeopardySimulator.Ui.Infrastructure
{
	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			if (ViewModelBase.IsInDesignModeStatic)
			{
				InitializeStatic();
			}
		}

		public IQuestionService QuestionService
		{
			get { return ServiceLocator.Current.GetInstance<IQuestionService>(); }
		}

		protected GameController GameController { get; private set; }

		private static void InitializeStatic()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (ViewModelBase.IsInDesignModeStatic)
			{
				SimpleIoc.Default.Register<IQuestionService, DesignDataQuestionService>();
			}
			else
			{
				SimpleIoc.Default.Register<IQuestionService, ExcelDataQuestionService>();
			}

			SimpleIoc.Default.Register<QuestionTableViewModel>();
			SimpleIoc.Default.Register<CommandResultsViewModel>();
			SimpleIoc.Default.Register<QuestionProcessViewModel>();
			SimpleIoc.Default.Register<MessagePopupViewModel>();
			SimpleIoc.Default.Register<TotalResultsViewModel>();
		}

		public void Initialize()
		{
			InitializeStatic();
		}

		public void GameControllerSetup(GameController gameController)
		{
			GameController = gameController;
		}

		#region ViewModels

		public QuestionProcessViewModel QuestionProcess
		{
			get { return ServiceLocator.Current.GetInstance<QuestionProcessViewModel>(); }
		}

		public TotalResultsViewModel TotalResults
		{
			get { return ServiceLocator.Current.GetInstance<TotalResultsViewModel>(); }
		}

		public MessagePopupViewModel MessagePopup
		{
			get { return ServiceLocator.Current.GetInstance<MessagePopupViewModel>(); }
		}

		public QuestionTableViewModel QuestionTable
		{
			get { return ServiceLocator.Current.GetInstance<QuestionTableViewModel>(); }
		}

		public CommandResultsViewModel CommandResults
		{
			get { return ServiceLocator.Current.GetInstance<CommandResultsViewModel>(); }
		}

		#endregion
	}
}