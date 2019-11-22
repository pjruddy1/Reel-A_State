using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reel_A_StateWpfPresentation
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;
        private ICommand deleteEstateCommand;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public DelegateCommand(ICommand deleteEstateCommand)
        {
            this.deleteEstateCommand = deleteEstateCommand;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
