using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Models;

namespace OwnGame.Messages
{
    public class LoadQuestionMessage : GenericMessage<Question>
    {
        public LoadQuestionMessage(Question content) : base(content)
        {
        }

        public LoadQuestionMessage(object sender, Question content) : base(sender, content)
        {
        }

        public LoadQuestionMessage(object sender, object target, Question content) : base(sender, target, content)
        {
        }
    }
}
