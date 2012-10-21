using System;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands.CommandResults;

namespace OwnGame.Messages
{
    public class PopupActivateMessage : GenericMessage<PopupActivateArgs>
    {
        public PopupActivateMessage(PopupActivateArgs content) : base(content)
        {
        }

        public PopupActivateMessage(object sender, PopupActivateArgs content) : base(sender, content)
        {
        }

        public PopupActivateMessage(object sender, object target, PopupActivateArgs content) : base(sender, target, content)
        {
        }
    }

    public sealed class PopupActivateArgs : Tuple<ChangeScoreCommand, int>
    {
        public PopupActivateArgs(ChangeScoreCommand item1, int item2) : base(item1, item2)
        {
        }
    }
}
