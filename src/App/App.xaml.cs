using Acr.UserDialogs;
using App.ViewModels;
using App.Views;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App
{
    public partial class App 
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            // Handle when your app starts
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await UserDialogs.Instance.AlertAsync("Network is Not Available, please check your Internet Connection");
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
            else {
                InitializeComponent();

                await NavigationService.NavigateAsync("NavigationPage/SearchView");
            }
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SearchView, SearchPageViewModel>();
        }

        //public App()
        //{
        //    InitializeComponent();

        //    // MainPage = new MainPage();
        //    MainPage = new MainShell();

        //}

        //protected override void OnStart()
        //{
        //    // Handle when your app starts
        //    var current = Connectivity.NetworkAccess;
        //    if (current != NetworkAccess.Internet)
        //    {
        //        UserDialogs.Instance.Alert("Network is Not Available, please check your Internet Connection");
        //    }
        //}

        //protected override void OnSleep()
        //{
        //    // Handle when your app sleeps
        //}

        //protected override void OnResume()
        //{
        //    // Handle when your app resumes
        //}
    }
}
