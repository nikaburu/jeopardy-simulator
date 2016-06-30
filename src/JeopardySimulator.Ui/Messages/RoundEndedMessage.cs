using GalaSoft.MvvmLight.Messaging;

namespace JeopardySimulator.Ui.Messages
{
	public class RoundEndedMessage : MessageBase
	{
		public RoundEndedMessage(bool isGameEnded = false)
		{
			IsGameEnded = isGameEnded;
		}

		public bool IsGameEnded { get; private set; }
	}
}