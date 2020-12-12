using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Ninject;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Windows;
using NewCourseWork.ViewModels;
namespace NewCourseWork
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private static WindowManager Wm;
        //private static MainWindowViewModel MWModel;
        App() {
           // Wm = new WindowManager();
           // MWModel = new MainWindowViewModel();
            InitializeComponent();
        }
        [STAThread]
        static void Main()
        {
            var kernel = new StandardKernel(new BLL.NinjectBLLBinding.NinjectBLLBinding("SupplyDb"), new NinjectViewModelBinding.NinjectViewModelBinding());
            
            //Объявить интерфейсы
            App app = new App();
            //MainWindow mainWindow = new MainWindow(Wm);
            app.Run(new RegWindow());
        }
    }
}
