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
        private DateTime? arrangementdate;

        private DateTime applicationdate;
        private DateTime deliverydate;

        private int applicantid;

        private int? arrangerid;


        private List<SupplyLine> lines;
        private decimal cost;

        private int statusid;

        private string status;

        private int warehouseid;
        private int providerid;

        public List<SupplyLine> Lines { get
            {
                return lines;
            }
            set
            {
                lines = value;
            }
        }



        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Date");
            }
        }

        public DateTime? ArrangementDate
        {
            get { return arrangementdate; }
            set
            {
                arrangementdate = value;
                OnPropertyChanged("ArrangementDate");
            }
        }

        public DateTime ApplicationDate
        {
            get { return applicationdate; }
            set
            {
                applicationdate = value;
                OnPropertyChanged("ApplicationDate");
            }
        }

        public DateTime DeliveryDate
        {
            get { return deliverydate; }
            set
            {
                deliverydate = value;
                OnPropertyChanged("DeliveryDate");
            }
        }
        public int StatusId
        {
            get { return statusid; }
            set
            {
                statusid = value;
                OnPropertyChanged("StatusId");
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


        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
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

        public int ProviderId
        {
            get
            {
                return providerid;
            }
            set
            {
                providerid = value;
                OnPropertyChanged("ProviderId");
            }
        }

        public int ApplicantId
        {
            get 
            { 
                return applicantid; 
            }
            set 
            { 
                applicantid = value;
                OnPropertyChanged("ApplicantId");
            }
        }

        public int? ArrangerId   
        {
            get 
            { 
                return arrangerid; 
            }
            set
            {
                arrangerid = value;
                OnPropertyChanged("ArrangerId");
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
