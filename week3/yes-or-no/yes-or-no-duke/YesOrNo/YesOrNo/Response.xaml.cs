using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YesOrNo
{
    public partial class Response : ContentPage
    {
        public Response()
        {
            InitializeComponent();
            Label header = new Label
            {
                Text = "YES or NO",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            switcher.Toggled += switcher_Toggled;

            Xamarin.Forms.Button exit = new Xamarin.Forms.Button
            {
                Text = "Exit",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            exit.Clicked += ExitButtonClicked;

            Xamarin.Forms.Button setting = new Xamarin.Forms.Button
            {
                Text = "Setting",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            setting.Clicked += SettingButtonClicked;


            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            var menu = new StackLayout
            {
                Children =
                {
                    exit,
                    header,
                    setting
                },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    menu,
                    switcher
                }
            };
        }
        void switcher_Toggled(object sender, ToggledEventArgs e)
        {

        }
        void ExitButtonClicked(object sender, EventArgs e)
        {

        }
        void SettingButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
