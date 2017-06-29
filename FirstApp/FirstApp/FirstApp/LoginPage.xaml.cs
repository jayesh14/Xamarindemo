using System;
using System.Collections.Generic;
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
    public partial class LoginPage : ContentPage
    {
        ICredentialsService storeService;
        public LoginPage()
        {
            storeService = DependencyService.Get<ICredentialsService>();
            InitializeComponent();

            // BindingContext = new LoginPageViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Person p = new Person();
                p.UserName = UserName.Text;
                p.Password = Password.Text;
                p = App.DAUtil.SelectEmployee(p);
                //Navigation.PopModalAsync();
                if (p != null && p.ID > 0)
                {
                    DependencyService.Get<ICredentialsService>().DeleteCredentials();
                    bool doCredentialsExist = storeService.DoCredentialsExist();
                    if (!doCredentialsExist)
                    {
                        storeService.SaveCredentials(p.UserName, p.Password);
                    }
                    //Navigation.PushModalAsync(new DemoPage());

                    Navigation.InsertPageBefore(new DemoPage(), this);
                    Navigation.PopAsync();
                }
                else
                    DisplayAlert("Alert", "UserName and Password inValid", "OK");
                //LoginPage = new NavigationPage(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.InnerException.ToString(), "OK");
            }
        }
    }

    class LoginPageViewModel : INotifyPropertyChanged
    {

        public LoginPageViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
