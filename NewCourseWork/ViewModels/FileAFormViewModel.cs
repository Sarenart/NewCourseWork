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
    public class FileAFormViewModel:INotifyPropertyChanged
    {
        FileAFormWindow win;
        DbDataOperations DataOpers;

        List<Provider> Providers;

        public FileAFormViewModel(FileAFormWindow wind, DbDataOperations DatOper)
        {
            this.win = wind;
            this.DataOpers = DatOper;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
