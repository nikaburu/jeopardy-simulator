using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Models;

namespace OwnGame.Messages
{
    public class CancelQuestionMessage : GenericMessage<Question>
    {
        public CancelQuestionMessage(Question content) : base(content)
        {
        }

        public CancelQuestionMessage(object sender, Question content) : base(sender, content)
        {
        }

        public CancelQuestionMessage(object sender, object target, Question content) : base(sender, target, content)
        {
        }
    }
}
