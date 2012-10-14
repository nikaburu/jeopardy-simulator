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
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<QuestionTableViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public QuestionTableViewModel QuestionTable
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionTableViewModel>();
            }
        }
        
    }
}