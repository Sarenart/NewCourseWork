using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BLL.DataOperations;

namespace NewCourseWork.ViewModels
{
    public class ApplicationViewModel:INotifyPropertyChanged
    {
        DbDataOperations DataOpers;
        WindowManager Wm;

        public List<BLL.BusinessModels.Supply> Supplies;
        public List<BLL.BusinessModels.Commodity> Commodities { get; set; }

        public List<BLL.BusinessModels.Commodity> ScarceCommodities { get; set; }

        public ApplicationViewModel() {
            DataOpers = new DbDataOperations();
            Commodities = DataOpers.GetCommodities();
            Commodities = DataOpers.GetCommodities();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
