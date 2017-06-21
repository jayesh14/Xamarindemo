using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
           
            InitializeComponent();
            //ObservableCollection<Page4ViewModel> employees = new ObservableCollection<Page4ViewModel>();
            //employees.Add(new Page4ViewModel { DisplayName = "Rob Finnerty" });
            //employees.Add(new Page4ViewModel { DisplayName = "Bill Wrestler" });
            //employees.Add(new Page4ViewModel { DisplayName = "Dr. Geri-Beth Hooper" });
            //employees.Add(new Page4ViewModel { DisplayName = "Dr. Keith Joyce-Purdy" });
            //employees.Add(new Page4ViewModel { DisplayName = "Sheri Spruce" });
            //employees.Add(new Page4ViewModel { DisplayName = "Burt Indybrick" });
            //Page4ViewModel1.ItemsSource = employees;

            this.BindingContext = new[] { "a", "b", "c" };
            //BindingContext = new ContentPageViewModel();
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }

   
}
