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
    class SearchViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Jobs> Jobss { get; set; }
        public Command LlenarListaCommand { get; set; }
        public SearchViewModel() {

            new Action(async () => await cargarDatos())();
        }

        public async Task cargarDatos()
        {
            var Cards = await "https://emplea-apm.azure-api.net/v1/api"
                .AppendPathSegment("jobs")
                .SetQueryParams(new { pagesize = 10, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", "155d4cd48bb34ba0b8375fd50b779b85")
                .GetJsonAsync<ListaEmpleos>();

            Jobss = new ObservableCollection<Jobs>(Cards.Jobs);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
