using MaterialDesignThemes.Wpf.Transitions;
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
    /// LoginControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public MainWindow mainwindow;
        public LauncherControl launchercontrol;

        public LoginControl()
        {
            InitializeComponent();
        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            int LoadData = await Mojang.LoadDataAsync();
            switch (LoadData)
            {
                case 1:
                    mainwindow.MainTransitioner.SelectedIndex = 1;
                    break;
                case 2:
                    if(await Mojang.Refresh())
                    {
                        mainwindow.MainTransitioner.SelectedIndex = 1;
                    }
                    else
                    {
                        ID_Textbox.Text = Mojang.ID;
                        Password_Textbox.Password = Mojang.Password;
                    }
                    break;
                case 3:
                    break;
            }
        }

        private async void Login_button_Click(object sender, RoutedEventArgs e)
        {
            //아이디와 비번이 입력되어있는지 확인하는 구문
            bool canlogin = true;
            InfoLabel.Content = "";
            IDInfoLabel.Content = "";
            PWInfoLabel.Content = "";
            if (String.IsNullOrWhiteSpace(ID_Textbox.Text))
            {
                IDInfoLabel.Content = "아이디를 입력해주세요";
                canlogin = false;
            }
            if (String.IsNullOrWhiteSpace(Password_Textbox.Password))
            {
                PWInfoLabel.Content = "비밀번호를 입력해주세요";
                canlogin = false;
            }
            if (!canlogin)
            {
                return;
            }
            //아이디와 비번이 입력되어있는지 확인하는 구문 끝

            bool logined = await Mojang.Login(ID_Textbox.Text, Password_Textbox.Password);
            if (logined)
            {
                launchercontrol.Initialize();
                mainwindow.MainTransitioner.SelectedIndex = 1;
                await Mojang.SaveDataAsync();
            }
            else
            {
                switch (Mojang.Errorcode)
                {
                    case 1:
                        InfoLabel.Content = $"인터넷이 연결되어있는지 확인해주세요 에러코드:{Mojang.Errorcode}";
                        break;
                    case 2:
                        InfoLabel.Content = $"잠시후에 시도해주세요 에러코드:{Mojang.Errorcode},{Mojang.Error}";
                        break;
                    case 3:
                        InfoLabel.Content = $"아이디/비밀번호가 맞는지 다시 시도해주세요 에러코드:{Mojang.Errorcode},{Mojang.Error}";
                        break;
                }
            }
        }
    }
}
