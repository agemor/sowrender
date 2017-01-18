using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace PrimeNum_Camille
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private int IsPrime(int num)
        {
            int i;
            if (num == 1) return 0;        //num이 1일 경우 return 0
            for (i = 2; i < num - 1; i++)   //0부터 num까지 반복
            {    
                if (num % i == 0)                //num의 약수이면 종료
                    return 0;
            }
            return i;
        }

        private void check_click(object sender, RoutedEventArgs e)
        {
            int num;
            if (string.IsNullOrWhiteSpace(InputNum.Text)) IsPrimePrint.Text = "입력 값이 없습니다.";
            else if (int.TryParse(InputNum.Text, out num))
            {
                if (IsPrime(num) != 0) 
                    IsPrimePrint.Text = "소수입니다.";
                else
                    IsPrimePrint.Text = "소수가 아닙니다.";
            }
            else IsPrimePrint.Text = "문자가 포함되었습니다.";
        }

        private void InputNum_GotFocus_1(object sender, RoutedEventArgs e)
        {
            InputNum.Text = "";
        }
        private void InputNum_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (InputNum.Text == "") InputNum.Text = "자연수를 입력하세요";
        }
    }
}
