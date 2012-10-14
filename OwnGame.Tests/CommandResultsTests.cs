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
    public class CommandResultsTests
    {
        [TestMethod]
        public void TestWhenInitializeCommandsThenDataLoadedFully()
        {
            //Assign
            CommandResultsViewModel viewModel = new CommandResultsViewModel();

            //Act
            viewModel.InitializeCommands(5);

            //Assert
            Assert.IsTrue(viewModel.CommandResults.Count == 5);
            Assert.IsTrue(viewModel.CommandResults.All(rec => rec.Score == 0));
        }
    }
}
