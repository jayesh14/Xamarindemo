using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public DemoPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Item 1", Icon = "itemIcon1.png", TargetType = typeof(Page1) };
            var page2 = new MasterPageItem() { Title = "Item 2", Icon = "itemIcon2.png", TargetType = typeof(TabDemo) };
            var page3 = new MasterPageItem() { Title = "Item 3", Icon = "itemIcon3.png", TargetType = typeof(Page2) };
            var page4 = new MasterPageItem() { Title = "Item 4", Icon = "itemIcon4.png", TargetType = typeof(Page3) };
            var page5 = new MasterPageItem() { Title = "Item 5", Icon = "itemIcon5.png", TargetType = typeof(Page4) };
            var page6 = new MasterPageItem() { Title = "List View", Icon = "itemIcon6.png", TargetType = typeof(BasicListView) };
            var page7 = new MasterPageItem() { Title = "Mvvm", Icon = "itemIcon7.png", TargetType = typeof(MvvmClockPage) };
            var page8 = new MasterPageItem() { Title = "MvvMCommand", Icon = "itemIcon8.png", TargetType = typeof(PowerOfThreePage) };
            var page9 = new MasterPageItem() { Title = "Item 9", Icon = "itemIcon9.png", TargetType = typeof(BasicListView) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            menuList.Add(page7);
            menuList.Add(page8);
            menuList.Add(page9);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Page1)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }

    public class MasterPageItem
    {

        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }

}
