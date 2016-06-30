using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Commands.CommandResults;
using JeopardySimulator.Ui.Messages;
using JeopardySimulator.Ui.ViewModels;
using Xunit;

namespace JeopardySimulator.Tests
{
    public class MessagePopupTests
    {
	    [Fact]
        public void TestMessagePopupWhenCallCloseThenUnactivate()
        {
            //Assign
            MessagePopupViewModel viewModel = new MessagePopupViewModel { IsActive = true };

            //Act
            viewModel.ClosePopup();

            //Assert
            Assert.True(!viewModel.IsActive);
        }

	    [Fact]
        public void TestMessagePopupWhenPopupActivateMessageSentThenMessagePopupActivated()
        {
            //Assign
            MessagePopupViewModel viewModel = new MessagePopupViewModel();
            var messageContent = new PopupActivateArgs(new AddScoreCommand(new CommandResultViewModel("aaa")), 0);
            bool prevActive = viewModel.IsActive;

            //Act
            Messenger.Default.Send(new PopupActivateMessage(messageContent));

            //Assert
            Assert.True(!prevActive);
            Assert.True(viewModel.IsActive);
        }
    }
}
