using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace yes_or_no_camille
{
    public partial class EntryPage : ContentPage
    {
        public EntryPage()
        {
            InitializeComponent();
        }
        async void EnterClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ResponsePage());
        }
    }
}
