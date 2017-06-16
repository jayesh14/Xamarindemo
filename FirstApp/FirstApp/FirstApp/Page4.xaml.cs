using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            ObservableCollection<Page4ViewModel> employees = new ObservableCollection<Page4ViewModel>();
            employees.Add(new Page4ViewModel { DisplayName = "Rob Finnerty" });
            employees.Add(new Page4ViewModel { DisplayName = "Bill Wrestler" });
            employees.Add(new Page4ViewModel { DisplayName = "Dr. Geri-Beth Hooper" });
            employees.Add(new Page4ViewModel { DisplayName = "Dr. Keith Joyce-Purdy" });
            employees.Add(new Page4ViewModel { DisplayName = "Sheri Spruce" });
            employees.Add(new Page4ViewModel { DisplayName = "Burt Indybrick" });
            Page4ViewModel1.ItemsSource = employees;
            //BindingContext = new ContentPageViewModel();
        }
    }

    class Page4ViewModel 
    {
        public string DisplayName { get; set; }
    }
}
