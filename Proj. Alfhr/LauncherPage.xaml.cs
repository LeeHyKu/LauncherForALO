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

namespace Proj.Alfhr
{
    /// <summary>
    /// LauncherPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LauncherPage : Page
    {
        public LauncherPage()
        {
            InitializeComponent();
            PlayerLabel.Content = "Hello, World! 안녕하세요" + Mojang.Name + " 님!";
        }
    }
}
