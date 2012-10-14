using System;
using System.Collections.Generic;
using OwnGame.Models;

namespace OwnGame.Servicies
{
    internal class DesignDataQuestionService : IQuestionService
    {
        #region Implementation of IQuestionService

        public List<QuestionGroup> GetQuestionGroupList()
        {
            return new List<QuestionGroup>()
                       {
                           new QuestionGroup(new List<Question>()
                                                 {
                                                     new Question()
                                                         {
                                                             Id = 1,
                                                             Text = "What is the answer (10)?",
                                                             Answer = "Hello",
                                                             Cost = 10
                                                         },
                                                     new Question()
                                                         {
                                                             Id = 1,
                                                             Text = "What is the answer (20)?",
                                                             Answer = "Hello",
                                                             Cost = 20
                                                         },
                                                     new Question()
                                                         {
                                                             Id = 1,
                                                             Text = "What is the answer (30)?",
                                                             Answer = "Hello",
                                                             Cost = 30
                                                         },
                                                     new Question()
                                                         {
                                                             Id = 1,
                                                             Text = "What is the answer (50)?",
                                                             Answer = "Hello",
                                                             Cost = 50
                                                         },
                                                 })
                               {
                                   Id = 1,
                                   Name = "World"
                               }
                       };
        }

        #endregion
    }
}