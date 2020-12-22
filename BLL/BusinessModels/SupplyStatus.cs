using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace BLL.BusinessModels
{
    public class SupplyStatus:INotifyPropertyChanged
    {
        private string status;
        private int id;
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

        public int Id { get 
            {
                return id;
            } 
            set 
            {
                id = value;
                OnPropertyChanged("Id");
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
