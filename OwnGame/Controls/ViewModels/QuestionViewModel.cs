using GalaSoft.MvvmLight;
using OwnGame.Models;

namespace OwnGame.Controls.ViewModels
{
    public class QuestionViewModel : ObservableObject
    {
        public QuestionViewModel(Question model)
        {
            Model = model;
            IsAnswered = false;
        }

        public Question Model { get; private set; }

        private bool _isAnswered;
        public bool IsAnswered
        {
            get { return _isAnswered; }
            set
            {
                _isAnswered = value;
                RaisePropertyChanged(() => IsAnswered);
            }
        }
    }
}