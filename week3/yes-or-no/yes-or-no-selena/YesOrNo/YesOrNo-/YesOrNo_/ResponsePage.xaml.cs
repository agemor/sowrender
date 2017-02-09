using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YesOrNo_
{
    public partial class ResponsePage : ContentPage
    {
        public ResponsePage()
        {
            InitializeComponent();
        }

        async void ExitClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
        async void SettingClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SettingPage());
        }

        void NoClicked(object sender, EventArgs args)
        {
            //YesButton.SetValue("BackgroundColor", "#ffffff");
            //((Button) YesButton).
            //NoButton.BackgroundColor = Color.Red;
        }
        void YesClicked(object sender, EventArgs args)
        {
            //NoButton.BackgroundColor = Color.White;
            //YesButton.BackgroundColor = Color.Green;
        }
    }
}
