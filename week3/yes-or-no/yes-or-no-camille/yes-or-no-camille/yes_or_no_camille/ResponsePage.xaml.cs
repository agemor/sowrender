using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace yes_or_no_camille
{
    public partial class ResponsePage : ContentPage
    {
        public ResponsePage()
        {
            InitializeComponent();

            //Index
            Label header = new Label
            {
                Text = "YES or NO",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            //Switch
            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            switcher.Toggled += switcher_Toggled;

            //Exit Button
            Button exit = new Button
            {
                Text = "Exit",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            exit.Clicked += ExitButtonClicked;

            //Setting Button
            Button setting = new Button
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

            // Menu Stack
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