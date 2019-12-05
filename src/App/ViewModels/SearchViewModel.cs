using App.Models;
using App.Services;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    class SearchViewModel : INotifyPropertyChanged
    {
        public JobListModel Jobss { get; set; }
        public Command LlenarListaCommand { get; set; }
        public SearchViewModel() {

            new Action(async () => await LoadData())();
        }

        public async Task LoadData()
        {
            var Cards = await AppConstant.ApiUrl
                .AppendPathSegment(AppConstant.ApiEndPoint)
                .SetQueryParams(new { pagesize = AppConstant.PageSize, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
                .GetJsonAsync<JobListModel>();

            Jobss = Cards;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
