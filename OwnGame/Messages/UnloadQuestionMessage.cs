using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using OwnGame.Models;

namespace OwnGame.Messages
{
    public class UnloadQuestionMessage : GenericMessage<Question>
    {
        public UnloadQuestionMessage(Question content) : base(content)
        {
        }

        public UnloadQuestionMessage(object sender, Question content) : base(sender, content)
        {
        }

        public UnloadQuestionMessage(object sender, object target, Question content) : base(sender, target, content)
        {
        }
    }
}
