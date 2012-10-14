using GalaSoft.MvvmLight;
using OwnGame.Models;

namespace OwnGame.ViewModels
{
    public class QuestionGroupViewModel : ViewModelBase
    {
        public QuestionGroup Model { get; private set; }

        public QuestionGroupViewModel(QuestionGroup questionGroup)
        {
            Model = questionGroup;
        }
    }
}