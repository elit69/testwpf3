using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace testwpf3 {
    class RelayCommand : ICommand {
        private Action targetMethodExecute;
        private Func<bool> targetMethodCanExecute;

        public RelayCommand ( Action executeMethod ) {
            this.targetMethodExecute = executeMethod;
        }
        public RelayCommand ( Action executeMethod, Func<bool> canExecuteMethod ) {
            this.targetMethodExecute = executeMethod;
            this.targetMethodCanExecute = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged ( ) {
            CanExecuteChanged(this, EventArgs.Empty);
        }


        public event EventHandler CanExecuteChanged;


        public bool CanExecute ( object parameter ) {
            if (targetMethodCanExecute != null) {
                return targetMethodCanExecute();
            }

            if (targetMethodExecute != null) {
                return true;
            }

            return false;
        }

        public void Execute ( object parameter ) {
            if (targetMethodExecute != null) {
                targetMethodExecute();
            }
        }
    }
}
