using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewCourseWork
{
    public class FileAFormCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _exec;
        public FileAFormCommand(Action exec)
        {
            _exec = exec;
        }

        public bool CanExecute(object sender)
        {
            return true;
        }

        public void Execute(object sender)
        {
            this._exec.Invoke();
        }

    }
}
