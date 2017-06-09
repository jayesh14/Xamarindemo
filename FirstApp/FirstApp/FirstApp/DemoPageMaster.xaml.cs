using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public DemoPageMaster()
        {
            InitializeComponent();
            BindingContext = new DemoPageMasterViewModel();
        }



        class DemoPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DemoPageMenuItem> MenuItems { get; }
            public DemoPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<DemoPageMenuItem>(new[]
                {
                    new DemoPageMenuItem { Id = 0, Title = "Page 1" },
                    new DemoPageMenuItem { Id = 1, Title = "Page 2" },
                    new DemoPageMenuItem { Id = 2, Title = "Page 3" },
                    new DemoPageMenuItem { Id = 3, Title = "Page 4" },
                    new DemoPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
