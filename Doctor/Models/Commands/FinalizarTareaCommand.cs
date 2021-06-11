using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Doctor.Models.Commands
{
    class FinalizarTareaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action execute;

        public FinalizarTareaCommand(Action _execute)
        {
            execute = _execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke();
        }
    }
}
