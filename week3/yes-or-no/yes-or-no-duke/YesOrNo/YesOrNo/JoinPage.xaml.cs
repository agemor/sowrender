using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YesOrNo
{
    public partial class JoinPage : ContentPage
    {
        public JoinPage()
        {
            InitializeComponent();

        }
        async void JoinClicked(object sender, EventArgs args)
        {
            if (String.IsNullOrWhiteSpace(RoomKey.Text))
                DisplayAlert("Room Name", "You have to Insert Room Name", "OK");
            else
                await Navigation.PushAsync(new ResponsePage(RoomKey.Text));
        }
    }
}
