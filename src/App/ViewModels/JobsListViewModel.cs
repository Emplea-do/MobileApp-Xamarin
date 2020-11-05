using Acr.UserDialogs;
using App.Models;
using App.Services;
using App.Views;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Prism.Commands;
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
        public string Keyword { get; set; }
        public string IsRemote { get; set; }
        public int Pagenumber;
        public bool IsBusy { get; set; }
        public DelegateCommand CallDetailScreenCommand { get; set; }
        public INavigationService Navigation { get; set; }
        public ICommand LoadMore { get; set; }
        public DelegateCommand BackButton { get; set; }


        public string Parameters
        {
            set
            {
                var vm = Task.Run(() => JsonConvert.DeserializeObject<ParametersSearch>(Uri.UnescapeDataString(value))).Result;
                Keyword = vm.EntryKeyWord;
                LoadMore = new DelegateCommand(async () => {
                   
                    //UserDialogs.Instance.ShowLoading(title: "Loading");
                    IsBusy = true;
                    try
                    {

                        Pagenumber++;
                        await LoadSearchDataAsync(vm.EntryKeyWord, vm.IsRemote, Pagenumber);
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

                LoadMore.Execute(null);
            }

        }
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
                JobsList = new JobListModel();
                JobsList.Jobs = new ObservableCollection<Jobs>();
                foreach (var NJobs in Cards.Jobs)
                {
                    JobsList.Jobs.Add(NJobs);
                }

                JobsList.Jobs = new ObservableCollection<Jobs>(JobsList.Jobs);
            }

        }
        public JobsListViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            //this.Navigation = navshell;
            //CallDetailScreenCommand = new DelegateCommand<string>(async (string Link) => await OpenDetailViewAsync(Link));
            //CallDetailScreenCommand = new DelegateCommand<string>((OpenDetailViewAsync) =>  );
            //BackButton = new DelegateCommand(async () =>
            //{

            //    await Navigation.PopAsync();

            //});
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
            //PushAsync(new JobDetailView(link));
        }

        private async void LoadData(ParametersSearch Parametros)
        {
            await LoadSearchDataAsync(Parametros.EntryKeyWord, Parametros.IsRemote, 0);
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("ListJobs"))
            {
                var ListJobs = parameters["ListJobs"] as ParametersSearch;

                LoadData(ListJobs);
            }   

            
        }

    }
   
}
