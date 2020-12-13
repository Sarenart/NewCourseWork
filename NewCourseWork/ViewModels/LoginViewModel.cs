using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DataOperations;

namespace NewCourseWork.ViewModels
{
    public class LoginViewModel
    {
        DbDataOperations DataOpers;
        RegWindow win;
        public LoginViewModel(RegWindow win)
        {
            this.win = win;
            DataOpers = new DbDataOperations();
        }

        private BasicCommand enter;
        public BasicCommand Enter
        {
            get
            {
                return enter ??
                (enter = new BasicCommand(obj =>
                {
                    //MainWindow wm = new MainWindow(DataOpers);
                   // wm.Show();
                    win.Close();
                },
                (obj => true)));
            }
        }
    }
}
