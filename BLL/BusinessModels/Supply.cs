using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class Supply: INotifyPropertyChanged
    {
        private int id;
        private DateTime date;

        private decimal cost;

        private int status;

        private string statusstring;
        private int warehouseid;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Date");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public int Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }


        public string StatusString
        {
            get { return statusstring; }
            set
            {
                statusstring = value;
                OnPropertyChanged("Cost");
            }
        }

        public int WarehouseId
        {
            get { return warehouseid; }
            set 
            {
                warehouseid = value;
                OnPropertyChanged("WarehouseId");
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
