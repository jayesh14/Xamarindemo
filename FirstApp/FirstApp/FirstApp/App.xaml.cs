using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstApp
{
    public partial class App : Application
    {
        public static string AppName { get { return "StoreAccountInfoApp"; } }
        static DataAccess dbUtils;

        public App()
        {
            InitializeComponent();
            if (DependencyService.Get<ICredentialsService>().DoCredentialsExist())
            {
                MainPage =  new FirstApp.DemoPage();
            }
            else
            {
                MainPage = new FirstApp.EntryPage();
            }

                //dbUtils = new DataAccess();
                //Person p = new Person();
                //p.FirstName = "Admin";
                //p.LastName = "Admin";
                //p.UserName = "Admin";
                //p.Password = "Admin";
                //p.ID = 1;
                //dbUtils.SaveEmployee(p);
                //List<Person> lst = dbUtils.GetAllEmployees();
                //MainPage = new FirstApp.DemoPage();
                //MainPage = new FirstApp.EntryPage();
        }

        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
