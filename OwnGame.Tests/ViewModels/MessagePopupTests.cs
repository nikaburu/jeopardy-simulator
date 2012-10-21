using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwnGame.Commands.CommandResults;
using OwnGame.Messages;
using OwnGame.ViewModels;

namespace OwnGame.Tests.ViewModels
{
    [TestClass]
    public class MessagePopupTests
    {
        [TestMethod]
        public void TestMessagePopupWhenPopupActivateMessageSentThenMessagePopupActivated()
        {
            //Assign
            MessagePopupViewModel viewModel = new MessagePopupViewModel();
            var messageContent = new PopupActivateArgs(new AddScoreCommand(new CommandResultViewModel("aaa")), 0);
            bool prevActive = viewModel.IsActive;

            //Act
            Messenger.Default.Send(new PopupActivateMessage(messageContent));

            //Assert
            Assert.IsTrue(!prevActive);
            Assert.IsTrue(viewModel.IsActive);
        }


        [TestMethod]
        public void TestMessagePopupWhenCallCloseThenUnactivate()
        {
            //Assign
            MessagePopupViewModel viewModel = new MessagePopupViewModel { IsActive = true };

            //Act
            viewModel.ClosePopup();

            //Assert
            Assert.IsTrue(!viewModel.IsActive);
        }
        
    }
}
