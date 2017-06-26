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
    public partial class EntryPageTab1 : ContentPage
    {
        public EntryPageTab1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Person p = new Person();
            p.UserName = UserName.Text.Trim();
            p.Password = Password.Text.Trim();
           int id= App.DAUtil.SaveEmployee(p);
            if(id>0)
                DisplayAlert("Added", "Registered", "OK");
            
            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[0];
        }
    }
}
