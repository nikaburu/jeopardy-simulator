using System;

namespace OwnGame.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public int Cost { get; set; }

        public int QuestionGroupId { get { return QuestionGroup != null ? QuestionGroup.Id : 0; } }
        public QuestionGroup QuestionGroup { get; set; }
    }
}