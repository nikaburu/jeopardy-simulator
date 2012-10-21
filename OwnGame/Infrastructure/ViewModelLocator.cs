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
            if (ViewModelBase.IsInDesignModeStatic)
            {
                var instance = SimpleIoc.Default.GetInstance<QuestionProcessViewModel>();
                Messenger.Default.Send<GenericMessage<Question>>(new GenericMessage<Question>(new Question()
                                                                                                  {
                                                                                                      Answer = "Qanswer",
                                                                                                      Cost = 100,
                                                                                                      Id = 1,
                                                                                                      QuestionGroupId = 1,
                                                                                                      Text = "The World Wide Web has succeeded in large part because its software architecture has been designed to meet the needs of an Internet-scale distributed hypermedia system"
                                                                                                  }));
                instance.MakeAnsweredCommand.Execute(null);
            }

            SimpleIoc.Default.Register<MessagePopupViewModel>();
            SimpleIoc.Default.GetInstance<MessagePopupViewModel>();
        }

        public QuestionProcessViewModel QuestionProcess
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionProcessViewModel>();
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
    }
}