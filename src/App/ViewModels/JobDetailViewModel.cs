using System;
using System.ComponentModel;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using System.Linq;
using Flurl;
using Flurl.Http;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class JobDetailViewModel : INotifyPropertyChanged
    {
        public JobDetailModel JobsDetail { get; set; }
        public Command OpenJobWebURLCommand { get; set; }

        public JobDetailViewModel(string Link)
        {

            new Action(async () => await LoadDataAsync(Link))();

            OpenJobWebURLCommand = new Command<string>(OpenJobWebURL);
        }
        public async Task LoadDataAsync(string link)
        {

            var Data = await AppConstant.ApiUrl
            .AppendPathSegment(AppConstant.ApiEndPointDetail+link)
            .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
            .GetJsonAsync<JobDetailModel>();

            JobsDetail = Data;
        }

        
        public void OpenJobWebURL(string Url) {
            
            Device.OpenUri(new Uri(Url));

        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}