using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OwnGame.Models;

namespace OwnGame.Servicies
{
    internal class DesignDataQuestionService : IQuestionService
    {
        private readonly Random _random = new Random();

        #region Implementation of IQuestionService

        public List<QuestionGroup> GetQuestionGroupList(int multi = 1)
        {
            var list = new List<QuestionGroup>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(GenerateQuestionGroup(multi));
            }

            return list;
        }

        private QuestionGroup GenerateQuestionGroup(int multi)
        {
            byte[] image = LoadImage();

            return new QuestionGroup(_random.Next(int.MaxValue), new List<Question>()
                                                                    {
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "Что такое экономика?",
                                                                                Answer = "Совокупность общественных наук, изучающих производство, распределение и потребление товаров и услуг. Экономическая действительность является объектом экономических наук, которые подразделяется на теоретические и прикладные.",
                                                                                Cost = 10 * multi,
                                                                                TextImage = image
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "Кто , где и когда впервые дал понятие Экономике?",
                                                                                Answer = "Ещё в IV веке до н. э. Ксенофонт написал произведение под названием «Домострой» , переведённое Цицероном на латынь как лат. Oeconomicus",
                                                                                Cost = 20 * multi,
                                                                                TextImage = image,
                                                                                AnswerImage = image
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "После кого понятие экономики закрепилось?",
                                                                                Answer = "Всеобщее признание термин получил после того как был употреблен в заглавии труда Джона Стюарта Милля «Основы политическаой экономии»",
                                                                                Cost = 30 * multi,
                                                                                AnswerImage = image
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "В связи чем и когд ознаменовалось выделение экономики как науки?",
                                                                                Answer = "с выходом в свет книги Адама Смита «Исследование о природе и причинах богатства народов» (распространённое название «Богатство народов») в 1776 году",
                                                                                Cost = 50 * multi
                                                                            },
                                                                        new Question()
                                                                            {
                                                                                Id = _random.Next(int.MaxValue),
                                                                                Text =
                                                                                    "Совокупность моделей экономики, сформировавшихся в западноевропейской экономической теории это...",
                                                                                Answer = "Экономикс",
                                                                                Cost = 80 * multi
                                                                            },
                                                                    })
            {
                Name = "История экономики" + " " + _random.Next(10)
            };
        }

        public static byte[] LoadImage()
        {
            return File.ReadAllBytes("Servicies\\" + "testImage.jpg");
        }

        #endregion
    }
}