using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OwnGame.Commands;
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

            if (ViewModelBase.IsInDesignModeStatic)
            {
                LoadDataCommand.Execute();
                LoadDataCommand.Execute();
                LoadDataCommand.Execute();
            }
        }

        public ObservableCollection<QuestionGroupViewModel> QuestionGroupList { get; set; }

        public CommandBase LoadDataCommand { get; private set; }
    }
}