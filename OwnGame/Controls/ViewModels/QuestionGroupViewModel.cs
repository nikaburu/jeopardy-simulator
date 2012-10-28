using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Commands.Base;
using OwnGame.Messages;
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

            MessengerInstance.Register<CancelQuestionMessage>(this, OnCancelQuestion);
            MessengerInstance.Register<UnloadQuestionMessage>(this, msg =>
                                                                        {
                                                                            IsFinished =
                                                                                _questions.All(rec => rec.IsAnswered);
                                                                        });
        }

        private void OnCancelQuestion(CancelQuestionMessage message)
        {
            if (message.Content.QuestionGroupId == _model.Id)
            {
                Questions.First(rec => rec.Model == message.Content).IsAnswered = false;
                MessengerInstance.Send(new UnloadQuestionMessage());
            }
        }

        public int Id { get { return _model.Id; } }
        public string Name { get { return _model.Name; } }

        private bool _isFinished;
        public bool IsFinished
        {
            get { return _isFinished; }
            private set
            {
                _isFinished = value;
                RaisePropertyChanged(() => IsFinished);
            }
        }

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