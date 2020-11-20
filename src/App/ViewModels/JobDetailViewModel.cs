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
using PropertyChanged;

namespace App.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class JobDetailViewModel : IInitialize, INavigationAware
    {
        public JobDetailModel JobsDetail { get; set; }
        public DelegateCommand OpenJobWebURLCommand { get; set; }

        public JobDetailViewModel()
        {

        }
        public async Task LoadDataAsync(string jobId)
        {

            var Data = await AppConstant.ApiUrl
            .AppendPathSegment(AppConstant.ApiEndPointDetail+ jobId)
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
            if (parameters.ContainsKey("JobId"))
            {
                var jobId = parameters["JobId"] as string;
                new Action(async () => await LoadDataAsync(jobId))();
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

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}