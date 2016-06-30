using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Models;

namespace JeopardySimulator.Ui.Messages
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