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
using BLL.BusinessModels;

namespace NewCourseWork.ViewModels
{
    public class FileAFormViewModel:INotifyPropertyChanged
    {
        FileAFormWindow win;
        DbDataOperations DataOpers;

        private BLL.BusinessModels.Provider selectedprovider;
        private BLL.BusinessModels.Warehouse selectedwarehouse;
        private BLL.BusinessModels.Commodity selectedcommodity;

        public BLL.BusinessModels.Provider SelectedProvider
        {
            get
            {
                return selectedprovider;
            }
            set
            {
                selectedprovider = value;
                SelectedProviderChanged(selectedprovider);
            }
        }

        public BLL.BusinessModels.Warehouse SelectedWarehouse
        {
            get
            {
                return selectedwarehouse;
            }
            set
            {
                selectedwarehouse = value;
                SelectedWarehouseChanged(selectedwarehouse);
            }
        }


        public List<Provider> Providers { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public List<Commodity> ProviderSupplies { get; set; }

        public List<Commodity> ProviderRelatedCommodities { get; set; }

        public FileAFormViewModel(FileAFormWindow wind, DbDataOperations DataOpers)
        {
            this.win = wind;
            this.DataOpers = DataOpers;
            this.Warehouses = DataOpers.getWarehouses();
            this.Providers = this.DataOpers.getProviders();
        }



        public void SelectedProviderChanged(Provider provider)
        {
            
        }

        public void SelectedWarehouseChanged(Warehouse warehouse)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
