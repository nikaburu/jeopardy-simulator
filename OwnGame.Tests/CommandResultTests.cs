using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OwnGame.Models;
using OwnGame.ViewModels;
using OwnGame.Servicies;
using OwnGame.Messages;

namespace OwnGame.Tests
{
    [TestClass]
    public class CommandResultTests
    {
        [TestMethod]
        public void TestAddScoreCommandWhenExecutedThenScoreAdded()
        {
            //Assign
            CommandResultViewModel viewModel = new CommandResultViewModel("aa");
            int prevScore = viewModel.Score;
            const int cost = 999;

            //Act
            viewModel.AddScoreCommand.Execute(cost);

            //Assert
            Assert.IsTrue(viewModel.Score == prevScore + cost);
        }

        [TestMethod]
        public void TestSubstractScoreCommandWhenExecutedThenScoreSubstractedOrNil()
        {
            //Assign
            CommandResultViewModel viewModel = new CommandResultViewModel("aa");
            int prevScore = viewModel.Score;
            const int cost = 999;

            //Act
            viewModel.SubstractScoreCommand.Execute(cost);

            //Assert
            Assert.IsTrue(viewModel.Score == 0 || viewModel.Score == prevScore - cost);
        }
    }
}
