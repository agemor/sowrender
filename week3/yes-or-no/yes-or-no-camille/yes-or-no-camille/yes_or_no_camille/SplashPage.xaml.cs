using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace yes_or_no_camille
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            Image wow = new Image();
            wow.Source = ImageSource.FromFile("wow.jpg");
        }
    }
}
