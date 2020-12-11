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

        public List<BLL.BusinessModels.Supply> AllSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> CloseSupplies { get; set; }

        public List<NotificationModel> Notifications { get; set; }

        public ApplicationViewModel(MainWindow win) {
            DataOpers = new DbDataOperations();
            this.win = win;
            //Commodities = DataOpers.GetCommodities();
            Commodities = DataOpers.getWarehouseCommodities(1);
            ScarceCommodities = DataOpers.getScarceWarehouseCommodities(1);
            Warehouses = DataOpers.getWarehouses();
            AllSupplies = DataOpers.getSupplies();
            Notifications = DataOpers.getNotifications();
            // ScarceCommodities = DataOpers.GetScarceCommodities();
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
                    win.Commodities.Visibility = Visibility.Collapsed;
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
                    win.Commodities.Visibility = Visibility.Visible;
                    win.ScarceCommodities.Visibility = Visibility.Collapsed;
                    win.ShowAllCommoditiesButton.Visibility = Visibility.Collapsed;
                    win.ShowScarceCommoditiesButton.Visibility = Visibility.Visible;
                    win.CommoditiesLabel.Text = "Все товары на складе";
                    win.Navigation.SelectedIndex = 0;
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
                    win.ShowAllCommoditiesButton.Visibility = Visibility.Collapsed;
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
                    CommodityReviewWindow wind = new CommodityReviewWindow();
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
                    win.Navigation.SelectedIndex = 3;
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
                    win.Navigation.SelectedIndex = 2;
                },
                (obj => true)));
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
