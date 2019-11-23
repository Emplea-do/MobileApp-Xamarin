using App.Models;
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
    class JobsListViewModel : INotifyPropertyChanged
    {
        public JobListModel Jobss { get; set; }
        public Command LlenarListaCommand { get; set; }
        public JobsListViewModel()
        {

            new Action(async () => await LoadData())();
        }

        public async Task LoadData()
        {
            var Cards = await "https://emplea-apm.azure-api.net/v1/api"
                .AppendPathSegment("jobs")
                .SetQueryParams(new { pagesize = 10, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", "155d4cd48bb34ba0b8375fd50b779b85")
                .GetJsonAsync<JobListModel>();
            //ObservableCollection
            //Jobss = new ListaEmpleos();
            Jobss = Cards;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
