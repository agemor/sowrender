using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YesOrNo
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            Image D = new Image();
            D.Source = ImageSource.FromFile("D.png");

            Content = D;
        }
    }
}