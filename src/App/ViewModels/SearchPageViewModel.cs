using App.Models;
using App.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class SearchPageViewModel
    {
        public ObservableCollection<JobCards> JobCards { get; set; }

        public SearchPageViewModel()
        {
            JobCards =  new ObservableCollection<JobCards>(new MockCardService().GetJobCards());
        }
     

        
    }
}
