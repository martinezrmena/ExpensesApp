using System;
using ExpensesApp.Resources;
using ExpensesApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp
{
    public partial class App : Application
    {
        public static string DatabasePath;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasePath)
        {
            InitializeComponent();

            #if DEBUG
                //This line should not be on app release because user needs to take this
                //config from global settings
                AppResources.Culture = new System.Globalization.CultureInfo("es");
            #endif

            DatabasePath = databasePath;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
