using System;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using OwnGame.Models;
using OwnGame.Servicies;
using OwnGame.ViewModels;

namespace OwnGame.Infrastructure
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
        
        private static void InitializeStatic()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IQuestionService, ExcelDataQuestionService>();
            }
            else
            {
                SimpleIoc.Default.Register<IQuestionService, ExcelDataQuestionService>(); //todo change in production
            }

            SimpleIoc.Default.Register<QuestionTableViewModel>();
            SimpleIoc.Default.Register<CommandResultsViewModel>();
            SimpleIoc.Default.Register<QuestionProcessViewModel>();
            SimpleIoc.Default.Register<MessagePopupViewModel>();
            SimpleIoc.Default.Register<TotalResultsViewModel>();
            
        }

        public IQuestionService QuestionService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IQuestionService>();
            }
        }

        #region ViewModels
        public QuestionProcessViewModel QuestionProcess
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionProcessViewModel>();
            }
        }

        public TotalResultsViewModel TotalResults
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TotalResultsViewModel>();
            }
        }
        
        public MessagePopupViewModel MessagePopup
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessagePopupViewModel>();
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
        #endregion
        
        public void Initialize()
        {
            InitializeStatic();
        }

        public void GameControllerSetup(GameController gameController)
        {
            GameController = gameController;
        }

        protected GameController GameController { get; private set; }
    }
}