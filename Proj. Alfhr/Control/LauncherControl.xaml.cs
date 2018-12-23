using Proj.Alfhr.Control;
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

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            if(!await Mincraft.ChackLastestVersionAsync())
            {
                StatusLabel.Content = "업데이트중입니다 잠시만 기다려주세요...";
                await Mincraft.UpdateAsync(StatusLabel);
            }
            StatusLabel.Content = "실행중입니다 잠시만 기다려주세요...";
            await Mincraft.LaunchAsync(StatusLabel);
            StartButton.IsEnabled = true;
            StatusLabel.Content = "";
            Application.Current.Shutdown();
        }

        //안쓸수도 있는것들
        private void Icon_List_MouseEnter(object sender, RoutedEventArgs e)
        {
            Icon_List.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_listhighlighted.png"));
        }

        private void Icon_Profile_MouseEnter(object sender, RoutedEventArgs e)
        {
            Icon_Profile.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_accounthighlighted.png"));
        }

        private void Icon_Setting_MouseEnter(object sender, RoutedEventArgs e)
        {
            Icon_Setting.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_settingshighlighted.png"));
        }

        private void Icon_Exit_MouseEnter(object sender, RoutedEventArgs e)
        {
            Icon_Exit.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_exithighlighted.png"));
        }

        private void Icon_List_MouseLeave(object sender, MouseEventArgs e)
        {
            Icon_List.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_list.png"));
        }

        private void Icon_Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            Icon_Profile.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_account.png"));
        }

        private void Icon_Setting_MouseLeave(object sender, MouseEventArgs e)
        {
            Icon_Setting.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_setting.png"));
        }

        private void Icon_Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            Icon_Exit.Source = new BitmapImage(new Uri(@"pack://application:,,,/Proj.Alfhr;component/Resource/ico_logout.png"));
        }

        private void Icon_List_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Icon_Profile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Icon_Setting_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Icon_Exit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
