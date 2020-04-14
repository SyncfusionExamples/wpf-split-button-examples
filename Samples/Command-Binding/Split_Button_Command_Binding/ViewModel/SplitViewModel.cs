using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Split_Button_Command_Binding
{
    public class DelegateCommand<T> : ICommand
    {
        private Predicate<T> _canExecute;
        private Action<T> _method;
        bool _canExecuteCache = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        public DelegateCommand(Action<T> method)
            : this(method, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="canExecute">The can execute.</param>
        public DelegateCommand(Action<T> method, Predicate<T> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                bool tempCanExecute = _canExecute((T)parameter);

                if (_canExecuteCache != tempCanExecute)
                {
                    _canExecuteCache = tempCanExecute;
                    this.RaiseCanExecuteChanged();
                }
            }

            return _canExecuteCache;
        }

        /// <summary>
        /// Raises CanExecuteChanged event to notify changes in command status.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (_method != null)
                _method.Invoke((T)parameter);
        }

        #region ICommand Members

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion
    }
    
    public class SplitViewModel : NotificationObject
    {
        private bool _canperformaction = true;
        private bool _canperformactionitem = true;

        public SplitViewModel()
        {
            ClickCommand = new DelegateCommand<object>(ClickAction, CanPerformClickAction);
            DropDownCommand = new DelegateCommand<object>(ItemClickAction, CanPerformClickActionItem);
        }

        public DelegateCommand<object> ClickCommand { get; set; }

        public DelegateCommand<object> DropDownCommand { get; set; }

        public bool CanPerformAction
        {
            get
            {
                return _canperformaction;
            }
            set
            {
                _canperformaction = value;
                this.ClickCommand.RaiseCanExecuteChanged();
                this.RaisePropertyChanged("CanPerformAction");
            }
        }

        public bool CanPerformActionItem
        {
            get
            {
                return _canperformactionitem;
            }
            set
            {
                _canperformactionitem = value;
                this.DropDownCommand.RaiseCanExecuteChanged();
                this.RaisePropertyChanged("CanPerformActionItem");
            }
        }

        private bool CanPerformClickAction(object parameter)
        {
            return CanPerformAction;
        }

        private void ClickAction(object parameter)
        {
            MessageBox.Show(parameter.ToString());
        }

        private bool CanPerformClickActionItem(object parameter)
        {
            return CanPerformActionItem;
        }

        private void ItemClickAction(object parameter)
        {
            MessageBox.Show(parameter.ToString() + " dropdown menu item has been clicked");
        }
    }
}



