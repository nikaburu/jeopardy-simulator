using System;
using System.Collections.Generic;
using OwnGame.Models;

namespace OwnGame.Servicies
{
    internal class DesignDataQuestionService : IQuestionService
    {
        private readonly Random _random = new Random();

        #region Implementation of IQuestionService

        public List<QuestionGroup> GetQuestionGroupList()
        {
            var list = new List<QuestionGroup>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(GenerateQuestionGroup());
            }

            return list;
        }

        private QuestionGroup GenerateQuestionGroup()
        {
            return new QuestionGroup(_random.Next(int.MaxValue), new List<Question>()
                                                                    {
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "What is the answer (10)?",
                                                                                Answer = "Hello",
                                                                                Cost = 10
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "What is the answer (20)?",
                                                                                Answer = "Hello",
                                                                                Cost = 20
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "What is the answer (30)?",
                                                                                Answer = "Hello",
                                                                                Cost = 30
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "What is the answer (50)?",
                                                                                Answer = "Hello",
                                                                                Cost = 50
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "What is the answer (80)?",
                                                                                Answer = "Hello",
                                                                                Cost = 80
                                                                            },
                                                                    })
                       {
                           Name = "World" + _random.Next(10)
                       };
        }

        #endregion
    }
}