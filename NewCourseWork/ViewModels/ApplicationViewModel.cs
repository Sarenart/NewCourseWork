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
using BLL.Services;
using iTextSharp.text.pdf;

namespace NewCourseWork.ViewModels
{
    public class ApplicationViewModel: INotifyPropertyChanged,IRequireClose
    {
        DbDataOperations DataOpers;


        SupplyReportService ReportService;



        #region ReportsVisibility
        private Visibility reportbyperiodvisibility;
        private Visibility reportbyprovidervisibility;
        public Visibility ReportByPeriodVisibility
        {
            get
            {
                return reportbyperiodvisibility;
            }
            set
            {
                reportbyperiodvisibility = value;
                OnPropertyChanged("ReportByPeriodVisibility");
            }
        }
        public Visibility ReportByProviderVisibility
        {
            get
            {
                return reportbyprovidervisibility;
            }
            set
            {
                reportbyprovidervisibility = value;
                OnPropertyChanged("ReportByProviderVisibility");
            }
        }
        #endregion 

        #region CommoditiesTablesAndButtonsVisibility
        private Visibility scarcecommoditiesbuttonvisibility { get; set; }

        private Visibility allcommoditiesbuttonvisibility { get; set; }
        private Visibility allcommoditiesvisibility { get; set; }
        private Visibility scarcecommoditiesvisibility { get; set; }

        public Visibility ScarceCommoditiesButtonVisibility 
        { 
            get 
            {
                return scarcecommoditiesbuttonvisibility;
            } set
            {
                scarcecommoditiesbuttonvisibility = value;
                OnPropertyChanged("ScarceCommoditiesButtonVisibility");
            } 
        }

        public Visibility AllCommoditiesButtonVisibility
        {
            get
            {
                return allcommoditiesbuttonvisibility;
            }
            set
            {
                allcommoditiesbuttonvisibility = value;
                OnPropertyChanged("AllCommoditiesButtonVisibility");
            }
        }

        public Visibility AllCommoditiesVisibility
        {
            get
            {
                return allcommoditiesvisibility;
            }
            set
            {
                allcommoditiesvisibility = value;
                OnPropertyChanged("AllCommoditiesVisibility");
            }
        }
        public Visibility ScarceCommoditiesVisibility
        {
            get
            {
                return scarcecommoditiesvisibility;
            }
            set
            {
                scarcecommoditiesvisibility = value;
                OnPropertyChanged("ScarceCommoditiesVisibility");
            }
        }

        private string commoditieslabel;
        public string CommoditiesLabel
        {
            get
            {
                return commoditieslabel;
            }
            set
            {
                commoditieslabel= value;
                OnPropertyChanged("CommoditiesLabel");
            }
        }

        #endregion

        #region SuppliesTablesAndButtonsVisibility
        private Visibility allsuppliesbuttonvisibility { get; set; }

        private Visibility nonarrangedsuppliesbuttonvisibility { get; set; }
        private Visibility allsuppliesvisibility { get; set; }
        private Visibility nonarrangedsuppliesvisibility { get; set; }

        public Visibility AllSuppliesButtonVisibility
        {
            get
            {
                return allsuppliesbuttonvisibility;
            }
            set
            {
                allsuppliesbuttonvisibility = value;
                OnPropertyChanged("AllSuppliesButtonVisibility");
            }
        }

        public Visibility NonArrangedSuppliesButtonVisibility
        {
            get
            {
                return nonarrangedsuppliesbuttonvisibility;
            }
            set
            {
                nonarrangedsuppliesbuttonvisibility = value;
                OnPropertyChanged("NonArrangedSuppliesButtonVisibility");
            }
        }
        public Visibility AllSuppliesVisibility
        {
            get
            {
                return allsuppliesvisibility;
            }
            set
            {
                allsuppliesvisibility = value;
                OnPropertyChanged("AllSuppliesVisibility");
            }
        }
        public Visibility NonArrangedSuppliesVisibility
        {
            get
            {
                return nonarrangedsuppliesvisibility;
            }
            set
            {
                nonarrangedsuppliesvisibility = value;
                OnPropertyChanged("NonArrangedSuppliesVisibility");
            }
        }

        private string supplylabel;
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

        #endregion


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

        #region SelectedVariables

        private Supply selectedallsupply;
        public Supply SelectedAllSupply
        {
            get 
            {
                return selectedallsupply;
            }
            set 
            {
                selectedallsupply = value;
                OnPropertyChanged("SelectedAllSupply");
            }
        }

        private Supply selectednonarrangedsupply;
        public Supply SelectedNonArrangedSupply
        {
            get
            {
                return selectednonarrangedsupply;
            }
            set
            {
                selectednonarrangedsupply = value;
                OnPropertyChanged("SelectedNonArrangedSupply");
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

        private DateTime start { get; set; }

        private DateTime finish { get; set; }

        public DateTime Start { 
            get 
            { 
                return start; 
            } 
            set 
            { 
                start = value; 
                OnPropertyChanged("Start"); 
            } 
        }

        public DateTime Finish
        {
            get
            {
                return finish;
            }
            set
            {
                finish = value;
                OnPropertyChanged("Finish");
            }
        }

        private Provider selectedreportprovider { get; set; }

        public Provider SelectedReportProvider { 
            get 
            { 
                return selectedreportprovider; 
            } 
            set 
            { 
                selectedreportprovider = value; 
                OnPropertyChanged("SelectedReportProvider"); 
            } 
        }

        private int navigation { get; set; }

        public int Navigation
        {
            get
            {
                return navigation;
            }
            set
            {
                navigation = value;
                OnPropertyChanged("Navigation");
            }
        }
        #endregion

        #region Lists
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

        public List<BLL.BusinessModels.Supply> NonArrangedSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> CloseSupplies { get; set; }

        public List<NotificationModel> Notifications { get; set; }

        public List<SupplyReportModel> ReportByPeriod { get; set; }
        #endregion

        #region StartOfViewModel
        public ApplicationViewModel(MainWindow win, DbDataOperations db, User CurUser) {
            this.DataOpers = db; //new DbDataOperations();
            this.CurrentUser = CurUser;
            initialize();
        }

        public void initialize()
        {
            _viewId = Guid.NewGuid();
            Warehouses = DataOpers.getWarehouses();
            Notifications = DataOpers.getNotifications();
            ReportService = new SupplyReportService();
            ReportByPeriodVisibility = Visibility.Collapsed;
            Navigation = 0;
            CommoditiesLabel = "Товары на исходе";
            ScarceCommoditiesButtonVisibility = Visibility.Collapsed;
            ScarceCommoditiesVisibility = Visibility.Visible;
            AllCommoditiesButtonVisibility = Visibility.Visible;
            AllCommoditiesVisibility = Visibility.Collapsed;
            AllSuppliesVisibility = Visibility.Collapsed;
            AllSuppliesButtonVisibility = Visibility.Visible;
            NonArrangedSuppliesVisibility = Visibility.Visible;
            NonArrangedSuppliesButtonVisibility = Visibility.Collapsed;
            SupplyLabel = "Неоформленные поставки";
        }
        #endregion

        #region ShowData
        private BasicCommand showscarcecommodities;
        public BasicCommand ShowScarceCommodities
        {
            get
            {
                return showscarcecommodities ??
                (showscarcecommodities = new BasicCommand(obj =>
                {
                    CommoditiesLabel = "Товары на исходе";
                    ScarceCommoditiesButtonVisibility = Visibility.Collapsed;
                    ScarceCommoditiesVisibility = Visibility.Visible;
                    AllCommoditiesButtonVisibility = Visibility.Visible;
                    AllCommoditiesVisibility = Visibility.Collapsed;
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
                    CommoditiesLabel = "Все товары на складе";
                    ScarceCommoditiesButtonVisibility = Visibility.Visible;
                    ScarceCommoditiesVisibility = Visibility.Collapsed;
                    AllCommoditiesButtonVisibility = Visibility.Collapsed;
                    AllCommoditiesVisibility = Visibility.Visible;

                },
                (obj => true)));
            }
        }

        private BasicCommand shownonarrangedsupplies;
        public BasicCommand ShowNonArrangedSupplies
        {
            get
            {
                return shownonarrangedsupplies ??
                (shownonarrangedsupplies = new BasicCommand(obj =>
                {

                    AllSuppliesVisibility = Visibility.Collapsed;
                    AllSuppliesButtonVisibility = Visibility.Visible;
                    NonArrangedSuppliesVisibility = Visibility.Visible;
                    NonArrangedSuppliesButtonVisibility = Visibility.Collapsed;
                    SupplyLabel = "Неоформленные поставки";
                    SelectedAllSupply = null;
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

                    AllSuppliesVisibility = Visibility.Visible;
                    AllSuppliesButtonVisibility = Visibility.Collapsed;
                    NonArrangedSuppliesVisibility = Visibility.Collapsed;
                    NonArrangedSuppliesButtonVisibility = Visibility.Visible;
                    SupplyLabel = "Все поставки";
                    SelectedNonArrangedSupply = null;
                },
                (obj => true)));
            }
        }


        #endregion

        #region WindowManaging

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
        private BasicCommand closeapp;
        public BasicCommand CloseApp
        {
            get
            {
                return closeapp ??
                (closeapp = new BasicCommand(obj =>
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

        private BasicCommand showsupply;
        public BasicCommand ShowSupply
        {
            get
            {
                return showsupply ??
                (showsupply = new BasicCommand(obj =>
                {
                    Supply SelectedSupply;
                    if (SelectedAllSupply != null) 
                        SelectedSupply = SelectedAllSupply;
                    else
                        SelectedSupply = SelectedNonArrangedSupply;
                    SupplyUpdateWindow wind = new SupplyUpdateWindow(this.DataOpers, SelectedSupply, CurrentUser);
                    wind.ShowDialog();
                },
                (obj => (SelectedNonArrangedSupply != null || SelectedAllSupply != null))));
            }
        }
        #endregion

        #region Navigation
        private BasicCommand tosupplies;
        public BasicCommand ToSupplies
        {
            get
            {
                return tosupplies ??
                (tosupplies= new BasicCommand(obj =>
                {
                    Navigation = 2;
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
                    Navigation = 3;
                },
                (obj => true)));
            }
        }
        #endregion

        private BasicCommand warehousechanged;//Артефакт
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

        #region Reports

        private BasicCommand makereportbyperiod;
        public BasicCommand MakeReportByPeriod
        {
            get
            {
                return makereportbyperiod ??
                (makereportbyperiod = new BasicCommand(obj =>
                {
                    ReportByPeriodVisibility = Visibility.Visible;
                    ReportByPeriod = ReportService.getReportByPeriod();
                    OnPropertyChanged("ReportByPeriod");
                },
                (obj => true)));
            }
        }
        #endregion


        public void SupplyWarehouseComboBoxChanged(Warehouse warehouse) {
            this.AllSupplies = DataOpers.getAllSupplies(warehouse.Id);
            OnPropertyChanged("AllSupplies");
            this.NonArrangedSupplies = DataOpers.getNonArrangedSupplies(warehouse.Id);
            OnPropertyChanged("NonArrangedSupplies");
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
