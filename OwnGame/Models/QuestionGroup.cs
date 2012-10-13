using System.Collections.Generic;
using System.Linq;

namespace OwnGame.Models
{
    public sealed class QuestionGroup
    {
        #region Constructors
        public QuestionGroup() : this(new Question[0])
        {
        }

        public QuestionGroup(IEnumerable<Question> questions)
        {
            Questions = questions.ToList();
        }
        #endregion

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Question> Questions { get; private set; }
    }
}
