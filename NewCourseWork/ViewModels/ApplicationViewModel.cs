using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BLL.DataOperations;
using BLL.BusinessModels;
using System.Windows;

namespace NewCourseWork.ViewModels
{
    public class ApplicationViewModel:INotifyPropertyChanged
    {
        DbDataOperations DataOpers;
        MainWindow win;

        public List<BLL.BusinessModels.Supply> Supplies;
        public List<BLL.BusinessModels.Commodity> Commodities { get; set; }

        public List<BLL.BusinessModels.Commodity> ScarceCommodities { get; set; }
        public List<BLL.BusinessModels.Warehouse> Warehouses{ get; set; }
        public Commodity Check;

        public ApplicationViewModel(MainWindow win) {
            DataOpers = new DbDataOperations();
            this.win = win;
            //Commodities = DataOpers.GetCommodities();
            Commodities = DataOpers.GetWarehouseCommodities(1);
            ScarceCommodities = DataOpers.GetScarceWarehouseCommodities(1);
            Warehouses = DataOpers.GetWarehouses();
           // ScarceCommodities = DataOpers.GetScarceCommodities();
        }

        //private BasicCommand showscarcecommodities;
        /*public BasicCommand ShowScarceCommodities
        {
            get
            {
                return showscarcecommodities ??
                (showscarcecommodities = new BasicCommand(obj =>
                { 
                }         
                    
                    ));
            }
        }*/


















        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
