using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BLL.BusinessModels
{
    public class Warehouse:INotifyPropertyChanged
    {
        private int id { get; set; }

        private string address { get; set; }

        public Warehouse() { }
        public Warehouse(DAL.Warehouse warehouse)
        {
            Address = warehouse.Address;
            Id = warehouse.Id;
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public int Id
        {
            get { return id; }
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
