using System;
using System.Windows.Input;

namespace RedditUWP.ViewModels.Base
{
    class DelegateCommand : ICommand
    {
        private Action execute;
        private Func<Boolean> canexecute;
        public DelegateCommand(Action execute, Func<Boolean> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canexecute == null)
            {
                return true;
            }

            return this.canexecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (execute != null)
            {
                this.execute();
            }
        }

        public void RaiseCanExecute()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
    public class DelegateCommand<T> : ICommand
    {
        private Action<T> execute;
        private Func<Boolean> canexecute;

        public DelegateCommand(Action<T> execute, Func<Boolean> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }


        public bool CanExecute(object parameter)
        {
            if (this.canexecute == null)
            {
                return true;
            }

            return this.canexecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (execute != null)
            {
                this.execute((T)parameter);
            }
        }

        public void RaiseCanExecute()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
