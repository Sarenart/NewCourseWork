using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DataOperations;
using NewCourseWork.WindowManaging;
using BLL.BusinessModels;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NewCourseWork.ViewModels
{
    public class LoginViewModel:INotifyPropertyChanged,IRequireClose
    {
        private string userlogin { get; set; }
        private string userpassword { get; set; }

        public string UserPassword { 
            get 
            {
                return userpassword;
            } 
            set 
            {
                userpassword = value;
                OnPropertyChanged("UserPassword");
            } 
        }

        public string UserLogin { 
            get 
            {
                return userlogin;
            } 
            set 
            {
                userlogin = value;
                OnPropertyChanged("UserLogin");
            } 
        }

        DbDataOperations DataOpers;
        List<User> PosUsers;
        public LoginViewModel(DbDataOperations db)
        {
            _viewId = Guid.NewGuid();
            DataOpers = db;
            PosUsers = DataOpers.getUsers();
        }
        public LoginViewModel()
        {
            _viewId = Guid.NewGuid();
            DataOpers = new DbDataOperations(); 
            PosUsers = DataOpers.getUsers();
        }

        private BasicCommand enter;
        public BasicCommand Enter
        {
            get
            {
                return enter ??
                (enter = new BasicCommand(obj =>
                {
                    foreach (User item in PosUsers)
                    {
                        if (item.Password == UserPassword && item.Login == UserLogin )
                        {
                            MainWindow wm = new MainWindow(DataOpers, item);
                            wm.Show();
                            WindowManager.CloseWindow(ViewID);
                        }
                    }
                },
                (obj => true)));
            }
        }
        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
