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
        private Supply selectedsupply;

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
        public UpdateWindowViewModel(DbDataOperations DbOps, Supply sup)
        {
            this.DataOpers = DbOps;
            SelectedSupply = sup;
            Lines = DataOpers.ReturnSupplyLines(sup.Id);
                    }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
