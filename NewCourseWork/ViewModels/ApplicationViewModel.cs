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
using NewCourseWork.WindowManaging;

namespace NewCourseWork.ViewModels
{
    public class ApplicationViewModel: INotifyPropertyChanged,IRequireClose
    {
        DbDataOperations DataOpers;
        MainWindow win;

        private User currentuser { get; set; }
        public User CurrentUser { 
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

        private Supply selectedsupply;
        public Supply SelectedSupply
        {
            get 
            {
                return selectedsupply;
            }
            set 
            {
                selectedsupply = value;
                OnPropertyChanged("SelectedSupply");
            }
        }

        private Warehouse selectedsupplywarehouse;
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

        private Warehouse selectedcommoditywarehouse;

        private Commodity check;


        public Commodity Check
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
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

        public List<BLL.BusinessModels.Supply> Supplies;
        public List<BLL.BusinessModels.Commodity> AllCommodities { get; set; }

        public List<BLL.BusinessModels.Commodity> ScarceCommodities { get; set; }
        public List<BLL.BusinessModels.Warehouse> Warehouses{ get; set; }

        public List<BLL.BusinessModels.Supply> AllSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> RecentSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> CloseSupplies { get; set; }

        public List<NotificationModel> Notifications { get; set; }

        //public Li

        public ApplicationViewModel(MainWindow win, DbDataOperations db, User CurUser) {
            this.DataOpers = db; //new DbDataOperations();
            this.win = win;
            this.CurrentUser = CurUser;
            _viewId = Guid.NewGuid();
            //RegWindow regwin = new RegWindow();
            //regwin.ShowDialog();
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
                    win.CommoditiesLabel.Text = "Товары на исходе";
                    win.AllCommodities.Visibility = Visibility.Collapsed;
                    win.ScarceCommodities.Visibility = Visibility.Visible;
                    win.ShowAllCommoditiesButton.Visibility = Visibility.Visible;
                    win.ShowScarceCommoditiesButton.Visibility = Visibility.Collapsed;
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
                    win.AllCommodities.Visibility = Visibility.Visible;
                    win.ScarceCommodities.Visibility = Visibility.Collapsed;
                    win.ShowAllCommoditiesButton.Visibility = Visibility.Collapsed;
                    win.ShowScarceCommoditiesButton.Visibility = Visibility.Visible;
                    win.CommoditiesLabel.Text = "Все товары на складе";
  
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
                    win.RecentSupplies.Visibility = Visibility.Visible;
                    win.AllSupplies.Visibility = Visibility.Collapsed;
                    win.SupplyLabel.Text = "Ближайшие поставки на складе";
                    win.ShowAllSuppliesButton.Visibility = Visibility.Visible;
                    win.ShowRecentSuppliesButton.Visibility = Visibility.Collapsed;
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
                    win.RecentSupplies.Visibility = Visibility.Collapsed;
                    win.AllSupplies.Visibility = Visibility.Visible;
                    win.SupplyLabel.Text = "Поставки";
                    win.ShowAllSuppliesButton.Visibility = Visibility.Collapsed;
                    win.ShowRecentSuppliesButton.Visibility = Visibility.Visible;
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
                    SupplyUpdateWindow wind = new SupplyUpdateWindow(this.DataOpers, SelectedSupply);
                    wind.ShowDialog();
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
                    FileAFormWindow wind = new FileAFormWindow(this.DataOpers, CurrentUser);
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


        private BasicCommand warehousechanged;
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
        }


        private BasicCommand closeapp;
        public BasicCommand CloseApp
        {
            get
            {
                return closeapp ??
                (closeapp= new BasicCommand(obj =>
                {
                    WindowManager.CloseWindow(ViewID);
                },
                (obj => true)));
            }
        }

        private BasicCommand returntoregister;
        public BasicCommand ReturnToRegister
        {
            get
            {
                return returntoregister ??
                (returntoregister = new BasicCommand(obj =>
                {
                    RegWindow win = new RegWindow(DataOpers);
                    win.Show();
                    WindowManager.CloseWindow(ViewID);
                },
                (obj => true)));
            }
        }

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


        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
