using System.Collections.Generic;
using OwnGame.Models;

namespace OwnGame.Servicies
{
    public interface IQuestionService
    {
        List<QuestionGroup> GetQuestionGroupList();
    }
}
