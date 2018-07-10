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

namespace Proj.Alfhr
{
    /// <summary>
    /// LauncherControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LauncherControl : UserControl
    {
        public MainWindow mainwindow;

        public LauncherControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            PlayerNameLabel.Content = Mojang.Name;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
