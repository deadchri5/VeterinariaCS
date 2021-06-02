using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Veterinaria.ViewModels.Commands
{
    public class EditUserDataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action execute;

        public EditUserDataCommand(Action _execute)
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
