using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace yes_or_no_camille
{
    class HomePage : ContentPage
    {
        public HomePage()
        {
            Content = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Table Title") {
                    new TableSection ("EntryCell in setting page") {

                        new EntryCell {
                            Label = "nickname",
                            Placeholder = "Insert new Nickname",
                            Keyboard = Keyboard.Default
                        }
                    }
                }
            };
        }
    }
}
