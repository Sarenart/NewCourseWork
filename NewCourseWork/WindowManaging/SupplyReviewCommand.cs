using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NewCourseWork
{
    public class SupplyReviewCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _exec;
        public SupplyReviewCommand(Action exec)
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
