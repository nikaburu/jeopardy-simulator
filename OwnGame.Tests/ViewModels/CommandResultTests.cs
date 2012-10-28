using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwnGame.ViewModels;

namespace OwnGame.Tests.ViewModels
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
            Assert.IsTrue(viewModel.Score == prevScore - cost);
        }

        [TestMethod]
        public void TestActivateWhenDisabledThenDonotActivate()
        {
            //Assign
            CommandResultViewModel viewModel = new CommandResultViewModel("aa", false, true);

            //Act
            viewModel.Activate(100);

            //Assert
            Assert.IsTrue(!viewModel.IsActivated);
        }
    }
}
