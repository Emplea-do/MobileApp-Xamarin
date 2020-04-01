using Acr.UserDialogs;
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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    [QueryProperty("Parameters", "parameters")]
    public class JobsListViewModel : INotifyPropertyChanged
    {


        public JobListModel JobsList { get; set; }
        public string Keyword { get; set; }
        public string IsRemote { get; set; }
        public int Pagenumber;
        public bool IsBusy { get; set; }
        public Command CallDetailScreenCommand { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand LoadMore { get; set; }
        public Command BackButton { get; set; }


        public string Parameters
        {
            set
            {
                var vm = Task.Run(() => JsonConvert.DeserializeObject<ParametersSearch>(Uri.UnescapeDataString(value))).Result;
                Keyword = vm.EntryKeyWord;
                LoadMore = new Command(async () => {
                   
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

                foreach (var NJobs in Cards.Jobs)
                {
                    JobsList.Jobs.Add(NJobs);
                }
            }

        }
        public JobsListViewModel(INavigation navshell)
        {
            this.Navigation = navshell;
            CallDetailScreenCommand = new Command<string>(async (string Link) => await OpenDetailViewAsync(Link));
            BackButton = new Command(async () =>
            {

                await Navigation.PopAsync();

            });
        }

        public async Task OpenDetailViewAsync(string link)
        {
            await Navigation.PushAsync(new JobDetailView(link));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
   
}
