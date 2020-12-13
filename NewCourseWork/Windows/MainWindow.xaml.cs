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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewCourseWork.ViewModels;
using BLL.DataOperations;
using BLL.BusinessModels;

namespace NewCourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationViewModel AppVM;
        public MainWindow(/*DbDataOperations DataOpers*/)
        {
            InitializeComponent();
            AppVM = new ApplicationViewModel(this/*, DataOpers*/);
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            //this.SupplyWarehouseComboBox.SelectionChanged += 
                //new SelectionChangedEventHandler(AppVM.SupplyWarehouseComboBoxChanged);
           // this.CommodityWarehouseComboBox.SelectionChanged += new SelectionChangedEventHandler(AppVM.CommodityWarehouseComboBoxChanged);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs args) {
            DataContext = AppVM;
        }

        void TestComboBox(object sender, RoutedEventArgs e)
        {
            Warehouse i =(Warehouse)SupplyWarehouseComboBox.SelectedItem;
            MessageBox.Show(i.Id.ToString());
        }
    }
}
