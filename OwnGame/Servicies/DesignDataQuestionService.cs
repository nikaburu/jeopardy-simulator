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
            Random random = new Random();
            return new List<QuestionGroup>()
                       {
                           new QuestionGroup(random.Next(int.MaxValue), new List<Question>()
                                                                            {
                                                                                new Question()
                                                                                    {
                                                                                        Id = random.Next(int.MaxValue),
                                                                                        Text =
                                                                                            "What is the answer (10)?",
                                                                                        Answer = "Hello",
                                                                                        Cost = 10
                                                                                    },
                                                                                new Question()
                                                                                    {
                                                                                        Id = random.Next(int.MaxValue),
                                                                                        Text =
                                                                                            "What is the answer (20)?",
                                                                                        Answer = "Hello",
                                                                                        Cost = 20
                                                                                    },
                                                                                new Question()
                                                                                    {
                                                                                        Id = random.Next(int.MaxValue),
                                                                                        Text =
                                                                                            "What is the answer (30)?",
                                                                                        Answer = "Hello",
                                                                                        Cost = 30
                                                                                    },
                                                                                new Question()
                                                                                    {
                                                                                        Id = random.Next(int.MaxValue),
                                                                                        Text =
                                                                                            "What is the answer (50)?",
                                                                                        Answer = "Hello",
                                                                                        Cost = 50
                                                                                    },
                                                                            })
                               {
                                   Name = "World"
                               }
                       };
        }

        #endregion
    }
}