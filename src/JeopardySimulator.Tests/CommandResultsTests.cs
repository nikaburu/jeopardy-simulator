using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Messages;
using JeopardySimulator.Ui.Models;
using JeopardySimulator.Ui.ViewModels;
using Xunit;

namespace JeopardySimulator.Tests
{
    public class CommandResultsTests
    {
	    [Fact]
        public void TestWhenInitializeCommandsThenDataLoadedFully()
        {
            //Assign
            CommandResultsViewModel viewModel = new CommandResultsViewModel();

            //Act
            viewModel.InitializeCommands(5);

            //Assert
            Assert.True(viewModel.CommandResults.Count == 5);
            Assert.True(viewModel.CommandResults.All(rec => rec.Score == 0));
            Assert.True(viewModel.CommandResults.All(rec => !rec.IsActivated));
        }

	    [Fact]
        public void TestWhenLoadQuestionMessageTriggeredThenCommandResultsSetActive()
        {
            //Assign
            CommandResultsViewModel viewModel = new CommandResultsViewModel();
            viewModel.InitializeCommands(5);
            Question question = new Question {Cost = 999};

            //Act
            Messenger.Default.Send(new LoadQuestionMessage(question));

            //Assert
            Assert.True(viewModel.CommandResults.All(rec => rec.CurrentBet == question.Cost));
            Assert.True(viewModel.CommandResults.All(rec => rec.IsActivated));
        }

	    [Fact]
        public void TestWhenSuperRoundMessageTriggeredThenStayOnlyTopThreeByScoreCommand()
        {
            //Assign
            CommandResultsViewModel viewModel = new CommandResultsViewModel();
            viewModel.InitializeCommands(5);
            foreach (CommandResultViewModel command in viewModel.CommandResults)
            {
                command.AddScore(100);
            }

            //Act
            Messenger.Default.Send(new SupperRoundStartedMessage());

            //Assert
            Assert.True(viewModel.CommandResults.Count(rec => !rec.IsDisabled) == 5);
        }

	    [Fact]
        public void TestWhenSuperRoundMessageTriggeredThenStayOnlyTopThreeCommands()
        {
            //Assign
            CommandResultsViewModel viewModel = new CommandResultsViewModel();
            viewModel.InitializeCommands(5);
            for (int index = 0; index < viewModel.CommandResults.Count; index++)
            {
                CommandResultViewModel command = viewModel.CommandResults[index];
                command.AddScore(index + 1);
            }

            //Act
            Messenger.Default.Send(new SupperRoundStartedMessage());

            //Assert
            Assert.True(viewModel.CommandResults.Count(rec => !rec.IsDisabled) == 3);
            Assert.True(viewModel.IsScoreCanbeChanged);
        }

	    [Fact]
        public void TestWhenUnloadQuestionMessageTriggeredThenCommandResultsSetInnactive()
        {
            //Assign
            CommandResultsViewModel viewModel = new CommandResultsViewModel();
            viewModel.InitializeCommands(5);
            Question question = new Question();
            Messenger.Default.Send(new LoadQuestionMessage(question));

            //Act
            Messenger.Default.Send(new UnloadQuestionMessage());

            //Assert
            Assert.True(viewModel.CommandResults.All(rec => !rec.IsActivated));
        }
    }
}
