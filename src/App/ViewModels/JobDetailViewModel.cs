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
        public Jobs JobsList { get; set; }

        public JobDetailViewModel()
        {

            new Action(async () => await LoadData())();
        }
        public async Task LoadData()
        {

            var Data = await AppConstant.ApiUrl
            .AppendPathSegment(AppConstant.ApiEndPoint)
            .SetQueryParams(new { pagesize = AppConstant.PageSize, page = 1 })
            .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
            .GetJsonAsync<JobListModel>();

            JobsList = Data.Jobs.Where(a => a.Link == "1327").FirstOrDefault();

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}