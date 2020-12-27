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
using System.Data.Entity.Infrastructure;
using NewCourseWork.WindowManaging;
using BLL.Services;
using iTextSharp.text.pdf;

namespace NewCourseWork.ViewModels
{
    public class ApplicationViewModel: INotifyPropertyChanged,IRequireClose
    {
        DbDataOperations DataOpers;


        SupplyReportService ReportService;

        FileManager fileMan;


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
        private Visibility reportbyperiodbuttonvisibility;
        private Visibility reportbyproviderbuttonvisibility;
        public Visibility ReportByPeriodButtonVisibility
        {
            get
            {
                return reportbyperiodbuttonvisibility;
            }
            set
            {
                reportbyperiodbuttonvisibility = value;
                OnPropertyChanged("ReportByPeriodButtonVisibility");
            }
        }
        public Visibility ReportByProviderButtonVisibility
        {
            get
            {
                return reportbyproviderbuttonvisibility;
            }
            set
            {
                reportbyproviderbuttonvisibility = value;
                OnPropertyChanged("ReportByProviderButtonVisibility");
            }
        }

        private Visibility makereportbyperiodbuttonvisibility;

        private Visibility makereportbyproviderbuttonvisibility;
        public Visibility MakeReportByPeriodButtonVisibility
        {
            get
            {
                return makereportbyperiodbuttonvisibility;
            }
            set
            {
                makereportbyperiodbuttonvisibility = value;
                OnPropertyChanged("MakeReportByPeriodButtonVisibility");
            }
        }
        public Visibility MakeReportByProviderButtonVisibility
        {
            get
            {
                return makereportbyproviderbuttonvisibility;
            }
            set
            {
                makereportbyproviderbuttonvisibility = value;
                OnPropertyChanged("MakeReportByProviderButtonVisibility");
            }
        }

        private Visibility startvisibility;

        private Visibility finishvisibility;

        public Visibility StartVisibility
        {
            get
            {
                return startvisibility;
            }
            set
            {
                startvisibility = value;
                OnPropertyChanged("StartVisibility");
            }
        }
        public Visibility FinishVisibility
        {
            get
            {
                return finishvisibility;
            }
            set
            {
                finishvisibility = value;
                OnPropertyChanged("FinishVisibility");
            }
        }

        private Visibility warehousereportvisibility;

        public Visibility WarehouseReportVisibility 
        {
            get
            {
                return warehousereportvisibility;
            }
            set
            {
                warehousereportvisibility = value;
                OnPropertyChanged("WarehouseReportVisibility");
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

        private string currentuserstring { get; set; }

        public string CurrentUserString {
            get 
            {
                return currentuserstring;
            }
            set
            {
                currentuserstring = value;
                OnPropertyChanged("CurrentUserString");
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

        private Warehouse selectedreportwarehouse { get; set; }

        public Warehouse SelectedReportWarehouse { 
            get 
            { 
                return selectedreportwarehouse; 
            } 
            set 
            { 
                selectedreportwarehouse = value; 
                OnPropertyChanged("SelectedReportWarehouse"); 
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

        #region providers
        public List<ProviderSupplyStock> SelectedProviderCommodity { get; set; }

        public List<Provider> Providers { get; set; }

        private Provider selectedprovider;

        public int UpdatedDate { get; set; }
        public Provider SelectedProvider
        {
            get
            {
                return selectedprovider;
            }
            set
            {
                selectedprovider = value;
                OnPropertyChanged("SelectedProvider");
                SelectedProviderChanged();
            }
        }

        private DateTime selecteddate { get; set; }
        public DateTime SelectedDate {
            get 
            { 
                return selecteddate; 
            } 
            set 
            { 
                selecteddate = value;
                OnPropertyChanged("SelectedDate");
                UpdatedDate++;
            } 
        }
        #endregion

        #endregion

        #region Lists

        public List<BLL.BusinessModels.Supply> Supplies;
        public List<BLL.BusinessModels.Commodity> AllCommodities { get; set; }

        public List<BLL.BusinessModels.Commodity> ScarceCommodities { get; set; }
        public List<BLL.BusinessModels.Warehouse> Warehouses{ get; set; }

        public List<BLL.BusinessModels.Supply> AllSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> NonArrangedSupplies { get; set; }

        public List<BLL.BusinessModels.Supply> CloseSupplies { get; set; }

        public List<NotificationModel> Notifications { get; set; }

        public List<SupplyReportByPeriodModel> ReportByPeriod { get; set; }

        public List<SupplyReportByWarehouseModel> ReportByWarehouse { get; set; }

        public List<Provider> ProvidersData { get; set; }
        #endregion

        #region StartOfViewModel
        public ApplicationViewModel(MainWindow win, DbDataOperations db, User CurUser) {
            this.DataOpers = db; //new DbDataOperations();
            this.CurrentUser = CurUser;
            fileMan = new FileManager();
            initialize();
            CurrentUserString = "Здравствуйте, " + CurrentUser.FirName;
            try
            {
                DataOpers.CheckProviders();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Не удалось обновить возможные даты поставок. Рассмотрите возможность сделать это вручную");
            }
        }

        public void initialize()
        {
            UpdatedDate = 0;
            _viewId = Guid.NewGuid();
            Warehouses = DataOpers.getWarehouses();
            Notifications = DataOpers.getNotifications();
            Providers = DataOpers.getProviders();
            ReportService = new SupplyReportService();
            Navigation = 0;
            CommoditiesLabel = "Товары на исходе";

            #region ComSupVisibility
            ScarceCommoditiesButtonVisibility = Visibility.Collapsed;
            ScarceCommoditiesVisibility = Visibility.Visible;
            AllCommoditiesButtonVisibility = Visibility.Visible;
            AllCommoditiesVisibility = Visibility.Collapsed;
            AllSuppliesVisibility = Visibility.Collapsed;
            AllSuppliesButtonVisibility = Visibility.Visible;
            NonArrangedSuppliesVisibility = Visibility.Visible;
            NonArrangedSuppliesButtonVisibility = Visibility.Collapsed;
            #endregion

            #region ReportVisibilitySet

            ReportByProviderVisibility = Visibility.Collapsed;
            ReportByPeriodVisibility = Visibility.Collapsed;
            ReportByPeriodButtonVisibility = Visibility.Visible;
            ReportByProviderButtonVisibility = Visibility.Visible;
            MakeReportByPeriodButtonVisibility = Visibility.Collapsed;
            MakeReportByProviderButtonVisibility = Visibility.Collapsed;
            FinishVisibility = Visibility.Collapsed;
            StartVisibility = Visibility.Collapsed;
            WarehouseReportVisibility = Visibility.Collapsed;
            #endregion

            SupplyLabel = "Неоформленные поставки";

            Start = DateTime.Now.AddDays(-10);
            Finish = DateTime.Now.AddDays(10);

            ProvidersData = DataOpers.getProviders();
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
                    if (SelectedCommodityWarehouse != null)
                        CommodityWarehouseComboBoxChanged(SelectedCommodityWarehouse);
                    if (SelectedSupplyWarehouse != null)
                        SupplyWarehouseComboBoxChanged(SelectedSupplyWarehouse);
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
                    if (SelectedCommodityWarehouse != null)
                        CommodityWarehouseComboBoxChanged(SelectedCommodityWarehouse);
                    if (SelectedSupplyWarehouse != null)
                        SupplyWarehouseComboBoxChanged(SelectedSupplyWarehouse);
                    Notifications = DataOpers.getNotifications();
                    OnPropertyChanged("Notifications");
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

        /*private BasicCommand warehousechanged;
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

        #region Reports

        private BasicCommand makereportbyperiod;
        public BasicCommand MakeReportByPeriod
        {
            get
            {
                return makereportbyperiod ??
                (makereportbyperiod = new BasicCommand(obj =>
                {
                    ReportByPeriod = this.ReportService.getReportByPeriod(Start, Finish);
                    OnPropertyChanged("ReportByPeriod");
                },
                (obj => (Start != null && Finish != null))));
            }
        }

        private BasicCommand makereportbywarehouse;
        public BasicCommand MakeReportByWarehouse
        {
            get
            {
                return makereportbywarehouse ??
                (makereportbywarehouse = new BasicCommand(obj =>
                {
                    ReportByWarehouse= this.ReportService.getReportByWarehouse(SelectedReportWarehouse.Id);
                    OnPropertyChanged("ReportByWarehouse");
                },
                (obj => (SelectedReportWarehouse!=null))));
            }
        }

        private BasicCommand showreportbyperiod;
        public BasicCommand ShowReportByPeriod
        {
            get
            {
                return showreportbyperiod ??
                (showreportbyperiod = new BasicCommand(obj =>
                {
                    ReportByPeriodVisibility = Visibility.Visible;
                    ReportByProviderVisibility = Visibility.Collapsed;
                    ReportByPeriodButtonVisibility = Visibility.Collapsed;
                    ReportByProviderButtonVisibility = Visibility.Visible;
                    MakeReportByPeriodButtonVisibility = Visibility.Visible;
                    MakeReportByProviderButtonVisibility = Visibility.Collapsed;
                    FinishVisibility = Visibility.Visible;
                    StartVisibility = Visibility.Visible;
                    WarehouseReportVisibility = Visibility.Collapsed;
                },
                (obj => true)));
            }
        }

        private BasicCommand showreportbywarehouse;
        public BasicCommand ShowReportByWarehouse
        {
            get
            {
                return showreportbywarehouse ??
                (showreportbywarehouse = new BasicCommand(obj =>
                {
                    ReportByPeriodVisibility = Visibility.Collapsed;
                    ReportByProviderVisibility = Visibility.Visible;
                    ReportByPeriodButtonVisibility = Visibility.Visible;
                    ReportByProviderButtonVisibility = Visibility.Collapsed;
                    MakeReportByPeriodButtonVisibility = Visibility.Collapsed;
                    MakeReportByProviderButtonVisibility = Visibility.Visible;
                    FinishVisibility = Visibility.Collapsed;
                    StartVisibility = Visibility.Collapsed;
                    WarehouseReportVisibility = Visibility.Visible;
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

        public void SelectedProviderChanged()
        {
            UpdatedDate = 0;
            SelectedProviderCommodity = DataOpers.getProviderSupplyStock(SelectedProvider.Id);
            OnPropertyChanged("SelectedProviderCommodity");
            SelectedDate = SelectedProvider.PossibleDeliveryDate;
        }


        private BasicCommand changedeliverydate;
        public BasicCommand ChangeDeliveryDate
        {
            get
            {
                return changedeliverydate??
                (changedeliverydate = new BasicCommand(obj =>
                {
                    if (SelectedDate <= DateTime.Now)
                        MessageBox.Show("Нельзя сделать такую дату.");
                    else
                    {
                        SelectedProvider.PossibleDeliveryDate = SelectedDate;
                        DataOpers.UpdateDeliveryDate(SelectedProvider);
                        UpdatedDate = 0;
                    }
                },
                (obj => (UpdatedDate > 1))));
            }
        }


        #region Auxilary
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
        #endregion
    }
}
