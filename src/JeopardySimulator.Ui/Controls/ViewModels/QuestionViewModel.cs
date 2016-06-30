using GalaSoft.MvvmLight;
using JeopardySimulator.Ui.Models;

namespace JeopardySimulator.Ui.Controls.ViewModels
{
	public class QuestionViewModel : ObservableObject
	{
		private bool _isAnswered;

		public QuestionViewModel(Question model)
		{
			Model = model;
			IsAnswered = false;
		}

		public Question Model { get; private set; }

		public bool IsAnswered
		{
			get { return _isAnswered; }
			set
			{
				_isAnswered = value;
				RaisePropertyChanged(() => IsAnswered);
			}
		}
	}
}