using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Explorer.WPF.Examples.Events
{
    public class MyCommand:ICommand
    {
        Action executeMethod;
        Func<bool> canExcuteMethod;
        bool canexecute = true;

        public MyCommand(Action executeMehtod)
        {
            this.executeMethod = executeMehtod;
        }

        public MyCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExcuteMethod = canExecuteMethod;
        }

        #region Implement ICommand

        public bool CanExecute(object parameter)
        {
            if (canExcuteMethod != null)
            {
                bool _result = canExcuteMethod();
                if (canexecute != _result)
                {
                    canexecute = _result;
                    EventHandler handler = CanExecuteChanged;
                    if (handler != null)
                    {
                        handler(parameter, EventArgs.Empty);
                    }
                }
            }

            return canexecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            executeMethod();
            if (canExcuteMethod != null)
            {
                CanExecuteChanged(parameter, EventArgs.Empty);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
