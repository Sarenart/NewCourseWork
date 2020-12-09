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

namespace NewCourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationViewModel AppVM;
        public MainWindow(/*WindowManager WindMan*/)
        {
            //WinMan = WindMan;
            //WinMan.SetOwnerWindow(this);
            InitializeComponent();
            AppVM = new ApplicationViewModel();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);

        }
        void MainWindow_Loaded(object sender, RoutedEventArgs args) {
            DataContext = AppVM;//WinMan;
            //Commodities = new AppVM.Commodities;
        }
    }
}
