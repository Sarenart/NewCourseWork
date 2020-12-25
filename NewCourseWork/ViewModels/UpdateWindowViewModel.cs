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
    public class UpdateWindowViewModel : INotifyPropertyChanged
    {

        private BLL.BusinessModels.User currentuser;

        private int StatusChanger;

        private bool isstatusenabled;
        public bool IsStatusEnabled
        {
            get
            {
                return isstatusenabled;
            }
            set
            {
                isstatusenabled = value;
                OnPropertyChanged("IsStatusEnabled");
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

        private string applicant;

        public string Warehouse { get; set; }
        public string Applicant
        {
            get
            {
                return applicant;
            }
            set
            {
                applicant = value;
                OnPropertyChanged("Applicant");
            }
        }

        private string arranger;

        private string provider;

        public string Provider
        {
            get
            {
                return provider;
            }
            set
            {
                provider = value;
                OnPropertyChanged("Provider");
            }
        }
        public string Arranger
        {
            get
            {
                return arranger;
            }
            set
            {
                arranger = value;
                OnPropertyChanged("Arranger");
            }
        }

        private string arrangementdate;
        public string ArrangementDate
        {
            get
            {
                return arrangementdate;
            }
            set
            {
                arrangementdate = value;
                OnPropertyChanged("ArrangementDate");
            }
        }


        private Supply selectedsupply;

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public List<SupplyLine> Lines { get; set; }
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

        DbDataOperations DataOpers;

        FileManager fileMan;
        public List<SupplyStatus> Statuses { get; set; }

        private SupplyStatus selectedstatus;
        public SupplyStatus SelectedStatus { 
            get
            {
                return selectedstatus;
            }
            set
            {
                selectedstatus = value;
                OnPropertyChanged("SelectedStatus");
                ChangeStatusChanger();
            }
        }

        public UpdateWindowViewModel(DbDataOperations DbOps, Supply sup, User CurUser)
        {
            this.DataOpers = DbOps;
            SelectedSupply = sup;
            //Lines = DataOpers.getSupplyLines(sup.Id);
            Title = "Просмотр поставки";
            CurrentUser = CurUser;
            Applicant = DataOpers.getUsers().Where(i => i.Id == sup.ApplicantId).FirstOrDefault().FamName + " " +
                DataOpers.getUsers().Where(i => i.Id == sup.ApplicantId).FirstOrDefault().FirName;
            SelectArranger();
            SelectArrangementDate();
            Provider = DataOpers.getProviders().Where(i => i.Id == sup.ProviderId).FirstOrDefault().CompanyName;
            Statuses = DataOpers.getSupplyStatuses();
            SelectedStatus = Statuses.Where(i=>i.Id == sup.StatusId).FirstOrDefault();
            StatusChanger = 0;
            SetStatus();
            Warehouse = DataOpers.getWarehouses().Where(i => i.Id == sup.WarehouseId).FirstOrDefault().Address;
            fileMan = new FileManager(DataOpers);
        }

        #region Auxilary Funcs
        public void SelectArranger()
        {
            if (SelectedSupply.ArrangerId != null)
                Arranger = DataOpers.getUsers().Where(i => i.Id == SelectedSupply.ArrangerId).FirstOrDefault().FamName + " " +
                DataOpers.getUsers().Where(i => i.Id == SelectedSupply.ArrangerId).FirstOrDefault().FirName;
            else Arranger = "Не оформлено";
        }
        public void SelectArrangementDate()
        {
            if (SelectedSupply.ArrangementDate != null)
                ArrangementDate = SelectedSupply.ArrangementDate.ToString();
            else ArrangementDate = "Не оформлено";
        }

        public void SetStatus()
        {
            if (SelectedSupply.StatusId == 1 || SelectedSupply.StatusId == 3)
                IsStatusEnabled = true;
            else
                IsStatusEnabled = false;
        }

        private void ChangeStatusChanger()
        {
            if (SelectedStatus.Id == SelectedSupply.StatusId)
                StatusChanger = 0;
            else
                StatusChanger = 1;
        }
        #endregion 

        private BasicCommand updatesupply;
        public BasicCommand UpdateSupply
        {
            get
            {
                return updatesupply ??
                (updatesupply = new BasicCommand(obj =>
                {
                    if (MessageBox.Show("Хотите обновить поставку?", "Изменение поставки?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        SelectedSupply.StatusId = SelectedStatus.Id;
                        if (SelectedStatus.Id == 2 || SelectedStatus.Id == 4 || SelectedStatus.Id == 5)
                        {
                            SelectedSupply.ArrangementDate = DateTime.Now;
                            SelectedSupply.ArrangerId = CurrentUser.Id;
                            Arranger = CurrentUser.FamName + " " + CurrentUser.FirName;
                            ArrangementDate = DateTime.Now.ToString();
                        }
                        DataOpers.UpdateSupply(SelectedSupply);
                        if (SelectedStatus.Id == 2)
                            fileMan.Arrange(SelectedSupply);
                        if(!(SelectedStatus.Id == 1 || SelectedStatus.Id == 3))
                        IsStatusEnabled = false;
                    }    
    
                },
                (obj => (IsStatusEnabled == true && StatusChanger == 1))));
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
