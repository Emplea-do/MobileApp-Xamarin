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
using Xamarin.Essentials;
using System.Windows.Input;
using Prism.Services;

namespace App.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class JobDetailViewModel : IInitialize
    {
        private string uri;

        private IPageDialogService _dialogService;

        public JobDetailModel JobsDetail { get; set; }

        public DelegateCommand NavigateToURLCommand { get; set; }

        public JobDetailViewModel( IPageDialogService dialogService)
        {
            RegisterCommands();

            _dialogService = dialogService;
        }

        private void RegisterCommands()
        {
            NavigateToURLCommand = new DelegateCommand(async () => await NavigateToURL());

        }

        private async Task NavigateToURL()
        {
            var url = JobsDetail.Company.Url.ToString();
            try
            {

                await Browser.OpenAsync(url, new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Color.AliceBlue,
                    PreferredControlColor = Color.Violet
                });

            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync("Alert", "No hay un navegador disponible para abrir", "OK");
            }
        }



        public async Task LoadDataAsync(string jobId)
        {

            var Data = await AppConstant.ApiUrl
            .AppendPathSegment(AppConstant.ApiEndPointDetail+ jobId)
            .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
            .GetJsonAsync<JobDetailModel>();

            JobsDetail = Data;
        }

      

      
        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("JobId"))
            {
                var jobId = parameters["JobId"] as string;
                new Action(async () => await LoadDataAsync(jobId))();
            }

        }

      
    }
}