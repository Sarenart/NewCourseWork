using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace BLL.BusinessModels
{
    public class User: INotifyPropertyChanged
    {
        private int id { get; set; }
        private string login { get; set; }
        private string password { get; set; }
        private string firname { get; set; }
        private string famname { get; set; }
        public int Id 
        {
            get
            {
                return id;
            }
            set 
            {
                id = value;
                OnPropertyChanged("Id");
            } 
        }

        public string Login { 
            get 
            {
                return login;
            } 
            set 
            {
                login = value;
                OnPropertyChanged("Login");
            } 
        }


        public string Password {
            get 
            {
                return password;
            }
            set 
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string FirName {
            get
            {
                return firname;
            }
            set
            {
                firname = value;
                OnPropertyChanged("FirName");
            }
        }

        public string FamName {
            get 
            {
                return famname;
            }

            set 
            {
                famname = value;
                OnPropertyChanged("FamName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
