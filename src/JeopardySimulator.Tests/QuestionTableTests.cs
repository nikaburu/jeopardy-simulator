using System.Collections.Generic;
using JeopardySimulator.Ui.Models;
using JeopardySimulator.Ui.Servicies;
using JeopardySimulator.Ui.ViewModels;
using Moq;
using Xunit;

namespace JeopardySimulator.Tests
{
    public class QuestionTableTests
    {
	    [Fact]
        public void TestWhenLoadQuestionGroupListThenDataLoadedFully()
        {
            //Assign
            Mock<IQuestionService> serviceMoq = new Mock<IQuestionService>();
            var questionGroupFakeList = new List<QuestionGroup>
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
            Assert.True(viewModel.QuestionGroupList.Count == questionGroupFakeList.Count + countBeforeCommand);
        }
    }
}
