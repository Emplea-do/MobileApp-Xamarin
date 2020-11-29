using Acr.UserDialogs;
using App.ViewModels;
using App.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Ioc;

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

                await NavigationService.NavigateAsync("NavigationPage/MainTabbedPage");
            }
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainTabbedPage>();
            containerRegistry.RegisterForNavigation<SearchView, SearchViewModel>();
            containerRegistry.RegisterForNavigation<JobDetailView, JobDetailViewModel>();
            containerRegistry.RegisterForNavigation<JobsListView, JobsListViewModel>();
        }

       
    }
}
