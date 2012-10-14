using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OwnGame.Servicies;

namespace OwnGame.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IQuestionService, DesignDataQuestionService>();
            }
            else
            {
                SimpleIoc.Default.Register<IQuestionService, DesignDataQuestionService>(); //todo change in production
            }
            
            SimpleIoc.Default.Register<QuestionTableViewModel>();
            SimpleIoc.Default.Register<CommandResultsViewModel>();
            SimpleIoc.Default.Register<QuestionProcessViewModel>();
        }

        public QuestionProcessViewModel QuestionProcess
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionProcessViewModel>();
            }
        }

        public QuestionTableViewModel QuestionTable
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionTableViewModel>();
            }
        }

        public CommandResultsViewModel CommandResults
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommandResultsViewModel>();
            }
        }
    }
}