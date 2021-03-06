﻿using System;
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
using BLL.DataOperations;
using NewCourseWork.ViewModels;
using BLL.BusinessModels;

namespace NewCourseWork
{
    /// <summary>
    /// Логика взаимодействия для FileAFormWindow.xaml
    /// </summary>
    public partial class FileAFormWindow : Window
    {
        FileAFormViewModel VM;
        public FileAFormWindow(DbDataOperations db, User CurUser)
        {
            InitializeComponent();
            VM = new FileAFormViewModel(this, db, CurUser);
            Loaded += new RoutedEventHandler(FileAFormWindow_Loaded);
        }

        void FileAFormWindow_Loaded(object sender, EventArgs e)
        {
            DataContext = VM;
        }

    }
}
