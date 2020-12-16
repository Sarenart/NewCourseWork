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

        private BLL.BusinessModels.User currentuser;

        private BLL.BusinessModels.Provider selectedprovider;
        private BLL.BusinessModels.Warehouse selectedwarehouse;
        private BLL.BusinessModels.ProviderSupplyStock selectedprovidercommodity;
        private BLL.BusinessModels.SupplyLine selectedaddedcommodity;

        private BLL.BusinessModels.User CurrentUser
        {
            get
            {
                return currentuser;
            }
            set
            {
                currentuser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

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
                RemoveOnProviderChange();
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
               // SelectedWarehouseChanged(selectedwarehouse);
            }
        }

        public BLL.BusinessModels.ProviderSupplyStock SelectedProviderCommodity
        {
            get
            {
                return selectedprovidercommodity;
            }
            set
            {
                selectedprovidercommodity = value;
                //SelectedWarehouseChanged(/*Warehouse warehouse*/);
                OnPropertyChanged("SelectedProviderCommodity");
            }

        }

        public BLL.BusinessModels.SupplyLine SelectedAddedCommodity
        {
            get
            {
                return selectedaddedcommodity;
            }
            set
            {
                selectedaddedcommodity = value;
                OnPropertyChanged("SelectedAddedCommodity");
            }

        }

        public List<Provider> Providers { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public List<ProviderSupplyStock> ProviderSupplies { get; set; }

        private List<SupplyLine> providerrelatedcommodity { get; set; }

       public List<SupplyLine> ProviderRelatedCommodities { 
            get 
            {
                return providerrelatedcommodity;
            } 
            set 
            {
                providerrelatedcommodity = value;
                OnPropertyChanged("ProviderRelatedCommodity");
            } 
        }

        public FileAFormViewModel(FileAFormWindow wind, DbDataOperations DataOpers, User CurUser)
        {
            this.win = wind;
            this.DataOpers = DataOpers;
            this.Warehouses = DataOpers.getWarehouses();
            this.Providers = this.DataOpers.getProviders();
            this.ProviderRelatedCommodities = new List<SupplyLine>();
            this.CurrentUser = CurUser;
        }



        public void SelectedProviderChanged(Provider provider)
        {
            this.ProviderSupplies = DataOpers.getProviderSupplyStock(provider.Id);
            OnPropertyChanged("ProviderSupplies");
        }

        public void SelectedWarehouseChanged(/*Warehouse warehouse*/)
        {
            SupplyLine line = new SupplyLine()
            {
                CommodityId = SelectedProviderCommodity.CommodityId,
                CommodityName = SelectedProviderCommodity.CommodityName,
                Quantity = 1,
                Cost = SelectedProviderCommodity.Cost,
                CommodityType = SelectedProviderCommodity.CommodityType
            };
            OnPropertyChanged("ProviderRelatedCommodities");
        }

        private BasicCommand addtosupplyform;
        public BasicCommand AddToSupplyForm
        {
            get
            {
                return addtosupplyform ??
                (addtosupplyform = new BasicCommand(obj =>
                {
                    SupplyLine line = new SupplyLine()
                    {
                        CommodityId = SelectedProviderCommodity.CommodityId,
                        CommodityName = SelectedProviderCommodity.CommodityName,
                        Quantity = 1,
                        Cost = SelectedProviderCommodity.Cost,
                        CommodityType = SelectedProviderCommodity.CommodityType,
                        Id = 1,
                        SupplyId = 1
                    };
                    if (this.ProviderRelatedCommodities.Find(i => i.CommodityId == line.CommodityId) != null)
                        MessageBox.Show("Товар уже добавлен");
                    else
                    {
                       this.ProviderRelatedCommodities = DataOpers.RecordSupplyLines(ProviderRelatedCommodities, line);
                        //this.ProviderRelatedCommodities.Add(line);
                        OnPropertyChanged("ProviderRelatedCommodities");
                    }
                },
                (obj => true)));
            }
        }


        private BasicCommand removefromsupplyform;
        public BasicCommand RemoveFromSupplyForm
        {
            get
            {
                return removefromsupplyform ??
                (removefromsupplyform = new BasicCommand(obj =>
                {
                    this.ProviderRelatedCommodities = DataOpers.RemoveSupplyLines(ProviderRelatedCommodities, SelectedAddedCommodity);
                    OnPropertyChanged("ProviderRelatedCommodities");
                },
                (obj => true)));
            }
        }

        private BasicCommand createsupply;
        public BasicCommand CreateSupply
        {
            get
            {
                return createsupply ??
                (createsupply = new BasicCommand(obj =>
                {
                    if (ProviderRelatedCommodities.Count > 0)
                    {
                        Warehouse Check =  this.SelectedWarehouse;
                        DataOpers.CreateSupply(ProviderRelatedCommodities, SelectedWarehouse.Id, SelectedProvider.Id ,CurrentUser.Id);
                        MessageBox.Show("Поставка успешно добавлена");
                        this.win.Close();
                    }
                    else MessageBox.Show("Нет добавленных продуктов");
                },
                (obj => (SelectedProvider!=null && SelectedWarehouse!=null))));
            }
        }



        private void RemoveOnProviderChange()
        {
            this.ProviderRelatedCommodities = new List<SupplyLine>();
            OnPropertyChanged("ProviderRelatedCommodities");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
