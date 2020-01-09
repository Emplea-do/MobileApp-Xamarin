using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JosbListView : ContentPage
    {
        public JosbListView()
        {
            InitializeComponent();
            BindingContext = new JobsListViewModel(Navigation);
        }
    }
}