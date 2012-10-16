using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Commands;
using OwnGame.Models;

namespace OwnGame.Messages
{
    class PopupActivateMessage : GenericMessage<Tuple<ChangeScoreCommand, int>>
    {
        public PopupActivateMessage(Tuple<ChangeScoreCommand, int> content) : base(content)
        {
        }

        public PopupActivateMessage(object sender, Tuple<ChangeScoreCommand, int> content) : base(sender, content)
        {
        }

        public PopupActivateMessage(object sender, object target, Tuple<ChangeScoreCommand, int> content) : base(sender, target, content)
        {
        }
    }
}
