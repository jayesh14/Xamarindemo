using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstApp
{
   public class BasicListView : ContentPage 
    {
        public BasicListView()
        {
            var listView = new ListView();

            listView.ItemsSource = new[] { "a", "b", "c" };

            // Using ItemTapped
            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                Debug.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            // If using ItemSelected
            //			listView.ItemSelected += (sender, e) => {
            //				if (e.SelectedItem == null) return;
            //				Debug.WriteLine("Selected: " + e.SelectedItem);
            //				((ListView)sender).SelectedItem = null; // de-select the row
            //			};

            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }
    }
}
