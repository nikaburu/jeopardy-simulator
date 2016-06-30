using System;
using System.Windows.Input;

namespace JeopardySimulator.Ui.Commands.Base
{
	public abstract class CommandBase<T> : ICommand
	{
		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged(this, new EventArgs());
		}

		#region Implementation of ICommand

		void ICommand.Execute(object parameter)
		{
			if (parameter is T)
			{
				Execute((T) parameter);
			}
			else
			{
				Execute((T) Convert.ChangeType(parameter, typeof(T)));
			}
		}

		bool ICommand.CanExecute(object parameter)
		{
			if (parameter is T)
			{
				return CanExecute((T) parameter);
			}

			return true;
		}

		public event EventHandler CanExecuteChanged;

		#endregion

		#region

		public abstract void Execute(T parameter);

		public virtual bool CanExecute(T parameter)
		{
			return true;
		}

		#endregion
	}
}