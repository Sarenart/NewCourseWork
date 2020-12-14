using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BLL.BusinessModels
{
    public class ProviderSupplyStock:INotifyPropertyChanged
    {
        private int id { get; set; }

        private int commodityid { get; set; }

        private int providerid { get; set; }

        private decimal cost { get; set; }

        private string commodityname { get; set; }

        private string commoditytype { get; set; }

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
        public int CommodityId
        {
            get
            {
                return commodityid;
            }
            set
            {
                commodityid = value;
                OnPropertyChanged("CommodityId");
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
        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public string CommodityName
        {
            get
            {
                return commodityname;
            }
            set
            {
                commodityname = value;
                OnPropertyChanged("CommodityName");
            }
        }

        public string CommodityType 
        { 
            get
            {
                return commoditytype;
            }
            set
            {
                commoditytype = value;
                OnPropertyChanged("CommodityType");
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
