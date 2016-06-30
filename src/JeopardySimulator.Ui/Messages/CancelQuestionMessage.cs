using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Models;

namespace JeopardySimulator.Ui.Messages
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