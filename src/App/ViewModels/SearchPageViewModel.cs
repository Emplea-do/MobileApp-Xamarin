using App.Models;
using App.Services;
using Newtonsoft.Json;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using PropertyChanged;

namespace App.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SearchPageViewModel
    {
        private string message = "No se permiten caracteres especiales";
        private bool isEnable;
        private bool visible;
        private string enKeywords;
        private bool isRemote;
        public ICommand CategorySearch { get; set; }
        public ICommand BtnSearch { get; set; }

        public INavigationService NavigationService { get; set; }
        public ObservableCollection<JobCards> JobCards { get; set; }

        public SearchPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            JobCards = new ObservableCollection<JobCards>(new MockCardService().GetJobCards());

            RegisterCommand();
        }


        public void RegisterCommand() {

            BtnSearch = new DelegateCommand(async () => await NavigateToJobList(enKeywords.ToString()));
            CategorySearch = new DelegateCommand<string>(async (searchParameter) => await NavigateToJobList(searchParameter));

        }


        public async Task NavigateToJobList(string searchParameters = "") {

            ParametersSearch parameters = new ParametersSearch
            {
                EntryKeyWord = searchParameters.Replace(System.Environment.NewLine, " "),
                IsRemote = isRemote.ToString()

            };

            await NavigationService.NavigateAsync("JobsListView", new NavigationParameters { { "ListJobs", parameters } });

        }


        public bool IsVisible
        {
            get { return visible; }
            set
            {
                visible = value;
            }
        }
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
            }
        }
        public string EnKeywords
        {
            get { return enKeywords; }
            set
            {
                enKeywords = value;
                if (enKeywords.Contains("=") || enKeywords.Contains("'") || enKeywords.Contains("?")
                    || enKeywords.Contains("/") || enKeywords.Contains("$") || enKeywords.Contains("#")
                    || enKeywords.Contains("|") /*|| enKeywords.Contains(" ")*/)
                {
                    IsVisible = true;
                    IsEnable = false;
                }
                else
                {
                    IsVisible = false;
                    IsEnable = true;
                }
            }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        //TODO:Add IdCategories GetJobCards
        public bool IsRemote
        {
            get { return isRemote; }
            set {
                isRemote = value;
            }
        }

    }
}
