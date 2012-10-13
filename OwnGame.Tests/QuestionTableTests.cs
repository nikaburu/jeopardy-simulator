using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OwnGame.Models;
using OwnGame.ViewModels;
using OwnGame.Servicies;

namespace OwnGame.Tests
{
    [TestClass]
    public class QuestionTableTests
    {
        [TestMethod]
        public void TestWhenLoadQuestionGroupListThenDataLoadedFully()
        {
            //Assign
            Mock<IQuestionService> serviceMoq = new Mock<IQuestionService>();
            var questionGroupFakeList = new List<QuestionGroup>()
                                            {
                                                new QuestionGroup(),
                                                new QuestionGroup(),
                                                new QuestionGroup()
                                            };
            serviceMoq.Setup(service => service.GetQuestionGroupList()).Returns(questionGroupFakeList);
            QuestionTableViewModel viewModel = new QuestionTableViewModel(serviceMoq.Object);

            //Act
            viewModel.LoadDataCommand.Execute();

            //Assert
            Assert.IsTrue(viewModel.QuestionGroupList.Count == questionGroupFakeList.Count);
        }

        ////[TestMethod]
        ////public void TestWhenQuestionSelectedThenMarkedAsAnswered()
        ////{
        ////    //Assign
        ////    Mock<IQuestionService> serviceMoq = new Mock<IQuestionService>();
        ////    QuestionTableViewModel viewModel = new QuestionTableViewModel(serviceMoq.Object);

        ////    //Act
        ////    viewModel.SelectQuestionCommand.Execute(30);

        ////    //Assert
        ////}
    }
}
