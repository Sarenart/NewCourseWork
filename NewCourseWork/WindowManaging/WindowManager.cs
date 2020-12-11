using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NewCourseWork
{
   /* public class WindowManager
    {
        private MainWindow mainWindow;
        private FileAFormWindow FAFWindow;

        private CommodityReviewWindow ComRevWindow;

        private SupplyReviewWindow SupRevWindow;
        public FileAFormCommand FAFCom { get; private set; }

        public SupplyReviewCommand SupRevCom { get; private set; }

        public CommodityReviewCommand ComRevCom { get; private set; }
        public WindowManager()
        {
            //WinManCom = new WindowManagerCommand(CreateFileAFormWindow);
            FAFCom = new FileAFormCommand(CreateFileAFormWindow);
            ComRevCom = new CommodityReviewCommand(CreateCommodityReviewWindow);
            SupRevCom = new SupplyReviewCommand(CreateSupplyReviewWindow);
        }

        public void SetOwnerWindow(MainWindow Mw)
        {
            mainWindow = Mw;
        }
       /* public void CreateFileAFormWindow() 
        {
                FAFWindow = new FileAFormWindow();
                FAFWindow.Owner = mainWindow;
                FAFWindow.Show();
        }
        public void CreateCommodityReviewWindow()
        {
            ComRevWindow = new CommodityReviewWindow();
            ComRevWindow.Owner = mainWindow;
            ComRevWindow.Show();
        }
        public void CreateSupplyReviewWindow()
        {
            SupRevWindow = new SupplyReviewWindow();
            SupRevWindow.Owner = mainWindow;
            SupRevWindow.Show();
        }
        public static void OpenMainWindow()
        {
            MainWindow Mw = new MainWindow();
        }
    }*/
}
