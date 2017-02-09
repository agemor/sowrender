using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YesOrNo
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }
        async void ExitClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}
