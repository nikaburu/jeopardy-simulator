using JeopardySimulator.Ui.ViewModels;
using Xunit;

namespace JeopardySimulator.Tests
{
    public class CommandResultTests
    {
	    [Fact]
        public void TestActivateWhenDisabledThenDonotActivate()
        {
            //Assign
            CommandResultViewModel viewModel = new CommandResultViewModel("aa", false, true);

            //Act
            viewModel.Activate(100);

            //Assert
            Assert.True(!viewModel.IsActivated);
        }

	    [Fact]
        public void TestAddScoreCommandWhenExecutedThenScoreAdded()
        {
            //Assign
            CommandResultViewModel viewModel = new CommandResultViewModel("aa");
            int prevScore = viewModel.Score;
            const int cost = 999;

            //Act
            viewModel.AddScoreCommand.Execute(cost);

            //Assert
            Assert.True(viewModel.Score == prevScore + cost);
        }

	    [Fact]
        public void TestSubstractScoreCommandWhenExecutedThenScoreSubstractedOrNil()
        {
            //Assign
            CommandResultViewModel viewModel = new CommandResultViewModel("aa");
            int prevScore = viewModel.Score;
            const int cost = 999;

            //Act
            viewModel.SubstractScoreCommand.Execute(cost);

            //Assert
            Assert.True(viewModel.Score == prevScore - cost);
        }
    }
}
