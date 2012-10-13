using System;
using System.Windows.Input;

namespace OwnGame.Commands
{
    public abstract class CommandBase : ICommand
    {
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

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, new EventArgs());
        }

        #region

        public abstract void Execute();

        public virtual bool CanExecute()
        {
            return true;
        }

        #endregion
    }
}
