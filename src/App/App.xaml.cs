using Acr.UserDialogs;
using App.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new MainShell();
          
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                UserDialogs.Instance.Alert("Network is Not Available, please check your Internet Connection");
            }
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
