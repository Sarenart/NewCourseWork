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

namespace NewCourseWork.ViewModels
{
    public class UpdateWindowViewModel : INotifyPropertyChanged
    {
        private BLL.BusinessModels.User currentuser;

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
        public UpdateWindowViewModel(DbDataOperations DbOps, Supply sup, User CurUser)
        {
            this.DataOpers = DbOps;
            SelectedSupply = sup;
            Lines = DataOpers.ReturnSupplyLines(sup.Id);
            Title = "Просмотр поставки";
            CurrentUser = CurUser;
        }

        private BasicCommand updatesupply;
        public BasicCommand UpdateSupply
        {
            get
            {
                return updatesupply ??
                (updatesupply = new BasicCommand(obj =>
                {

                },
                (obj => (SelectedSupply.StatusId != 2))));
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
                    DataOpers.ArrangeSupply(SelectedSupply, Lines, CurrentUser);
                },
                (obj => (SelectedSupply.StatusId != 2))));
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
