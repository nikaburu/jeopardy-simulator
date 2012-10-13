using GalaSoft.MvvmLight;
using OwnGame.Models;

namespace OwnGame.ViewModels
{
    public class QuestionGroupViewModel : ViewModelBase
    {
        public QuestionGroup QuestionGroup { get; private set; }

        public QuestionGroupViewModel(QuestionGroup questionGroup)
        {
            QuestionGroup = questionGroup;
        }
    }
}