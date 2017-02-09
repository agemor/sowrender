using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YesOrNo_
{
    public partial class EntryPage : ContentPage
    {
        public EntryPage()
        {
            InitializeComponent();
        }

        async void EntryClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ResponsePage());
        }
    }
}
