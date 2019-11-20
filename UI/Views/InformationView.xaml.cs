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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Tools.Navigation;
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Логика взаимодействия для InformationView.xaml
    /// </summary>
    public partial class InformationView : UserControl, INavigatable
    {
        public InformationView()
        {
            InitializeComponent();
            DataContext = new InformationViewModel();
        }
    }
}
