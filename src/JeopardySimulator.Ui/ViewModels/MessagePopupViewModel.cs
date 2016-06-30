using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JeopardySimulator.Ui.Commands.CommandResults;
using JeopardySimulator.Ui.Messages;

namespace JeopardySimulator.Ui.ViewModels
{
	public class MessagePopupViewModel : ViewModelBase
	{
		public MessagePopupViewModel()
		{
			if (IsInDesignMode)
			{
				Text = "Поздравляем!\t\nКомманда 1\t\n+30 баллов";
				IsActive = true;
			}

			ProcessCommand = new RelayCommand(OnProcessCommandExecute);
			CloseCommand = new RelayCommand(OnCloseCommandExecute);

			Messenger.Default.Register<PopupActivateMessage>(this, OnPopupActivate);
		}

		public void ClosePopup()
		{
			IsActive = false;
		}

		#region Fields

		private bool _isActive;
		private ChangeScoreCommand _command;
		private int _score;
		private string _text;

		#endregion

		#region Commands

		public RelayCommand ProcessCommand { get; private set; }
		public RelayCommand CloseCommand { get; private set; }

		private void OnCloseCommandExecute()
		{
			ClosePopup();
		}

		private void OnProcessCommandExecute()
		{
			ClosePopup();
			_command.Execute(_score);
		}

		#endregion

		#region Messages

		private const string CongsText = "Поздравляем!\t\n{0}\t\n+{1} баллов";
		private const string OopsText = "Увы!\t\n{0}\t\n-{1} баллов";

		private void OnPopupActivate(PopupActivateMessage message)
		{
			_command = message.Content.Item1;
			_score = message.Content.Item2;

			IsActive = true;

			Text = string.Format(_command is AddScoreCommand ? CongsText : OopsText, _command.CommandName, _score);
		}

		#endregion

		#region Properties

		public string Text
		{
			get { return _text; }
			set
			{
				_text = value;
				RaisePropertyChanged(() => Text);
			}
		}

		public bool IsActive
		{
			get { return _isActive; }
			set
			{
				_isActive = value;
				RaisePropertyChanged(() => IsActive);
			}
		}

		#endregion
	}
}