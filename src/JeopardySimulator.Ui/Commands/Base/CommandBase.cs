using System;
using System.Windows.Input;

namespace JeopardySimulator.Ui.Commands.Base
{
	public abstract class CommandBase : ICommand
	{
		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged(this, new EventArgs());
		}

		#region Implementation of ICommand

		void ICommand.Execute(object parameter)
		{
			Execute();
		}

		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute();
		}

		public event EventHandler CanExecuteChanged;

		#endregion

		#region

		public abstract void Execute();

		public virtual bool CanExecute()
		{
			return true;
		}

		#endregion
	}
}