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
using System.Windows;
using System.Windows.Controls;


namespace NewCourseWork.ViewModels
{
    public class LoginViewModel:INotifyPropertyChanged,IRequireClose
    {
        private string userlogin { get; set; }
        private string userpassword { get; set; }

        private string status { get; set; }

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

        public string Status {
            get 
            {
                return status;
            } 
            set 
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        DbDataOperations DataOpers;
        List<User> PosUsers;
        public LoginViewModel(DbDataOperations db)
        {
            _viewId = Guid.NewGuid();
            DataOpers = db;
            PosUsers = DataOpers.getUsers();
            Status = "Введите свои данные";
        }
        public LoginViewModel()
        {
            _viewId = Guid.NewGuid();
            DataOpers = new DbDataOperations(); 
            PosUsers = DataOpers.getUsers();
            Status = "Введите свои данные";
        }

        private BasicCommand enter;
        public BasicCommand Enter
        {
            get
            {
                return enter ??
                (enter = new BasicCommand(obj => {
                    try {
                        PasswordBox temp = obj as PasswordBox;
                        UserPassword = temp.Password;
                        foreach (User item in PosUsers)
                        {
                            if (item.Password == UserPassword && item.Login == UserLogin)
                            {
                                MainWindow wm = new MainWindow(DataOpers, item);
                                wm.Show();
                                WindowManager.CloseWindow(ViewID);
                            }

                        }
                        throw new UnauthorizedAccessException();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Status = "Login failed! Please provide some valid credentials.";
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

        private void Login(object parameter)
        {

        }
    }
}
