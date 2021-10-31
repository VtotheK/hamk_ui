using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _func;

        public RelayCommand(Action func)
        {
            _func = func;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _func();
        }
    }
}
