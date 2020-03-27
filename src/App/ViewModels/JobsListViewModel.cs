using App.Models;
using App.Services;
using App.Views;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    [QueryProperty("Parameters", "parameters")]
    public class JobsListViewModel : INotifyPropertyChanged
    {


        //public ParametersSearch ParametersSearch { get; set; }
        public JobListModel JobsList { get; set; }
        public Command CallDetailScreenCommand { get; set; }
        public INavigation Navigation { get; set; }


        public string Parameters
        {
            set
            {
                var vm = Task.Run(() => JsonConvert.DeserializeObject<ParametersSearch>(Uri.UnescapeDataString(value))).Result;

                new Action(async () => await LoadSearchDataAsync(vm.EntryKeyWord, vm.IsRemote))();
            }
            
        }
        public async Task LoadInitialDataAsync()
        {   
            var Cards = await AppConstant.ApiUrl
                .AppendPathSegment(AppConstant.ApiEndPointSearch)
                .SetQueryParams(new {pagesize = AppConstant.PageSize, page = 1 })
                .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
                .GetJsonAsync<JobListModel>();
            JobsList = Cards;

        }
        public async Task LoadSearchDataAsync(string enterkeyboard, string isRemote)
        {
            var Cards = await AppConstant.ApiUrl
                .AppendPathSegment(AppConstant.ApiEndPointSearch)
                .SetQueryParams(new
                {
                    keyword = enterkeyboard,
                    Isremote = isRemote,
                    //category = parametersSearch.Category,
                    pagesize = AppConstant.PageSize,
                    page = 1
                })
                .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
                .GetJsonAsync<JobListModel>();
            JobsList = Cards;

        }
        public JobsListViewModel(INavigation navshell)
        {
            this.Navigation = navshell;
            CallDetailScreenCommand = new Command<string>(async (string Link) => await OpenDetailViewAsync(Link));
                   
            new Action(async () => await LoadInitialDataAsync())();
        }

        public async Task OpenDetailViewAsync(string link)
        {
            await Navigation.PushAsync(new JobDetailView(link));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
   
}
