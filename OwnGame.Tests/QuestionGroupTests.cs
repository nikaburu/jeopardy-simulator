using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwnGame.Commands;
using OwnGame.Controls.ViewModels;
using OwnGame.Models;
using OwnGame.ViewModels;

namespace OwnGame.Tests
{
    [TestClass]
    public class QuestionGroupTests
    {
        [TestMethod]
        public void TestWhenCreatedThenLoadQuestionCommandContainsCorrectGroupId()
        {
            //Assign
            QuestionGroup group = new QuestionGroup(10);
            
            //Act
            QuestionGroupViewModel viewModel = new QuestionGroupViewModel(group);

            //Assert
            Assert.IsTrue(((LoadQuestionCommand)viewModel.LoadQuestionCommand).GroupId == group.Id);
        }

        [TestMethod]
        public void TestWhenLoadQuestionThenQuestionMarkAsAnswered()
        {
            //Assign
            QuestionGroupViewModel viewModel = new QuestionGroupViewModel(new QuestionGroup(10, new List<Question>()
                                                                                                {
                                                                                                    new Question()
                                                                                                        {
                                                                                                            Cost = 30
                                                                                                        }
                                                                                                }));

            //Act
            viewModel.LoadQuestionCommand.Execute(viewModel.Questions.First().Model.Cost);

            //Assert
            Assert.IsTrue(viewModel.Questions.First().IsAnswered);
        }

        [TestMethod]
        public void TestWhenAskLoadQuestionThatDonotExistsThenThrowArgumentOutOfRangeException()
        {
            //Assign
            QuestionGroupViewModel viewModel = new QuestionGroupViewModel(new QuestionGroup());

            try
            {
                //Act
                viewModel.LoadQuestionCommand.Execute(30);
                
                //Assert
                Assert.Fail("Exception was not throw");
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
            catch(Exception)
            {
                Assert.Fail("Exception with not correct type");   
            }
        }
    }
}
