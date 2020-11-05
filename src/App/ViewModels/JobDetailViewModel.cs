using System;
using System.ComponentModel;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using System.Linq;
using Flurl;
using Flurl.Http;
using Xamarin.Forms;
using Prism.Commands;
using Prism.Navigation;

namespace App.ViewModels
{
    public class JobDetailViewModel : INotifyPropertyChanged, IInitialize, INavigationAware
    {
        public JobDetailModel JobsDetail { get; set; }
        public DelegateCommand OpenJobWebURLCommand { get; set; }

        public JobDetailViewModel(string Link)
        {

            new Action(async () => await LoadDataAsync(Link))();

           // this.OpenJobWebURLCommand = new DelegateCommand<string>(OpenJobWebURL);
 
           // OpenJobWebURLCommand=    DelegateCommand(Action OpenJobWebURLCommand, Func<bool> OpenJobWebURL);
            //OpenJobWebURLCommand = new Command<string>(OpenJobWebURL);
        }
        public async Task LoadDataAsync(string link)
        {

            var Data = await AppConstant.ApiUrl
            .AppendPathSegment(AppConstant.ApiEndPointDetail+link)
            .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
            .GetJsonAsync<JobDetailModel>();

            JobsDetail = Data;
        }

        
        public async void OpenJobWebURL(string uri) {

            if (await Xamarin.Essentials.Launcher.CanOpenAsync(uri))
                await Xamarin.Essentials.Launcher.OpenAsync(uri);
           // Device.OpenUri(new Uri(Url));

        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Link"))
            {
                var Link = parameters["Link"] as string;
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}