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

namespace NewCourseWork
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        LoginViewModel VM;
        public RegWindow()
        {
            InitializeComponent();
            VM = new LoginViewModel(this);
            Loaded += new RoutedEventHandler(RegWindow_Loaded);
        }
        void RegWindow_Loaded(object sender, RoutedEventArgs args)
        {
            DataContext = VM;
        }

    }
}
