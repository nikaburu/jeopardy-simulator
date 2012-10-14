using System.Collections.Generic;
using System.Linq;

namespace OwnGame.Models
{
    public sealed class QuestionGroup
    {
        #region Constructors
        public QuestionGroup(): this(0, new Question[0])
        {
        }

        public QuestionGroup(int id) : this(id, new Question[0])
        {
        }

        public QuestionGroup(int id, IEnumerable<Question> questions)
        {
            Id = id;

            Questions = questions;
            foreach (var question in Questions)
            {
                question.QuestionGroupId = Id;
            }
        }
        #endregion

        public int Id { get; private set; }
        public string Name { get; set; }

        public IEnumerable<Question> Questions { get; private set; }
    }
}
