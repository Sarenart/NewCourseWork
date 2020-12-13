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
using System.Windows.Controls;

namespace NewCourseWork.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        DbDataOperations DataOpers;
        MainWindow win;

        private string supplylabel;
        private string commoditylabel;

        private Warehouse selectedsupplywarehouse;
        private Warehouse selectedcommoditywarehouse;

        private Visibility allsuppliesvisible;
        private Visibility recentsuppliesvisible;
        private Visibility allsuppliesbuttonvisible;
        private Visibility recentsuppliesbuttonvisible;


        private Visibility allcommoditiesvisible;
        private Visibility scarcecommoditiesvisible;
        private Visibility allcommoditiesbuttonvisible;
        private Visibility scarcecommoditiesbuttonvisible;

        public string SupplyLabel
        {
            get
            {
                return supplylabel;
            }
            set
            {
                supplylabel = value;
                OnPropertyChanged("SupplyLabel");
            }
        }
        public string CommodityLabel
        {
            get
            {
                return commoditylabel;
            }
            set
            {
                commoditylabel = value;
                OnPropertyChanged("CommodityLabel");
            }
        }

        public Warehouse SelectedSupplyWarehouse
        {
            get
            {
                return selectedsupplywarehouse;
            }
            set
            {
                selectedsupplywarehouse = value;
                SupplyWarehouseComboBoxChanged(selectedsupplywarehouse);
            }
        }
        public Warehouse SelectedCommodityWarehouse
        {
            get
            {
                return selectedcommoditywarehouse;
            }
            set
            {
                selectedcommoditywarehouse = value;
                CommodityWarehouseComboBoxChanged(selectedcommoditywarehouse);
            }
        }
        public Visibility RecentSuppliesVisible
        {
            get
            {
                return recentsuppliesvisible;
            }
            set
            {
                recentsuppliesvisible = value;
                OnPropertyChanged("RecentSuppliesVisible");
            }
        }
        public Visibility AllSuppliesVisible
        {
            get
            {
                return allsuppliesvisible;
            }
            set
            {
                allsuppliesvisible = value;
                OnPropertyChanged("AllSuppliesVisible");
            }
        }
        public Visibility AllSuppliesButtonVisible
        {
            get
            {
                return allsuppliesbuttonvisible;
            }
            set
            {
                allsuppliesbuttonvisible = value;
                OnPropertyChanged("AllSuppliesButtonVisible");
            }
        }
        public Visibility RecentSuppliesButtonVisible
        {
            get
            {
                return recentsuppliesbuttonvisible;
            }
            set
            {
                recentsuppliesbuttonvisible = value;
                OnPropertyChanged("RecentSuppliesButtonVisible");
            }
        }


        public Visibility ScarceCommoditiesVisible
        {
            get
            {
                return scarcecommoditiesvisible;
            }
            set
            {
                scarcecommoditiesvisible = value;
                OnPropertyChanged("ScarceCommoditiesVisible");
            }
        }
        public Visibility AllCommoditiesVisible
        {
            get
            {
                return allcommoditiesvisible;
            }
            set
            {
                allcommoditiesvisible = value;
                OnPropertyChanged("AllCommoditiesVisible");
            }
        }
        public Visibility AllCommoditiesButtonVisible
        {
            get
            {
                return allcommoditiesbuttonvisible;
            }
            set
            {
                allcommoditiesbuttonvisible = value;
                OnPropertyChanged("AllCommoditiesButtonVisible");
            }
        }
        public Visibility ScarceCommoditiesButtonVisible
        {
            get
            {
                return scarcecommoditiesbuttonvisible;
            }
            set
            {
                scarcecommoditiesbuttonvisible = value;
                OnPropertyChanged("ScarceCommoditiesButtonVisible");
            }
        }


        public List<BLL.BusinessModels.Supply> Supplies;
        public List<BLL.BusinessModels.Commodity> AllCommodities { get; set; }

        public List<BLL.BusinessModels.Commodity> ScarceCommodities { get; set; }
        public List<BLL.BusinessModels.Warehouse> Warehouses{ get; set; }
        public Commodity Check;

        public List<BLL.BusinessModels.Supply> AllSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> RecentSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> CloseSupplies { get; set; }

        public List<NotificationModel> Notifications { get; set; }



        public ApplicationViewModel(MainWindow win) {
           this.DataOpers = new DbDataOperations();
            this.win = win;
            RegWindow regwin = new RegWindow();
            //regwin.ShowDialog();
            RecentSuppliesVisible = Visibility.Visible;
            AllSuppliesVisible = Visibility.Collapsed;
            AllSuppliesButtonVisible = Visibility.Visible;
            RecentSuppliesButtonVisible = Visibility.Collapsed;
            SupplyLabel = "Ближайшие поставки";
            CommodityLabel = "Товары на исходе";
            AllCommoditiesVisible = Visibility.Collapsed;
            ScarceCommoditiesVisible = Visibility.Visible;
            AllCommoditiesButtonVisible = Visibility.Visible;
            ScarceCommoditiesButtonVisible = Visibility.Collapsed;
            Warehouses = DataOpers.getWarehouses();
            Notifications = DataOpers.getNotifications();
        }


        private BasicCommand showscarcecommodities;
        public BasicCommand ShowScarceCommodities
        {
            get
            {
                return showscarcecommodities ??
                (showscarcecommodities = new BasicCommand(obj =>
                {  
                    ScarceCommoditiesVisible = Visibility.Visible;
                    AllCommoditiesVisible = Visibility.Collapsed;
                    ScarceCommoditiesButtonVisible = Visibility.Collapsed;
                    AllCommoditiesButtonVisible = Visibility.Visible;
                    CommodityLabel = "Товары на исходе";
                },
                (obj => true)));
            }
        }

        private BasicCommand showallcommodities;
        public BasicCommand ShowAllCommodities
        {
            get
            {
                return showallcommodities ??
                (showallcommodities = new BasicCommand(obj =>
                {
                    ScarceCommoditiesVisible = Visibility.Collapsed;
                    AllCommoditiesVisible = Visibility.Visible;
                    ScarceCommoditiesButtonVisible = Visibility.Visible;
                    AllCommoditiesButtonVisible = Visibility.Collapsed;
                    CommodityLabel = "Все товары";

                },
                (obj => true)));
            }
        }

        private BasicCommand showrecentsupplies;
        public BasicCommand ShowRecentSupplies
        {
            get
            {
                return showrecentsupplies ??
                (showrecentsupplies = new BasicCommand(obj =>
                {
                    AllSuppliesVisible = Visibility.Collapsed;
                    RecentSuppliesVisible = Visibility.Visible;
                    AllSuppliesButtonVisible = Visibility.Visible;
                    RecentSuppliesButtonVisible = Visibility.Collapsed;
                    SupplyLabel = "Ближайшие поставки";
                },
                (obj => true)));
            }
        }

        private BasicCommand showallsupplies;
        public BasicCommand ShowAllSupplies
        {
            get
            {
                return showallsupplies ??
                (showallsupplies = new BasicCommand(obj =>
                {
                    AllSuppliesVisible = Visibility.Visible;
                    AllSuppliesButtonVisible = Visibility.Collapsed;
                    RecentSuppliesVisible = Visibility.Collapsed;
                    RecentSuppliesButtonVisible = Visibility.Visible;
                    SupplyLabel = "Все поставки";
                },
                (obj => true)));
            }
        }

        private BasicCommand arrangesupply;
        public BasicCommand ArrangeSupply
        {
            get
            {
                return arrangesupply ??
                (arrangesupply = new BasicCommand(obj =>
                {
                    SupplyUpdateWindow wind = new SupplyUpdateWindow();
                    wind.Show();
                },
                (obj => true)));
            }
        }

        private BasicCommand fileaform;
        public BasicCommand FileAForm
        {
            get
            {
                return fileaform ??
                (fileaform = new BasicCommand(obj =>
                {
                    FileAFormWindow wind = new FileAFormWindow(this.DataOpers);
                    wind.Owner = this.win;
                    wind.ShowDialog();
                },
                (obj => true)));
            }
        }

        private BasicCommand tosupplies;
        public BasicCommand ToSupplies
        {
            get
            {
                return tosupplies ??
                (tosupplies= new BasicCommand(obj =>
                {
                    win.Navigation.SelectedIndex = 2;
                },
                (obj => true)));
            }
        }

        private BasicCommand tocommodities;
        public BasicCommand ToCommodities
        {
            get
            {
                return tocommodities ??
                (tocommodities= new BasicCommand(obj =>
                {
                    win.Navigation.SelectedIndex = 3;
                },
                (obj => true)));
            }
        }


      /*  private BasicCommand warehousechanged;
        public BasicCommand WarehouseChanged
        {
            get
            {
                return warehousechanged ??
                (warehousechanged = new BasicCommand(obj =>
                {
                    TestGround testwin = new TestGround();
                    testwin.Show();
                },
                (obj => true)));
            }
        }*/

        public void SupplyWarehouseComboBoxChanged(Warehouse warehouse) {
            this.AllSupplies = DataOpers.getAllSupplies(warehouse.Id);
            OnPropertyChanged("AllSupplies");
            this.RecentSupplies = DataOpers.getRecentSupplies(warehouse.Id);
            OnPropertyChanged("RecentSupplies");
        }


        public void CommodityWarehouseComboBoxChanged(Warehouse warehouse)
        {
            this.AllCommodities = DataOpers.getWarehouseCommodities(warehouse.Id);
            OnPropertyChanged("AllCommodities");
            this.ScarceCommodities = DataOpers.getScarceWarehouseCommodities(warehouse.Id);
            OnPropertyChanged("ScarceCommodities");
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
