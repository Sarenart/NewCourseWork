using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NewCourseWork.ViewModels;
using BLL.BusinessModels;
using BLL.DataOperations;

namespace NewCourseWork
{
    /// <summary>
    /// Логика взаимодействия для SupplyUpdateWindow.xaml
    /// </summary>
    public partial class SupplyUpdateWindow : Window
    {
        UpdateWindowViewModel VM;
        public SupplyUpdateWindow(DbDataOperations db, Supply sup, User CurUser)
        {
            InitializeComponent();
            VM = new UpdateWindowViewModel(db, sup, CurUser);
            Loaded += new RoutedEventHandler(SupplyUpdateWindow_Loaded);
        }

        void SupplyUpdateWindow_Loaded(object sender, RoutedEventArgs args)
        {
            DataContext = VM;
        }
    }
}
