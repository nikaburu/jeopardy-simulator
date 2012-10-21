using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OwnGame.Models;
using OwnGame.ViewModels;
using OwnGame.Servicies;

namespace OwnGame.Tests.ViewModels
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
            serviceMoq.Setup(servMoq => servMoq.GetQuestionGroupList(1)).Returns(questionGroupFakeList);
            QuestionTableViewModel viewModel = new QuestionTableViewModel(serviceMoq.Object);
            int countBeforeCommand = viewModel.QuestionGroupList.Count;
            //Act
            viewModel.LoadDataCommand.Execute(service => service.GetQuestionGroupList());

            //Assert
            Assert.IsTrue(viewModel.QuestionGroupList.Count == questionGroupFakeList.Count + countBeforeCommand);
        }
    }
}
