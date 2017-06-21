using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstApp
{
    public partial class App : Application
    {

        static DataAccess dbUtils;

        public App()
        {
            InitializeComponent();
            //MainPage = new FirstApp.EntryPage();
            //MainPage = new NavigationPage(new FirstApp.EntryPage());
            MainPage = new FirstApp.DemoPage();
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
