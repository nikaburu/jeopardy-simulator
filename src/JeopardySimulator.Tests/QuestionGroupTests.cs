using System;
using System.Collections.Generic;
using System.Linq;
using JeopardySimulator.Ui.Commands;
using JeopardySimulator.Ui.Controls.ViewModels;
using JeopardySimulator.Ui.Models;
using Xunit;

namespace JeopardySimulator.Tests
{
    public class QuestionGroupTests
    {
	    [Fact]
        public void TestWhenAskLoadQuestionThatDonotExistsThenThrowArgumentOutOfRangeException()
        {
            //Assign
            QuestionGroupViewModel viewModel = new QuestionGroupViewModel(new QuestionGroup());

		    Action action = () =>
		    {
				//Act
				viewModel.LoadQuestionCommand.Execute(30);
			};

			//Assert
			Assert.Throws<ArgumentOutOfRangeException>(action);
        }

	    [Fact]
        public void TestWhenCreatedThenLoadQuestionCommandContainsCorrectGroupId()
        {
            //Assign
            QuestionGroup group = new QuestionGroup(10);
            
            //Act
            QuestionGroupViewModel viewModel = new QuestionGroupViewModel(group);

            //Assert
            Assert.True(((LoadQuestionCommand)viewModel.LoadQuestionCommand).GroupId == group.Id);
        }

	    [Fact]
        public void TestWhenLoadQuestionThenQuestionMarkAsAnswered()
        {
            //Assign
		    QuestionGroupViewModel viewModel = new QuestionGroupViewModel(new QuestionGroup(10, new List<Question>
		    {
			    new Question
			    {
				    Cost = 30
			    }
		    }));

            //Act
            viewModel.LoadQuestionCommand.Execute(viewModel.Questions.First().Model.Cost);

            //Assert
            Assert.True(viewModel.Questions.First().IsAnswered);
        }
    }
}
