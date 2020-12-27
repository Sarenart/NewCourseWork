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
using System.Collections.Specialized;

namespace NewCourseWork.ViewModels
{
    public class FileAFormViewModel:INotifyPropertyChanged
    {
        FileAFormWindow win;
        DbDataOperations DataOpers;
        FileManager fileMan;
        private DateTime supplydate { get; set; }

        public DateTime SupplyDate // Suda
        {
            get
            {
                return supplydate;
            }
            set
            {
                supplydate = value;
                OnPropertyChanged("SupplyDate");
            }
        }

        private decimal totalsum;
        public decimal TotalSum
        {
            get
            {
                return totalsum;
            }
            set
            {
                totalsum = value;
                OnPropertyChanged("TotalSum");
            }
        }

        private BLL.BusinessModels.User currentuser;
        #region SelectedVariables

        private BLL.BusinessModels.Provider selectedprovider;
        private BLL.BusinessModels.Warehouse selectedwarehouse;
        private BLL.BusinessModels.ProviderSupplyStock selectedprovidercommodity;
        private BLL.BusinessModels.SupplyLine selectedaddedcommodity;

        private int selectedamount { get; set; }

        public int SelectedAmount 
        { 
            get 
            {
                return selectedamount;
            } 
            set 
            {
                selectedamount = value;
            } 
        }
        public BLL.BusinessModels.User CurrentUser
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

        #region SelectedVariables
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
                OnPropertyChanged("SelectedProviderCommodity");
            }

        }
        #endregion
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
        #endregion
        public List<Provider> Providers { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public List<ProviderSupplyStock> ProviderSupplies { get; set; }

        public ObservableCollection<SupplyLine> NewSupplyLines { get; set; }

        private void NewSupplyLines_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: {
                        OnPropertyChanged("NewSupplyLines");
                        foreach (SupplyLine item in e.NewItems) {
                            item.PropertyChanged += ItemChanged;
                        }
                        break; 
                    }
                case NotifyCollectionChangedAction.Remove: {
                        OnPropertyChanged("NewSupplyLines");
                        foreach (SupplyLine item in e.OldItems)
                        {
                            item.PropertyChanged -= ItemChanged;
                        }
                        break; 
                    }
                case NotifyCollectionChangedAction.Replace:{ 
                        break; 
                    }
            }
        }
        public FileAFormViewModel(FileAFormWindow wind, DbDataOperations DataOpers, User CurUser)
        {
            this.win = wind;
            this.DataOpers = DataOpers;
            this.Warehouses = DataOpers.getWarehouses();
            this.Providers = this.DataOpers.getProviders();
            this.NewSupplyLines = new ObservableCollection<SupplyLine>();
            NewSupplyLines.CollectionChanged += NewSupplyLines_Changed;
            this.CurrentUser = CurUser;
            TotalSum = 0;
            fileMan = new FileManager(DataOpers);
        }


        public void ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            TotalSum = 0;
            foreach(SupplyLine item in NewSupplyLines)
            {
                TotalSum += item.Cost * item.Quantity;
            }
            OnPropertyChanged("TotalSum");
        }

        public void SelectedProviderChanged(Provider provider)
        {
            this.ProviderSupplies = DataOpers.getProviderSupplyStock(provider.Id);
            OnPropertyChanged("ProviderSupplies");
            SupplyDate = provider.PossibleDeliveryDate;
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
                    SelectedAmount = 1;
                    SupplyLine line = new SupplyLine()
                    {
                        CommodityId = SelectedProviderCommodity.CommodityId,
                        CommodityName = SelectedProviderCommodity.CommodityName,
                        Quantity = 1,
                        Cost = SelectedProviderCommodity.Cost,
                        CommodityType = SelectedProviderCommodity.CommodityType,
                        SupplyId = 1
                    };
                    
                    if (NewSupplyLines.Where(i=>i.CommodityName == line.CommodityName).Count() != 0)
                        MessageBox.Show("Товар уже добавлен");
                    else
                    {
                    TotalSum += line.Cost;
                    NewSupplyLines.Add(line);
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
                    TotalSum -= SelectedAddedCommodity.Cost;
                    NewSupplyLines.Remove(SelectedAddedCommodity);
                   
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
                    if (NewSupplyLines.Count > 0)
                    {
                        BLL.BusinessModels.Supply newSupply = new Supply() { WarehouseId = SelectedWarehouse.Id, Lines = NewSupplyLines.ToList(), DeliveryDate = SupplyDate, ProviderId = SelectedProvider.Id,
                        StatusId = 1, ApplicationDate=DateTime.Now, ApplicantId = CurrentUser.Id };
                        newSupply.Cost = 0;
                        foreach (SupplyLine item in NewSupplyLines)
                        {
                            newSupply.Cost += item.Cost * item.Quantity;
                        }
                        DataOpers.CreateSupply(newSupply);
                        newSupply = DataOpers.getLastSupply(newSupply);
                        fileMan.CreateForm(newSupply);
                        MessageBox.Show("Поставка успешно добавлена");
                        this.NewSupplyLines.Clear();
                        TotalSum = 0;
                    }
                    else MessageBox.Show("Нет добавленных продуктов");
                },
                (obj => (SelectedProvider!=null && SelectedWarehouse!=null && NewSupplyLines.Count>0))));
            }
        }



        private void RemoveOnProviderChange()
        {
            this.NewSupplyLines.Clear();
            TotalSum = 0;
            OnPropertyChanged("NewSupplyLines");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
