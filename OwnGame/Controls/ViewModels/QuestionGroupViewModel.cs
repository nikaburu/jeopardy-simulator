using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using OwnGame.Commands;
using OwnGame.Models;

namespace OwnGame.Controls.ViewModels
{
    public class QuestionGroupViewModel : ViewModelBase
    {
        private readonly QuestionGroup _model;

        public QuestionGroupViewModel(QuestionGroup questionGroup)
        {
            _model = questionGroup;
            LoadQuestionCommand = new LoadQuestionCommand(this, _model.Id);
        }

        public int Id { get { return _model.Id; } }
        public string Name { get { return _model.Name; } }

        private IEnumerable<QuestionViewModel> _questions;
        public IEnumerable<QuestionViewModel> Questions
        {
            get
            {
                if (_questions == null)
                {
                    _questions = new List<QuestionViewModel>(
                            _model.Questions.Select(question => new QuestionViewModel(question)));
                }

                return _questions;
            }
        }

        public CommandBase<int> LoadQuestionCommand { get; private set; }
    }
}