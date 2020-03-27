using App.Models;
using App.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class SearchPageViewModel: INotifyPropertyChanged
    {
        private string message = "No se permiten caracteres especiales";
        private bool isEnable;
        private bool visible;
        private string enKeywords;
        private bool isRemote;
    
        public ObservableCollection<JobCards> JobCards { get; set; }

        public SearchPageViewModel()
        {
            JobCards = new ObservableCollection<JobCards>(new MockCardService().GetJobCards());
 
            BtnSearch = new Command(async () =>
            {
                ParametersSearch parameters = new ParametersSearch
                {
                    EntryKeyWord = enKeywords.ToString(),
                    //Category = ""
                    IsRemote = isRemote.ToString()
                    
                };
                string jason = await Task.Run(() =>  JsonConvert.SerializeObject(parameters));
                
                await Shell.Current.GoToAsync($"//listJobs?parameters={jason}");
             });
        }

        public ICommand BtnSearch { get; }

        public bool IsVisible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Message));
            }
        }
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Message));
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
                    || enKeywords.Contains("|") || enKeywords.Contains(" "))
                {
                    IsVisible = true;
                    IsEnable = false;
                }
                else
                {
                    IsVisible = false;
                    IsEnable = true;
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(Message));
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
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



    }
}
