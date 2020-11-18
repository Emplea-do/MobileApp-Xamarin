using Acr.UserDialogs;
using App.Models;
using App.Services;
using App.Views;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class JobsListViewModel : IInitialize
    {

        public JobListModel JobsList { get; set; }
        public string Keyword { get;set; }

        public string IsRemote { get; set; }

        public int Pagenumber { get; set; }

        public bool _isBusy;
        public bool IsBusy { get; set; }
        public DelegateCommand CallDetailScreenCommand { get; set; }
        public INavigationService Navigation { get; set; }
        public ICommand LoadMore { get; set; }
        public DelegateCommand BackButton { get; set; }

        public async Task LoadSearchDataAsync(string enterkeyboard, string isRemote, int PageNumber)
        {
            var Cards = await AppConstant.ApiUrl
                .AppendPathSegment(AppConstant.ApiEndPointSearch)
                .SetQueryParams(new
                {
                    keyword = enterkeyboard,
                    Isremote = isRemote,
                    pagesize = AppConstant.PageSize,
                    page = PageNumber
                })
                .WithHeader("Ocp-Apim-Subscription-Key", AppConstant.AppSecrets)
                .GetJsonAsync<JobListModel>();

            if (PageNumber == 1)
            {
                JobsList = Cards;
                Keyword = enterkeyboard;
            }
            else
            {
                if (Cards.Jobs != null) {
                    foreach (var NJobs in Cards.Jobs)
                    {
                        JobsList.Jobs.Add(NJobs);
                    }

                    JobsList.Jobs = new ObservableCollection<Jobs>(JobsList.Jobs);
                }
                
            }

            
        }
        public JobsListViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;

            LoadMore = new DelegateCommand(async () => {

                //UserDialogs.Instance.ShowLoading(title: "Loading");
                IsBusy = true;
                try
                {

                    Pagenumber++;
                    await LoadSearchDataAsync(Keyword, IsRemote, Pagenumber);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {

                    //UserDialogs.Instance.HideLoading();
                    IsBusy = false;
                }

            });


        }

        public DelegateCommand<object> JobListView => new DelegateCommand<object>(CargarListView);
        void CargarListView(object param)
        {

        }

        public async Task OpenDetailViewAsync(string link)
        {
            NavigationParameters Params = new NavigationParameters();
            Params.Add("Link", link);

            await Navigation.NavigateAsync("JobDetailView", Params);
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("ListJobs"))
            {
                var ListJobs = parameters["ListJobs"] as ParametersSearch;
                Keyword = ListJobs.EntryKeyWord;
                IsRemote = ListJobs.IsRemote;
                Pagenumber = 0;

                LoadMore.Execute(null);

            }

           
        }

    }
   
}
