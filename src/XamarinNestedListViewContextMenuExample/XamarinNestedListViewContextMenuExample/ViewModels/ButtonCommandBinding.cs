using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace XamarinNestedListViewContextMenuExample.ViewModels
{
    internal class ButtonCommandBinding : ICommand
    {
        private readonly Action handler_;

        public bool IsEnabled
        {
            get => isEnabled_;
            set
            {
                if (value != isEnabled_)
                {
                    isEnabled_ = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }
        private bool isEnabled_;

        public ButtonCommandBinding(Action handler, bool isEnabled)
        {
            handler_ = handler;
            isEnabled_ = isEnabled;
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            handler_();
        }
    }
}
