using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwnGame.Models;
using OwnGame.ViewModels;
using OwnGame.Messages;

namespace OwnGame.Tests.ViewModels
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
            Assert.IsTrue(viewModel.CommandResults.All(rec => !rec.IsActivated));
        }

        [TestMethod]
        public void TestWhenLoadQuestionMessageTriggeredThenCommandResultsSetActive()
        {
            //Assign
            CommandResultsViewModel viewModel = new CommandResultsViewModel();
            viewModel.InitializeCommands(5);
            Question question = new Question() {Cost = 999};

            //Act
            Messenger.Default.Send(new LoadQuestionMessage(question));

            //Assert
            Assert.IsTrue(viewModel.CommandResults.All(rec => rec.CurrentBet == question.Cost));
            Assert.IsTrue(viewModel.CommandResults.All(rec => rec.IsActivated));
        }

        [TestMethod]
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
            Assert.IsTrue(viewModel.CommandResults.All(rec => !rec.IsActivated));
        }
        
        [TestMethod]
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
            Assert.IsTrue(viewModel.CommandResults.Count(rec => !rec.IsDisabled) == 3);
            Assert.IsTrue(viewModel.IsScoreCanbeChanged);
        }
        
        [TestMethod]
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
            Assert.IsTrue(viewModel.CommandResults.Count(rec => !rec.IsDisabled) == 5);
        }
        
    }
}
