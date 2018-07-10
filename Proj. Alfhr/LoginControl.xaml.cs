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

        public LoginControl()
        {
            InitializeComponent();
        }

        private async void Login_button_Click(object sender, RoutedEventArgs e)
        {
            //아이디와 비번이 입력되어있는지 확인하는 구문
            bool canlogin = true;
            InfoLabel.Content = "";
            IDInfoLabel.Content = "";
            PWInfoLabel.Content = "";
            if (ID_TB.Text.Equals(""))
            {
                IDInfoLabel.Content = "아이디를 입력해주세요";
                canlogin = false;
            }
            if (PW_TB.Password.Equals(""))
            {
                PWInfoLabel.Content = "비밀번호를 입력해주세요";
                canlogin = false;
            }
            if (!canlogin)
            {
                return;
            }
            //아이디와 비번이 입력되어있는지 확인하는 구문 끝

            bool logined = await Mojang.Login(ID_TB.Text, PW_TB.Password);
            if (logined)
            {
                mainwindow.MainTransitioner.SelectedIndex = 1;
            }
            else
            {
                switch (Mojang.Errorcode)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        InfoLabel.Content = "알수없는 에러! 다시 시도해주세요 에러코드:" + Mojang.Errorcode;
                        break;
                    case 4:
                        InfoLabel.Content = "아이디/비밀번호가 맞는지 다시 시도해주세요 에러코드:" + Mojang.Errorcode;
                        break;
                }
            }
        }
    }
}
