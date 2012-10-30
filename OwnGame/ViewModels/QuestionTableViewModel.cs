using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Commands.Base;
using OwnGame.Controls.ViewModels;
using OwnGame.Messages;
using OwnGame.Models;
using OwnGame.Servicies;

namespace OwnGame.ViewModels
{
    public class QuestionTableViewModel : ViewModelBase
    {
        private readonly IQuestionService _questionService;

        public QuestionTableViewModel(IQuestionService questionService)
        {
            _questionService = questionService;

            QuestionGroupList = new ObservableCollection<QuestionGroupViewModel>();
            LoadDataCommand = new LoadQuestionGroupCommand(this, _questionService);

            if (IsInDesignMode)
            {
                LoadDataCommand.Execute(service => service.GetQuestionGroupList());
            }

            MessengerInstance.Register<UnloadQuestionMessage>(this, OnUnloadQuestion);
        }

        private void OnUnloadQuestion(UnloadQuestionMessage obj)
        {
            if (!IsSkipRound)
            {
                if (QuestionGroupList.All(group => group.Questions.All(question => question.IsAnswered)))
                {
                    MessengerInstance.Send(new RoundEndedMessage());
                }
            }
            else
            {
                if (QuestionGroupList.Any(group => group.Questions.Any(question => question.IsAnswered)))
                {
                    MessengerInstance.Send(new RoundEndedMessage());
                }
            }
        }

        private ObservableCollection<QuestionGroupViewModel> _questionGroupList;
        private bool _isSkipRound;

        public ObservableCollection<QuestionGroupViewModel> QuestionGroupList
        {
            get { return _questionGroupList; }
            set
            {
                _questionGroupList = value;
                RaisePropertyChanged(() => QuestionGroupList);
            }
        }

        public CommandBase<Func<IQuestionService, IEnumerable<QuestionGroup>>> LoadDataCommand { get; private set; }

        public bool IsSkipRound
        {
            get { return _isSkipRound; }
            set
            {
                _isSkipRound = value;
                RaisePropertyChanged(() => IsSkipRound);
            }
        }
    }
}